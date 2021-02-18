using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Admin
{
    public partial class AdminClientForm : Form
    {
        private bool connected = false;
        private Thread client = null;
        private struct MyClient
        {
            public string username;
            public string key;
            public TcpClient client;
            public NetworkStream stream;
            public byte[] buffer;
            public StringBuilder data;
            public EventWaitHandle handle;
        };
        private MyClient obj;
        private string pubKeyString;
        private Task send = null;
        private bool exit = false;
        public AdminClientForm()
        {
            InitializeComponent();
            
        }


        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutAppForm();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                obj.client.Close();
            }
            else if (client == null || !client.IsAlive)
            {
                string address = addrTextBox.Text.Trim();
                string number = portTextBox.Text.Trim();
                string username = usernameTextBox.Text.Trim();
                bool error = false;
                IPAddress ip = null;
                if (address.Length < 1)
                {
                    error = true;
                    Log(SysteMessage("Требуется IP-адрес"));
                }
                else
                {
                    try
                    {
                        ip = Dns.Resolve(address).AddressList[0];
                    }
                    catch
                    {
                        error = true;
                        Log(SysteMessage("Неверный IP"));
                    }
                }
                int port = 0;
                if (number.Length < 1)
                {
                    error = true;
                    Log(SysteMessage("Требуется порт"));
                }
                else if (!int.TryParse(number, out port)|| port < 0 || port > 65535)
                {
                    error = true;
                    Log(SysteMessage("Неверный порт"));
                }
                if (!error)
                {
                    client = new Thread(() => Connection(ip, port, username, keyTextBox.Text))
                    {
                        IsBackground = true
                    };
                    client.Start();
                }
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TrayMode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void AdminClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected)
            {
                obj.client.Close();
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutAppForm();
        }

        private void AboutAppForm()
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void AdminClientForm_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = Environment.UserName;
        }

        private void SendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (sendTextBox.Text.Length > 0)
                {
                    string msg = sendTextBox.Text;
                    sendTextBox.Clear();
                    Log(string.Format("{0} (Вы): {1}", obj.username, msg));
                    if (connected)
                    {
                        Send(msg);
                    }
                }
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Log();
        }

        private string SysteMessage(string msg)
        {
            return string.Format("SYSTEM: {0}", msg);
        }

        private void Connected(bool status)
        {
            if (!exit)
            {
                connectButton.Invoke((MethodInvoker)delegate
                {
                    connected = status;
                    if (status)
                    {
                        addrTextBox.Enabled = false;
                        portTextBox.Enabled = false;
                        keyTextBox.Enabled = false;
                        connectButton.Text = "Disconnect";
                        statuslabel.Text = "Вы подключены";
                    }
                    else
                    {
                        addrTextBox.Enabled = true;
                        portTextBox.Enabled = true;
                        keyTextBox.Enabled = true;
                        connectButton.Text = "Connect";
                        statuslabel.Text = "Вы отключены";
                    }
                });
            }
        }

        private void BeginWrite(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);

            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(Write), null);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
        }
        private void Write(IAsyncResult result)
        {
            if (obj.client.Connected)
            {
                try
                {
                    obj.stream.EndWrite(result);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
        }
        private string ErrorMsg(string msg)
        {
            return string.Format("ERROR: {0}", msg);
        }
        private void Send(string msg)
        {
            if (send == null || send.IsCompleted)
            {
                send = Task.Factory.StartNew(() => BeginWrite(msg));
            }
            else
            {
                send.ContinueWith(antecendent => BeginWrite(msg));
            }
        }
        private void Log(string msg = "")
        {
            if (!exit)
            {
                logTextBox.Invoke((MethodInvoker)delegate
                {
                    if (msg.Length > 0)
                        logTextBox.AppendText(string.Format("[ {0} ] {1}{2}", DateTime.Now.ToString("HH:mm"), msg, Environment.NewLine));
                    else
                        logTextBox.Clear();
                });
            }
        }
        public bool ParseMessage(string message)
        {
            if (message.Contains("<GetDate"))
            {
                GetDate j = new GetDate();
                j.ParseCommand(message);
                List<string> report = j.information;
                Aes aes = Aes.Create();
                Send(String.Format("<GK>{0}", EncryptKey((aes.Key))));
                Thread.Sleep(1000);
                Send(String.Format("<IV>{0}", EncryptKey(aes.IV)));
                Thread.Sleep(3000);
                foreach (string g in report)
                {
                    Send(String.Format("<GetDateResult>{0}",  AESEncrypt(g, aes.Key, aes.IV)));
                    Thread.Sleep(1000);
                }

                return true;
            }
            else if (message.Contains("RSAKeyValue"))
            {
                pubKeyString = message;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Read(IAsyncResult result)
        {
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                    }
                    else
                    {
                        if (!ParseMessage(obj.data.ToString()))
                        {
                            Log(obj.data.ToString());
                           
                        }
                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Log(ErrorMsg(ex.Message));
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private void ReadAuth(IAsyncResult result)
        {
            int bytes = 0;
            if (obj.client.Connected)
            {
                try
                {
                    bytes = obj.stream.EndRead(result);
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
            if (bytes > 0)
            {
                obj.data.AppendFormat("{0}", Encoding.UTF8.GetString(obj.buffer, 0, bytes));
                try
                {
                    if (obj.stream.DataAvailable)
                    {
                        obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), null);
                    }
                    else
                    {
                        JavaScriptSerializer json = new JavaScriptSerializer();
                        Dictionary<string, string> data = json.Deserialize<Dictionary<string, string>>(obj.data.ToString());
                        if (data.ContainsKey("status") && data["status"].Equals("authorized"))
                        {
                            Connected(true);
                        }
                        obj.data.Clear();
                        obj.handle.Set();
                    }
                }
                catch (Exception ex)
                {
                    obj.data.Clear();
                    Log(ErrorMsg(ex.Message));
                    obj.handle.Set();
                }
            }
            else
            {
                obj.client.Close();
                obj.handle.Set();
            }
        }

        private bool Authorize()
        {
            bool success = false;
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("username", obj.username);
            data.Add("key", obj.key);
            JavaScriptSerializer json = new JavaScriptSerializer();
            Send(json.Serialize(data));
            while (obj.client.Connected)
            {
                try
                {
                    obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(ReadAuth), null);
                    obj.handle.WaitOne();
                    if (connected)
                    {
                        success = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Log(ErrorMsg(ex.Message));
                }
            }
            if (!connected)
            {
                Log(SysteMessage("Unauthorize"));
            }
            return success;
        }

        private void Connection(IPAddress ip, int port, string username, string key)
        {
            try
            {
                obj = new MyClient();
                obj.username = username;
                obj.key = key;
                obj.client = new TcpClient();
                obj.client.Connect(ip, port);
                obj.stream = obj.client.GetStream();
                obj.buffer = new byte[obj.client.ReceiveBufferSize];
                obj.data = new StringBuilder();
                obj.handle = new EventWaitHandle(false, EventResetMode.AutoReset);
                if (Authorize())
                {
                    while (obj.client.Connected)
                    {
                        try
                        {
                            obj.stream.BeginRead(obj.buffer, 0, obj.buffer.Length, new AsyncCallback(Read), null);
                            obj.handle.WaitOne();
                        }
                        catch (Exception ex)
                        {
                            Log(ErrorMsg(ex.Message));
                        }
                    }
                    obj.client.Close();
                    Connected(false);
                }
            }
            catch (Exception ex)
            {
                Log(ErrorMsg(ex.Message));
            }
        }
        #region AES
        public string EncryptKey(byte[] keyAes)
        {

            var rsa = new RSACryptoServiceProvider(1024);
            rsa.FromXmlString(pubKeyString);
            var encryptedData = rsa.Encrypt(keyAes, true);
            var base64Encrypted = Convert.ToBase64String(encryptedData);
            return base64Encrypted;
        }
        public string AESEncrypt(string temp, byte[] keyAes, byte[] IVaes)
        {
            if (temp == null || temp.Length <= 0 || IVaes == null || IVaes.Length <= 0 || keyAes == null || keyAes.Length <= 0)
                throw new ArgumentNullException("Checkinputdate");
            byte[] encrypted = EncryptAesData(temp, keyAes, IVaes);
            return Convert.ToBase64String(encrypted);
        }

        private static byte[] EncryptAesData(string currentData, byte[] Key, byte[] IV)
        {
            byte[] byteEncrypt;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(currentData);
                        }
                        byteEncrypt = ms.ToArray();
                    }
                }
            }
            return byteEncrypt;
        }
            #endregion AES
    }
}

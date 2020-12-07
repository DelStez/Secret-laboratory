using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class AdminClientForm : Form
    {
        private bool MainExit = false;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        public static TcpClient client;
        public static NetworkStream stream;
        public AdminClientForm()
        {
            InitializeComponent();
            
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutAppForm();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainExit = true;
            Close();
        }

        private void TrayMode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void AdminClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!MainExit)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                e.Cancel = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AdminClientForm_Load(object sender, EventArgs e)
        {
            RestartClient();
        }
        static void SendMessage(string message)
        {
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
        }
        // получение сообщений
        void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    ParseMessage(message);
                }
                catch
                {
                    label3.BeginInvoke((MethodInvoker)(() => label3.Text="Подключение прервано!")); //соединение было прервано
                    Disconnect();
                }
            }
        }

        static void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            SendMessage(textBox1.Text);
            textBox2.AppendText(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Close();
            RestartClient();
        }

        public void RestartClient()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                stream = client.GetStream(); // получаем поток
                label3.Text = "Online";
                string message = Environment.UserName;//Отпрака Имя текущей учетной записи;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // запускаем новый поток для получения данных
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потока
                textBox2.BeginInvoke((MethodInvoker)(() => textBox2.Text = "Добро пожаловать..."));
            }
            catch (Exception ex)
            {
                textBox2.BeginInvoke((MethodInvoker)(() => textBox2.Text = "Не удалось подключиться серверу"));
            }
        }
        public void ParseMessage(string message)
        {
            if (message.Contains("<GetDate"))
            {
                GetDate j = new GetDate();
                string report = j.ParseCommand(message);
                SendMessage(report);
            }
            else
            {
                textBox2.BeginInvoke((MethodInvoker)(() => textBox2.AppendText("\n\0" + message)));
            }
        }
    }
}

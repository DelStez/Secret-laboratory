using AdminServer.Scripts.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminServer
{
    public partial class AdminServerForm : Form
    {
        static Thread listenThread; // потока для прослушивания
        static ServerObject server;

        public AdminServerForm()
        {
            InitializeComponent();
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutAppForm();
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
                server.Disconnect();
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
            About about = new About();
            about.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void ShowStatus(string status)
        {
            textBox3.BeginInvoke((MethodInvoker)(()=>textBox3.Text=status));
        }

        private void AdminServerForm_Load(object sender, EventArgs e)
        {
            ServerRestart();
        }

        private void AdminServerForm_Shown(object sender, EventArgs e)
        {
            
        }

        public void WriteMessage(string status)
        {
            textBox2.BeginInvoke((MethodInvoker)(() => textBox2.AppendText("\n" + status)));
        }

        public void ServerRestart()
        {
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                server.Disconnect();
            }
        }
        public void UpdateTableUsers()
        {
            tableClients.BeginInvoke((MethodInvoker)(() => tableClients.ForeColor = Color.Black));
            tableClients.BeginInvoke((MethodInvoker)(() => tableClients.Rows.Clear()));
            foreach (var t in server.clients)
            {
                tableClients.BeginInvoke((MethodInvoker)(() => tableClients.Rows.Add(new string[] { t.userName, ((IPEndPoint)t.client.Client.RemoteEndPoint).Address.ToString()})));
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        internal void WriteMessageDate(string message)
        {
            richTextBox1.BeginInvoke((MethodInvoker)(() => richTextBox1.Text = message));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            server.Disconnect();
            ServerRestart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (disks.Checked || files.Checked || regedit.Checked)
            {
                string command = "<GetDate ";
                if (disks.Checked)
                {
                    command += "-D ";
                }
                if (files.Checked)
                {
                    command += "-I ";
                }
                if (files.Checked)
                {
                    command += "-R";
                }
                command += "> ";
                foreach (var cli in server.clients)
                {
                    if (cli.userName == label1.Text)
                    {
                        server.SendMessage(command, cli.Id);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите тип ресурсов");
            }
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                foreach (var cli in server.clients)
                {
                    if (cli.userName == label1.Text)
                    {
                        server.SendMessage(textBox1.Text, cli.Id);
                    }
                }
                
            }     
        }

        private void tableClients_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label1.Text = tableClients[0, e.RowIndex].Value.ToString();
        }
    }
}

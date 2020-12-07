using System;
using AdminServer.Scripts.Server;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminServer.Scripts.Server
{
    class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }

        public string userName;
        public TcpClient client;
        public ServerObject server;
        public List<string> chat = new List<string>();
        public List<string> OtherDate = new List<string>();
        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }
        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                userName = message;

                ((AdminServerForm)Application.OpenForms[0]).ShowStatus(userName + " подключился");

                ((AdminServerForm)Application.OpenForms[0]).UpdateTableUsers();

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        ParseMessage(message);

                    }
                    catch
                    {
                        foreach (Form frm in Application.OpenForms)
                        {
                            AdminServerForm form = (AdminServerForm)frm;
                            form.ShowStatus($"{userName} отключился");
                        }
                        server.SendMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }            
        }
        // чтение входящего сообщения и преобразование в строку
        string GetMessage()
        {
            byte[] data = new byte[1024]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        public void ParseMessage(string message)
        {
            if (message.Contains("<GetDateResult>"))
            {
                OtherDate.Add(message.Replace("<GetDateResult>",""));
                ((AdminServerForm)Application.OpenForms[0]).WriteMessageDate(message);
            }
            else
            {
                string temp = String.Format("{0}: {1}", userName, message);
                chat.Add(temp);
                ((AdminServerForm)Application.OpenForms[0]).WriteMessage(temp);
            }
        }
        // закрытие подключения
        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}

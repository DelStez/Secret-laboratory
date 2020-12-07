using System;
using System.Collections.Generic;
using AdminServer.Scripts.Server;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AdminServer.Scripts.Server
{
    class ServerObject
    {
        static TcpListener tcpListener;
        public List<ClientObject> clients = new List<ClientObject>();
        protected internal void AddConnection(ClientObject clientObject)
        {
                clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }
        // прослушивание входящих подключений
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                foreach (Form frm in Application.OpenForms)
                {
                    AdminServerForm form = (AdminServerForm)frm;
                    form.ShowStatus("Сервер запущен. Ожидание подключений...");
                }
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                    ((AdminServerForm)Application.OpenForms[0]).ShowStatus("");
                }
            }
            catch (Exception ex)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    AdminServerForm form = (AdminServerForm)frm;
                    form.ShowStatus("Ошибка подключения");
                }
            }
        }

        // трансляция сообщения Выбранному клиенту
        public void SendMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            foreach (var cli in clients)
            {
                if (cli.Id == id)
                {
                    if (!message.Contains("<GetDate"))
                    {
                        clients[clients.IndexOf(cli)].Stream.Write(data, 0, data.Length); //передача данных
                        clients[clients.IndexOf(cli)].chat.Add(message);
                    }
                    else
                        clients[clients.IndexOf(cli)].Stream.Write(data, 0, data.Length);
                }
                break;
            }
        }
        // отключение всех клиентов
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;
using Data;
using Services;
using ServicesImpl;

namespace Server
{
    internal class Server
    {
        private readonly string _serverAdress;
        private readonly int _port;
        /// <summary>
        /// Создание сервера.
        /// </summary>
        /// <param name="serverAdress">IP-адрес сервера.</param>
        /// <param name="port">Порт сервера.</param>
        public Server(string serverAdress, int port)
        {
            _serverAdress = serverAdress;
            _port = port;
        }
        /// <summary>
        /// Запуск сервера.
        /// </summary>
        public void Start()
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Parse(_serverAdress), _port);
                server.Start();
                var bytes = new byte[512];
                Console.WriteLine($"Сервер {_serverAdress}:{_port} запущен!");
                while (true)
                {
                    Console.Write("Ожидаем подключения... ");
                    var client = server.AcceptTcpClient();
                    Console.Write("Клиент подключился!");
                    var stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine($"Получена информация:\n{data}");
                        data = ProcessingData(data);
                        var msg = System.Text.Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine($"Отправили клиенту: {data}");
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }
            finally
            {
                server?.Stop();
            }
        }

        private string ProcessingData(string data)
        {
            try
            {
                var stream = new MemoryStream(Encoding.ASCII.GetBytes(data));
                var lfs = new LocalFileSystemData().Load(@"LFSData.dat") as LocalFileSystem;
                var ser = new XmlSerializer(typeof(List<object>));
                var array = ser.Deserialize(stream) as List<object>;
                object returnMethod = "";
                if (array != null)
                {
                    var method = array[0].ToString();
                    array.RemoveAt(0);
                    var methodparam = array.ToArray();
                    var methodInfo = lfs.GetType().GetMethod(method);
                    returnMethod = methodInfo.Invoke(lfs, methodparam);
                    var lfsd = new LocalFileSystemData();
                    lfsd.Safe(lfs, @"LFSData.dat");
                }
                return returnMethod?.ToString() ?? "Sucsess";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

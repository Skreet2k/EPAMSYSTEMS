using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Data;
using Infrastructure;
using ServicesImpl;

namespace Server
{
    internal class Server
    {
        private readonly string _serverAdress;
        private readonly int _port;
        public Server()
        {
            try
            {
                var config = ConfigurationManager.GetSection("serverSetting") as ServerConfigSection;
                _serverAdress = config.IpAdress;
                _port = config.Port;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Ошибка при получении данных из конфиг секции 'serverSetting'. {ex.Message}", "Information");
                throw;
            }
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
                var bytes = new byte[2048];
                Trace.WriteLine($"Сервер {_serverAdress}:{_port} запущен!", "Information");
                while (true)
                {
                    Trace.WriteLine("Ожидаем подключения... ", "Information");
                    var client = server.AcceptTcpClient();
                    Trace.WriteLine("Клиент подключился!", "Information");
                    var stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                         var data = Encoding.Default.GetString(bytes, 0, i);
                        Trace.WriteLine($"Получена информация:\n{data}", "Information");
                        data = ProcessingData(data);
                        var msg = Encoding.Default.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Trace.WriteLine($"Отправили клиенту: {data}", "Information");
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Trace.WriteLine($"SocketException: {e}", "Information");
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
                var stream = new MemoryStream(Encoding.Default.GetBytes(data));
                var lfs = new LocalFileSystemData().Load(@"LFSData.dat") as LocalFileSystem;
                var ser = new BinaryFormatter();
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

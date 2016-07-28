
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Connect
    {
        private readonly string _server;
        private readonly int _port;

        public Connect(string server, int port)
        {
            _server = server;
            _port = port;
        }

        public string SendData(byte[] data)
        {
            using (var client = new TcpClient(_server, _port))
            {
                using (var stream = client.GetStream())
                {
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Отправили данные:\n {Encoding.ASCII.GetString(data, 0, data.Length)}");
                    data = new byte[512];
                    var bytes = stream.Read(data, 0, data.Length);
                    var str = Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine($"Получили данные:\n {str}");
                    return str;
                }
            }
        }
    }
}

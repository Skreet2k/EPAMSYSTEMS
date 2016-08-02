using System;
using System.Diagnostics;

namespace Server
{
    internal class Program
    {
        public static void Main()
        {
            var server = new Server();
            server.Start(); //Запуск сервера   

        }
    }
}
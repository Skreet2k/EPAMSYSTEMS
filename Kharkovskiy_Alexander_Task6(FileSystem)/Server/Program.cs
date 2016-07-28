using System;

namespace Server
{
    internal class Program
    {
        public static void Main()
        {
            var server = new Server("127.0.0.1", 13000); //Создание сервера
            server.Start(); //Запуск сервера   

        }
    }
}
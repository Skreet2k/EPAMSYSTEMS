using System;

namespace Task5
{
    internal class Program
    {
        private static void Main()
        {
            var figure = Figure.CreateFromConsole(); // Создаем фигуру
            figure.ShowAtConsole(); // Отображаем ее в консоле
            Console.ReadLine();
        }
    }
}
using System;

namespace Task1
{
    public static class DoubleHelper 
    {
        public static double ReadDoubleFormConsole(string text, bool isPositiveOnly) // Парсер с консоли double с выводом ошибки в консоль
        {
            while (true)
            {
                double temp;
                Console.Write(text);
                if (double.TryParse(Console.ReadLine(), out temp) && (temp > 0 || !isPositiveOnly))
                {
                    return temp;
                }
                Console.WriteLine("Вы ввели некоректное значение!");
            }
        }
    }
}

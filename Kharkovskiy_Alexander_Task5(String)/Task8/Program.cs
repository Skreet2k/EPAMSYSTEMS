using System;
using System.Diagnostics;
using System.Text;

namespace Task8
{
    internal class Program
    {
        /// <summary>
        /// Рассчет времени выполнения n операций конкатенации строк для класса String и StringBuilder.
        /// </summary>
        /// <param name="n">Количество итераций.</param>
        public static void CompareSpeedStringAndStringBuilder(int n)
        {
            var sw = Stopwatch.StartNew();
            var str = "";
            for (var i = 0; i < n; i++)
            {
                str += "*";
            }
            sw.Stop();
            Console.WriteLine($"Скорость выполнения кода:\nString = \t\t{sw.Elapsed} с.");
            sw.Restart();
            var sb = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                sb.Append("*");
            }
            sw.Stop();
            Console.WriteLine($"StringBuilder = \t{sw.Elapsed} с.");
        }

        private static void Main()
        {
            CompareSpeedStringAndStringBuilder(100);
            Console.ReadLine();
        }
    }
}
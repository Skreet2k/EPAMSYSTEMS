using System;
using System.Text;

namespace Task2
{
    internal class Program
    {
        /// <summary>
        /// Удваиваивает символы в строке str1, если они содержатся в str2.
        /// </summary>
        /// <param name="str1">Исходная строка.</param>
        /// <param name="str2">Строка для поиска в ней совподающих символов.</param>
        /// <returns>Новая строка с удвоиными по алгоритму символами.</returns>
        public static string DualCharacterString(string str1, string str2)
        {
            var sb = new StringBuilder();         
            foreach (var item in str1)
            {
                sb.Append(item);
                if(str2.Contains(item.ToString()))
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }
        private static void Main()
        {
            Console.WriteLine("Введите строку, символы которой при совпадении со следующей строкой будут удваиваться:");
            var str1 = Console.ReadLine();
            Console.WriteLine("Введите строку, символы которой будут удваиватся в первой строке:");
            var str2 = Console.ReadLine();
            Console.WriteLine($"Полученая строка: {DualCharacterString(str1,str2)}");
            Console.ReadLine();
        }
    }
}
using System;

namespace Task1
{
    internal class Program
    {
        /// <summary>
        /// Находит среднюю длинну слова в строке.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <returns>Средняя длинна.</returns>
        public static int FindAverageWordLength(string text)
        {
            var lettersCount = 0;
            var str =
                text.Replace(",", "")
                    .Replace(".", "")
                    .Replace("!", "")
                    .Replace("-", "")
                    .Replace(":", "")
                    .Replace("?", "")
                    .Replace("!", "")
                    .Replace("  ", " ")
                    .Trim().Split(' ');
                //Удаляет из строки знаки препинания, а также оставшиеся после удаления повторы пробелов.
            foreach (var item in str)
            {
                lettersCount += item.Length;
            }
            return lettersCount/str.Length;
        }

        private static void Main()
        {
            Console.WriteLine("Введите текст, среднюю длинну слова которого будем находить:");
            Console.WriteLine($"Средняя длинна слова равна {FindAverageWordLength(Console.ReadLine())}");
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        /// <summary>
        ///     Находит частоту вхождений слова в тексте. Регистр игнорируется. Разделители точка и пробел.
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="word">Слово</param>
        /// <returns>Частота вхождений слова</returns>
        public static int FindFrequencyOfOccurrenceInText(string text, string word)
        {
            var list = new List<string>();
            list.AddRange(text.Replace(".", "").Split(' '));
            return list.Count(item => string.Compare(item, word, StringComparison.OrdinalIgnoreCase) == 0);
        }

        private static void Main()
        {
            Console.WriteLine("Введите какой нибудь текст:");
            var text = Console.ReadLine();
            Console.Write("Введите слова, частоту встречаемости которорых мы будем находить через пробел: ");
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                var words = readLine.Split(' ');
                foreach (var item in words)
                {
                    Console.WriteLine(
                        $"Слово '{item}' встречается в тексте {FindFrequencyOfOccurrenceInText(text, item)} раз.");
                }
            }
            Console.ReadLine();
        }
    }
}
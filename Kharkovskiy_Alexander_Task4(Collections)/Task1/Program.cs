using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        /// <summary>
        ///     Удаляет каждый второй итем из листа по кругу
        /// </summary>
        /// <param name="list">Исходный лист для обработки</param>
        /// <param name="showProcess">Показывать результат каждой операции</param>
        /// <returns>Оставшийся итем</returns>
        public static int StrikeEverySecond(List<int> list, bool showProcess = false)
        {
            if (showProcess)
            {
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
                Console.Write("\nРезультат итерации: ");
            }
            var isOdd = list.Count%2 != 0;
            for (var i = 1; i < list.Count; i++)
            {
                list.RemoveAt(i);
            }
            if (isOdd)
                // Если количество итемов нечетное, следовательно последний итем становится первым на новом круге.
            {
                list.Insert(0, list.Last());
                list.RemoveAt(list.Count - 1);
            }

            return list.Count > 1 ? StrikeEverySecond(list, showProcess) : list[0];
                // Если итемов больше 1 продолжаем удалять каждого второго (рекурсия)
        }

        /// <summary>
        ///     Заполняет List порядковыми значениями итемов.
        /// </summary>
        /// <param name="n">Количество итемов в List</param>
        public static List<int> FillList(int n)
        {
            var list = new List<int>(n);
            for (var i = 1; i <= list.Capacity; i++)
            {
                list.Add(i);
            }
            return list;
        }

        private static void Main()
        {
            Console.Write("Отберем по кругу каждого второго из N человек.\nN = ");
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Вы неверно ввели значение N, предположим что оно равно 10!");
                n = 10;
            }
            Console.WriteLine(StrikeEverySecond(FillList(n), true));
            Console.Read();
        }
    }
}
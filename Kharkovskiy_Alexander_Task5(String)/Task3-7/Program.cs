using System;
using System.Text.RegularExpressions;

namespace Task3_7
{
    internal class Program
    {
        /// <summary>
        /// Проверяет, содержатся ли в строке даты формата dd:mm:yyyy.
        /// </summary>
        /// <param name="text">Исходная строка.</param>
        /// <returns>Возвращает true, если есть дата dd:mm:yyyy.</returns>
        public static bool IsContainsDate(string text)
        {
            const string pattern = @"\b(0[1-9]|[1-2][0-9]|3[0-1])-(0[1-9]|1[0-2])-(1[0-9][0-9][0-9]|2[0-2][0-9][0-9])\b";
            return Regex.IsMatch(text, pattern);
        }
        /// <summary>
        /// Заменяет HTML код на другую строку.
        /// </summary>
        /// <param name="text">Исходная строка.</param>
        /// <param name="replaceString">Заменяющая строка.</param>
        public static string ReplaceHtml(string text, string replaceString)
        {
            const string pattern = @"<[^>]*>";
            return Regex.Replace(text, pattern, replaceString);
        }
        /// <summary>
        /// Находит email адреса в строке и записывает их в массив string. 
        /// </summary>
        /// <param name="text">Исходная строка.</param>
        /// <returns>Массив string.</returns>
        public static string[] FindEmailAdress(string text)
        {
            const string pattern =
                @"\b[0-9a-zA-Z](([\w\.\-]+[0-9a-zA-Z])|[a-zA-Z0-9])@([0-9a-zA-Z]([\w\-]+[0-9a-zA-Z])*\.){1,30}[a-zA-Z]{2,6}\b";
            var regex = Regex.Matches(text, pattern);
            var arrayString = new string[regex.Count];
            for (var i = 0; i < arrayString.Length; i++)
            {
                arrayString[i] = regex[i].Value;
            }
            return arrayString;
        }
        /// <summary>
        /// Определяет тип нотации числа.
        /// </summary>
        /// <param name="text">Исходная строка.</param>
        /// <returns>Возвращает описание введенного числа</returns>
        public static string DefinitionTypeOfNumber(string text)
        {
            const string patternScientificNotation = @"^(-+){0,1}[0-9]+\.{0,1}[0-9]*[eE][-+]{0,1}[0-9]+$";
            const string patternSimpleNotation = @"^(-+){0,1}[0-9]+((\.[0-9]+)|[0-9]*)$";
            if (Regex.IsMatch(text, patternScientificNotation))
                return "Это число в научной нотации";
            if (Regex.IsMatch(text, patternSimpleNotation))
                return "Это число в обычной нотации";
            return "Это не число";
        }
        /// <summary>
        /// Находит количество вхождений времени формата hh:mm в строке.
        /// </summary>
        /// <param name="text">Исходная строка.</param>
        /// <returns>Количество вхождений.</returns>
        public static int FindHowManyTimesTime(string text)
        {
            const string pattern = @"\b(([0-1][0-9])|(2[0-3])):[0-5][0-9]\b";
            return Regex.Matches(text, pattern).Count;
        }
        /// <summary>
        /// Интерфейс пользователя в консоли, для выбора решаемой задачи.
        /// </summary>
        public static void UserConsoleInterface()
        {
            Console.WriteLine(
                "Выберите проверку строки:\n\n1.Содержание в строке даты вида dd-mm-yyyy.\n2.Замена всех HTML тегов на '_'.\n3.Поиск в строке адресов e-mail.\n4.Определение типа числа.\n5.Сколько раз встречается время формата чч:мм.");
            var choice = Console.ReadLine();
            Console.WriteLine("Введите строку для обработки:");
            var text = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(IsContainsDate(text)
                        ? "Введенная строка содержит дату."
                        : "Введенная строка не содержит дат.");
                    break;
                case "2":
                    Console.WriteLine($"Полученная строка: {ReplaceHtml(text, "_")}");
                    break;
                case "3":
                    var str = FindEmailAdress(text);
                    Console.WriteLine("Введенный текст содержит следующие email:");
                    foreach (var t in str)
                    {
                        Console.WriteLine(t);
                    }
                    break;
                case "4":
                    Console.WriteLine(DefinitionTypeOfNumber(text));
                    break;
                case "5":
                    Console.WriteLine($"Время в тексте присутствует {FindHowManyTimesTime(text)} раз(a).");
                    break;
            }
        }

        private static void Main()
        {
            UserConsoleInterface();
            Console.ReadLine();
        }
    }
}
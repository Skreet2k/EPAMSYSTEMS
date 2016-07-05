using System;

namespace Task3
{
    public static class DateHelper
    {
        public static DateTime ReadDateOfBirthdayFormConsole() // Парсер дат рождения с выводом ошибок в консоль
        {
            int day, month, year;
            while (true)
            {
                Console.Write("Введите год: ");
                if (!int.TryParse(Console.ReadLine(), out year) || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Неправильный ввод!");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("Введите месяц: ");
                if (!int.TryParse(Console.ReadLine(), out month) || month > 12 || (year == DateTime.Now.Year && month > DateTime.Now.Month))
                {
                    Console.WriteLine("Неправильный ввод!");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Введите день: ");
                if (!int.TryParse(Console.ReadLine(), out day) || day > DateTime.DaysInMonth(year, month) || (year == DateTime.Now.Year && month == DateTime.Now.Month && day > DateTime.Now.Day))
                {
                    Console.WriteLine("Неправильный ввод!");
                }
                else
                {
                    break;
                }
            }
            return new DateTime(year, month, day);
        }
    }
}

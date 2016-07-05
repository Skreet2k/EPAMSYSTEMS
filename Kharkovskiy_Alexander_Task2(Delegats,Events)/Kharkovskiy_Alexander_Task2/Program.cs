using System;

namespace Kharkovskiy_Alexander_Task2
{
    internal class Program
    {
        private static void Main()
        {
            string inputPathFile;
            while (true) // Проверка на существование файла с введенным путем.
            {
                Console.WriteLine("Введите путь файла для обработки данных: ");
                inputPathFile = Console.ReadLine();
                if (System.IO.File.Exists(inputPathFile))
                {
                    break;
                }
                Console.WriteLine($"Файла с адресом {inputPathFile} не существует!");
            }
            Console.WriteLine("Введите имя файла для сохранения результата: ");
            var outputPathFile = Console.ReadLine();
            var fileHandler = new FileHandler(inputPathFile, outputPathFile);
            fileHandler.HandleData();
            Console.ReadLine();
        }
    }
}

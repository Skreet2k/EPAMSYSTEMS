using System;
using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task2
{
    internal class FileHandler // Тип для обработки данных считанных из файла.
    {
        public const char Spliter = ';';
        private readonly FileReadWrite _file;

        public FileHandler(string inputFilePath, string outputFilePath)
        {
            _file = new FileReadWrite(); // Создание экземляра типа FileReadWrite, для дальнейшей обработки/подписи на события.
            _file.EndRead += FileEndRead;
            _file.EndWrite += FileEndWrite;
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
        }

        public string InputFilePath { get; }
        public string OutputFilePath { get; }
        public int SumOfDigits { get; private set; }
        public int NumOfLetters { get; private set; }


        public void HandleData() // Обработка данных в зависимости от ее типа.
        {
            var list = _file.ReadToList(InputFilePath, Spliter);
            foreach (var item in list)
            {
                int temp;
                if (int.TryParse(item, out temp))
                {
                    SumOfDigits += HandleString(SumOfDigit, temp.ToString());
                }
                else
                {
                    NumOfLetters += HandleString(NumOfLitters, item);
                }
            }
            var outputData = new List<string>
            {
                $"Арифметическая Сумма = {SumOfDigits}",
                $"Число символов: {NumOfLetters}"
            };
            _file.WriteToFile(OutputFilePath, outputData);
        }
        private static int HandleString(FileDataHandler fileDataHandler, string s) // Метод принимающий метод, в зависимости от типа обрабатываемых данных.
        {
            return fileDataHandler(s);
        }
        private static int SumOfDigit(string s)
        {
            var sumOfDigit = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != '-')
                {
                    sumOfDigit += int.Parse(s[i].ToString());
                }
                else
                {
                    sumOfDigit -= int.Parse(s[i + 1].ToString());
                    i++;
                }
            }
            return sumOfDigit;
        }

        private static int NumOfLitters(string s)
        {
            return s.Length;
        }

        private static void FileEndRead(object sender, FileReadWriteEventArgs e) // Метод для подписи на событие окончания чтения из файла.
        {
            Console.WriteLine($"Считывание данных из файла завершено!\nСчитанные данные: ");
            foreach (var data in e.FileData)
            {
                Console.WriteLine($"{data}");
            }
        }

        private static void FileEndWrite(object sender, FileReadWriteEventArgs e)// Метод для подписи на событие окончания записи в файла.
        {
            Console.WriteLine($"Запись данных в файл завершено!\nЗаписанные данные: ");
            foreach (var data in e.FileData)
            {
                Console.WriteLine($"{data}");
            }
        }

        private delegate int FileDataHandler(string s);
    }
}
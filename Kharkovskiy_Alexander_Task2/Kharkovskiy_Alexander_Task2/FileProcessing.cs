using System;
using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task2
{
    internal class FileProcessing
    {
        public string InputFilePath { get; }
        public string OutputFilePath { get; }
        public const char Spliter = ';';
        public int SumOfDigits { get; private set; }
        public int NumOfLetters { get; private set; }
        private readonly File _file;

        public FileProcessing(string inputFilePath, string outputFilePath)
        {
            _file = new File();
            _file.EndRead += FileEndRead;
            _file.EndWrite += FileEndWrite;
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
            ProcessData();
        }

        private delegate int ProcessDataDelegate(string s); //todo: Rename idk how
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

        private static int SumMethod(ProcessDataDelegate processDataDelegate, string s)
        {
            return processDataDelegate(s);
        }

        private void ProcessData()
        {
            var list = _file.ReadToList(InputFilePath, Spliter);
            foreach (var item in list)
            {
                int temp;
                if (int.TryParse(item, out temp))
                {
                    SumOfDigits += SumMethod(SumOfDigit, temp.ToString());
                }
                else
                {
                    NumOfLetters += SumMethod(NumOfLitters, item);
                }
            }
            var outputData = new List<string>() {$"Арифметическая Сумма = {SumOfDigits}", $"Число символов: {NumOfLetters}" };
            _file.WriteToFile(OutputFilePath, outputData);
        }

        private static void FileEndRead(object sender, FileEventArgs e)
        {
            Console.WriteLine($"Считывание данных из файла завершено!\nСчитанные данные: ");
            foreach (var data in e.FileData)
            {
                Console.WriteLine($"{data}");
            }
        }

        private static void FileEndWrite(object sender, FileEventArgs e)
        {
            Console.WriteLine($"Запись данных в файл завершено!\nЗаписанные данные: ");
            foreach (var data in e.FileData)
            {
                Console.WriteLine($"{data}");
            }
        }
    }
}

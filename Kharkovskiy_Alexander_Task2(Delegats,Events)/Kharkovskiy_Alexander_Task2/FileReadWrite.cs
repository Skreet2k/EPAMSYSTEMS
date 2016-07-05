using System;
using System.Collections.Generic;
using System.Text;

namespace Kharkovskiy_Alexander_Task2
{
    internal class FileReadWrite // Класс с методами считывания/записи данных из файла.
                                 //Тип хранящий подписавшиеся на события типы. Тип инициализирующий события.
    {
        public event EventHandler<FileReadWriteEventArgs> EndRead;
        public event EventHandler<FileReadWriteEventArgs> EndWrite;
        public List<string> ReadToList(string inputFilePath, char spliter) //Считывание данных из файла по сплитеру в List.
        {
            using (var streamReader = new System.IO.StreamReader(inputFilePath, Encoding.Default))
            {
                var list = new List<string>();
                list.AddRange(streamReader.ReadToEnd().Split(spliter));
                var e = new FileReadWriteEventArgs(list);
                OnEndRead(e);
                return list;
            }
        }

        public void WriteToFile(string outputFilePath, List<string> data ) // Запись данных в файл из List.
        {
            using (var streamWriter = new System.IO.StreamWriter(outputFilePath))
            {
                foreach (var str in data)
                {
                    streamWriter.WriteLine(str);
                }
                var e = new FileReadWriteEventArgs(data);
                OnEndWrite(e);
            }
        }
        protected virtual void OnEndRead(FileReadWriteEventArgs e) // Инициализатор события EndRead.
        {
            EndRead?.Invoke(this, e);
        }

        protected virtual void OnEndWrite(FileReadWriteEventArgs e) // Инициализатор события EndWrite.
        {
            EndWrite?.Invoke(this, e);
        }
    }
}

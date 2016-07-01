using System;
using System.Collections.Generic;
using System.Text;

namespace Kharkovskiy_Alexander_Task2
{
    internal class File
    {
        public event EventHandler<FileEventArgs> EndRead;
        public event EventHandler<FileEventArgs> EndWrite;
        public List<string> ReadToList(string inputFilePath, char spliter)
        {
            using (var streamReader = new System.IO.StreamReader(inputFilePath, Encoding.Default))
            {
                var list = new List<string>();
                list.AddRange(streamReader.ReadToEnd().Split(spliter));
                var e = new FileEventArgs(list);
                OnEndRead(e);
                return list;
            }
        }

        public void WriteToFile(string outputFilePath, List<string> data )
        {
            using (var streamWriter = new System.IO.StreamWriter(outputFilePath))
            {
                foreach (var str in data)
                {
                    streamWriter.WriteLine(str);
                }
                var e = new FileEventArgs(data);
                OnEndWrite(e);
            }
        }
        protected virtual void OnEndRead(FileEventArgs e)
        {
            EndRead?.Invoke(this, e);
        }

        protected virtual void OnEndWrite(FileEventArgs e)
        {
            EndWrite?.Invoke(this, e);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task2
{
    internal class FileEventArgs: EventArgs
    {
        public List<string> FileData { get; }

        public FileEventArgs(List<string> fileData)
        {
            FileData = fileData;
        }
    }
}

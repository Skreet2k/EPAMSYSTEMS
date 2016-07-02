using System;
using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task2
{
    internal class FileReadWriteEventArgs: EventArgs // Тип для хранения доп. иформации передаваемой получателям уведомления событий.
    {
        public List<string> FileData { get; } // Информация которая была записана/считана из файла.

        public FileReadWriteEventArgs(List<string> fileData)
        {
            FileData = fileData;
        }
    }
}

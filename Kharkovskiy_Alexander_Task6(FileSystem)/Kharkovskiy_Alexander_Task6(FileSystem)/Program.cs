using System;

namespace Kharkovskiy_Alexander_Task6_FileSystem_
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                UserConsoleInterface.ShowFolderToConsole();
                UserConsoleInterface.ReadCommandFormConsole();
            }
            Console.ReadLine();
        }
    }
}

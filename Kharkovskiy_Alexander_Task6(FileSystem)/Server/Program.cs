using System;
using System.Diagnostics;
using Data;
using Services;
using ServicesImpl;

namespace Server
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine();
            // //ТЕСТИРОВАНИЕ РЕАЛИЗАЦИИ СЕРВИСА.
            var lfsd = new LocalFileSystemData();
            var lfs = lfsd.Load(@"LFSDate.dat") as LocalFileSystem;          

            ConsoleInterface.Show(lfs);
            Console.ReadLine();
        }
    }
}
using System;
using Data;
using Services;
using ServicesImpl;

namespace Server
{
    internal class Program
    {
        private static void Main()
        {
            // ТЕСТИРОВАНИЕ РЕАЛИЗАЦИИ СЕРВИСА.
            var lfs1 = new LocalFileSystem();
            lfs1.Create("Name", typeof(Folder), null);
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Create(null, typeof(Folder), null);
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Create(null, typeof(string), null);
            Console.WriteLine(lfs1.ResultRequest);


            lfs1.Rename("Name", null, "New Name");
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Rename("Name", null, "New Name");
            Console.WriteLine(lfs1.ResultRequest);

            lfs1.Move("New Name", null, @"root:\New name");
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Move("New Name", null, @"New name");
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Move("New Name", null, @"123");
            Console.WriteLine(lfs1.ResultRequest);

            lfs1.Copy("New Name", null, @"root:\New name");
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Copy("New Name", null, @"New name");
            Console.WriteLine(lfs1.ResultRequest);
            lfs1.Copy("New Name", null, @"123");
            Console.WriteLine(lfs1.ResultRequest);

            Console.WriteLine($"lfs1: {lfs1.GetDirectoryThree("")}"); //Вывод папок для рута.

            // ТЕСТИРОВАНИЕ ВЗАИМОДЕЙСТВИЯ СО СТОЛЕМ DATA.
            var lfsd = new LocalFileSystemData(); // Создание эзкемляра для считывания данных.
            var lfs2 = lfsd.Load(@"DataFile.dat") as LocalFileSystem;

            Console.WriteLine($"lfs2: {lfsd.ResultRequest}{lfs2?.GetDirectoryThree("")}"); //Вывод папок для рута.

            Console.ReadLine();
        }
    }
}
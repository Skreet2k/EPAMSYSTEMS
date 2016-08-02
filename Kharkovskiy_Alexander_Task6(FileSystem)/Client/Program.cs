using System;
using Services;

namespace Client
{
    internal class Program
    {       
        private static void Main()
        {
            var rfs = new RemoteFileSystem();
            rfs.Create(new Folder("theName"), @"root:\");
            rfs.Remove("TestClient", @"root:\");
            rfs.GetDirectoryThree(@"root:\");
            Console.ReadLine();
        }
    }
}
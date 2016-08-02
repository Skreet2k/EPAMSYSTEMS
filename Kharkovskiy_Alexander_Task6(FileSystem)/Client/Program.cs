﻿using System;
using System.Net.Sockets;
using System.Text;
using Services;

namespace Client
{
    internal class Program
    {       
        private static void Main(string[] args)
        {
            var rfs = new RemoteFileSystem();
            rfs.Create(new Folder("theName"), @"root:\");
            rfs.Remove("TestClient", @"root:\");
            rfs.GetDirectoryThree(@"root:\");
            Console.ReadLine();
        }
    }
}
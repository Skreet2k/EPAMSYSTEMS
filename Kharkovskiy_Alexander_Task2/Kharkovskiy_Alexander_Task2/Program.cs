using System;

namespace Kharkovskiy_Alexander_Task2
{
    internal class Program
    {
        private static void Main()
        {
            new FileProcessing(@"C:\Users\Sckor\Documents\OneDrive\test.txt",
                @"C:\Users\Sckor\Documents\OneDrive\outtest.txt");
            Console.ReadLine();
        }
    }
}

using System;

namespace Task3
{
    class Program
    {
        private static void DrawPyramidofStarsinConsole(int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < n; i++)
            {
                
                Console.WriteLine($"{new string('*', i + 1), 50}{new string('*', i)}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк для нашей пирамидки:");
            while (true)
            {
                int num;
                if (int.TryParse(Console.ReadLine(), out num) && num > 0)
                {
                    DrawPyramidofStarsinConsole(num);
                    break;
                }
                else
                {
                    Console.WriteLine("Введено неверное значение параметра!");
                }
            }

            Console.Read();
        }
    }
}

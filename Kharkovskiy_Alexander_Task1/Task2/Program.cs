using System;
namespace Task2
{
    class Program
    {
        private static void DrawImageofStarsinConsole(int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк для изображения:");
            while (true)
            {
                int num;
                if (int.TryParse(Console.ReadLine(), out num) && num > 0)
                {
                    DrawImageofStarsinConsole(num);
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

using System;


namespace Task4
{
    class Program
    {
        private static void DrawPyramidofStarsinConsole(int n)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{new string('*', i + 1),50}{new string('*', i)}");
            }
        }

        private static void DrawFirofStarsinConsole(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                DrawPyramidofStarsinConsole(i);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите количество треугольников для нашей ёлочки: ");
            int num;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num) && num > 0)
                {
                    DrawFirofStarsinConsole(num);
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

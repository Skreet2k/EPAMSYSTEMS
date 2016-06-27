using System;

namespace Task
{
    class Program
    {
        private static int FindSquareRectangle(int a, int b)
        {
            return a * b;
        }

        private static string ReadDigitsFromConsole()
        {
            string result = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1, 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return result;
                    default:
                        if (char.IsNumber(key.KeyChar) || 
                            (key.KeyChar == '-' && result.Length == 0) || 
                            (key.KeyChar == '+' && result.Length == 0)) 
                        {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                        }
                        break;
                }
            }
        }
        public static int ReadPositiveNumFromConsole()
        {
            while (true)
            {
                int num;
                if (int.TryParse(ReadDigitsFromConsole(), out num) && num > 0)
                {
                    return num;
                }
                Console.WriteLine("Введено неверное значение параметра!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вычислим площадь прямоугольника со сторонами a и b.\nВведите a:");
            var a = ReadPositiveNumFromConsole();
            Console.WriteLine("Введите b:");
            var b = ReadPositiveNumFromConsole();
            Console.WriteLine($"Площадь прямоугольника со сторонами a = {a} и b = {b} равна:\nS = {a}x{b} = {FindSquareRectangle(a, b)}");
            Console.Read();
        }
    }
}

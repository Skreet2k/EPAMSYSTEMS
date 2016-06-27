using System;

namespace Task5
{
    class Program
    {

        private static string ReadDigitsFromConsole(bool isMassive, bool isOnlyPossitive)
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
                            (key.KeyChar == '-' && result.Length == 0 && isOnlyPossitive) ||
                            (key.KeyChar == '+' && result.Length == 0) ||
                            (key.KeyChar == ' ' && isMassive))
                        {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                        }
                        break;
                }
            }
        }
        private static int SumofNumberofMultiple(int lessNumber, params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < (double)lessNumber/nums[i]; j++)
                {
                    sum += j * nums[i];
                }
            }
            return sum;
        }
   
        static void Main(string[] args)
        {
            Console.Write("Введите число, меньше которого будут складываться кратные числа: ");
            var lessNumber = int.Parse(ReadDigitsFromConsole(false, false));
            Console.Write("Введите через пробел числа, кратные которым требуется сложить: ");
            var nums = Array.ConvertAll(ReadDigitsFromConsole(true, false).Split(' '), int.Parse);
            Console.WriteLine(SumofNumberofMultiple(lessNumber,nums));
            Console.Read();
        }
    }
}

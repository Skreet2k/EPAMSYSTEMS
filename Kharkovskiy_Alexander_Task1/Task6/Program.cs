using System;


namespace Task6
{
    public class Inscription
    {
        public string Text { get;}
        public bool IsBold;
        public bool IsItalic;
        public bool IsUnderline;
        public Inscription(string text, bool isBold = false, bool isItalic = false, bool isUnderline = false)
        {
            Text = text;
            IsBold = isBold;
            IsItalic = isItalic;
            IsUnderline = isUnderline;
        }
        public string GetTextStyle()
        {
            if (IsBold || IsItalic || IsUnderline)
            {
                return (IsBold ? "Bold " : "") + (IsItalic ? "Italic " : "") + (IsUnderline ? "Underline" : "");
            }
            else
                return "None";
        }
        public void SetTextStyleFromConsole()
        {
            string str;
            bool exit = true;
            while (exit)
            {
                Console.WriteLine($"Параметры надписи: {GetTextStyle()}\nВведите:\n{"1: ",10}bold\n{"2: ",10}italic\n{"3: ",10}underline");
                str = Console.ReadLine();

                switch (str)
                {
                    case "0":
                        exit = false;
                        break;
                    case "1":
                        IsBold = !IsBold;
                        break;
                    case "2":
                        IsItalic = !IsItalic;
                        break;
                    case "3":
                        IsUnderline = !IsUnderline;
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверное значение параметра. Для выхода из параметров введите '0'.");
                        break;
                }

            }
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите текст, параметры которого будем менять: ");
            var inscription = new Inscription(Console.ReadLine());
            inscription.SetTextStyleFromConsole();
            Console.Read();
        }
    }
}

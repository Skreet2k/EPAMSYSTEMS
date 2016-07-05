using System;

namespace Task1
{
    internal class Program
    {
        private static void Main()
        {
            var round = Round.CreateRoundFromConsole();
            Console.WriteLine(
                $"Наш круг с координатами центра ({round.X},{round.Y}) и радиусом R = {round.Radius} имеет\nплощадь S = {round.Area}\nдлинну окружности L = {round.Length}");
            Console.ReadLine();
        }
    }
}
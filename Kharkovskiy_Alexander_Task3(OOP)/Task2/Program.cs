using System;

namespace Task2
{
    internal class Program
    {

        private static void Main()
        {
            var triangle = Triangle.CreateTriangleFromConsole();
            Console.WriteLine($"Наш треугольник со сторонами A = {triangle.A}, B = {triangle.B}, C = {triangle.C} имеет\nплощадь S = {triangle.Area}\nпериметр P = {triangle.Perimeter}");
            Console.ReadLine();
        }
    }
}

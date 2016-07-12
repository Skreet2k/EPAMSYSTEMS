using System;
using System.Drawing;
using Task5.Figures;
using Rectangle = Task5.Figures.Rectangle;

namespace Task5
{
    internal abstract class Figure : IDraw
    {
        public PointF[] Points { get; protected set; }
        public Pen Pen { get; protected set; } = new Pen(Color.Black, 2);
        public abstract void Draw();
        public abstract void ShowAtConsole();

        public static Figure CreateFromConsole()
        {
            Console.WriteLine("Давайте создадим фигуру:\n1. Окружность\n2. Линия\n3. Квадрат\n4. Кольцо\n5. Круг");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return Circle.CreateFromConsole();
                    case "2":
                        return Line.CreateFromConsole();
                    case "3":
                        return Rectangle.CreateFromConsole();
                    case "4":
                        return Ring.CreateFromConsole();
                    case "5":
                        return Round.CreateFromConsole();
                    default:
                        Console.WriteLine("Введен неверный параметр!");
                        break;
                }

            }
        }
    }
}
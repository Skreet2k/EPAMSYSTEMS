using System;
using System.Drawing;
using Task1;

namespace Task5.Figures
{
    internal class Circle: Figure
    {
        public PointF CenterPoint;
        public float Radius;

        public Circle(PointF centerPoint, float radius)
        {
            CenterPoint = centerPoint;
            Radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Отрисовка окружности");
        }

        public new static Circle CreateFromConsole()
        {
            Console.WriteLine("Создадим окружность! Введите координаты центра окружности:");
            var centerPoint = new PointF((float) DoubleHelper.ReadDoubleFormConsole("x = ", false),
                (float) DoubleHelper.ReadDoubleFormConsole("y = ", false));
            Console.WriteLine("Введите радиус окружности:");
            return new Circle(centerPoint, (float) DoubleHelper.ReadDoubleFormConsole("R = ", true));
        }

        public override void ShowAtConsole()
        {
            Console.WriteLine($"Окружность с центром {CenterPoint} и радиусом R = {Radius}.");
        }
    }
}

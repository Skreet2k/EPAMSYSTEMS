using System;
using System.Drawing;
using Task1;

namespace Task5.Figures
{
    internal class Rectangle : Figure
    {
        public Rectangle(PointF pt, float width, float height)
        {
            Points = new[] {pt};
            Width = width;
            Height = height;
        }

        public float Width { get; }
        public float Height { get; }

        public override void Draw()
        {
            Console.WriteLine("Отрисовка квадрата по точке и двум сторонам");
        }

        public new static Rectangle CreateFromConsole()
        {
            Console.WriteLine("Создадим прямоугольник! Введите координаты левого нижнего угла прямоугольника:");
            var pt = new PointF((float) DoubleHelper.ReadDoubleFormConsole("x = ", false),
                (float) DoubleHelper.ReadDoubleFormConsole("y = ", false));
            Console.WriteLine("Введите ширину и высоту прямоугольника:");
            var width = (float) DoubleHelper.ReadDoubleFormConsole("width = ", true);
            var height = (float) DoubleHelper.ReadDoubleFormConsole("height = ", true);
            return new Rectangle(pt, width, height);
        }

        public override void ShowAtConsole()
        {
            Console.WriteLine(
                $"Квадрат с нижним левым уголом с координатами {Points[0]} и сторонами width = {Width}, height = {Height}.");
        }
    }
}
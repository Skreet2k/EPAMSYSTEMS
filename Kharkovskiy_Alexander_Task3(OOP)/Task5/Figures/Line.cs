using System;
using System.Drawing;
using Task1;


namespace Task5.Figures
{
    internal class Line: Figure
    {
        public Line(PointF pt1, PointF pt2)
        {
            Points = new[] {pt1, pt2};
        }

        public override void Draw() // Реализация отрисовки прямой по двум точкам.
        {
            Console.WriteLine("Отрисовка линии по координатам начала и конца.");
        }

        public new static Line CreateFromConsole()
        {
            Console.WriteLine("Создадим линию! Введите координаты начала и конца линии:");
            var pt1 = new PointF((float)DoubleHelper.ReadDoubleFormConsole("x1 = ", false), (float)DoubleHelper.ReadDoubleFormConsole("y1 = ", false));
            var pt2 = new PointF((float)DoubleHelper.ReadDoubleFormConsole("x2 = ", false), (float)DoubleHelper.ReadDoubleFormConsole("y2 = ", false));
            return new Line(pt1, pt2);
        }

        public override void ShowAtConsole()
        {
            Console.WriteLine($"Линия с началом в точке {Points[0]} и концом в точке {Points[1]}.");
        }
    }
}

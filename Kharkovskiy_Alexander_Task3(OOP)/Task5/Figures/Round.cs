using System;
using System.Drawing;
using Task1;

namespace Task5.Figures
{
    internal class Round : Circle
    {
        public Round(PointF centerPoint, float radius) : base(centerPoint, radius)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Закрашивает круг изнутри");
        }

        public new static Round CreateFromConsole()
        {
            Console.WriteLine("Создадим круг! Введите координаты центра круга:");
            var centerPoint = new PointF((float) DoubleHelper.ReadDoubleFormConsole("x = ", false),
                (float) DoubleHelper.ReadDoubleFormConsole("y = ", false));
            Console.WriteLine("Введите радиус круга:");
            return new Round(centerPoint, (float) DoubleHelper.ReadDoubleFormConsole("R = ", true));
        }

        public override void ShowAtConsole()
        {
            Console.WriteLine($"Круг с центром {CenterPoint} и радиусом R = {Radius}.");
        }
    }
}
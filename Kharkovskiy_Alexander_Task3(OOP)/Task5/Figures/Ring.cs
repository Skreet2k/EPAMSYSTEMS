using System;
using System.Drawing;
using Task1;

namespace Task5.Figures
{
    internal class Ring : Circle
    {
        public Ring(PointF centerPoint, float radius, float innerRadius) : base(centerPoint, radius)
        {
            InnerRadius = innerRadius;
        }

        public float InnerRadius { get; }

        public override void Draw()
        {
            base.Draw(); // Вызывается отрисовка окружности с большим радиусом
            var circle2 = new Circle(CenterPoint, InnerRadius);
            circle2.Draw(); // Далее отрисовы
            Console.WriteLine("Закрашиваем получившиеся кольцо!");
        }

        public new static Ring CreateFromConsole()
        {
            Console.WriteLine("Создадим кольцо! Введите координаты центра кольца:");
            var centerPoint = new PointF((float) DoubleHelper.ReadDoubleFormConsole("x = ", false),
                (float) DoubleHelper.ReadDoubleFormConsole("y = ", false));
            Console.WriteLine("Введите внеший радиус:");
            var r1 = (float) DoubleHelper.ReadDoubleFormConsole("R1 = ", true);
            Console.WriteLine("Введите внутренний радиус:");
            var r2 = (float) DoubleHelper.ReadDoubleFormConsole("R2 = ", true);
            return new Ring(centerPoint, r1, r2);
        }

        public override void ShowAtConsole()
        {
            Console.WriteLine($"Кольцо с внешним радиусом R1 = {Radius} и внутренним R2 = {InnerRadius}.");
        }
    }
}
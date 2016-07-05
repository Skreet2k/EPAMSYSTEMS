using System;

namespace Task1
{
    internal class Round
    {
        private double _area;
        private double _length;
        private double _radius;

        public Round(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public double X { get; }
        public double Y { get; }

        public double Radius
        {
            get { return _radius; }

            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _radius = value;
            }
        }

        public double Area
        {
            get
            {
                if (_area > 0)
                {
                    return _area;
                }
                _area = Math.PI*_radius*_radius;
                return _area;
            }
        }

        public double Length
        {
            get
            {
                if (_length > 0)
                {
                    return _length;
                }
                _length = 2*Math.PI*_radius;
                return _length;
            }
        }

        public static Round CreateRoundFromConsole()
        {
            Console.WriteLine("Давайте создадим круг! Введите координаты центра круга и его радиус!");
            var x = DoubleHelper.ReadDoubleFormConsole("x = ", false);
            var y = DoubleHelper.ReadDoubleFormConsole("y = ", false);
            var radius = DoubleHelper.ReadDoubleFormConsole("r = ", true);
            return new Round(x, y, radius);
        }
    }
}
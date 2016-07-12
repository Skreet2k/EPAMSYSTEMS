using System;
using Task1;

namespace Task2
{
    internal class Triangle
    {
        private double _a;
        private double _area;
        private double _b;
        private double _c;
        private double _perimeter;

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double A
        {
            get { return _a; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _b = value;
            }
        }

        public double C
        {
            get { return _c; }
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _c = value;
            }
        }

        public double Perimeter
        {
            get
            {
                if (_perimeter > 0)
                {
                    return _perimeter;
                }
                _perimeter = A + B + C;
                return _perimeter;
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
                _area = Math.Sqrt(Perimeter/2*(Perimeter/2 - A)*(Perimeter/2 - B)*(Perimeter/2 - C));
                return _area;
            }
        }

        public static bool CheckingExistenceTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && c + b > a;
        }

        public static Triangle CreateTriangleFromConsole()
        {
            double a, b, c;
            Console.WriteLine("Давайте создадим треугольник! Введите длинны сторон треугольника!");
            while (true)
            {
                a = DoubleHelper.ReadDoubleFormConsole("A = ", true);
                b = DoubleHelper.ReadDoubleFormConsole("B = ", true);
                c = DoubleHelper.ReadDoubleFormConsole("C = ", true);
                if (CheckingExistenceTriangle(a, b, c))
                {
                    break;
                }
                Console.WriteLine(
                    "К сожалению треугольника с такими сторонами не существует :( Попробуйте заново! (Сумма двух сторон больше третьей)");
            }

            return new Triangle(a, b, c);
        }
    }
}
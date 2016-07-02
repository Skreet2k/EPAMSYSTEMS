using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Round
    {
        public Round(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
        public double Radius
        {
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                Radius = value;
            }
        }
    }
}

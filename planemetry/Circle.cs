using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planemetry
{
    public class Circle:Figure
    {
        public Circle(double r)
        {
            this.borders = new List<double>();
            if (r == null)
                throw new ArgumentNullException(nameof(r), "Не задан радиус круга.");
            if (r < 0)
                throw new ArgumentException("Радиус должен быть положительным числом.", nameof(r));
            this.borders.Add(r);
        }
        public Circle(double x, double y)
        {
            this.borders = new List<double>();
            this.borders.Add(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
        }
        public Circle(double x1, double y1, double x2, double y2)
        {
            this.borders = new List<double>();
            this.borders.Add(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(borders[0], 2);
        }
    }
}

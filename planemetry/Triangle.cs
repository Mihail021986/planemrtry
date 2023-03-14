using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planemetry
{
    public class Triangle : Figure
    {
        List<PointF> points {get;set;}
        public Triangle(double a, double b, double c)
        {
            this.borders = new List<double>();
            if (a == null)
                throw new ArgumentNullException(nameof(a), "Не заданa сторона треугольника.");
            if (a < 0)
                throw new ArgumentException("Сторона должна иметь размер.", nameof(a));
            if (b == null)
                throw new ArgumentNullException(nameof(b), "Не заданa сторона треугольника.");
            if (b < 0)
                throw new ArgumentException("Сторона должна иметь размер.", nameof(b));
            if (c == null)
                throw new ArgumentNullException(nameof(c), "Не заданa сторона треугольника.");
            if (c < 0)
                throw new ArgumentException("Сторона должна иметь размер.", nameof(c));
            this.borders.Add(a);
            this.borders.Add(b);
            this.borders.Add(c);
        }
        public Triangle(List<PointF> points)
        {
            if (points.Count != 3)
                throw new ArgumentException("Треугольник определяют только 3 точки.", nameof(points.Count));
            if (points == null)
                throw new NullReferenceException("Список точек не существует.");
            this.points = points.ToList();
        }
        public override double Area()
        {
            double result = 0;
            if (borders != null)
            {

                var c = borders.IndexOf(borders.Max());
                double corner;
                switch (c)
                {
                    case 0:
                        corner = Math.Acos((Math.Pow(borders[1], 2) + Math.Pow(borders[2], 2) - Math.Pow(borders[0], 2)) / (2 * borders[1] * borders[2]));
                        result = borders[1] * borders[2] * Math.Sin(corner) / 2;
                        break;
                    case 1:
                        corner = Math.Acos((Math.Pow(borders[0], 2) + Math.Pow(borders[2], 2) - Math.Pow(borders[1], 2)) / (2 * borders[0] * borders[2]));
                        result = borders[0] * borders[2] * Math.Sin(corner) / 2;
                        break;
                    case 2:
                        corner = Math.Acos((Math.Pow(borders[1], 2) + Math.Pow(borders[0], 2) - Math.Pow(borders[0], 2)) / (2 * borders[1] * borders[0]));
                        result = borders[1] * borders[0] * Math.Sin(corner) / 2;
                        break;

                }
            }
            if (points != null)
            {
                double sum1 = 0;
                for (int i = 0; i < points.Count - 1; i++)
                {
                    sum1 += points[i].X * points[i + 1].Y;
                }
                sum1 += points[points.Count - 1].X * points[0].Y;
                double sum2 = 0;
                for (int i = 0; i < points.Count - 1; i++)
                {
                    sum2 += points[i + 1].X * points[i].Y;
                }
                sum2 += points[0].X * points[points.Count - 1].Y;
                result = 0.5 * Math.Abs(sum1 - sum2);
            }
            return result;
        }
        public bool IsRightAngle()
        {
            if (borders != null)
            {
                double corner1 = Math.Acos((Math.Pow(borders[1], 2) + Math.Pow(borders[2], 2) - Math.Pow(borders[0], 2)) / 2 * borders[1] * borders[2]);
                double corner2 = Math.Acos((Math.Pow(borders[0], 2) + Math.Pow(borders[2], 2) - Math.Pow(borders[1], 2)) / 2 * borders[0] * borders[2]);
                double corner3 = Math.Acos((Math.Pow(borders[1], 2) + Math.Pow(borders[0], 2) - Math.Pow(borders[0], 2)) / 2 * borders[1] * borders[0]);
                if (corner1 == Math.PI / 2 || corner2 == Math.PI / 2 || corner3 == Math.PI / 2)
                    return true;
                else
                    return false;
            }
            if (points != null)
            {
                double vMult1 = (points[1].X - points[0].X) * (points[2].X - points[0].X) + (points[1].Y - points[0].Y) * (points[2].Y - points[0].Y);
                double vMult2 = (points[2].X - points[1].X) * (points[0].X - points[1].X) + (points[2].Y - points[1].Y) * (points[0].Y - points[1].Y);
                double vMult3 = (points[1].X - points[2].X) * (points[0].X - points[2].X) + (points[1].Y - points[2].Y) * (points[0].Y - points[2].Y);
                if (vMult1 == 0 || vMult2 == 0 || vMult3 == 0)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}

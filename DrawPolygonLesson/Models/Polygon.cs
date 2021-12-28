using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawPolygonLesson.Models
{
    public abstract class Polygon : IPolygon
    {
        const double _radian = 0.0174533;

        public List<Point> Points { get; private set; } = new List<Point>();
        public List<Line> Lines { get; private set; } = new List<Line>();

        public static IsoscelesPolygon CreateIsoscelesPolygon(int angleCount, double sideLength, Point startPoint)
        {
            List<Point> points = new List<Point>();
            points.Add(startPoint);

            double alfa = 180 * (angleCount - 2) / angleCount;

            for (int i = 0; i < angleCount - 1; i++)
            {
                int n = i + 1;

                double angle = (n * alfa - 180 * (n - 1)) * _radian;

                double cos = -Math.Cos(angle);
                double sin = -Math.Sin(angle);

                double newX = points[i].X + sideLength * cos;
                double newY = points[i].Y + sideLength * sin;

                Point next = new Point(newX, newY);
                points.Add(next);
            }

            return new IsoscelesPolygon(points, sideLength);
        }

        public Polygon(List<Point> points)
        {
            Points = points;

            for (int i = 0; i < points.Count - 1; i++)
            {
                Line newLine = new Line(points[i], points[i + 1]);
                Lines.Add(newLine);
            }
            Line lastLine = new Line(points.Last(), points.First());
            Lines.Add(lastLine);
        }

        public double GetPerimeter()
        {
            double result = 0;
            Lines.ForEach(l => result += l.Length);

            return result;
        }

        public virtual double GetArea()
        {
            throw new NotImplementedException();
        }

        public virtual double GetVolume()
        {
            throw new NotImplementedException();
        }
    }
}

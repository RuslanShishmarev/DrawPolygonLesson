using System;

namespace DrawPolygonLesson.Models
{
    public class Line
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public double Length
        {
            get
            {
                double result = Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2));
                return result;
            }
        }
    }
}

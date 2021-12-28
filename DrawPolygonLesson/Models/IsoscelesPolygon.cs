using System.Collections.Generic;

namespace DrawPolygonLesson.Models
{
    public class IsoscelesPolygon : Polygon
    {
        public double SideLength { get; private set; }

        public IsoscelesPolygon(List<Point> points, double side) : base(points)
        {
            SideLength = side;
        }
    }
}

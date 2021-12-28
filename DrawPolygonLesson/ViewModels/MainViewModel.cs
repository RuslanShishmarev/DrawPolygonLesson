using DrawPolygonLesson.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;

namespace DrawPolygonLesson.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public DelegateCommand CreatePolygonCommand { get; private set; }

        private int angleCount = 3;
        public int AngleCount
        {
            get { return angleCount; }
            set 
            { 
                angleCount = value;
                RaisePropertyChanged(nameof(AngleCount));
            }
        }

        private double sideLength = 100;
        public double SideLength
        {
            get { return sideLength; }
            set
            {
                sideLength = value;
                RaisePropertyChanged(nameof(SideLength));
            }
        }

        public Point StartPoint = new Point(300, 300);

        private System.Windows.Media.PointCollection points;
        public System.Windows.Media.PointCollection Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged(nameof(Points));
            }
        }

        public MainViewModel()
        {
            CreatePolygonCommand = new DelegateCommand(CreatePolygon);
        }

        private void CreatePolygon()
        {
            var myPoly = Polygon.CreateIsoscelesPolygon(AngleCount, SideLength, StartPoint);
            Points = ConvertPointsToSystemMedia(myPoly.Points);
        }

        private System.Windows.Media.PointCollection ConvertPointsToSystemMedia(List<Point> points)
        {
            System.Windows.Media.PointCollection newPoints = new System.Windows.Media.PointCollection();

            foreach(Point point in points)
            {
                System.Windows.Point newPoint = new System.Windows.Point(point.X, point.Y);
                newPoints.Add(newPoint);
            }

            return newPoints;
        }
    }
}

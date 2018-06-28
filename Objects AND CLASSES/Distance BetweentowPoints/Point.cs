using System;
using System.Collections.Generic;
using System.Text;

namespace DistanceBetweentowPoints
{
    class Point
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {

            int X = x;
            int Y = y;



        }

        public static double CalculateDistanceBetweenTwoPoints(Point p1, Point p2)
        {

            return Math.Sqrt(Math.Pow(p2.X - p1.X,))

        }
    }
}

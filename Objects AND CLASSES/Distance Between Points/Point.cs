using System;

namespace Distance_Between_Points
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) {

            X = x;
            Y = y;
        }
        public static double CalculateDistanceBetweenTwoPoints(Point p1, Point p2);
    }
}

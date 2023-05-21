using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1.BL
{
    public class MyPoint
    {
        public int x;
        public int y;
        public MyPoint()
        {
            x = 0;
            y = 0;
        }
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double DistanceWithCords(int x2, int y2)
        {
            double distance = Math.Sqrt(Math.Pow((x2 - x), 2) + Math.Pow((y2 - y), 2));
            return distance;
        }
        public double DistanceWithObject(MyPoint another)
        {
            double distance = Math.Sqrt(Math.Pow((another.x - x), 2) + Math.Pow((another.y - y), 2));
            return distance;
        }
        public double DistanceFromZero()
        {
            double distance = Math.Sqrt(Math.Pow((0 - x), 2) + Math.Pow((0 - y), 2));
            return distance;
        }
    }
}

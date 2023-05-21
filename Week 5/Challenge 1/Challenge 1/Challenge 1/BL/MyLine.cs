using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1.BL
{
    public class MyLine
    {
        public MyPoint Begin;
        public MyPoint End;
        public MyLine(MyPoint Begin, MyPoint End)
        {
            this.Begin = Begin;
            this.End = End;
        }
        public MyPoint GetBegin()
        {
            return Begin;
        }
        public void SetBegin(MyPoint Begin)
        {
            this.Begin = Begin;
        }
        public MyPoint GetEnd()
        {
            return End;
        }
        public void SetEnd(MyPoint End)
        {
            this.End = End;
        }
        public double GetLength()
        {
            double Length = Math.Sqrt(Math.Pow((Begin.GetX() - End.GetX()), 2) + Math.Pow((Begin.GetY() - End.GetY()), 2));
            return Length;
        }
        public double GetGradient()
        {
            double Gradient = (End.GetY() - Begin.GetY()) / (End.GetX() - Begin.GetX());
            return Gradient;
        }
    }
}

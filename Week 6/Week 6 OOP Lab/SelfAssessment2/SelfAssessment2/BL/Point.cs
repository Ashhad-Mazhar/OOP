using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment2.BL
{
    class Point
    {
        public void SetXY()
        {
            this.x = x;
            this.y = y;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point()
        {
            x = 0;
            y = 0;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}

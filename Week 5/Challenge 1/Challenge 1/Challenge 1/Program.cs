using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_1.BL;
using Challenge_1.UI;

namespace Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyPoint XCo = new MyPoint();
            MyPoint YCo = new MyPoint();
            MyLine Line = new MyLine(XCo, YCo);
            int Input;
            do
            {
                AppUI.DisplayMenu();
                Input = AppUI.TakeMenuInput();
                if (Input == 2)
                {

                }
            } while (Input != 10);
        }
    }
}

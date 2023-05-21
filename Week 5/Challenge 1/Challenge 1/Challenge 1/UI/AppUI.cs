using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_1.BL;

namespace Challenge_1.UI
{
    class AppUI
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("1. Make a Line");
            Console.WriteLine("2. Update the begin point");
            Console.WriteLine("3. Update the end point");
            Console.WriteLine("4. Show the begin Point");
            Console.WriteLine("5. Show the end point");
            Console.WriteLine("6. Get the Length of the line");
            Console.WriteLine("7. Get the Gradient of the Line");
            Console.WriteLine("8. Find the distance of begin point from zero coordinates");
            Console.WriteLine("9. Find the distance of end point from zero coordinates");
            Console.WriteLine("10.Exit");
        }
        public static int TakeMenuInput()
        {
            Console.WriteLine("Enter your choice: ");
            int Input = int.Parse(Console.ReadLine());
            return Input;
        }
        public static void ShowBegin(MyLine Line)
        {
            Console.WriteLine(Line.Begin.x + "," + Line.Begin.y);
        }
        public static void ShowEnd(MyLine Line)
        {
            Console.WriteLine(Line.End.x + "," + Line.End.y);
        }
    }
}

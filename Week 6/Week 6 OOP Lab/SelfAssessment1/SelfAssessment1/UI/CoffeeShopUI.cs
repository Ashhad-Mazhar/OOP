using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfAssessment1.BL;
using SelfAssessment1.DL;

namespace SelfAssessment1.UI
{
    class CoffeeShopUI
    {
        public MenuItem AddMenu()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter type of item: ");
            string type = Console.ReadLine();

            Console.Write("Enter price of item: ");
            int price = int.Parse(Console.ReadLine());

            MenuItem m = new MenuItem(name, type, price);
            return m;
        }
    }
}

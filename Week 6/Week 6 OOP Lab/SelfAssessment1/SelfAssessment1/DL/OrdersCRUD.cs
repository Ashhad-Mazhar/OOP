using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfAssessment1.BL;

namespace SelfAssessment1.DL
{
    class OrdersCRUD
    {
        public static void RemoveFromList()
        {
            o.RemoveAt(0);
        }
        public static void AddInList(Orders ord)
        {
            o.Add(ord);
        }
        public static int PayableAmount()
        {
            int total = 0;
            foreach (MenuItem i in CoffeeShopCRUD.menu)
            {
                foreach (Orders j in OrdersCRUD.o)
                {
                    if (i.item == j.itemName)
                    {
                        total = total + i.price;
                    }
                }
            }
            return total;
        }
        public static List<Orders> o = new List<Orders>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfAssessment1.BL;
using SelfAssessment1.DL;

namespace SelfAssessment1.UI
{
    class OrdersUI
    {
        public void DueAmount()
        {
            int total = OrdersCRUD.PayableAmount();
            Console.WriteLine("Total payable amount is: " + total);
            Console.ReadKey();
        }
        public void FullFillOrder()
        {
            bool flag = false;
            foreach (Orders i in OrdersCRUD.o)
            {
                if (i.itemName != null)
                {
                    Console.WriteLine("The " + i.itemName + " is ready");
                    OrdersCRUD.RemoveFromList();
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("All orders are fulfilled");
            }
            Console.ReadKey();
        }
        public void ViewOrders()
        {
            bool flag = false;
            Console.WriteLine("Orders: ");
            foreach (Orders i in OrdersCRUD.o)
            {

                Console.WriteLine(i.itemName);
                flag = true;
            }
            if (!flag)
            {
                Console.WriteLine("No orders yet");
            }
            Console.ReadKey();
        }
        public Orders TakeOrders()
        {
            Console.Write("What would you like to order: ");
            string name = Console.ReadLine();
            while (true)
            {
                bool flag = false;

                foreach (MenuItem i in CoffeeShopCRUD.menu)
                {
                    if (name == i.item)
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    Console.Write("No such item exists. Please enter again: ");
                    name = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Orders o = new Orders(name);
            return o;
        }
    }
}

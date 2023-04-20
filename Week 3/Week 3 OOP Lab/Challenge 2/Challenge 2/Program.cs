using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            List<Products> Products_List = new List<Products>();
            while (input != 6)
            {
                Console.Clear();
                Print_Menu();
                Console.WriteLine("Enter your Choice: ");
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input >= 7)
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }
                else if (input == 1)
                {
                    Products_List.Add(Add_Product());
                    Console.WriteLine("Product successfully added");
                    Console.ReadKey();
                }
                else if (input == 2)
                {
                    View_All_Products(Products_List);
                }
                else if (input == 3)
                {
                    Console.Clear();
                    Products Highest_Price_Product = Find_Highest_Price(Products_List);
                    Console.WriteLine("The product with the highest price is: " + Highest_Price_Product.Product_Name);
                    Console.ReadKey();
                }
                else if (input == 4)
                {
                    View_Sales_Tax(Products_List);
                }
                else if (input == 5)
                {
                    View_Products_To_Be_Ordered(Products_List);
                }
            }
        }
        static void Print_Menu()
        {
            Console.Clear();
            Console.WriteLine("1.   Add Product");
            Console.WriteLine("2.   View All Products");
            Console.WriteLine("3.   Find Product with the Highest Unit Price");
            Console.WriteLine("4.   View Sales Tax of All Products");
            Console.WriteLine("5.   View Products to be Ordered");
            Console.WriteLine("6.   Exit Program");
        }
        static Products Add_Product()
        {
            Console.Clear();
            Console.WriteLine("Enter the Name of the Product: ");
            string n = Console.ReadLine();
            Console.WriteLine("Enter the Category of the Product: ");
            string c = Console.ReadLine();
            Console.WriteLine("Enter the Price of the Product: ");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Stock Quantity of the Product: ");
            int q = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Minimum Stock Quantity of the Product: ");
            int mq = int.Parse(Console.ReadLine());
            Products New_Product = new Products(n, c, p, q, mq);
            return New_Product;
        }
        static void View_All_Products(List<Products> Products_List)
        {
            Console.Clear();
            Console.WriteLine("All Products:");
            for (int i = 0; i < Products_List.Count; i++)
            {
                Products_List[i].Display_Record();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static Products Find_Highest_Price(List<Products> Products_List)
        {
            int Highest_Price = Products_List[0].Product_Price;
            Products Highest_Price_Product = Products_List[0];
            for (int i = 1; i < Products_List.Count; i++)
            {
                if (Products_List[i].Product_Price > Highest_Price)
                {
                    Highest_Price_Product = Products_List[i];
                }
            }
            return Highest_Price_Product;
        }
        static void View_Sales_Tax(List <Products> Products_List)
        {
            Console.Clear();
            Console.WriteLine("Sales Tax:");
            int Sales_Tax = 0;
            foreach (Products i in Products_List)
            {
                Sales_Tax = i.Calculate_Sales_Tax();
                Console.WriteLine(i.Product_Name + ": Rs. " + Sales_Tax);
            }
            Console.ReadKey();
        }
        static void View_Products_To_Be_Ordered(List <Products> Products_List)
        {
            Console.Clear();
            Console.WriteLine("Products to be Ordered:");
            foreach(Products i in Products_List)
            {
                if (i.Is_Needed())
                {
                    Console.WriteLine(i.Product_Name);
                }
            }
            Console.ReadKey();
        }
    }
    class Products
    {
        public Products(string n, string c, int p, int q, int mq)
        {
            Product_Name = n;
            Product_Category = c;
            Product_Price = p;
            Stock_Quantity = q;
            Minimum_Quantity = mq;
        }
        public string Product_Name;
        public string Product_Category;
        public int Product_Price;
        public int Stock_Quantity;
        public int Minimum_Quantity;
        public void Display_Record()
        {
            Console.WriteLine("Product Name: " + Product_Name);
            Console.WriteLine("Product Category: " + Product_Category);
            Console.WriteLine("Product Price: " + Product_Price);
            Console.WriteLine("Stock Quantity: " + Stock_Quantity);
            Console.WriteLine("Minimum Stock Quantity: " + Minimum_Quantity);
        }
        public int Calculate_Sales_Tax()
        {
            int Sales_Tax;
            if (Product_Category == "Grocery")
            {
                Sales_Tax = (Product_Price * 10) / 100;
            }
            else if (Product_Category == "Fruit")
            {
                Sales_Tax = (Product_Price * 5) / 100;
            }
            else
            {
                Sales_Tax = (Product_Price * 15) / 100;
            }
            return Sales_Tax;
        }
        public bool Is_Needed()
        {
            bool To_Be_Ordered = false;
            if (Stock_Quantity < Minimum_Quantity)
            {
                To_Be_Ordered = true;
            }
            return To_Be_Ordered;
        }
    }
}
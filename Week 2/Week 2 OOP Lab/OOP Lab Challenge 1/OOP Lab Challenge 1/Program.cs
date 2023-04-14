using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Products[] s = new Products[10];
            int count = 0;
            char option;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addProduct();
                    count++;
                }
                else if (option == '2')
                {
                    showProducts(s, count);
                }
                else if (option == '3')
                {
                    totalStoreWorth(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            } while (option != 4);
            Console.WriteLine("Press enter to exit");
            Console.Read();
        }
        static char menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Show Products");
            Console.WriteLine("3. Show Total Store Worth");
            Console.WriteLine("4. Exit the Program");
            Console.WriteLine("Enter Your Choice: ");
            char choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static Products addProduct()
        {
            Console.Clear();
            Products s1 = new Products();
            Console.Write("Enter ID of the product: ");
            s1.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Name of the Product: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Price of the Product: ");
            s1.price = int.Parse(Console.ReadLine());
            Console.Write("Enter Category of the Product: ");
            s1.category = Console.ReadLine();
            Console.Write("Enter Brand Name of the Product: ");
            s1.brandName = Console.ReadLine();
            Console.Write("Enter Country: ");
            s1.country = Console.ReadLine();
            return s1;
        }
        static void showProducts(Products[] s, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Price: {2}, Category: {3}, Brand: {4}, Country: {5}", s[i].ID, s[i].name, s[i].price, s[i].category, s[i].brandName, s[i].country);
            }
            Console.ReadKey();
        }
        static void totalStoreWorth(Products[] s, int count)
        {
            Console.Clear();
            int sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum = sum + s[i].price;
            }
            Console.WriteLine("Total Store Worth is: " + sum);
            Console.ReadKey();
        }
    }
}

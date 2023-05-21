using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Statement_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer NewCustomer = new Customer("Ashhad", "Lahore", "gmail.com");
            Product NewProduct1 = new Product("Shampoo", "Grocery", 200);
            Product NewProduct2 = new Product("Soap", "Grocery", 100);
            NewCustomer.addProduct(NewProduct1);
            List <Product> ProductsList = NewCustomer.getAllProducts();
            foreach (Product i in ProductsList)
            {
                Console.WriteLine(i.name);
            }
            NewCustomer.addProduct(NewProduct2);
            ProductsList = NewCustomer.getAllProducts();
            foreach (Product i in ProductsList)
            {
                Console.WriteLine(i.name);
            }
            Console.ReadKey();
        }
    }
    class Customer
    {
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerContact;
        public List<Product> products = new List<Product>();
        public Customer(string n, string a, string c)
        {
            CustomerName = n;
            CustomerAddress = a;
            CustomerContact = c;
        }
        public List<Product> getAllProducts()
        {
            return products;
        }
        public void addProduct(Product p)
        {
            products.Add(p);
        }
    }
    class Product
    {
        public string name;
        public string category;
        public int price;
        public Product(string n, string c, int p)
        {
            name = n;
            category = c;
            price = p;
        }
        public float calculateTax()
        {
            float tax;
            tax = price * (20.0f / 100.0f);
            return tax;
        }
    }
}
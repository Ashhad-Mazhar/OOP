using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskB6();
        }
        static void TaskA1()
        {
            Console.Write("Hello World!!");
            Console.Write("Hello World!!");
            Console.ReadKey();
        }
        static void TaskA2()
        {
            Console.WriteLine("Hello World!!");
            Console.Write("Hello World!!");
            Console.ReadKey();
        }
        static void TaskA3()
        {
            float length;
            float area;
            string str;
            Console.WriteLine("Enter Length");
            str = Console.ReadLine();
            length = float.Parse(str);
            area = length * length;
            Console.WriteLine("The area is:");
            Console.Write(area);
            Console.ReadKey();
        }
        static void TaskB1()
        {
            string input;
            float marks;
            Console.WriteLine("Enter Marks:");
            input = Console.ReadLine();
            marks = float.Parse(input);
            if (marks > 50)
            {
                Console.WriteLine("You are passed");
            }
            else
            {
                Console.WriteLine("You are failed");
            }
            Console.ReadKey();
        }
        static void TaskB2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Welcome Jack");
            }
            Console.ReadKey();
        }
        static void TaskB3()
        {
            int num;
            int sum = 0;
            string input;
            Console.WriteLine("Enter Number: ");
            input = Console.ReadLine();
            num = int.Parse(input);
            while (num != -1)
            {
                sum = sum + num;
                Console.WriteLine("Enter Number: ");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The total sum is {0}", sum);
            Console.ReadKey();
        }
        static void TaskB4()
        {
            int num;
            int sum = 0;
            string input;
            Console.WriteLine("Enter Number: ");
            input = Console.ReadLine();
            num = int.Parse(input);
            do
            {
                sum = sum + num;
                Console.WriteLine("Enter Number: ");
                num = int.Parse(Console.ReadLine());
            }
            while (num != -1);
            Console.WriteLine("The total sum is {0}", sum);
            Console.ReadKey();
        }
        static void TaskB5()
        {
            int[] num = new int[3];
            int largest = -1;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter number {0}", i + 1);
                num[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                if (num[i] > largest)
                {
                    largest = num[i];
                }
            }
            Console.WriteLine("Largest number is {0}", largest);
            Console.ReadKey();
        }
        static void TaskB6()
        {
            int age;
            float price;
            int toyPrice;
            Console.Write("Enter age:");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter price of washing machine:");
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter toy price:");
            toyPrice = int.Parse(Console.ReadLine());
            CalculateMoney(age, price, toyPrice);
        }

        static void CalculateMoney(int age, float price, int toyPrice)
        {
            float money = 0;
            int a = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money += a;
                    money -= 1;
                    a += 10;
                }
                else
                {
                    money += toyPrice;
                }
            }
            if (money >= price)
            {
                Console.WriteLine("Yes! {0:F2}", money - price);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No! {0:F2}", price - money);
                Console.ReadKey();
            }
        }
        static void TaskC1()
        {
            int num1, num2;
            Console.WriteLine("Enter 1st number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number: ");
            num2 = int.Parse(Console.ReadLine());
            int sum = add(num1, num2);
            Console.WriteLine("Sum is {0}", sum);
            Console.ReadKey();
        }
        static int add(int num1, int num2)
        {
            return num1 + num2;
        }
        static void TaskC2()
        {
            string path = "F:\\Visual Studio Projects\\Week 1\\PF Lab Week 1\\TaskC2.txt";
            if (File.Exists(path))
            {
                StreamReader fileV = new StreamReader(path);
                string record;
                while ((record = fileV.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                    Console.ReadKey();
                }
                fileV.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
                Console.ReadKey();
            }
        }
        static void TaskC3()
        {
            string path = "F:\\Visual Studio Projects\\Week 1\\PF Lab Week 1\\TaskC2.txt";
            StreamWriter fileV = new StreamWriter(path, true);
            fileV.WriteLine("Hello");
            fileV.Flush();
            fileV.Close();
        }
        static void TaskC4()
        {
            string path = "F:\\Visual Studio Projects\\Week 1\\PF Lab Week 1\\TaskC2.txt";
            string[] names = new string[5];
            string[] passwords = new string[5];
            int option;
            do
            {
                readData(path, names, passwords);
                Console.Clear();
                option = menu();
                Console.Clear();
                if(option == 1)
                {
                    Console.WriteLine("Enter name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, names, passwords);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter new name:");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter new password:");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            Console.ReadKey();
        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void readData (string path, string[] names, string[] passwords)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileV = new StreamReader(path);
                string record;
                while ((record = fileV.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    passwords[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileV.Close();
            }
            else
            {
                Console.WriteLine("Does Not Exist");
            }
        }
        static void signIn (string n, string p, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (n == names[i] && p == passwords[i])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        static void signUp (string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static void pizza_points(int orders, int price)
        {
            string path = "F:\\Visual Studio Projects\\Week 1\\PF Lab Week 1\\Customers.txt";
            string output = TaskC5InputParsing(path, orders, price);
            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] == ',')
                {
                    Console.Write("\n");
                }
                else
                {
                    Console.Write(output[i]);
                }
            }
            Console.ReadKey();
        }
        static string TaskC5InputParsing(string path, int orders, int price)
        {
            string output = "";
            string record;
            StreamReader file = new StreamReader(path);
            while ((record = file.ReadLine()) != null)
            {
                string username = "";
                for (int i = 0; record[i] != ' '; i++)
                {
                    username = username + record[i];
                }
                if (isEligible(record, orders, price))
                {
                    output = output + username + ",";
                }
            }
            file.Close();
            return output;
        }
        static bool isEligible (string record, int orders, int price)
        {
            bool result = false;
            int validOrders = 0;
            int index = -1;
            string number = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == '[')
                {
                    index = i + 1;
                    break;
                }
            }
            for (int i = index; i < record.Length - 1; i++)
            {
                if (record[i] != ',')
                {
                    number = number + record[i];
                }
                else
                {
                    if (int.Parse(number) >= price)
                    {
                        validOrders++;
                    }
                    number = "";
                }
            }
            if (validOrders >= orders)
            {
                result = true;
            }
            return result;
        }
    }
}
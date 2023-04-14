using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Credentials[] s = new Credentials[5];
            for (int i = 0; i < 5; i++)
            {
                s[i] = new Credentials();
            }
            int count = 0;
            string path = "Credentials.txt";
            count = readData(path, s);
            int option;
            do
            {
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, s);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter new name:");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter new password:");
                    string p = Console.ReadLine();
                    signUp(path, n, p, s, count);
                    count++;
                }
            }
            while (option < 3);
            Console.ReadKey();
        }
        static int menu()
        {
            Console.Clear();
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
        static int readData(string path, Credentials[] s)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileV = new StreamReader(path);
                string record;
                while ((record = fileV.ReadLine()) != null)
                {
                    s[x].username = parseData(record, 1);
                    s[x].password = parseData(record, 2);
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
            return x;
        }
        static void signIn(string n, string p, Credentials[] s)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (n == s[i].username && p == s[i].password)
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
        static void signUp(string path, string n, string p, Credentials[] s, int count)
        {
            s[count].username = n;
            s[count].password = p;
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
    }
}

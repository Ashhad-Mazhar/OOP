using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Users.txt";
            int currentUsers = 0;
            List<Credentials> s = new List<Credentials>();
            currentUsers = LoadData(s, path);
            int input = 0;
            while (input != 5)
            {
                printNewScreen("Menu Screen");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Enter your choice: ");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    currentUsers = SignUp(s, path, currentUsers);
                }
                else if (input == 2)
                {
                    SignIn(s, path, currentUsers);
                }
                else if (input == 3)
                {
                    UpdateRecord(s, path, currentUsers);
                }
                else if (input == 4)
                {
                    currentUsers = DeleteRecord(s, path, currentUsers);
                }
            }
        }
        static int SignUp(List<Credentials> s, string path, int currentUsers)
        {
            string record = "";
            Credentials info = new Credentials();
            Console.WriteLine("Enter username: ");
            info.username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            info.password = Console.ReadLine();
            s.Add(info);
            currentUsers++;
            record = info.username + "," + info.password;
            StreamWriter filevar = new StreamWriter(path, true);
            filevar.WriteLine(record);
            filevar.Flush();
            filevar.Close();
            Console.WriteLine("User successfully registered");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return currentUsers;
        }
        static void SignIn(List<Credentials> s, string path, int currentUsers)
        {
            string n, p;
            Console.WriteLine("Enter username: ");
            n = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            p = Console.ReadLine();
            for (int i = 0; i < currentUsers; i++)
            {
                if (n == s[i].username && p == s[i].password)
                {
                    Console.WriteLine("User successfully logged in");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void UpdateRecord(List<Credentials> s, string path, int currentUsers)
        {
            string n, p;
            Console.WriteLine("Enter the username of the record you want to update: ");
            n = Console.ReadLine();
            Console.WriteLine("Enter the password of the record you want to update: ");
            p = Console.ReadLine();
            for (int i = 0; i < currentUsers; i++)
            {
                if (n == s[i].username && p == s[i].password)
                {
                    Console.WriteLine("Enter new username: ");
                    s[i].username = Console.ReadLine();
                    Console.WriteLine("Enter new password: ");
                    s[i].password = Console.ReadLine();
                    RewriteData(s, path, currentUsers);
                    Console.WriteLine("User successfully updated");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
        static void RewriteData(List<Credentials> s, string path, int currentUsers)
        {
            string record = "";
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < currentUsers; i++)
            {
                record = s[i].username + "," + s[i].password;
                file.WriteLine(record);
            }
            file.Flush();
            file.Close();
        }
        static int DeleteRecord(List<Credentials> s, string path, int currentUsers)
        {
            string n, p;
            Console.WriteLine("Enter the username of the record you want to delete: ");
            n = Console.ReadLine();
            Console.WriteLine("Enter the password of the record you want to delete: ");
            p = Console.ReadLine();
            for (int i = 0; i < s.Count; i++)
            {
                if (n == s[i].username && p == s[i].password)
                {
                    s.RemoveAt(i);
                    currentUsers--;
                    RewriteData(s, path, currentUsers);
                    Console.WriteLine("User successfully deleted");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
            return currentUsers;
        }
        static int LoadData(List<Credentials> s, string path)
        {
            int currentUsers = 0;
            string record = "";
            StreamReader file = new StreamReader(path);
            while ((record = file.ReadLine()) != null)
            {
                Credentials info = new Credentials();
                info.username = parsing(record, 1);
                info.password = parsing(record, 2);
                s.Add(info);
                currentUsers++;
            }
            file.Close();
            return currentUsers;
        }
        static string parsing(string record, int field)
        {
            string result = "";
            int comma = 1;
            for (int i = 0; i < record.Length; i++)
            {
                if (comma == field)
                {
                    result = result + record[i];
                }
                else if (record[i] == ',')
                {
                    comma++;
                }
            }
            return result;
        }
        static void printHeader()
        {
            // Used to print the header of the application.
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("************************************************************************************************************************");
            Console.Write("\n");
            Console.Write("********************************************** ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hospital Management System ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**********************************************");
            Console.Write("\n");
            Console.Write("************************************************************************************************************************");
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void printSubHeader(string heading)
        {
            // Used to print the subheader of the application.
            Console.Write(heading);
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("------------------------------------------------------------------------------------------------------------------------");
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void printNewScreen(string subHeader)
        {
            // Used to print the header and subheader of a new screen.
            Console.Clear();
            printHeader();
            printSubHeader(subHeader);
        }
    }
    class Credentials
    {
        public string username;
        public string password;
    }
}

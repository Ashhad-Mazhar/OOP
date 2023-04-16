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
            string path = "Users.txt";
            int userArraySize = 100;
            int currentUsers = 0;
            string[] usernames = new string[userArraySize];
            string[] passwords = new string[userArraySize];
            string[] registrationNumbers = new string[userArraySize];
            currentUsers = LoadData(usernames, passwords, path);
            int input = 0;
            while (input != 5)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Enter your choice: ");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    currentUsers = SignUp(usernames, passwords, path, currentUsers);
                }
                else if (input == 2)
                {
                    SignIn(usernames, passwords, path, currentUsers);
                }
                else if (input == 3)
                {
                    UpdateRecord(usernames, passwords, path, currentUsers);
                }
                else if (input == 4)
                {
                    currentUsers = DeleteRecord(usernames, passwords, path, currentUsers);
                }
            }
        }
        static int SignUp (string[] usernames, string[] passwords, string path, int currentUsers)
        {
            string username, password, record = "";
            Console.WriteLine("Enter username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();
            usernames[currentUsers] = username;
            passwords[currentUsers] = password;
            currentUsers++;
            record = username + "," + password;
            StreamWriter filevar = new StreamWriter(path, true);
            filevar.WriteLine(record);
            filevar.Flush();
            filevar.Close();
            Console.WriteLine("User successfully registered");
            return currentUsers;
        }
        static void SignIn(string[] usernames, string[] passwords, string path, int currentUsers)
        {
            string username, password;
            Console.WriteLine("Enter username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();
            for (int i = 0; i < currentUsers; i++)
            {
                if (username == usernames[i] && password == passwords[i])
                {
                    Console.WriteLine("User successfully logged in");
                    break;
                }
            }
        }
        static void UpdateRecord(string []usernames, string []passwords, string path, int currentUsers)
        {
            string username, password;
            Console.WriteLine("Enter the username of the record you want to update: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter the password of the record you want to update: ");
            password = Console.ReadLine();
            for (int i = 0; i < currentUsers; i++)
            {
                if (username == usernames[i] && password == passwords[i])
                {
                    Console.WriteLine("Enter new username: ");
                    usernames[i] = Console.ReadLine();
                    Console.WriteLine("Enter new password: ");
                    passwords[i] = Console.ReadLine();
                    RewriteData(usernames, passwords, registrationNumbers, path, currentUsers);
                }
            }
        }
        static void RewriteData (string []usernames, string []passwords, string []registrationNumbers, string path, int currentUsers)
        {
            string record = "";
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < currentUsers; i++)
            {
                record = usernames[i] + "," + passwords[i] + "," registrationNumbers[i];
                file.WriteLine(record);
            }
            file.Flush();
            file.Close();
        }
        static int DeleteRecord (string []usernames, string []passwords, string path, int currentUsers)
        {
            string username, password;
            Console.WriteLine("Enter the username of the record you want to delete: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter the password of the record you want to delete: ");
            password = Console.ReadLine();
            for (int i = 0; i < currentUsers; i++)
            {
                if (username == usernames[i] && password == passwords[i])
                {
                    for (int j = i; j < currentUsers; j++)
                    {
                        usernames[i] = usernames[i + 1];
                        passwords[i] = passwords[i + 1];
                    }
                    currentUsers--;
                    RewriteData(usernames, passwords, path, currentUsers);
                    break;
                }
            }
            return currentUsers;
        }
        static int LoadData (string []usernames, string []passwords, string path)
        {
            int currentUsers = 0;
            string record = "";
            StreamReader file = new StreamReader(path);
            while ((record = file.ReadLine()) != null)
            {
                usernames[currentUsers] = parsing(record, 1);
                passwords[currentUsers] = parsing(record, 2);
                currentUsers++;
            }
            file.Close();
            return currentUsers;
        }
        static string parsing (string record, int field)
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
            Console.Clear;
            printHeader();
            printSubHeader(subHeader);
        }
    }
}

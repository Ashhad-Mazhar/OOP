using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            students[] s = new students[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count++;
                }
                else if (option == '2')
                {
                    viewStudents(s, count);
                }
                else if (option == '3')
                {
                    topStudents(s, count);
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
            char choice;
            Console.WriteLine("Press 1 for adding a student");
            Console.WriteLine("Press 2 to view students");
            Console.WriteLine("Press 3 to view top three students");
            Console.WriteLine("Press 4 to exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.Write("Enter name of the student: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter roll no of the student: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA of the student: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.Write("Is the student a hostelite? (y||n): ");
            s1.isHostelite = char.Parse(Console.ReadLine());
            Console.Write("Enter department of the student: ");
            s1.department = Console.ReadLine();
            return s1;
        }
        static void viewStudents(students[] s, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0}, Roll no: {1}, CGPA: {2}, Department: {3}, isHostelite: {4}", s[i].name, s[i].roll_no, s[i].cgpa, s[i].department, s[i].isHostelite);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void topStudents(students[] s, int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("No record present");
            }
            else if (count == 1)
            {
                viewStudents(s, 1);
            }
            else if (count == 2)
            {
                for (int x = 0; x < 2; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudents(s, 2);
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudents(s, 3);
            }
            Console.ReadKey();
        }
        static int largest(students[] s, int start, int end)
        {
            int index = start;
            float largest = s[start].cgpa;
            for (int x = start; x < end; x++)
            {
                if (largest < s[x].cgpa)
                {
                    largest = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
    }
}

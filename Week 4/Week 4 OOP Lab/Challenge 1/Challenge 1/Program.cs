using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class Program
    {
        static List<Student> studentList = new List<Student>();
        static List<Student> sortedStudentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();
        static void Main(string[] args)
        {
            int option;
            do
            {
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    if (programList.Count > 0)
                    {
                        Student s = takeInputForStudent();
                        sortedStudentList.Add(s);
                    }
                }
                else if (option == 2)
                {
                    DegreeProgram d = takeInputForDegree();
                    programList.Add(d);
                }
                Console.Clear();
            }
            while (option != 8);
            Console.ReadKey();
        }
        static int Menu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("               UAMS");
            Console.WriteLine("**********************************");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a specific Program");
            Console.WriteLine("6. Register Subjects for a specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Enter an option: ");
            int input = int.Parse(Console.ReadLine());
            return input;
        }
        static Student takeInputForStudent()
        {
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter FSC Marks: ");
            double fscmarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter ECAT Marks: ");
            double ecatmarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs:");
            foreach(DegreeProgram i in programList)
            {
                Console.WriteLine(i.degreeName);
            }
            Console.WriteLine("Enter how many preferences to enter: ");
            int j = int.Parse(Console.ReadLine());
            for (int i = 0; i < j; i++)
            {
                string s = Console.ReadLine();
                foreach(DegreeProgram n in programList)
                {
                    if (s == n.degreeName)
                    {
                        preferences.Add(n);
                    }
                }
            }
            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();
            Student s = new Student(name, age, fscmarks, ecatmarks, preferences);
            return s;
        }
        static DegreeProgram takeInputForDegree()
        {
            DegreeProgram d = new DegreeProgram();
            Console.WriteLine("Enter degree name: ");
            d.degreeName = Console.ReadLine();
            Console.WriteLine("Enter degree duration: ");
            d.degreeDuration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter seats for degree: ");
            d.seats = int.Parse(Console.ReadLine());
            Console.WriteLine("How many subjects to enter: ");
            int j = int.Parse(Console.ReadLine());
            List<Subject> subjects = new List<Subject>();
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine("Enter Subject Code: ");
                string code = Console.ReadLine();
                Console.WriteLine("Enter Subject Type: ");
                string type = Console.ReadLine();
                Console.WriteLine("Enter Subject Credit Hours: ");
                int creditHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Subject Fees: ");
                int fees = int.Parse(Console.ReadLine());
                Subject s = new Subject(code, type, creditHours, fees);
                subjects.Add(s);
            }
            d.subjects = subjects;
            return d;
        }
    }
}

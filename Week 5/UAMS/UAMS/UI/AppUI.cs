using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.UI
{
    public class AppUI
    {
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void viewStudentInDegree(string degName, List<Student> studentList)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }
        public static void viewRegisteredStudents(List <Student> studentList)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
        public static DegreeProgram takeInputForDegree()
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.WriteLine("Enter degree name: ");
            degreeName = Console.ReadLine();
            Console.WriteLine("Enter degree duration: ");
            degreeDuration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter seats for the degree: ");
            seats = int.Parse(Console.ReadLine());

            DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);
            Console.WriteLine("Enter how many subjects to enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                degProg.AddSubject(takeInputForSubject());
            }
            return degProg;
        }
        public static Subject takeInputForSubject()
        {
            string code;
            string type;
            int creditHours;
            int subjectFees;
            Console.WriteLine("Enter Subject Code: ");
            code = Console.ReadLine();
            Console.WriteLine("Enter Subject Type: ");
            type = Console.ReadLine();
            Console.WriteLine("Enter Subject Credit Hours: ");
            creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fees: ");
            subjectFees = int.Parse(Console.ReadLine());
            Subject sub = new Subject(code, type, creditHours, subjectFees);
            return sub;
        }
        public static Student takeInputForStudent(List <DegreeProgram> programList)
        {
            string name;
            int age;
            double fscMarks;
            double ecatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.WriteLine("Enter student name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter student age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student FSC marks: ");
            fscMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter student ECAT marks: ");
            ecatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Availabe degree programs");
            viewDegreePrograms(programList);
            Console.WriteLine("Enter how many preferences to enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in programList)
                {
                    if (degName == dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter valid degree program name");
                    x--;
                }
            }
            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }
        public static void viewDegreePrograms(List <DegreeProgram> programList)
        {
            foreach (DegreeProgram dp in programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
        public static void header()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("                  UAMS                 ");
            Console.WriteLine("***************************************");
        }
        public static int Menu()
        {
            header();
            int option;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}

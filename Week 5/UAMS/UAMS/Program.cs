using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.UI;
using UAMS.DL;

namespace UAMS
{
    public class Program
    {
        DataLayer data = new DataLayer();
        static void Main(string[] args)
        {
            int option;
            do
            {
                option = AppUI.Menu();
                AppUI.clearScreen();
                if(option == 1)
                {
                    if (DataLayer.programList.Count > 0)
                    {
                        Student s = AppUI.takeInputForStudent(DataLayer.programList);
                        DataLayer.addIntoStudentList(s);
                    }
                }
                else if (option == 2)
                {
                    DegreeProgram d = AppUI.takeInputForDegree();
                    DataLayer.addIntoDegreeList(d);
                }
                else if (option == 3)
                {
                    List <Student> sortedStudentList = new List<Student>();
                    sortedStudentList = sortStudentsByMerit();
                }
                else if (option == 4)
                {
                    AppUI.viewRegisteredStudents(DataLayer.studentList);
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write("Enter degree name: ");
                    degName= Console.ReadLine();
                    AppUI.viewStudentInDegree(degName, DataLayer.studentList);
                }
                else if (option == 6)
                {
                    Console.WriteLine("Enter the student name: ");
                    string name = Console.ReadLine();
                    Student s = StudentPresent(name);
                    if (s != null)
                    {
                        viewSubjects(s);
                        registerSubjects(s);
                    }
                }
                else if (option == 7)
                {
                    calculateFeeForAll();
                }
            }
            while (option != 8);

            Console.ReadKey();
        }
        static void viewSubjects (Student s)
        {
            foreach (Subject i in s.regSubject)
            {
                Console.WriteLine(i.code);
            }
        }
        static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedList = DataLayer.studentList.OrderBy(o => o.merit).ToList();
            return sortedList;
        }
        static Student StudentPresent(string name)
        {
            foreach(Student s in DataLayer.studentList)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        static void calculateFeeForAll()
        {
            foreach (Student s in DataLayer.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.calculateFee() + " fees");
                }
            }
        }
        static void registerSubjects(Student s)
        {
            Console.WriteLine("Enter how many subjects you want ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Enter the subject code");
                string code = Console.ReadLine();
                bool Flag = false;
                foreach (Subject sub in s.regDegree.subjects)
                {
                    if (code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        s.regStudentSubject(sub);
                        Flag= true;
                        break;
                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter valid course");
                    x--;
                }
            }
        }
        static void printStudents()
        {
            foreach(Student s in DataLayer.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get admission");
                }
            }
        }
    }
}

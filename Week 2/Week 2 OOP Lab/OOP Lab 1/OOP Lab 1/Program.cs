using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2PF
{
    class Program
    {
        class students
        {
            public string name;
            public int roll_no;
            public float cgpa;
        }
        static void Main(string[] args)
        {
            Task03();
        }
        static void Task01()
        {
            students s1 = new students();
            s1.name = "Ahmed";
            s1.roll_no = 10;
            s1.cgpa = 3.2F;
            Console.WriteLine("Name: " + s1.name);
            Console.WriteLine("Roll no: " + s1.roll_no);
            Console.WriteLine("CGPA: " + s1.cgpa);
            Console.Read();
        }
        static void Task02()
        {
            students s1 = new students();
            s1.name = "Ahmed";
            s1.roll_no = 10;
            s1.cgpa = 3.2F;
            Console.WriteLine("Name: " + s1.name);
            Console.WriteLine("Roll no: " + s1.roll_no);
            Console.WriteLine("CGPA: " + s1.cgpa);
            students s2 = new students();
            s2.name = "Shahid";
            s2.roll_no = 11;
            s2.cgpa = 2.8F;
            Console.WriteLine("Name: " + s2.name);
            Console.WriteLine("Roll no: " + s2.roll_no);
            Console.WriteLine("CGPA: " + s2.cgpa);
            Console.Read();
        }
        static void Task03()
        {
            students s1 = new students();
            Console.Write("Enter name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter roll no: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name: " + s1.name);
            Console.WriteLine("Roll no: " + s1.roll_no);
            Console.WriteLine("CGPA: " + s1.cgpa);
            Console.Read();
        }
    }
}

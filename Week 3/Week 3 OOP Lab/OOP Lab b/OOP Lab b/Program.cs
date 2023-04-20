using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_b
{
    class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student("Ashhad");
            student s2 = new student("Tayyab");
            Console.WriteLine(s1.sname);
            Console.WriteLine(s2.sname);
            Console.ReadKey();
        }
    }
    class student
    {
        public student(string n)
        {
            sname = n;
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}

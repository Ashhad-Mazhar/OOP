using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_a
{
    class Program
    {
        static void Main(string[] args)
        {
            Task03();
        }
        static void Task01()
        {
            student s1 = new OOP_Lab_a.student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void Task02()
        {
            student s2 = new student();
            Console.ReadKey();
        }
        static void Task03()
        {
            student s3 = new student();
            Console.WriteLine(s3.sname);
            Console.ReadKey();
        }
    }
    class student
    {
        public student()
        {
            sname = "Jill";
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}

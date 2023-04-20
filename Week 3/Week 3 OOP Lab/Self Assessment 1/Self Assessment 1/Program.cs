using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student();
            student s2 = new student();
            student s3 = new student();
            Console.WriteLine("Name 1: " + s1.sname);
            Console.WriteLine("Matric Marks 1: " + s1.matricMarks);
            Console.WriteLine("FSC Marks 1: " + s1.fscMarks);
            Console.WriteLine("ECAT Marks 1: " + s1.ecatMarks);
            Console.WriteLine("Aggregate 1: " + s1.aggregate);
            Console.WriteLine();
            Console.WriteLine("Name 2: " + s2.sname);
            Console.WriteLine("Matric Marks 2: " + s2.matricMarks);
            Console.WriteLine("FSC Marks 2: " + s2.fscMarks);
            Console.WriteLine("ECAT Marks 2: " + s2.ecatMarks);
            Console.WriteLine("Aggregate 2: " + s2.aggregate);
            Console.WriteLine();
            Console.WriteLine("Name 3: " + s3.sname);
            Console.WriteLine("Matric Marks 3: " + s3.matricMarks);
            Console.WriteLine("FSC Marks 3: " + s3.fscMarks);
            Console.WriteLine("ECAT Marks 3: " + s3.ecatMarks);
            Console.WriteLine("Aggregate 3: " + s3.aggregate);
            Console.ReadKey();
        }
    }
    class student
    {
        public student()
        {
            sname = "Ashhad";
            matricMarks = 1038F;
            fscMarks = 970F;
            ecatMarks = 227F;
            aggregate = 84F;
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            student s1 = new student("Ashhad", 1038F, 970F, 227F, 84F);
            student s2 = new student("Tayyab", 1050F, 1011F, 200F, 82F);
            student s3 = new student("Ahmed", 1028F, 1000F, 180F, 80F);
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
        public student(string n, float m, float f, float e, float a)
        {
            sname = n;
            matricMarks = m;
            fscMarks = f;
            ecatMarks = e;
            aggregate = a;
        }
        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}

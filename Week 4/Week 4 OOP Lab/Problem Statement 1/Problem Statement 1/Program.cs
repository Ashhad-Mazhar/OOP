using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem_Statement_1
{
    class Program
    {
        static void Main(string[] args)
        {
            student Student1 = new student("Alice", 1, 3.1f, 1022, 1040, 250, "XYZ Town", true, false);
            float merit = Student1.calculateMerit();
            Console.WriteLine("The merit is: " + merit);
            bool isEligible = Student1.isEligibleForSchlarship(merit);
            if (isEligible == true)
            {
                Console.WriteLine(Student1.Name + " is eligible for scholarship");
            }
            else
            {
                Console.WriteLine(Student1.Name + " is ineligible for scholarship");
            }
            Console.ReadKey();
        }
    }
    class student
    {
        public string Name;
        public int rollNumber;
        public float CGPA;
        public int matricMarks;
        public int fscMarks;
        public int ecatMarks;
        public string homeTown;
        public bool isHostelite;
        public bool isTakingScholarShip;
        public student(string n, int rn, float cgpa, int mm, int fm, int em, string ht, bool ih, bool its)
        {
            Name = n;
            rollNumber = rn;
            CGPA = cgpa;
            matricMarks = mm;
            fscMarks = fm;
            ecatMarks = em;
            homeTown = ht;
            isHostelite = ih;
            isTakingScholarShip = its;
        }
        public float calculateMerit()
        {
            float merit;
            float ecatPercentage = (ecatMarks * (100.0f / 400.0f));
            float fscPercentage = (fscMarks * (100.0f / 1100.0f));
            float ECAT = (ecatPercentage * (40.0f / 100.0f));
            float FSC = (fscPercentage * (60.0f / 100.0f));
            merit = ECAT + FSC;
            return merit;
        }
        public bool isEligibleForSchlarship(float meritPercentage)
        {
            bool isEligible = false;
            if ((meritPercentage > 80) && (isHostelite == true))
            {
                isEligible = true;
            }
            return isEligible;
        }
    }
}
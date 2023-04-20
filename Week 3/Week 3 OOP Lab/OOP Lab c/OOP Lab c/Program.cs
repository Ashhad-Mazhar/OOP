using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_c
{
    class Program
    {
        static void Main(string[] args)
        {
            Task01();
        }
        static void SampleTask()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        static void Task01()
        {
            clockType empty_time = new clockType();
            Console.Write("Empty Time: ");
            empty_time.printTime();
            clockType hour_time = new clockType(8);
            Console.Write("Hour Time: ");
            hour_time.printTime();
            clockType minute_time = new clockType(8, 10);
            Console.Write("Minute Time: ");
            minute_time.printTime();
            clockType full_time = new clockType(8, 10, 30);
            Console.Write("Full Time: ");
            full_time.printTime();
            full_time.incrementSeconds();
            Console.Write("Full Time (Increment Second): ");
            full_time.printTime();
            full_time.incrementMinutes();
            Console.Write("Full Time (Increment Minute): ");
            full_time.printTime();
            full_time.incrementHours();
            Console.Write("Full Time (Increment Hour): ");
            full_time.printTime();
            bool flag = full_time.isEqual(9, 10, 11);
            Console.WriteLine("Flag: " + flag);
            clockType cmp = new clockType(10, 12, 1);
            flag = full_time.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);
            Console.ReadKey();
        }
    }
    class clockType
    {
        public int hours;
        public int minutes;
        public int seconds;
        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int h)
        {
            hours = h;
        }
        public clockType(int h, int m)
        {
            hours = h;
            minutes = m;
        }
        public clockType(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public void incrementHours()
        {
            hours++;
        }
        public void incrementMinutes()
        {
            minutes++;
        }
        public void incrementSeconds()
        {
            seconds++;
        }
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes + " " + seconds);
        }
        public bool isEqual(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isEqual(clockType temp)
        {
            if (temp.hours == hours && temp.minutes == minutes && temp.seconds == seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            clockType NewClock = new clockType(8, 11, 0);
            int ElapsedTime = NewClock.elapsedTime();
            Console.WriteLine("The elapsed time is: " + ElapsedTime + " seconds.");
            int RemainingTime = NewClock.remainingTime();
            Console.WriteLine("The remaining time is: " + RemainingTime + " seconds.");
            clockType Clock2 = new clockType(8, 12, 30);
            NewClock.howFarApart(Clock2);
            NewClock.OutputTime();
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
        public int elapsedTime()
        {
            int elapsedTime = 0;
            elapsedTime = (hours * 3600) + (minutes * 60) + seconds;
            return elapsedTime;
        }
        public int remainingTime()
        {
            int remainingTime = 0, elapsedTime = 0;
            elapsedTime = (hours * 3600) + (minutes * 60) + seconds;
            remainingTime = (24 * 3600) - elapsedTime;
            return remainingTime;
        }
        public void howFarApart(clockType s)
        {
            int elapsedTime = 0, elapsedTimeOfS = 0, difference = 0;
            elapsedTime = (hours * 3600) + (minutes * 60) + seconds;
            elapsedTimeOfS = (s.hours * 3600) + (s.minutes * 60) + s.seconds;
            difference = elapsedTime - elapsedTimeOfS;
            if (difference < 0)
            {
                difference = difference * -1;
            }
            Console.WriteLine("The clocks are " + difference + " seconds apart.");
        }
        public void OutputTime()
        {
            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
        }
    }
}
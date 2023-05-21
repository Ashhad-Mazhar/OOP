using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ship> List_Of_Ships = new List<ship>();
            int input = -1;
            do
            {
                Print_Menu();
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Add_Ship(List_Of_Ships);
                }
                else if (input == 2)
                {
                    View_Ship_Position(List_Of_Ships);
                }
                else if (input == 3)
                {
                    View_Ship_Serial_Number(List_Of_Ships);
                }
                else if (input == 4)
                {
                    Change_Ship_Position(List_Of_Ships);
                }
            } while (input != 5);
        }
        static void Print_Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
        }
        static void Add_Ship(List<ship> List_Of_Ships)
        {
            Console.WriteLine("Enter Ship Number: ");
            string number = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude:");
            Console.WriteLine("Enter Latitude's Degree: ");
            int degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude's Minute: ");
            float minute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude's Direction: ");
            char direction = char.Parse(Console.ReadLine());
            angle Latitude = new angle(degree, minute, direction);
            Console.WriteLine("Enter Ship Longitude:");
            Console.WriteLine("Enter Longitude's Degree: ");
            degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude's Minute: ");
            minute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude's Direction: ");
            direction = char.Parse(Console.ReadLine());
            angle Longitude = new angle(degree, minute, direction);
            ship new_Ship = new ship(Latitude, Longitude, number);
            List_Of_Ships.Add(new_Ship);
            Console.WriteLine("Ship successfully added");
            Console.ReadKey();
        }
        static void View_Ship_Position(List<ship> List_Of_Ships)
        {
            Console.WriteLine("Enter Ship Serial Number to find its position: ");
            string Serial_Number = Console.ReadLine();
            foreach (ship i in List_Of_Ships)
            {
                if (Serial_Number == i.serial_Number)
                {
                    i.Print_Position();
                }
            }
        }
        static void View_Ship_Serial_Number(List<ship> List_Of_Ships)
        {
            Console.WriteLine("Enter the ship's latitude: ");
            string latitude = Console.ReadLine();
            Console.WriteLine("Enter the ship's longitude: ");
            string longitude = Console.ReadLine();
            foreach (ship i in List_Of_Ships)
            {
                if (latitude == i.latitude.Get_Angle_Value() && longitude == i.longitude.Get_Angle_Value())
                {
                    Console.WriteLine("Ship's serial number is: " + i.serial_Number);
                    Console.ReadKey();
                }
            }
        }
        static void Change_Ship_Position(List<ship> List_Of_Ships)
        {
            Console.WriteLine("Enter Ship Serial Number to change its position: ");
            string Serial_Number = Console.ReadLine();
            for (int i = 0; i < List_Of_Ships.Count; i++)
            {
                if (List_Of_Ships[i].serial_Number == Serial_Number)
                {
                    Console.WriteLine("Enter Ship Latitude:");
                    Console.WriteLine("Enter Latitude's Degree: ");
                    int degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude's Minute: ");
                    float minute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude's Direction: ");
                    char direction = char.Parse(Console.ReadLine());
                    List_Of_Ships[i].latitude.Change_Angle_Value(degree, minute, direction);
                    Console.WriteLine("Enter Ship Longitude:");
                    Console.WriteLine("Enter Longitude's Degree: ");
                    degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude's Minute: ");
                    minute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude's Direction: ");
                    direction = char.Parse(Console.ReadLine());
                    List_Of_Ships[i].longitude.Change_Angle_Value(degree, minute, direction);
                    Console.WriteLine("Ship Position Successfully changed");
                    Console.ReadKey();
                }
            }
        }
    }
    class ship
    {
        public angle latitude;
        public angle longitude;
        public string serial_Number;
        public ship(angle Latitude, angle Longitude, string Serial_Number)
        {
            latitude = Latitude;
            longitude = Longitude;
            serial_Number = Serial_Number;
        }
        public void Print_Position()
        {
            string Latitude = latitude.Get_Angle_Value();
            string Longitude = longitude.Get_Angle_Value();
            Console.WriteLine("Ship is at {0} and {1}", Latitude, Longitude);
            Console.ReadKey();
        }
        public string Get_Serial_Number()
        {
            return serial_Number;
        }
    }
    class angle
    {
        public int degrees;
        public float minutes;
        public char direction;
        public angle(int Degrees, float Minutes, char Direction)
        {
            degrees = Degrees;
            minutes = Minutes;
            direction = Direction;
        }
        public void Change_Angle_Value(int Degrees, float Minutes, char Direction)
        {
            degrees = Degrees;
            minutes = Minutes;
            direction = Direction;
        }
        public string Get_Angle_Value()
        {
            string Angle_Value;
            Angle_Value = degrees + "\u00b0" + minutes + "' " + direction;
            return Angle_Value;
        }
    }
}

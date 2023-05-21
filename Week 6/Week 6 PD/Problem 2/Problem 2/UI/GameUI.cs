using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.UI
{
    class GameUI
    {
        public static string getPredictionFromUser(string currentCard)
        {
            Console.WriteLine("The current card is: " + currentCard);
            Console.WriteLine("Will the next card be Higher or Lower?");
            string prediction = Console.ReadLine();
            return prediction;
        }
        public static void displayScore(int score)
        {
            Console.WriteLine("Your score was: " + score);
        }
        public static string getResponseToPlayAgain()
        {
            Console.WriteLine("Would you like to play again?");
            string response = Console.ReadLine();
            return response;
        }
        public static void displayAverageScore(float average)
        {
            Console.WriteLine("Your average score was: " + average);
            Console.ReadKey();
        }
    }
}

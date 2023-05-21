using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_2.BL;
using Problem_2.UI;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int timesPlayed = 0;
            string response = "Yes";
            while (response == "Yes")
            {
                score = 0;
                Deck deck = new Deck();
                deck.Shuffle();
                Card currentCard = deck.DealCard();
                bool isPredictionTrue = true;
                string prediction;
                while (isPredictionTrue)
                {
                    Console.Clear();
                    prediction = GameUI.getPredictionFromUser(currentCard.toString());
                    Card nextCard = deck.DealCard();
                    isPredictionTrue = isThePredictionTrue(prediction, currentCard, nextCard);
                    currentCard = nextCard;
                    if (isPredictionTrue == true)
                    {
                        score++;
                        Console.WriteLine("You were right!");
                    }
                    else
                    {
                        timesPlayed++;
                        Console.WriteLine("You were wrong");
                    }
                    Console.WriteLine("The next card is " + currentCard.toString());
                    Console.ReadKey();
                }
                Console.Clear();
                GameUI.displayScore(score);
                response = GameUI.getResponseToPlayAgain();
            }
            Console.Clear();
            float average = (float)score / timesPlayed;
            GameUI.displayAverageScore(average);
        }
        static bool isThePredictionTrue(string prediciton, Card currentCard, Card nextCard)
        {
            bool output = false;
            string state = "Lower";
            if (nextCard.getSuit() == currentCard.getSuit())
            {
                if (nextCard.getValue() > currentCard.getValue())
                {
                    state = "Higher";
                }
            }
            else if (nextCard.getSuit() > currentCard.getSuit())
            {
                state = "Higher";
            }
            if (state == prediciton)
            {
                output = true;
            }
            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.BL
{
    class Card
    {
        private int suit;
        private int value;
        public Card (int suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }
        public int getSuit()
        {
            return suit;
        }
        public int getValue()
        {
            return value;
        }
        public String getSuitAsString()
        {
            string Suit = "";
            if (suit == 1)
            {
                Suit = "Spades";
            }
            else if (suit == 2)
            {
                Suit = "Hearts";
            }
            else if (suit == 3)
            {
                Suit = "Diamonds";
            }
            else if (suit == 4)
            {
                Suit = "Clubs";
            }
            return Suit;
        }
        public String getValueAsString()
        {
            string Value = "";
            {
                if (value == 1)
                {
                    Value = "Ace";
                }
                else if (value == 2)
                {
                    Value = "2";
                }
                else if (value == 3)
                {
                    Value = "3";
                }
                else if (value == 4)
                {
                    Value = "4";
                }
                else if (value == 5)
                {
                    Value = "5";
                }
                else if (value == 6)
                {
                    Value = "6";
                }
                else if (value == 7)
                {
                    Value = "7";
                }
                else if (value == 8)
                {
                    Value = "8";
                }
                else if (value == 9)
                {
                    Value = "9";
                }
                else if (value == 10)
                {
                    Value = "10";
                }
                else if (value == 11)
                {
                    Value = "Jack";
                }
                else if (value == 12)
                {
                    Value = "Queen";
                }
                else if (value == 13)
                {
                    Value = "King";
                }
            }
            return Value;
        }
        public String toString()
        {
            string Output = getValueAsString() + " of " + getSuitAsString();
            return Output;
        }
    }
}

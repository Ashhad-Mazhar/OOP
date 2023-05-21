using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.BL
{
    class Deck
    {
        private List<Card> cards;
        private int currentIndex;

        public Deck()
        {
            cards = new List<Card>();
            currentIndex = 0;
            InitializeDeck();
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card temp = cards[k];
                cards[k] = cards[n];
                cards[n] = temp;
            }
        }

        public int CardsLeft()
        {
            return cards.Count - currentIndex;
        }

        public Card DealCard()
        {
            if (currentIndex >= cards.Count)
            {
                return null;
            }
            Card card = cards[currentIndex];
            currentIndex++;
            return card;
        }

        private void InitializeDeck()
        {
            int[] suits = {1, 2, 3, 4};
            int[] ranks = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

            foreach (int suit in suits)
            {
                foreach (int rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }
    }
}
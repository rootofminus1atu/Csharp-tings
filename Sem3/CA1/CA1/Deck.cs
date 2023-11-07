using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new();

        public Deck()
        {
            InitializeDeck();
            Shuffle();
        }

        public void Reset()
        {
            Cards.Clear();
            InitializeDeck();
            Shuffle();
        }

        public void InitializeDeck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Card.GetAllRanks())
                {
                    Cards.Add(new Card(rank, s));
                }
            }
        }

        public void Shuffle()
        {
            var rand = new Random();
            Cards = Cards.OrderBy(c => rand.Next()).ToList();
        }

        public Card DrawBottom()
        {
            Card card = Cards.First();

            Cards.RemoveAt(0);

            return card;
        }

        public Card DrawTop()
        {
            Card card = Cards.Last();

            Cards.RemoveAt(Cards.Count - 1);

            return card;
        }
    }
}

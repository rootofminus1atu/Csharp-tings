using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    /// <summary>
    /// Represents a deck of playing cards.
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// The list of cards in the deck.
        /// </summary>
        public List<Card> Cards { get; private set; } = new();

        /// <summary>
        /// Initializes a new instance of the Deck class and shuffles it.
        /// </summary>
        public Deck()
        {
            InitializeDeck();
            Shuffle();
        }

        /// <summary>
        /// Resets the deck by clearing all cards, initializing, and shuffling it.
        /// </summary>
        public void Reset()
        {
            Cards.Clear();
            InitializeDeck();
            Shuffle();
        }

        /// <summary>
        /// Helper method that Initializes the deck by creating cards for each combination of suits and ranks.
        /// </summary>
        private void InitializeDeck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Card.GetAllRanks())
                {
                    Cards.Add(new Card(rank, s));
                }
            }
        }

        /// <summary>
        /// Shuffles the cards in the deck to randomize their order.
        /// </summary>
        public void Shuffle()
        {
            var rand = new Random();
            Cards = Cards.OrderBy(c => rand.Next()).ToList();
        }

        /// <summary>
        /// Draws the card from the bottom of the deck.
        /// </summary>
        /// <returns>The card drawn from the bottom of the deck.</returns>
        public Card DrawBottom()
        {
            Card card = Cards.First();

            Cards.RemoveAt(0);

            return card;
        }

        /// <summary>
        /// Draws the card from the top of the deck.
        /// </summary>
        /// <returns>The card drawn from the top of the deck.</returns>
        public Card DrawTop()
        {
            Card card = Cards.Last();

            Cards.RemoveAt(Cards.Count - 1);

            return card;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO:
// change the Player to instead have a list of cards

namespace CA1
{
    public class Player
    {
        public const int MAX_POINTS = 21;

        public List<Card> Cards { get; } = new();

        public List<string> CardSymbols => Cards.Select(c => c.ToStringShort()).ToList();
        public string AllCardSymbolsString => string.Join(", ", CardSymbols);

        public int Points => GetPoints();
        public bool Bust => Points > MAX_POINTS;
        public bool GotBlackjack => Points == MAX_POINTS;

        public StickOrTwist StickOrTwist { get; set; } = StickOrTwist.Twist;
        public bool IsTwisting => this.StickOrTwist == StickOrTwist.Twist;
        public bool IsSticking => !IsTwisting;



        public Card DrawTop(Deck deck)
        {
            Card card = deck.DrawTop();
            Cards.Add(card);
            return card;
        }

        public Card TestGetCard(Card card)
        {
            Cards.Add(card);
            return card;
        }

        public void ResetHand()
        {
            Cards.Clear();
            StickOrTwist = StickOrTwist.Twist;
        }

        private int GetPoints()
        {
            const int ACE_ALT_POINTS = 1;

            int total = 0;

            foreach(Card card in Cards)
            {
                if (card.Rank is Ace && total + card.GetPoints() > MAX_POINTS)
                {
                    total += ACE_ALT_POINTS;
                }
                else
                {
                    total += card.GetPoints();
                }
                    
            }

            return total;
        }
    }

    public class Dealer : Player
    {
        const int DEALER_CUTOFF = 17;

        public bool HasToTake => Points < DEALER_CUTOFF;
    }

}

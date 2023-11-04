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
        public const int MAX_SCORE = 21;

        public List<Card> Cards { get; set; } = new();

        public int Points => GetPoints();


        public bool Bust => Points > MAX_SCORE;
        public bool GotBlackjack => Points == MAX_SCORE;

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

        private int GetPoints()
        {
            const int ACE_ALT_POINTS = 1;

            int total = 0;

            foreach(Card card in Cards)
            {
                if (card.Rank is Ace && total + card.GetPoints() > MAX_SCORE)
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
        /*
        private void AddPoints(Card card)
        {
            if (card.Rank is Ace)
            {
                if (Score + card.GetPoints() > MAX_SCORE)
                {
                    // special value
                    Score += 1;
                    Console.WriteLine("Ace counted as 1 instead of 11");
                    return;
                }
            }

            Score += card.GetPoints();
        }
        */
    }

    public class Dealer : Player
    {
        const int DEALER_CUTOFF = 17;

        public bool HasToTake => Points < DEALER_CUTOFF;
    }

}

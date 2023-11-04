using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    public class Player
    {
        public const int MAX_SCORE = 21;

        public int Score { get; set; } = 0;
        public bool Bust => Score > MAX_SCORE;
        public bool GotBlackjack => Score == MAX_SCORE;

        public StickOrTwist StickOrTwist { get; set; } = StickOrTwist.Twist;
        public bool IsTwisting => this.StickOrTwist == StickOrTwist.Twist;
        public bool IsSticking => !IsTwisting;



        public Card DrawTop(Deck deck)
        {
            Card card = deck.DrawTop();
            AddPoints(card);
            return card;
        }

        public Card TestGetCard(Card card)
        {
            AddPoints(card);
            return card;
        }

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
    }

    public class Dealer : Player
    {
        const int DEALER_CUTOFF = 17;

        public bool HasToTake => Score < DEALER_CUTOFF;
    }

}

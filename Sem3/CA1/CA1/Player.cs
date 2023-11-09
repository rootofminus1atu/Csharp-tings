using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO:
// change the Player to instead have a list of cards

namespace CA1
{
    /// <summary>
    /// Represents a player in a card game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The list of cards in the player's hand.
        /// </summary>
        public List<Card> Cards { get; } = new();

        /// <summary>
        /// The list of short string representations (e.g. "A♠") of the cards in the player's hand.
        /// </summary>
        public List<string> CardSymbols => Cards.Select(c => c.ToStringShort()).ToList();

        /// <summary>
        /// A string representation of the <see cref="CardSymbols"/> list.
        /// </summary>
        public string AllCardSymbolsString => string.Join(", ", CardSymbols);



        /// <summary>
        /// The maximum allowed points for the player before they go bust (e.g., 21 in a typical blackjack game).
        /// </summary>
        public const int MAX_POINTS = 21;
        
        /// <summary>
        /// The total amount of points in the player's hand.
        /// </summary>
        public int Points => CalculatePoints();

        /// <summary>
        /// Whether the player has busted (exceeded the maximum amount points <see cref="MAX_POINTS"/>).
        /// </summary>
        public bool Bust => Points > MAX_POINTS;

        /// <summary>
        /// Whether the player has achieved a blackjack (got the maximum amount of points <see cref="MAX_POINTS"/>).
        /// </summary>
        public bool GotBlackjack => Points == MAX_POINTS;



        /// <summary>
        /// The player's decision to stick or twist in the game.
        /// </summary>
        public StickOrTwist StickOrTwist { get; set; } = StickOrTwist.Twist;

        /// <summary>
        /// Whether the player is currently twisting (choosing to draw additional cards).
        /// </summary>
        public bool IsTwisting => this.StickOrTwist == StickOrTwist.Twist;
        
        /// <summary>
        /// Whether the player is currently sticking (choosing to not draw additional cards).
        /// </summary>
        public bool IsSticking => !IsTwisting;

        /// <summary>
        /// The name of the Player
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        /// Initializes a new instance of the Player class with the specified name (if not provided, default is "Player").
        /// </summary>
        /// <param name="name">The name of the player (if not provided, default is "Player").</param>
        public Player(string name = "Player")
        {
            Name = name;
        }

        /// <summary>
        /// Draws a card from the top of the deck and adds it to the player's <see cref="Cards"/> list.
        /// </summary>
        /// <param name="deck">The deck of cards to draw from.</param>
        /// <returns>The card drawn from the top of the deck.</returns>
        public Card DrawTop(Deck deck)
        {
            Card card = deck.DrawTop();
            Cards.Add(card);
            return card;
        }

        /// <summary>
        /// Adds a specified card to the player's <see cref="Cards"/> list for testing purposes.
        /// </summary>
        /// <param name="card">The card to add to the player's <see cref="Cards"/> list.</param>
        /// <returns>The card added to the player's <see cref="Cards"/> list.</returns>
        public Card TestGetCard(Card card)
        {
            Cards.Add(card);
            return card;
        }

        /// <summary>
        /// Resets the player's hand by clearing all cards and setting the player's decision to twist.
        /// </summary>
        public void ResetHand()
        {
            Cards.Clear();
            StickOrTwist = StickOrTwist.Twist;
        }

        /// <summary>
        /// Calculates and returns the total points in the player's hand, considering special rules for Ace cards.
        /// </summary>
        /// <remarks>
        /// <br></br> An Ace card is initially worth 11 points. However, if adding 11 points would cause the player
        ///   to exceed the maximum allowed points <see cref="MAX_POINTS"/>, the Ace card is worth 1 point.
        /// </remarks>
        /// <returns>The total point value of the player's hand.</returns>
        private int CalculatePoints()
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

    /// <summary>
    /// Represents the dealer in a card game, a specialized player with specific rules.
    /// <br>Inherits from <see cref="Player"/></br>
    /// </summary>
    public class Dealer : Player
    {
        /// <summary>
        /// The dealer's point cutoff after which they must not take additional cards.
        /// <br>In a typical game that's 17 including.</br>
        /// </summary>
        const int DEALER_CUTOFF = 17;

        /// <summary>
        /// Whether the dealer has to take additional cards based on their current amount of points.
        /// </summary>
        public bool HasToTake => Points < DEALER_CUTOFF;



        /// <summary>
        /// Initializes a new instance of the Dealer class with the specified name (if not provided, default is "Dealer").
        /// </summary>
        /// <param name="name">The name of the dealer (if not provided, default is "Dealer").</param>
        public Dealer(string name = "Dealer") : base(name) { }
    }

}

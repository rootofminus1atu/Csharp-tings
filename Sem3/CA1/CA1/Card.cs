using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CA1
{
    /// <summary>
    /// Represents the suit of a playing card.
    /// </summary>
    public enum Suit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

    public static class SuitExtension
    {
        /// <summary>
        /// Gets the icon representation of the suit. Aka one of the following: ♦, ♥, ♠, ♣  
        /// </summary>
        /// <param name="suit">The suit value.</param>
        /// <returns>The suit's icon.</returns>
        public static string Icon(this Suit suit)
        {
            return suit switch
            {
                Suit.Diamonds => "♦",
                Suit.Hearts => "♥",
                Suit.Spades => "♠",
                Suit.Clubs => "♣",
                _ => throw new ArgumentException("Invalid Suit variant")
            };
        }

        /// <summary>
        /// Gets the console color associated with the suit.
        /// </summary>
        /// <param name="suit">The suit value.</param>
        /// <returns>The console color for the suit.</returns>
        public static ConsoleColor Color(this Suit suit)
        {
            return suit switch
            {
                Suit.Diamonds => ConsoleColor.Red,
                Suit.Hearts => ConsoleColor.Red,
                Suit.Spades => ConsoleColor.Black,
                Suit.Clubs => ConsoleColor.Black,
                _ => throw new ArgumentException("Invalid Suit variant")
            };
        }
    }

    /// <summary>
    /// Represents the rank of a playing card.
    /// </summary>
    public abstract class Rank
    {
        /// <summary>
        /// Returns the name of the rank as a string.
        /// </summary>
        /// <returns>The name of the rank.</returns>
        public override string ToString()
        {
            return GetType().Name;
        }

        /// <summary>
        /// Returns the initial (initial character or the number) of the rank.
        /// </summary>
        /// <returns>The initial character or the number of the rank.</returns>
        public virtual string Initial()
        {
            return ToString()[0].ToString();
        }
    }

    /// <summary>
    /// Represents the Ace rank.
    /// </summary>
    public class Ace : Rank { }

    /// <summary>
    /// Represents the King rank.
    /// </summary>
    public class King : Rank { }

    /// <summary>
    /// Represents the Queen rank.
    /// </summary>
    public class Queen : Rank { }

    /// <summary>
    /// Represents the Jack rank.
    /// </summary>
    public class Jack : Rank { }

    /// <summary>
    /// Represents a Number rank. From 2 to 10.
    /// </summary>
    public class Number : Rank
    {
        /// <summary>
        /// The maximum valid value for a number rank.
        /// </summary>
        public const int MAX_VALUE = 10;

        /// <summary>
        /// The minimum valid value for a number rank.
        /// </summary>
        public const int MIN_VALUE = 2;

        private int _value;

        /// <summary>
        /// The number value of the rank.
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    throw new ArgumentOutOfRangeException($"A card's number value must be between {MIN_VALUE} and {MAX_VALUE}");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Initializes a new Number rank instance with the given value.
        /// </summary>
        /// <param name="value">The number rank.</param>
        public Number(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns the string representation of the number rank, the number itself as a string.
        /// </summary>
        /// <returns>The number as a string.</returns>
        public override string ToString()
        {
            return $"{Value}";
        }

        /// <summary>
        /// Returns the string representation of the number rank, the number itself as a string.
        /// </summary>
        /// <returns>The number as a string.</returns>
        public override string Initial()
        {
            return ToString();
        }
    }

    /// <summary>
    /// Represents a playing card with a rank and a suit.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The rank of the card.
        /// </summary>
        public Rank Rank { get; private set; }

        /// <summary>
        /// The suit of the card.
        /// </summary>
        public Suit Suit { get; private set; }

        /// <summary>
        /// Initializes a new Card instance with the specified rank and suit.
        /// </summary>
        /// <param name="name">The rank of the card.</param>
        /// <param name="suit">The suit of the card.</param>
        public Card(Rank name, Suit suit)
        {
            Rank = name;
            Suit = suit;
        }

        /// <summary>
        /// Returns a string representation of the card.
        /// </summary>
        /// <returns>e.g., "Ace of Spades".</returns>
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        /// <summary>
        /// Returns a long string representation of the card.
        /// </summary>
        /// <returns>e.g., "Card dealt is the Ace of Spades, worth 11 points".</returns>
        public string ToStringLong()
        {
            return $"Card dealt is the {this}, worth {GetPoints()} points";
        }

        /// <summary>
        /// Returns a short string representation of the card.
        /// </summary>
        /// <returns>e.g., "A♠".</returns>
        public string ToStringShort()
        {
            return $"{Rank.Initial()}{Suit.Icon()}";
        }

        /// <summary>
        /// Gets the amount of points associated with the card based on its rank.
        /// </summary>
        /// <remarks>
        /// The point value of a card is determined by its rank. The rules for point values are as follows:
        /// <br></br>- An Ace card is worth 11 points.
        /// <br></br>- King, Queen, and Jack cards are each worth 10 points.
        /// <br></br>- Numbered cards (2 to 10) are worth their face value (e.g., 2 points for a '2' card, 3 points for a '3' card, etc.).
        /// </remarks>
        /// <returns>The point value of the card.</returns>
        public int GetPoints()
        {
            return Rank switch
            {
                Ace => 11,
                King or Queen or Jack => 10,
                Number { Value: int n } => n,
                _ => throw new Exception("I don't know how, but you somehow created a card that shouldn't exit, shame on you")
            };
        }


        /// <summary>
        /// Returns a collection of all picture ranks (Ace, King, Queen, Jack).
        /// </summary>
        /// <returns>A collection of picture ranks.</returns>
        public static IEnumerable<Rank> GetPictureRanks()
        {
            return new List<Rank>() { new Ace(), new King(), new Queen(), new Jack() };
        }

        /// <summary>
        /// Gets a collection of all number ranks (2 to 10).
        /// </summary>
        /// <returns>A collection of number ranks.</returns>
        public static IEnumerable<Rank> GetNumberRanks()
        {
            return Enumerable
                .Range(Number.MIN_VALUE, Number.MAX_VALUE - 1)
                .Select(num => new Number(num));
        }

        /// <summary>
        /// Gets a collection of all ranks (both picture and number ranks).
        /// </summary>
        /// <returns>A collection of all card ranks.</returns>
        public static IEnumerable<Rank> GetAllRanks()
        {
            return GetNumberRanks().Concat(GetPictureRanks());
        }
    }
}

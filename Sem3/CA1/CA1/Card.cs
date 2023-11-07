using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CA1
{
    // MAYBE TODOS:
    // use records instead of interfaces for the Rank type
    public enum Suit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

    public static class SuitExtension
    {
        public static string Icon(this Suit suit)
        {
            return suit switch
            {
                Suit.Diamonds => "♦",
                Suit.Hearts => "♥",
                Suit.Spades => "♠",
                Suit.Clubs => "♣",
                _ => ""
            };
        }

        public static ConsoleColor Color(this Suit suit)
        {
            return suit switch
            {
                Suit.Diamonds => ConsoleColor.Red,
                Suit.Hearts => ConsoleColor.Red,
                Suit.Spades => ConsoleColor.Black,
                Suit.Clubs => ConsoleColor.Black,
                _ => ConsoleColor.Black,
            };
        }
    }

    public abstract class Rank
    {
        public override string ToString()
        {
            return GetType().Name;
        }

        public virtual string Initial()
        {
            return ToString()[0].ToString();
        }
    }

    public class Ace : Rank { }
    public class King : Rank { }
    public class Queen : Rank { }
    public class Jack : Rank { }
    public class Number : Rank
    {
        public const int MAX_VALUE = 10;
        public const int MIN_VALUE = 2;

        private int _value;
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

        public Number(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public override string Initial()
        {
            return ToString();
        }
    }

    public class Card
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }


        public Card(Rank name, Suit suit)
        {
            Rank = name;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public string ToStringLong()
        {
            return $"Card dealt is the {this}, worth {GetPoints()}";
        }

        public string ToStringShort()
        {
            return $"{Rank.Initial()}{Suit.Icon()}";
        }

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


        public static IEnumerable<Rank> GetPictureRanks()
        {
            return new List<Rank>() { new Ace(), new King(), new Queen(), new Jack() };
        }

        public static IEnumerable<Rank> GetNumberRanks()
        {
            return Enumerable
                .Range(Number.MIN_VALUE, Number.MAX_VALUE - 1)
                .Select(num => new Number(num));
        }

        public static IEnumerable<Rank> GetAllRanks()
        {
            return GetNumberRanks().Concat(GetPictureRanks());
        }
    }
}

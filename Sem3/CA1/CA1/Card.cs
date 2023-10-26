using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    public enum Suit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

    public class Card
    {
        public ICardValue Value { get; set; }
        public Suit Suit { get; set; }



        public interface ICardValue { }

        public class Ace : ICardValue
        {
            public override string ToString()
            {
                return "Ace";
            }
        }

        public class King : ICardValue
        {
            public override string ToString()
            {
                return "King";
            }
        }
        public class Queen : ICardValue
        {
            public override string ToString()
            {
                return "Queen";
            }
        }

        public class Jack : ICardValue
        {
            public override string ToString()
            {
                return "Jack";
            }
        }

        public class Number : ICardValue
        {
            public const int MAX_VAL = 10;
            public const int MIN_VAL = 2;

            public int Val { get; set; }

            public Number(int value)
            {
                Val = value;
            }

            public override string ToString()
            {
                return $"{Val}";
            }
        }




        public Card(ICardValue name, Suit suit)
        {
            // do a check for valid card here and throw exception maybe
            Value = name;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }

        public string GetDetails()
        {
            return $"Card dealt is the {this}, value {GetPoints()}";
        }

        public int GetPoints()  // rename to get points
        {
            return Value switch
            {
                Ace => 11,
                King or Queen or Jack => 10,
                Number { Val: int n } when n >= 2 && n <= 10 => n,
                _ => throw new Exception("No value for this card")
            };
        }



        public static List<ICardValue> GetPictureValues()
        {
            return new List<ICardValue>() { new Ace(), new King(), new Queen(), new Jack() };
        }

        public static IEnumerable<ICardValue> GetNumberValues()
        {
            return Enumerable.Range(Number.MIN_VAL, Number.MAX_VAL - 1)
                .Select(num => new Number(num));
        }
    }
}

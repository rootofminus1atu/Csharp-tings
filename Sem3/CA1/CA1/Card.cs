﻿using System;
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

    public abstract class IRank
    {
        public override string ToString()
        {
            return GetType().Name;
        }
    }

    public class Ace : IRank { }
    public class King : IRank { }
    public class Queen : IRank { }
    public class Jack : IRank { }
    public class Number : IRank
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

        public Number(int Rank)
        {
            Value = Rank;
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }

    public class Card
    {
        public IRank Rank { get; set; }
        public Suit Suit { get; set; }


        public Card(IRank name, Suit suit)
        {
            // do a check for valid card here and throw exception maybe
            Rank = name;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public string GetDetails()
        {
            return $"Card dealt is the {this}, Rank {GetPoints()}";
        }

        public int GetPoints()  // rename to get points
        {
            return Rank switch
            {
                Ace => 11,
                King or Queen or Jack => 10,
                Number { Value: int n } => n,
                _ => throw new Exception("No Rank for this card")
            };
        }


        public static IEnumerable<IRank> GetPictureRanks()
        {
            return new List<IRank>() { new Ace(), new King(), new Queen(), new Jack() };
        }

        public static IEnumerable<IRank> GetNumberRanks()
        {
            return Enumerable
                .Range(Number.MIN_VALUE, Number.MAX_VALUE - 1)
                .Select(num => new Number(num));
        }

        public static IEnumerable<IRank> GetAllRanks()
        {
            return GetNumberRanks().Concat(GetPictureRanks());
        }
    }
}
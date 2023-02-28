using System.Collections.Generic;

namespace Lab11Q2
{
    internal static class Program
    {
        public static Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            {"A", "Ace" },

            {"2", "Two" },
            {"3", "Three" },
            {"4", "Four" },
            {"5", "Five" },
            {"6", "Six" },
            {"7", "Seven" },
            {"8", "Eight" },
            {"9", "Nine" },
            {"10", "Ten" }, // why

            {"J", "Jack" },
            {"Q", "Queen" },
            {"K", "King" },

            {"D", "Diamonds" },
            {"H", "Hearts" },
            {"S", "Spades" },
            {"C", "Clubs" },
        };

        static void Main(string[] args)
        {

            Console.Write("Card: ");
            string card = Console.ReadLine().ToUpper();

            try
            {
                char color = card[2];
                // string 

            }
            catch
            {
                Console.WriteLine("nvm");
            }
            



            // Console.Write($"Card name: {dict[card[0]]} of {dict[card[1]]}");




        }

        
    }
}
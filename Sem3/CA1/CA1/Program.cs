using System.Net.Http.Headers;
using System.Reflection;

namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card c = new(new Number(10), Suit.Diamonds);


            int width = 11;
            string word = "HELLO";

            // Padding on the left
            string leftPaddedString = word.PadLeft(width, '_');

            // Padding on the right
            string rightPaddedString = word.PadRight(width, '_');

            Console.WriteLine(leftPaddedString);
            Console.WriteLine(rightPaddedString);



            Console.WriteLine(InsertWithLeftSpace("_____", "HI", 2));
            Console.WriteLine(InsertWithLeftSpace2("_____", "HI", 2));
            Console.WriteLine();


            // DrawAt(10, 10, c.GetDrawing());
            DrawCard(2, 5, c);
            DrawCard(20, 5, c);
        }

        public static string InsertWithLeftSpace2(string slate, string thing, int space)
        {
            string total = "";

            // ok maybe not
            char[] slateArr = slate.ToCharArray();
            // Console.WriteLine(thing.ToCharArray().Prepend('\0');


            return "";
        }

        public static string InsertWithLeftSpace(string slate, string inserted, int space)
        {
            string total = "";

            int j = 0;

            for (int i = 0; i < slate.Length; i++)
            {
                if (i >= space && j < inserted.Length)
                {
                    total += inserted[j];
                    j++;
                }
                else
                {
                    total += slate[i];
                }
            }

            return total;
        }

        public static void DrawCard(int x, int y, Card card)
        {
            const int WIDTH = 11;
            const int HEIGHT = 9;

            string rankInitial = card.Rank.GetInitial();
            string suitIcon = card.Suit.Icon();
            ConsoleColor fg = card.Suit.Color();
            ConsoleColor bg = ConsoleColor.White;

            // isolate this below
            var rankIndex1 = (1, 0);
            var rankIndex2 = (WIDTH - 2, HEIGHT - 1);
            var suitIndex = (WIDTH / 2, HEIGHT / 2);
            List<(int, int)> rankIndeces = new() { rankIndex1, rankIndex2 };
            List<(int, int)> suitIndeces = new() { suitIndex };

            // replace with more efficient string blank slate
            /*
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    string thingToDraw = (i, j) switch
                    {
                        _ when (i, j) == rankIndex1 => rankInitial,
                        _ when (i, j) == rankIndex2 => rankInitial,
                        _ when (i, j) == suitIndex => suitIcon,
                        _ => " "
                    };

                    DrawAt(x + i, y + j, thingToDraw, bg, fg);
                }
            }
            */



            foreach (var (i, j) in suitIndeces)
            {
                DrawAt(x + i, y + j, suitIcon, bg, fg);
            }

            foreach (var (i, j) in  rankIndeces)
            {
                DrawAt(x + i, y + j, rankInitial, bg, fg);
            }

            

        }

        public static void DrawAt(int x, int y, string thing, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.Gray)
        {
            string[] chunks = thing.Split('\n');

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            for (int i = 0; i < chunks.Length; i++)
            {
                string chunk = chunks[i];
                Console.SetCursorPosition(x, y + i);
                Console.Write(chunk);
            }

            Console.ResetColor();
        }
    }





    



    public class Testing
    {
        public static void DeckDemo()
        {
            Deck d1 = new();
            d1.Shuffle();

            Console.WriteLine(d1.Cards.Stringify());
            Console.WriteLine(d1.DiscardedCards.Stringify());

            Card c = d1.DrawBottom();
            Console.WriteLine(c);

            Console.WriteLine(d1.Cards.Stringify());
            Console.WriteLine(d1.DiscardedCards.Stringify());

            Console.WriteLine("♥ ♣ ♦ ♠ ♤ ♡ ♧ ♢");
        }

        public static void CardDemo()
        {
            Card c1 = new(new King(), Suit.Diamonds);
            Console.WriteLine(c1);
        }
    }



    public static class ListExtension
    {
        public static string Stringify<T>(this IEnumerable<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }
    }

}
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card cc = new(new Number(10), Suit.Diamonds);

            // DrawAt(10, 10, c.GetDrawing());
            DrawCard(2, 5, cc);
            DrawCard(20, 5, cc);





            Console.WriteLine("XX".InsertIntoStringWithPadRight("abcdef", 1));
        }





        public static void DrawCard(int x, int y, Card card)
        {
            const int WIDTH = 9;
            const int HEIGHT = 7;

            string rankInitial = card.Rank.GetInitial();
            string suitIcon = card.Suit.Icon();
            ConsoleColor fg = card.Suit.Color();
            ConsoleColor bg = ConsoleColor.White;


            for (int i = 0; i < HEIGHT; i++)
            {
                DrawAt(x, y + i, " ".Repeat(WIDTH), bg, fg);
            }

            // drawing the 1st row
            DrawAt(x, y, rankInitial.InsertIntoStringWithPadLeft(" ".Repeat(WIDTH), 1), bg, fg);

            // drawing the last row
            DrawAt(x, y + HEIGHT - 1, rankInitial.InsertIntoStringWithPadRight(" ".Repeat(WIDTH), 1), bg, fg);

            // draw the suit in the center
            DrawAt(x + WIDTH / 2, y + HEIGHT / 2, suitIcon, bg, fg);

            // reset cursor position for the future
            Console.SetCursorPosition(x + WIDTH, y + HEIGHT - 1);
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

    public static class StringExtension
    {
        public static string InsertIntoStringWithPadLeft(this string str, string slate, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[..howMuchRemove];


            var slateSB = new StringBuilder(slate);
            slateSB.Remove(pad, howMuchRemove);
            slateSB.Insert(pad, strLimited);

            return slateSB.ToString();
        }

        public static string Repeat(this string str, int n)
        {
            return Enumerable.Repeat(str, n).Aggregate("", (acc, c) => acc + c);
        }


        public static string InsertIntoStringWithPadRight(this string str, string slate, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[^howMuchRemove..];


            var slateSB = new StringBuilder(slate);
            int where = slate.Length - pad - howMuchRemove;
            slateSB.Remove(where, howMuchRemove);
            slateSB.Insert(where, strLimited);

            return slateSB.ToString();
        }

    }

}
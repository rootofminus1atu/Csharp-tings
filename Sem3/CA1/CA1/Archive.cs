using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class Archive
    {
        static string InsertIntoStringWithPadLeft(string slate, string str, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[..howMuchRemove];


            var slateSB = new StringBuilder(slate);
            slateSB.Remove(pad, howMuchRemove);
            slateSB.Insert(pad, strLimited);

            return slateSB.ToString();
        }

        static string InsertIntoStringWithPadRight(string slate, string str, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[^howMuchRemove..];


            var slateSB = new StringBuilder(slate);
            int where = slate.Length - pad - howMuchRemove;
            slateSB.Remove(where, howMuchRemove);
            slateSB.Insert(where, strLimited);

            return slateSB.ToString();
        }

        static string InsertIntoSlateWithPadLeft(string slate, string str, int pad)
        {
            string extended = ExtendWithLeftPad(slate, str, pad);

            var inserted = slate
                .Zip(extended, (c1, c2) => c2 == '\0' ? c1 : c2)
                .Aggregate("", (acc, c) => acc + c);

            return inserted;
        }

        static string ExtendWithLeftPad(string slate, string str, int pad)
        {
            int maxLength = slate.Length - pad;
            var result = Enumerable
                .Repeat('\0', pad)
                .Concat(str.Take(maxLength))
                .Concat(Enumerable.Repeat('\0', maxLength - Math.Min(maxLength, str.Length)));


            return string.Join("", result);
        }

        static string ExtendWithRightPad(string slate, string str, int pad)
        {
            int maxLength = slate.Length - pad;

            var result = Enumerable
                .Repeat('\0', maxLength - Math.Min(maxLength, str.Length))
                .Concat(str.TakeLast(maxLength))
                .Concat(Enumerable.Repeat('\0', pad));

            return string.Join("", result);
        }

        /*
        static char[] ExtendWithRightPad(char[] slate, char[] str, int pad)
        {
            int maxLength = slate.Length - pad;

            char[] result = Enumerable
                .Repeat('\0', maxLength - Math.Min(maxLength, str.Length))
                .Concat(str.TakeLast(maxLength))
                .Concat(Enumerable.Repeat('\0', pad))
                .ToArray();

            return result;
        }
        */

        
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

            string rankInitial = card.Rank.Initial();
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

            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    string thingToDraw = (i, j) switch
                    {
                        //_ when (i, j) == rankIndex1 => rankInitial,
                        //_ when (i, j) == rankIndex2 => rankInitial,
                        //_ when (i, j) == suitIndex => suitIcon,
                        _ => " "
                    };

                    //DrawAt(x + i, y + j, thingToDraw, bg, fg);
                }
            }


            /*
            foreach (var (i, j) in suitIndeces)
            {
                DrawAt(x + i, y + j, suitIcon, bg, fg);
            }

            foreach (var (i, j) in  rankIndeces)
            {
                DrawAt(x + i, y + j, rankInitial, bg, fg);
            }
            */

            // drawing the 1st row
            //DrawAt(x, y, rankInitial.InsertIntoStringWithPadLeft(" ".Repeat(WIDTH), 1), bg, fg);

            // drawing the last row
            //DrawAt(x, y + HEIGHT, rankInitial.InsertIntoStringWithPadRight(" ".Repeat(WIDTH), 1), bg, fg);

            Console.SetCursorPosition(x + WIDTH, y + HEIGHT);
        }
    }
}

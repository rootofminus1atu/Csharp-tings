using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    public class Utils
    {
        public static T CasePrompt<T>(params (string, T)[] cases)
        {
            while (true)
            {
                Console.Write("> ");
                string? input = Console.ReadLine()?.ToLower();

                foreach (var (str, outcome) in cases)
                {
                    if (input == str.ToLower())
                    {
                        return outcome;
                    }
                }
            }
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

        public static string Repeat(this string str, int n)
        {
            return Enumerable.Repeat(str, n).Aggregate("", (acc, c) => acc + c);
        }

        public static string InsertIntoStringWithPadLeft(this string str, string slate, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[..howMuchRemove];


            var slateSB = new StringBuilder(slate);
            slateSB.Remove(pad, howMuchRemove);
            slateSB.Insert(pad, strLimited);

            return slateSB.ToString();
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

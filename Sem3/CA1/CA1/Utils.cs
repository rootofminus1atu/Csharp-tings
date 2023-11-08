using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    /// <summary>
    /// A utility class that provides various helper methods.
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Prompts the user for input, until one of the cases provided is matched. 
        /// </summary>
        /// <typeparam name="T">The type of outcome to return.</typeparam>
        /// <param name="cases">A list of cases to match input against.</param>
        /// <returns>The outcome corresponding to the user's input.</returns>
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
        /// <summary>
        /// Returns a dev-friendly string representation of an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable.</typeparam>
        /// <param name="list">The enumerable to stringify.</param>
        /// <returns>A string representation of the enumerable.</returns>
        public static string Stringify<T>(this IEnumerable<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }
    }

    public static class StringExtension
    {
        /// <summary>
        /// Repeats the input string multiple times.
        /// </summary>
        /// <param name="str">The input string to repeat.</param>
        /// <param name="n">The number of times to repeat the string.</param>
        /// <returns>The repeated string.</returns>
        public static string Repeat(this string str, int n)
        {
            return Enumerable.Repeat(str, n).Aggregate("", (acc, c) => acc + c);
        }

        /// <summary>
        /// Inserts the given string into another string with padding on the left. <br></br>If the given string is too long no errors are thrown, instead the trailing bit is cut off.
        /// </summary>
        /// <param name="str">The string to insert.</param>
        /// <param name="slate">The target string to insert into.</param>
        /// <param name="pad">The number of characters to pad from the left.</param>
        /// <returns>A new string with the input string inserted at the specified position.</returns>
        public static string InsertIntoStringWithPadLeft(this string str, string slate, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[..howMuchRemove];


            var slateSB = new StringBuilder(slate);
            slateSB.Remove(pad, howMuchRemove);
            slateSB.Insert(pad, strLimited);

            return slateSB.ToString();
        }

        /// <summary>
        /// Inserts the given string into another string with padding on the right. <br></br>If the given string is too long no errors are thrown, instead the trailing bit is cut off.
        /// </summary>
        /// <param name="str">The string to insert.</param>
        /// <param name="slate">The target string to insert into.</param>
        /// <param name="pad">The number of characters to pad from the right.</param>
        /// <returns>A new string with the input string inserted at the specified position.</returns>
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

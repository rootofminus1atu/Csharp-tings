using System.Text.RegularExpressions;
using System.Linq;

namespace Lab11Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string numbr = "-123";
            Console.WriteLine(IsInteger(numbr));

            string susNum = "-.01";
            Console.WriteLine(IsDouble(susNum));


            string nastyNums = "-123  jk 1    .123 + 100.5";
            double[] betterNums = GetNums(nastyNums);

            foreach (double betterNum in betterNums)
                Console.WriteLine(betterNum);

        }

        public static bool IsInteger(string input)
        {
            Regex re = new Regex(@"^-?\d+$");

            if (re.IsMatch(input))
                return true;
            else
                return false;
        }

        public static bool IsDouble(string input)
        {
            Regex re = new Regex(@"^-?\d*\.?\d+$");

            if (re.IsMatch(input))
                return true;
            else
                return false;
        }

        
        public static double[] GetNums(string input)
        {
            var numbers = Regex.Matches(input, @"-?\d*\.?\d+").ToArray();
            double[] doubles = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
                doubles[i] = Convert.ToDouble(numbers[i].Value);  // value

            return doubles;
            /*
            double[] doubles = numbers.Select(double.Parse).ToArray();

            foreach (double num in doubles)
                Console.WriteLine(num);

            return doubles;
            */
        }
    }
}
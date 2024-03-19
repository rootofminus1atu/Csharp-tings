using NUnit.Framework;

namespace Q1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// Q1
        /// </summary>
        public static bool CanAccess(int age)
        {
            return age >= 18 && age <= 21 ? true : false;
        }

        /// <summary>
        /// Q2
        /// </summary>
        public static double ProductCost(string productDesc)
        {
            return productDesc switch
            {
                "ABC" => 10.1,
                "XYZ" => 69.34,
                "FR45" => 34,
                "S34" or "G65" or "F34" => 5,
                _ => -999
            };
        }

        /// <summary>
        /// Q3
        /// </summary>
        public static void AllTheNines(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 9;
            }
        }

        /// <summary>
        /// Q4
        /// </summary>
        public static int PassCounter(int[] arr)
        {
            return arr.Where(elem => elem > 40).Count();
        }

        /// <summary>
        /// Q5
        /// </summary>
        public static double GetBMI(double weight, double height)
        {
            return weight / Math.Pow(height, 2);
        }

        /// <summary>
        /// Q6 - sum of odd numbers between 2 given numbers, inclusive
        /// </summary>
        public static int Sum(int n1, int n2)
        {
            return Enumerable.Range(n1, n2 - n1 + 1).Where(n => n % 2 == 1).Sum();
        }

        public static double LawnmowerCost(int days)
        {
            if (days >= 5)
            {
                return days * 10;
            } else
            {
                int additionalDays = 5 - days;
                return days * 10 + additionalDays * 8;
            }
        }
    }

    [TestFixture]
    public class Tests2
    {
        [Test]
        public void SumTestAnother()
        {
            var _ = Program.Sum(2, 4);
            Assert.Pass();
        }
    }
}
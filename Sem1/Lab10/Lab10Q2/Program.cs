namespace Lab10Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // sum between 2 numbers, inclusive
            // recursion is so cool

            Console.WriteLine(SumBetween(1, 3));
        }

        public static int SumBetween(int n, int k)
        {
            int sum = 0;

            if (n > k)
                return SumBetween(k, n); 

            else
            {
                for (int i = n; i <= k; i++)
                    sum += i;

                return sum;
            }
        }

    }
}
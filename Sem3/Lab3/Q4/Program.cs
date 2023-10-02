namespace Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int, int)[] cases = { (1, 5), (2, 10), (10, 2), (8, 9), (9, 8), (6, 6), (-3, 3) };

            foreach (var (n1, n2) in cases )
            {
                Console.WriteLine($"Sum between {n1} and {n2} = {Sum(n1, n2)}");
            }
        }

        static int Sum(int n1, int n2)
        {
            if (n1 > n2)
                return Sum(n2, n1);

            int total = 0;

            for (int i = n1; i <= n2; i++)
            {
                if (i % 2 == 0)
                    total += i;
            }

            return total;
        }
    }
}
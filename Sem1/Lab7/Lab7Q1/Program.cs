namespace Lab7Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sum of 20 first natural numbers, aka 1 + 2 + ... + 20

            int length = 20;
            int sum = 0;

            for (int i = 1; i <= length; i++)
            {
                sum += i;
                Console.WriteLine(sum);
            }

            Console.WriteLine($"Look at the sum: {sum}");

        }
    }
}
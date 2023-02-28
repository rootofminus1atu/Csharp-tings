namespace Lab10Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // calculate the average of n numbers

            Console.WriteLine(Average(2, 4, 6, 8));
            Console.WriteLine(Average2(2, 4, 6, 8));

        }

        public static double Average(params double[] nums) // foreach loop
        {
            double total = 0;

            foreach (double num in nums)
                total += num;

            return total/ nums.Length;
        }

        public static double Average2(params double[] nums) // for loop
        {
            double total = 0;

            for (int i = 0; i < nums.Length; i++)
                total += nums[i];

            return total / nums.Length;
        }

    }
}
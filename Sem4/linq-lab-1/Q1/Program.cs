namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };

            var outputNumbers = from number in numbers
                                where number > 5
                                orderby numbers
                                select number;

            foreach (var number in outputNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
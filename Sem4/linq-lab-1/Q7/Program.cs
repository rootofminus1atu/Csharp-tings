namespace Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8, };

            var query1 = from number in numbers
                         orderby number descending
                         select number;

            var query2 = from number in query1
                         where number < 8
                         select number;

            var query3 = from number in query2
                          select DoubleIt(number);

            // var query4 = numbers.OrderByDescending(n => n);
            // var query5 = query4.Where(n => n < 8);
            // var query6 = query5.Select(n => DoubleIt(n));

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        private static int DoubleIt(int value)
        {
            Console.WriteLine($"About to double the number {value}");
            return value * 2;
        }
    }
}
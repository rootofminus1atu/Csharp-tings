namespace Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] filmReviews =
            {
                new int[] { 3, 4 },
                new int[] { 1, 2, 1, 3 },
                new int[] { 5, 4, 2 }
            };

            for (int i = 0; i <  filmReviews.Length; i++)
            {
                int[] ratings = filmReviews[i];

                double average = ratings.Average();

                Console.WriteLine($"Average rating for movie no.{i + 1} is {average:0.##}");
            }
        }
    }
}
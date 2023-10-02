namespace Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a 2D array which has movie ratings for 3 films.
            // Each film has 3 reviews.  Output the average rating for each film.
            int[,] filmReviews =
            {
                { 3, 4, 5 },
                { 1, 2, 1 },
                { 5, 4, 2 }
            };

            for (int i = 0; i <  filmReviews.GetLength(0); i++)
            {
                int total = 0;
                int howManyReviews = filmReviews.GetLength(1);

                for (int j = 0; j <  howManyReviews; j++)
                {
                    total += filmReviews[i, j];
                }

                double average = (double)total / (double)howManyReviews;

                Console.WriteLine($"Average rating for film no.{i + 1} is {average:0.##}");
            }
        }
    }
}
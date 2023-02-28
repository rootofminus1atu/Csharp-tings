namespace Lab7Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //how much is your car worth after n years

            double carVal = 1000;
            const double PERCENTER = 0.8;
            int years = 10;

            for (int i = 0; i < years; i++)
            {
                carVal = carVal * PERCENTER;
                Console.WriteLine($"Year {i+1}: {carVal:.###}");
            }
        }
    }
}
namespace Lab14Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a concert analyzer 

            Concert concert = new Concert("dude", 99, 100, 25);

            Console.WriteLine(concert.GetPriceClassification());
            Console.WriteLine(concert.GetPercentageSeatsSold());
            Console.WriteLine(concert.ToString());
        }
    }

    
}
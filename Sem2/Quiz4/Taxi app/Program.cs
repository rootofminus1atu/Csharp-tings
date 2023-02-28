namespace Taxi_app
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // an app that calculates taxi fares based on the distance traveled and the amount of cases

            Console.Write("Input the distance: ");
            int dist = int.Parse(Console.ReadLine());

            Console.Write("Input the number of cases: ");
            int cases = int.Parse(Console.ReadLine());

            Console.WriteLine($"You have to pay {CalcFare(dist, cases):c}");
        }

        static double CalcFare(int distance, int cases)
        {
            const double MIN_FARE = 2;
            const double MIN_DIST = 1000;
            const double COST_PER_METER = 0.02;
            double fare;

            if (distance <= MIN_DIST)
                fare = MIN_FARE;
            else
                fare = MIN_FARE + COST_PER_METER * (distance - MIN_DIST);

            if (cases > 1)
                fare += cases - 1;

            return fare;
        }
    }
}
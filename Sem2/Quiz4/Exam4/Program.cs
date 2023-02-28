namespace Exam4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // testing and debugging

            double value = 10000;
            int age = 20;
            int penaltyPoints = 4;
            int yearsNoClaim = -1;

            double premium = CalcPremium(value, age, penaltyPoints, yearsNoClaim);
            Console.WriteLine(premium);
        }

        static double CalcPremium(double value, int age, int penalty, int years)
        {
            const double PPRICE = 110;
            double premium = 0.03 * value;

            if (age < 18)
                return -1;
            else if (age >= 18 && age <= 25)
                premium = premium * 1.1;

            Console.WriteLine(premium);

            if (penalty == 0)
                premium = premium;
            else if (penalty >= 1 && penalty <= 4)
                premium += PPRICE;
            else if (penalty >= 5 && penalty <= 7)
                premium += 2 * PPRICE;
            else if (penalty >= 8 && penalty <= 10)
                premium += 3 * PPRICE;
            else if (penalty >= 11 && penalty <= 12)
                premium += 4 * PPRICE;
            else
                return -1;

            Console.WriteLine(premium);

            if (years >= 0 && years <= 5)
                premium = premium - (0.05 * years * premium);
            else if (years > 5)
                premium = premium - (0.25 * premium);
            else
                return -1;

            Console.WriteLine(premium);

            return premium;
        }
    }
}
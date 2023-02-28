namespace Car_insurance_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a menu driven app that calculates insurance costs and displays statistics

            int choice = 0;
            int amountBelow1k = 0, amountAbove1k = 0;

            while (choice != 3)
            {
                DisplayMenu();
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("\nEnter Vehicle value: ");
                    double value = double.Parse(Console.ReadLine());

                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Enter penalty points: ");
                    int penaltyPoints = int.Parse(Console.ReadLine());

                    Console.Write("Enter years with no Claims: ");
                    int yearsNoClaim = int.Parse(Console.ReadLine());



                    double premium = CalcPremium(value, age, penaltyPoints, yearsNoClaim);



                    if (premium == -1)
                        Console.WriteLine("NO QUOTE POSSIBLE\n");
                    else
                    {
                        Console.WriteLine($"Your Premium quote is: {premium}\n");
                        if (premium < 1000)
                            amountBelow1k++;
                        else
                            amountAbove1k++;
                    }
                }

                else if (choice == 2)
                {
                    Console.WriteLine($"\n{"Cost", -15} Number of Quotes");
                    Console.WriteLine($"{"<1000",-15} {amountBelow1k}");
                    Console.WriteLine($"{"+1000",-15} {amountAbove1k}\n");
                }

                else if (choice != 1 && choice != 2 && choice != 3)
                {
                    Console.WriteLine("\nThis isn't a valid menu option\n");
                }
            }

        }

        static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Calculate Quote");
            Console.WriteLine("2. Print Statistics");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");
        }

        static double CalcPremium(double value, int age, int penalty, int years)
        {
            const double PPRICE = 110;
            double premium = 0.03 * value;

            if (age < 18)
                return -1;
            else if (age >= 18 && age <= 25)
                premium = premium * 1.1;

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

            if (years >= 0 && years <= 5)
                premium = premium - (0.05 * years * premium);
            else if (years > 5)
                premium = premium - (0.25 * premium);
            else
                return -1;

            return premium;
        }
    }
}
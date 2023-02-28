namespace Quiz3again
{
    internal class Program
    {
        const int k1 = -55;  // the indent
        const int k2 = -34;  // the other indent

        const double MIN_FEE = 15;
        const double HOURLY_FEE = 7;
        const double MAX_FEE = 45;
        const double DISCOUNT = 0.85;

        static void Main(string[] args)
        {
            // a program to calculate how much you have to pay on a tennis court

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double hours;
            string membership;

            List<double> charge = new List<double>() { };   // yeah lists are way better for this problem
            List<double> receipt = new List<double>() { };  // dealing with arrays here was painful



            Console.WriteLine("Tennis Court Cost Charges per Visit");
            Console.WriteLine(StringMult("=", 35));



            for (int i = 0; i > -1; i++)
            {
                hours = 0;        // to reset hour info
                while (hours <= 0 && hours != -99)
                {
                    Console.Write($"{"Enter the number of hours on court or -99 to quit >>",k1}");
                    hours = double.Parse(Console.ReadLine());
                }

                if (hours == -99)  // I have to include it here, so that I could exit the loop before asking for membership
                    break;         // better not use breaks/continues in the future

                membership = "O";  // to reset membership info
                while (membership != "Y" && membership != "N")
                {
                    Console.Write($"{"Are you a member? (Y/N) >>",k1}");
                    membership = Console.ReadLine().ToUpper();
                }



                charge.Add(CalculateCharge(hours));

                if (membership == "N")
                    receipt.Add(charge[i]);
                else
                    receipt.Add(charge[i] * DISCOUNT);



                Console.WriteLine($"{"Customer charge",k2}:     {charge[i]:c}");
                Console.WriteLine($"{"Customer receipt",k2}:     {receipt[i]:c}\n");
            }

            Console.WriteLine($"{"Total receipt cost",k2}:     {ListSum(receipt):c}");
            Console.WriteLine($"{"Average receipt cost",k2}:     {ListAverage(receipt):c}");
        }

        static string StringMult(string thing, int n)
        {
            string line = "";

            for (int i = 0; i < n; i++)
                line += thing;

            return line;
        }

        static double CalculateCharge(double hours)
        {
            if (hours <= 3)
                return MIN_FEE;

            else if (hours > 3 && hours <= 7)
                return MIN_FEE + Math.Ceiling(hours - 3) * HOURLY_FEE;

            else
                return MAX_FEE;
        }

        static double ListSum(List<double> list)
        {
            double sum = 0;

            foreach (double num in list)
                sum += num;

            return sum;
        }

        static double ListAverage(List<double> list)
        {
            if (list.Count == 0)
                return 0;
            else
                return ListSum(list) / list.Count;
        }
    }
}
namespace Quiz2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // how much a lawn job costs

            const int k1 = -40; // the 1st indent, so that everything would be aligned

            Console.Write($"{"Enter customer name", k1}: ");
            string name = Console.ReadLine();

            Console.Write($"{"Enter number of lawns",k1}: ");
            int lawnsNumber = int.Parse(Console.ReadLine());

            Console.Write($"{"Enter size of lawns in square meters",k1}: ");
            double lawnsSize = double.Parse(Console.ReadLine());

            Console.Write($"{"Enter cost per 50 liters of fertilizer",k1}: ");
            double fertCost = double.Parse(Console.ReadLine());

            Console.Write($"{"Enter cost per bag of seed",k1}: ");
            double seedCost = double.Parse(Console.ReadLine());

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double fertCostTotal;
            double fertCostTotalVat;
            double seedCostTotal;
            double seedCostTotalVat;
            double allLawnCost;
            double laborCostTotal;
            double laborCostTotalVat;
            double allLaborCost;
            double jobCost;

            double discount;
            double discountAmount;
            string star = "";

            double fertLiters;
            double fertGallons;

            const double LAWN_REQ = 25;   // 25 square meters

            const double LABOR_COST = 25;

            const double PRODUCTS_VAT = 0.2;
            const double LABOR_VAT = 0.15;

            const double FERT_VOLUME = 50;
            const double L_TO_G = 0.2199;
            const double EUR_TO_STER = 0.85;

            double amountOfReqs = ((lawnsNumber * lawnsSize) / LAWN_REQ);  // amount of 25sqm areas



            // 2nd big display row

            fertCostTotal = amountOfReqs * fertCost;
            fertCostTotalVat = fertCostTotal * PRODUCTS_VAT; 

            seedCostTotal = amountOfReqs * 2 * seedCost;
            seedCostTotalVat = seedCostTotal * PRODUCTS_VAT;

            allLawnCost = fertCostTotal + fertCostTotalVat + seedCostTotal + seedCostTotalVat;



            // 3rd big display row

            laborCostTotal = amountOfReqs * 5 * LABOR_COST;
            laborCostTotalVat = laborCostTotal * LABOR_VAT;

            allLaborCost = laborCostTotal + laborCostTotalVat;



            // 4th big display row

            jobCost = allLawnCost + allLaborCost;

            if (jobCost < 1000)
                discount = 0;

            else if (jobCost < 5000)
                discount = 0.05;

            else
                discount = 0.08;

            discountAmount = jobCost * discount;

            if (discountAmount > 100)
                star += "*";



            // 5th big display row

            fertLiters = amountOfReqs * FERT_VOLUME;
            fertGallons = fertLiters * L_TO_G;



            const int k2 = -35;  // the 2nd indent

            Console.WriteLine("\n\nMurphy Bros Garden Centre");
            Console.WriteLine("       Job Quote");

            Console.WriteLine(StringMult("=", 25));  // a function that writes 25 strings

            Console.WriteLine($"{"Customer name",k2}: {name}\n");
            Console.WriteLine($"{"Total number of lawns", k2}: {lawnsNumber}");
            Console.WriteLine($"{"Cost of 50 liters of fertilizer", k2}: {fertCost:c2}");
            Console.WriteLine($"{"Cost of oe 25kg bag of seeds",k2}: {seedCost:c2}");

            Console.WriteLine(StringMult("-", 60));

            Console.WriteLine($"{"Cost of fertilizer",k2}: {fertCostTotal:c2}");
            Console.WriteLine($"{"Fertilizer VAT",k2}: {fertCostTotalVat:c2}");
            Console.WriteLine($"{"Cost of seed",k2}: {seedCostTotal:c2}");
            Console.WriteLine($"{"Seed VAT",k2}: {seedCostTotalVat:c2}");
            Console.WriteLine($"{"Total cost of lawn",k2}: {allLawnCost :c2}");

            Console.WriteLine(StringMult("-", 60));

            Console.WriteLine($"{"Labor hourly cost",k2}: {LABOR_COST:c2}");
            Console.WriteLine($"{"Labor cost",k2}: {laborCostTotal:c2}");
            Console.WriteLine($"{"Labor VAT",k2}: {laborCostTotalVat:c2}");
            Console.WriteLine($"{"Total labor cost",k2}: {allLaborCost:c2}");

            Console.WriteLine(StringMult("-", 60));

            Console.WriteLine($"{"Total cost of job",k2}: {jobCost:c2}");
            Console.WriteLine($"\n{"Discount rate",k2}: {discount:p2}");
            Console.WriteLine($"{"Discount amount",k2}: {discountAmount:c2}{star}\n");
            Console.WriteLine($"{"Nett Cost",k2}: {jobCost - discountAmount:c2}");

            Console.WriteLine(StringMult("-", 60));

            Console.WriteLine($"{"UK Figures",k2}");
            Console.WriteLine($"{"Total number of gallons",k2}: {fertGallons:.###}");

            Console.WriteLine($"{"Net Str Equivalent",k2}: {jobCost * EUR_TO_STER:.##} sterling");
        }

        public static string StringMult(string thing, int n)
        {
            string line = "";

            for (int i = 0; i < n; i++)
                line += thing;

            return line;
        }

    }
}
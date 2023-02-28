namespace Lab7Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i forgor what this app was about

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter hours worked: ");
            int hours = int.Parse(Console.ReadLine());

            const double H_Rate = 16;
            const double Over_Rate = 24;
            const double Tax_Rate = 0.2;
            const double EtoS_Rate = 0.9;
            const double Tax_Cutoff = 300;

            double taxMoney = 0;
            double taxOnWhat = 0;
            double sickPay;
            double totalPayTaxed;
            double totalPaySterling;



            double regPay = Math.Min(hours, 40) * H_Rate;
            double overPay = (Math.Max(hours, 40) - 40) * Over_Rate;
            double totalPay = regPay + overPay;

            if (totalPay > Tax_Cutoff)
            {
                taxOnWhat = totalPay - Tax_Cutoff;
                taxMoney = taxOnWhat * Tax_Rate;
            }


            totalPayTaxed = totalPay - taxMoney;
            totalPaySterling = totalPayTaxed * EtoS_Rate;


            if (totalPay < 200)
                sickPay = 203;

            else if (totalPay >= 200 && totalPay < 300)
                sickPay = 250;

            else if (totalPay >= 300 && totalPay < 400)
                sickPay = 300;

            else
                sickPay = 350;


            //generate --------------------------------------
            //why not
            string lineee = "";
            int howLong = 40;

            for (int i = 0; i < howLong; i++)
                lineee += "-";


            const int k = -25; //the indent

            Console.WriteLine($"\n\n\nPay Slip");
            Console.WriteLine($"=========");
            Console.WriteLine($"\n{"Employee name",k}: {name}");
            Console.WriteLine($"\n{"Total hours of labor",k}: {hours}");

            Console.WriteLine(lineee);

            Console.WriteLine($"{"Hourly Rate",k}: {H_Rate}");
            Console.WriteLine($"{"Regular Pay",k}: {regPay}");
            Console.WriteLine($"{"Overtime Pay",k}: {overPay}");

            Console.WriteLine(lineee);

            Console.WriteLine($"{"Total Gross pay",k}: {totalPay}\n");
            Console.WriteLine($"{$"Tax @{Tax_Rate:p0} on {taxOnWhat}",k}: {taxMoney}");

            Console.WriteLine(lineee);

            Console.WriteLine($"{"Total take home",k}: {totalPayTaxed}\n");
            Console.WriteLine($"{"Sterling equivalent",k}: {totalPaySterling}\n");

            Console.WriteLine(lineee);

            Console.WriteLine($"{"Sick payment would be",k}: {sickPay}");

        }
    }
}
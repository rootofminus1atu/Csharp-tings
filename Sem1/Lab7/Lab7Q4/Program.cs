namespace Lab7Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //how much you have to pay for a book and the delivery 

            double weight;
            double price = 0;
            string delivaryType, yesno;
            const double BASE_PRICE = 2.5;
            const double FEE1 = 0.025, FEE2 = 0.03, FEE3 = 0.05, FEE_EXTRA = 1.5;

            while (true)
            {
                Console.Write("Enter weight of book (in grams): ");
                weight = double.Parse(Console.ReadLine());

                Console.Write("Enter delivery (r = regular, x = express): ");
                delivaryType = Console.ReadLine();



                if (weight > 0 && weight <= 2000)
                    price = BASE_PRICE + weight * FEE1;


                if (weight > 2000 && weight <= 5000)
                    price = BASE_PRICE + 2000 * FEE1 + (weight - 2000) * FEE2;


                if (weight > 5000)
                    price = BASE_PRICE + 2000 * FEE1 + 3000 * FEE2 + (weight - 5000) * FEE3;


                if (delivaryType.ToLower() == "x")
                    price += FEE_EXTRA;



                Console.WriteLine($"You have to pay {price:.##} euro for {weight} grams");



                Console.Write("Calculate another (y/n): ");
                yesno = Console.ReadLine();

                if (yesno.ToLower() == "n")
                {
                    Console.WriteLine($"Goodbye\n");
                    break;
                }

                Console.WriteLine($"Ok!\n");

            }

        }
    }
}
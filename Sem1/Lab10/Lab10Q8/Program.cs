namespace Lab10Q8
{
    internal class Program
    {
        const int k1 = -8;  // indent for the menu
        static void Main(string[] args)
        {
            // unfinished business

            int key = ShowMenuAskForKey();
            int cost;

            while (key != 4)
            {
                key = ShowMenuAskForKey();

                if (key == 1)
                {
                    Console.WriteLine("Enter the cost of the item:");
                    cost = 

                }
                else if (key == 2)
                {
                    Console.WriteLine("hi");
                }
                else if (key == 3)
                {
                    Console.WriteLine("hi");
                }
                else
                {

                }
            }

            Console.WriteLine("Thanks for shopping!");
        }

        static int ShowMenuAskForKey()
        {
            Console.WriteLine("--- Sligo Shop App ---");
            Console.WriteLine($"{"Option",k1} Description");
            Console.WriteLine($"{"1.",k1} Buy Item");
            Console.WriteLine($"{"2.",k1} Apply Coupon");
            Console.WriteLine($"{"3.",k1} Calculate Bill");
            Console.WriteLine($"{"4.",k1} Exit");
            Console.Write("Please enter a code (1 - 4): ");
            return int.Parse(Console.ReadLine());
        }

        static double ArraySum(double[] arr)
        {
            double total = 0;

            for (int i = 0; i < arr.Length; i++)
                total += arr[i];

            return total;
        }
    }
}
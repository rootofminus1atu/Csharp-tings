namespace Method_overloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //add up all the prices from your shopping cart
            Console.WriteLine("How many items?");
            int n = int.Parse(Console.ReadLine());

            double[] shoppingList = new double[n];


            ReadArray(shoppingList);

            Console.WriteLine($"[{string.Join(", ", shoppingList)}]");
            Console.WriteLine($"You have to pay {ArraySum(shoppingList)} in total");



            //same thing, but with params
            double total = Checkout(2, 5, 6);

            Console.WriteLine(total);
        }

        public static void ReadArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Item number {i+1}: ");
                array[i] = double.Parse(Console.ReadLine());
            }
        }

        public static double ArraySum(double[] prices) // accepts 1 variable, an array //for loop
        {
            int howMany = prices.Length;
            double total = 0;

            for (int i = 0; i < howMany; i++)
                total += prices[i];

            return total;
        }

        public static double ArraySum2(double[] prices) // accepts 1 variable, an array //foreach loop
        {
            double total = 0;

            foreach (double element in prices )
                total += element;

            return total;
        }

        public static double Checkout(params double[] prices) //accepts an array number of variables
        {
            double total = 0;

            foreach (double price in prices)
                total += price;

            return total;
        }
    }
}
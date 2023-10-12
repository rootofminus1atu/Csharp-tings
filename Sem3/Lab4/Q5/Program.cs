namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * The store manager wants to know how much money and how many items have gone through all his cash registers today.
             * Make a copy of the CashRegister class and put it in a new project.  
             * Add two static variables, one to hold the total cash amount from all CashRegister objects 
             * the second to hold the total number of items from all CashRegister objects. 
             * Update the class as appropriate so these two new static variables are updated anytime any Cash Register handles an item. 
             * Output these total results.
             */

            CashRegister cashReg1 = new();
            CashRegister cashReg2 = new();

            double[] items1 = { 2.7, 3.45, 5.97 };
            double[] items2 = { 12.52, 1.43, 15.57, 5.15 };

            foreach (double item in items1)
            {
                cashReg1.AddItem(item);
                Console.WriteLine($"Adding an item worth {item} to Cash Register 1");
            }

            Console.WriteLine();

            foreach (double item in items2)
            {
                cashReg2.AddItem(item);
                Console.WriteLine($"Adding an item worth {item} to Cash Register 2");
            }

            Console.WriteLine($"\nCash Register 1 - {cashReg1.ToString()}");
            Console.WriteLine($"Cash Register 2 - {cashReg2.ToString()}");

            Console.WriteLine($"\nTotal Cash Amount from All Cash Registers: {CashRegister.TotalForAllRegisters:.##}");
            Console.WriteLine($"Total Number of Items from All Cash Registers: {CashRegister.NumOfItemsForAllRegisters}");
        }
    }

    public class CashRegister
    {
        public double Total { get; private set; } = 0;
        public int NumOfItems { get; private set; } = 0;
        public static double TotalForAllRegisters { get; private set; } = 0;
        public static int NumOfItemsForAllRegisters { get; private set; } = 0;

        public CashRegister() { }

        public void AddItem(double price)
        {
            Total += price;
            NumOfItems += 1;
            TotalForAllRegisters += price;
            NumOfItemsForAllRegisters += 1;
        }

        public override string ToString()
        {
            return $"Total: {Total:.##}, Number of Items: {NumOfItems}";
        }
    }
}
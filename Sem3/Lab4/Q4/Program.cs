namespace Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Create an application named TestCashRegister that instantiates and displays a CashRegister object. 
             * The CashRegister class contains a field for a total (a decimal) and a field for the number of items (an integer). 
             * The CashRegister class has a method called AddItem that takes in a price, adds it to the total and increments the number of items. 
             * The class should include properties with only a getter (no setter) to get a Cash Registers total cash price and number of items. 
             * Create several CashRegister objects, add a number of items to each and print out the total price and number of items per cash register.
             */

            CashRegister cashReg1 = new();
            CashRegister cashReg2 = new();

            double[] items1 = { 2.7, 3.45, 5.97 };
            double[] items2 = { 12.52, 1.43, 15.57, 5.16 };

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

            Console.WriteLine();
            Console.WriteLine($"Cash Register 1 - {cashReg1.ToString()}");
            Console.WriteLine($"Cash Register 2 - {cashReg2.ToString()}");
        }
    }

    public class CashRegister
    {
        public double Total { get; private set; } = 0;
        public int NumOfItems { get; private set; } = 0;
        
        public CashRegister() { }

        public void AddItem(double price)
        {
            Total += price;
            NumOfItems += 1;
        }

        public override string ToString()
        {
            return $"Total: {Total:.##}, Number of Items: {NumOfItems}";
        }
    }
}
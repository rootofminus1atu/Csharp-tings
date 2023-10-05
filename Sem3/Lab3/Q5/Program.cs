namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a method that accepts a stock-on-hand figure and a sales figure as int arguments.
            // It will update the stock-on-hand figure by deducting the sales figure if there is sufficient stock to fulfil the sale.
            // The method shall return true if the stock-on-hand figure has been updated, otherwise false.

            int stock = 100;

            StockLevelDisplay(stock);
            TakeFromStock(ref stock, 20);
            StockLevelDisplay(stock);
            TakeFromStock(ref stock, 50);
            StockLevelDisplay(stock);
            TakeFromStock(ref stock, 50);
            StockLevelDisplay(stock);
        }

        static void StockLevelDisplay(int stock)
        {
            Console.WriteLine($"Stock amount left: {stock}");
        }

        static void TakeFromStock(ref int stockOnHand, int sales)
        {
            if (sales > stockOnHand)
            {
                Console.WriteLine($"Not enough stock left (cannot take {sales} from {stockOnHand})");
                return;
            }

            stockOnHand -= sales;
            Console.WriteLine("Updated the stock");
        }
    }
}
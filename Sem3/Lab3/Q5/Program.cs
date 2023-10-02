namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
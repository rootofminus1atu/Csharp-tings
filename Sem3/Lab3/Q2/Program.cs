namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a method that uses a switch statement to return the cost of a product, where the method receives a product description as a string argument.

            string[] products = { "Jeans", "JACKET", "boots", "scarves", "Belts", "socks", "house" };

            foreach (string product in products)
            {
                Console.WriteLine($"Product {product} costs {ProductCost(product)} euro");
            }
        }

        static double ProductCost(string product)
        {
            switch (product.ToLower())
            {
                case "jeans":
                    return 67.99;
                case "jacket":
                    return 68.99;
                case "boots":
                    return 34.99;
                case "scarves" or "belts" or "socks":
                    return 10;
                default:
                    return -999;
            }

            return 0;
        }
    }
}
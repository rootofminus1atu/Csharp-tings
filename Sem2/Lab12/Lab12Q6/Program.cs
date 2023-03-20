namespace Lab12Q6
{
    internal class Program
    {

        public static Dictionary<string, string> choices = new Dictionary<string, string>()
        {
            ["h"] = "hi"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our shop");
            string choice = "";





            var date1 = new DateTime(2008, 5, 1);
            Console.WriteLine(date1);


            /* ideas
             https://dribbble.com/shots/18690883-Landing-Page-NFT-Cryptogame/attachments/13879616?mode=media
            
             
             */







            Product prod1 = new Product("oranges", 5, 10);
            Product prod2 = new Product("apples", 3, 10);
            Product prod3 = new Product("bananas", 4, 10);

            List<Product> products = new List<Product>() { prod1, prod2, prod3 };


            double price = products.CalcPrice();
            Console.WriteLine(price);












            while (choice != "4")
            {
                DisplayMenu();
                Console.Write(">");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("1st");

                }
                else if (choice == "2")
                {
                    Console.WriteLine("2nd");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("3rd");
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                    Console.WriteLine("Not a valid choice");
            }

            Console.WriteLine("Bye");

        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. Process sale transaction");
            Console.WriteLine("2. Restock product");
            Console.WriteLine("3. Print report");
            Console.WriteLine("4. Quit");
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public Product(string name, double price, int amount)
        {
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }

    static class ProductExtension
    {
        public static double CalcPrice(this Product[] products)
        {
            double price = 0;

            foreach (Product product in products)
            {
                price += product.Price * product.Amount;
            }

            return price;
        }

        public static double CalcPrice(this List<Product> products)
        {
            double price = 0;

            foreach (Product product in products)
            {
                price += product.Price * product.Amount;
            }

            return price;
        }
    }
}
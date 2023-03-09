namespace Lab12Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our shop");
            string choice = "";

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
                else
                    Console.WriteLine("what?");
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

    }
}
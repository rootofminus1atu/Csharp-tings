namespace CA5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pizza> pizzas = new List<Pizza>()
            {
                new Pizza("marinara", "tomatoes and other ingredients", 10),
                new Pizza("salami", "salamis cheese chorizo, out favorite", 20),
                new Pizza("hawaii", "from hawaii", 30)
            };



            double totalPrice = pizzas.TotalPrice();

            Console.WriteLine(totalPrice);


        }
    }



    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }


        public Pizza(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }



    public static class PizzaExtension
    {
        public static double TotalPrice(this List<Pizza> pizzas)
        {
            double total = 0;

            foreach (Pizza pizza in pizzas)
                total += pizza.Price;

            return total;
        }

        // another method that can be used on an structure of objects
    }
}
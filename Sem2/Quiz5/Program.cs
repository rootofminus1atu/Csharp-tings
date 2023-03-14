using System.Runtime.CompilerServices;

namespace Quiz5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pizza> pizzas = new List<Pizza>() { };

            pizzas.Add(new Pizza("tomato", "mushroom"));
            pizzas.Add(new Pizza("mayo", "mushroom"));
            pizzas.Add(new Pizza("tomato", "nutella"));

            Console.WriteLine(pizzas.CountMushrooms());  // shows 999 
            // isn't it awesome that you can call it like that instead of CountMushrooms(pizzas)
        }
    }

    public class Pizza
    {
        public string sauce;
        public string ingredient;

        public Pizza(string sauce, string ingredient)
        {
            this.sauce = sauce;
            this.ingredient = ingredient;
        }

    }

    public static class PizzaExtension
    {
        public static int CountMushrooms(this List<Pizza> pizzas)
        {
            // isn't this cursed? static method, this keyword, static class
            return 999;
        }
    }
}
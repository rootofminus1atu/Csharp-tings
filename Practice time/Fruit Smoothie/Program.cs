using System.Linq;

namespace Fruit_Smoothie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Smoothie bananah = new Smoothie(new string[] { "Banana" });

            bananah.ShowIngredients();
            Console.WriteLine(bananah.GetCost());
            Console.WriteLine(bananah.GetCost2());
            Console.WriteLine(bananah.GetPrice());
        }
    }

    public class Smoothie
    {
        static Dictionary<string, double> pricing = new Dictionary<string, double>
        {
            ["Strawberries"] = 1.5,
            ["Banana"] = 0.5,
            ["Mango"] = 2.5,
            ["Blueberries"] = 1,
            ["Raspberries"] = 1,
            ["Apple"] = 1.75,
            ["Pineapple"] = 3.5
        };

        public string[] ingredients { get; set; }

        public Smoothie(string[] ingredients)
        {
            this.ingredients = ingredients;
        }

        public double GetCost()
        {
            double total = 0;

            foreach (string ingredient in this.ingredients)
                total += pricing[ingredient];

            return total;
        }

        public double GetCost2()
        {
            return this.ingredients.Select(x => pricing[x]).Sum();
        }

        public double GetPrice()
        {
            return this.GetCost() * 2.5;
        }

        public void ShowIngredients()
        {
            foreach(string ingredient in this.ingredients)
                Console.WriteLine(ingredient);
        }
    }
}
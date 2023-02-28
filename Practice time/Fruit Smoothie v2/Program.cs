using System.Xml.Schema;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Security.Policy;

namespace Fruit_Smoothie_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ingredient rasp = new Ingredient("Raspberries", 1);
            Ingredient banah = new Ingredient("Bananas", 1.5);

            // legacy
            // Smoothie niceOne = new Smoothie(new Ingredient[] { rasp, banah });

            SmoothieBetter drink = new SmoothieBetter(rasp, banah);

            drink.ShowIngredients();

            Console.WriteLine(drink.Cost());
            Console.WriteLine(drink.Cost2());
            Console.WriteLine(drink.GetName());

        }
    }

    public class Ingredient
    {
        public string name { get; set; }
        public double price { get; set; }

        public Ingredient(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }

    public class Smoothie
    {
        public Ingredient[] ingredients { get; set; }

        public Smoothie(Ingredient[] ingredients)
        {
            this.ingredients = ingredients;
        }

        public void ShowIngredients()
        {
            foreach (Ingredient ingredient in this.ingredients)
                Console.WriteLine(ingredient.name);
        }

        public double GetCost()
        {
            double total = 0;

            foreach (Ingredient ingredient in this.ingredients)
                total += ingredient.price;

            return total;
        }

        public double GetCost2()
        {
            return this.ingredients.Select(x => x.price).Sum();
        }
    }

    
    public class SmoothieBetter
    {
        PluralizationService ps = PluralizationService.CreateService(CultureInfo.CurrentCulture);
        public Ingredient[] ingredients { get; set; }

        public SmoothieBetter(params Ingredient[] ingredients)
        {
            this.ingredients = new Ingredient[ingredients.Length];

            for (int i = 0; i < ingredients.Length; i++)
                this.ingredients[i] = ingredients[i];
        }

        public void ShowIngredients()
        {
            foreach (Ingredient ingredient in this.ingredients)
                Console.WriteLine(ingredient.name);
        }

        public string[] GetIngredients()
        {
            return this.ingredients.Select(x => x.name).ToArray();
        }

        public double Cost()
        {
            double total = 0;

            foreach (Ingredient ingredient in this.ingredients)
                total += ingredient.price;

            return total;
        }

        public double Cost2()
        {
            return this.ingredients.Select(x => x.price).Sum();
        }

        public string GetName()
        {
            string str = "";

            foreach (Ingredient ingredient in this.ingredients)
                str += ps.Singularize(ingredient.name) + " ";

            str += (ingredients.Length > 1 ? "Fusion" : "Smoothie");

            return str;
        }
    }
}
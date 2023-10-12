namespace Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create an application named LunchDemo that declares several Lunch objects and includes a display method 
             * to which you can pass different numbers of Lunch objects in successive method calls.  
             * This should use the params keyword. Not something we have seen so some research is needed.
             * The Lunch class contains auto-implemented properties for an entree, side dish, and drink.
             */

            Lunch l1 = new("Burger", "Fries", "Cola");
            Lunch l2 = new("Hot-dog", "Chips", "Lemonade");
            Lunch l3 = new("Pizza", "Salad", "Iced tea");
            Lunch l4 = new("Tuna sandwich", "Fruit cup", "Water");
            Lunch l5 = new("Peanut butter sandwich", "Cookie", "Milk");

            Lunch.Display(l1, l2, l3);
            Console.WriteLine();
            Lunch.Display(l1, l2, l3, l4);
            Console.WriteLine();
            Lunch.Display(l1, l2, l3, l4, l5);
        }
    }

    public class Lunch
    {
        public string Entree { get; set; }
        public string Side { get; set; }
        public string Drink { get; set; }

        // the indents used for pretty display
        public const int i1 = -26;
        public const int i2 = -18;


        public Lunch(string entree, string side, string drink)
        {
            Entree = entree;
            Side = side;
            Drink = drink;
        }

        public static void Display(params Lunch[] lunches)
        {
            Console.WriteLine($"{"Entree", i1}{"Side",i2}{"Drink",0}");
            foreach (Lunch lunch in lunches)
            {
                Console.WriteLine(lunch.ToString());
            }
        }

        public override string ToString()
        {
            return $"{Entree,i1}{Side,i2}{Drink}";
        }
    }
}
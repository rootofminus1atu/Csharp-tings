namespace Q8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // cannot create Game objects anymore
            ComputerGame g1 = new("best game", 100, DateTime.Now, 8);
            Console.WriteLine(g1.ToString());
        }
    }

    public abstract class Game
    {
        public string Name { get; }
        protected double Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Game(string name, double price, DateTime releaseDate)
        {
            Name = name;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public Game(string name, double price) : this(name, price, DateTime.Now) { }

        public Game() : this("", 0) { }


        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Release date: {ReleaseDate}";
        }

        public abstract void UpdatePrice(double percentageIncrease);

    }

    public class ComputerGame : Game
    {
        public int PEGI { get; set; }

        public ComputerGame(string name, double price, DateTime releaseDate, int pegi) : base(name, price, releaseDate)
        {
            PEGI = pegi;
        }

        public ComputerGame(int pegi) : base()
        {
            PEGI = pegi;
        }


        public override string ToString()
        {
            return $"{base.ToString()}, PEGI: {PEGI}";
        }

        public double GetDiscountPrice()
        {
            return Price * 0.9;
        }

        public override void UpdatePrice(double percentageIncrease)
        {
            Console.WriteLine("Updating the price in the ComputerGame class");
            Price *= (1 + percentageIncrease);
        }
    }
}
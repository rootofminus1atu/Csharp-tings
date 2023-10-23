namespace Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game g1 = new Game("Game game", 999);
            Game g2 = new Game();
            ComputerGame g3 = new(12);
            ComputerGame g4 = new(16);

            DisplayGame(g1);
            DisplayGame(g2);
            DisplayGame(g3);
            DisplayGame(g4);

        }

        static void DisplayGame(Game game)
        {
            Console.WriteLine(game.ToString());
        }
    }

    public class Game
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

        public virtual void UpdatePrice(double percentageIncrease)
        {
            Price *= (1 + percentageIncrease);
        }

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
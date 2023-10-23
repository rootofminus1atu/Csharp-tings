namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerGame game = new ComputerGame("game", 89, DateTime.Now, 12);
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

    }

    public class ComputerGame : Game
    {
        public int PEGI { get; set; }

        public ComputerGame(string name, double price, DateTime releaseDate, int pegi) : base(name, price, releaseDate)
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
    }
}
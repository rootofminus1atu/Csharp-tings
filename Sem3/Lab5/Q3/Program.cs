namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game g1 = new Game("Monopoly", 19.99, new DateTime(1970, 01, 31));
            Game g2 = new Game() { Price = 10.99, ReleaseDate = new DateTime(2000, 6, 15) };
        }
    }

    public class Game
    {
        public string Name { get; }
        public double Price { get; set; }
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
}
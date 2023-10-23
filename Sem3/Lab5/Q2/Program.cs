namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

    }

    public class Game
    {
        public string Name { get; }  // I think this works for a readonly prop
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
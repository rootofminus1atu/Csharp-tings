namespace Alergies_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            


















            Console.WriteLine("Hello, World!");

            Allergy mary = new Allergy("Mary");

            Console.WriteLine(mary.name);
            Console.WriteLine(mary.score);
        }
    }

    public class Allergy
    {
        [Flags]
        public enum Allergen
        {
            Eggs = 1,
            Peanuts = 2,
            Shellfish = 4,
            Strawberries = 8,
            Tomatoes = 16,
            Chocolate = 32,
            Pollen = 64,
            Cats = 128
        }

        public string name { get; set; }
        public readonly int score;

        public Allergy(string name)
        {
            this.name = name;
            this.score = 0;
        }

        public Allergy(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public Allergy(string name, string allergies)
        {
            this.name = name;
            this.score = 0;
        }


    }
}
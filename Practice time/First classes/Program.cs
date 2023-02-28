using System.Xml.Linq;

namespace First_classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //naive approach
            Human human1 = new Human();

            human1.name = "Belzebub";
            human1.age = 2012;

            human1.Eat();


            //better and shorter approach (constructors)
            BetterHuman human3 = new BetterHuman("Rick", 65);

            human3.Eat();

            //they do the same thing in the end
        }
    }

    public class Human
    {
        public string name;
        public int age;

        public void Eat()
        {
            Console.WriteLine($"{name} is eating");
        }
    }

    public class BetterHuman
    {
        string name;
        int age;

        public BetterHuman(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Eat()
        {
            Console.WriteLine($"{name} is eating");
        }
    }
}
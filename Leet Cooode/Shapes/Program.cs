using System.Security.Cryptography.X509Certificates;

namespace Shapes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circ = new Circle(2, 4, 4);
            Console.WriteLine($"The radius is {circ.radius}, location: ({circ.x}, {circ.y})");
            circ.Info();
        }
    }

    public class Shape
    {
        public int x;
        public int y;

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Info()
        {
            Console.WriteLine($"{this.GetType().Name} object at: ({this.x}, {this.y})");
        }
    }

    public class Circle: Shape
    {
        public int radius;

        public Circle(int radius, int x, int y) : base(x, y)
        {
            this.radius = radius;
        }
        public void Info()
        {
            base.Info();
            Console.WriteLine($"The radius is {this.radius}");
        }
    }
}
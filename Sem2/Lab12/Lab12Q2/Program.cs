using System.Reflection;  // for GetType() and other similar things

namespace Lab12Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // shapes class, with inheritance
            // this works better than inheritance actually

            Circle circ = new Circle(2, -5, 4);
            circ.Info();

            Console.WriteLine("\n");

            Rectangle rect = new Rectangle(2, -5, 4, 3);
            rect.Info();
        }

        public class Location
        {
            public int x;
            public int y;

            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void Info()
            {
                Console.WriteLine($"{this.GetType().Name} object at ({this.x}, {this.y})");
                PropertyInfo[] properties = this.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string name = property.Name;
                    object value = property.GetValue(this);
                    Console.WriteLine($"{name} = {value}");
                }
            }
        }

        public class Circle : Location
        {
            public int radius { get; set; }

            public Circle(int x, int y, int radius) : base(x, y)
            {
                this.radius = radius;
            }

            public double Area()
            {
                return Math.PI * Math.Pow(radius, 2);
            }

            public double Perimeter()
            {
                return 2 * Math.PI * radius;
            }
        }

        public class Rectangle : Location
        {
            public int width { get; set; }
            public int height { get; set; }

            public Rectangle(int x, int y, int width, int height) : base(x, y)
            {
                this.width = width;
                this.height = height;
            }

            public double Area()
            {
                return width * height;
            }

            public double Perimeter()
            {
                return 2 * width + 2 * height;
            }
        }
    }
}
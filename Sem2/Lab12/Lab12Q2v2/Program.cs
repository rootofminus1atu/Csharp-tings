using System.Reflection;

namespace Lab12Q2v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // shapaes class with composition 
            // this doesn't work as well

            Circle circ = new Circle(new Location(2, 3), 5);

            circ.Info();

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

        public class Circle
        {
            public Location location { get; set; }
            public double radius { get; set; }

            public Circle(Location location, double radius)
            {
                this.location = location;
                this.radius = radius;
            }

            public void Info()
            {
                Console.WriteLine($"{this.GetType().Name} object at ({this.location.x}, {this.location.y})");

                PropertyInfo[] properties = this.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string name = property.Name;
                    object value = property.GetValue(this);
                    Console.WriteLine($"{name} = {value}");
                }
            }
        }

        public class Rectangle
        {
            public Location location { get; set; }
            public double width { get; set; }
            public double height { get; set; }

            public Rectangle(Location location, double width, double height)
            {
                this.location = location;
                this.width = width;
                this.height = height;
            }
        }
    }
}
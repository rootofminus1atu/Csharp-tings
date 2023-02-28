using System.Reflection.Metadata.Ecma335;

namespace Inherit_and_array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] garage = new Car[3];

            Car car1 = new Car("Mustang");
            Car car2 = new Car("Corv");
            Car car3 = new Car("Lambo");

            garage[0] = car1;
            garage[1] = car2;
            garage[2] = car3;


            // instead of writing all that we can write:

            Car[] garage2 = { new Car("Mustangeeee"), new Car("Corv"), new Car(":)") };




            foreach(Car car in garage)
                Console.WriteLine(car.model);

            for (int i = 0; i < garage2.Length; i++)
                Console.WriteLine(garage2[i].model);

            ChangeColor(car1, "silver");
            Console.WriteLine(car1.color);
        }

        public static void ChangeColor(Car car, string color)
        {
            car.color = color;
        }
    }

    abstract class Vehicle //abstract parent class yay!
    {
        public int speed = 0;
        public void Go()
        {
            Console.WriteLine($"This vehicle is moving!");
        }
    }

    class Car : Vehicle
    {
        public string model;
        public string color;
        public int maxSpeed = 500;

        public Car(string model)
        {
            this.model = model;
        }

        public Car(string model, string color)
        {
            this.model = model;
            this.color = color;
        }
    }
}
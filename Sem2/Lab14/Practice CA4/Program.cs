using System.IO.Pipes;

namespace Practice_CA4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Car
    {
        private static int counter = 0;

        private int _id;
        private int _tankSize;
        private double _fuelEfficiency;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int TankSize
        {
            get { return _tankSize; }
            set { _tankSize = value; }
        }
        public double FuelEfficiency
        {
            get { return _fuelEfficiency; }
            set { _fuelEfficiency = value; }
        }

        public Car()
        {
            _id = counter;

            counter++;
        }

        public Car(int id, int tankSize, double fuelEfficiency)
        {
            _id = id;
            _tankSize = tankSize;
            _fuelEfficiency = fuelEfficiency;

            counter++;
        }


    }
}
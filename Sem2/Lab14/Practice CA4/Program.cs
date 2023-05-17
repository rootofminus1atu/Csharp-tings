using System.Diagnostics.Metrics;
using System.IO.Pipes;
using System.Security.Cryptography;

namespace Practice_CA4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[4] 
            { 
                new Car(100, 3), 
                new HybridCar(100, 3, 40), 
                new Car(50, 3.5), 
                new HybridCar(200, 2.5, 100) 
            };

            foreach (Car car in cars)
                Console.WriteLine(car.ToString());
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
            _id = GetNextId();
        }

        public Car(int tankSize, double fuelEfficiency)
        {
            TankSize = tankSize;
            FuelEfficiency = fuelEfficiency;

            _id = GetNextId();
        }

        public virtual double CalcRange()
        {
            return TankSize * FuelEfficiency;
        }

        protected int GetNextId()
        {
            return counter++;
        }

        public override string ToString()
        {
            return $"Car #{Id}, Tank size: {TankSize}, Fuel efficiency: {FuelEfficiency}, Range: {CalcRange()}";
        }
    }

    public class HybridCar : Car
    {
        private int _batteryRange;

        public int BatteryRange
        {
            get { return _batteryRange; }
            set { _batteryRange = value; }
        }

        public HybridCar() : base()
        {

        }

        public HybridCar(int tankSize, double fuelEfficiency, int batteryRange) : base(tankSize, fuelEfficiency)
        {
            BatteryRange = batteryRange;
        }

        public override double CalcRange()
        {
            return base.CalcRange() + BatteryRange;
        }

        public override string ToString()
        {
            return $"{base.ToString()} (with Battery range: {BatteryRange})";
        }
    }
}
namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a Car class with the following properties - Make, Model, Current Speed, Engine Size. 
             * Use long hand properties, with private attributes and getters and setters. 
             * In the program.cs file make use of this class by creating two objects and displaying details on the cars. 
             */

            Car car1 = new Car("Ford", "Focus", 0, 1.6);
            Car car2 = new Car("Opel", "Astra", 0, 1.2);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());
        }
    }

    public class Car
    {
        private string _make;
        private string _model;
        private double _currentSpeed;
        private double _engineSize;

        public Car(string make, string model, double currentSpeed, double engineSize)
        {
            _make = make;
            _model = model;
            _currentSpeed = currentSpeed;
            _engineSize = engineSize;
        }

        public string Make
        {
            get => _make;
            set => _make = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public double CurrentSpeed
        {
            get => _currentSpeed;
            set => _currentSpeed = value;
        }

        public double EngineSize
        {
            get => _engineSize;
            set => _engineSize = value;
        }

        public override string ToString()
        {
            return $"The {_make} {_model}, engine size {_engineSize}, is currently traveling at {_currentSpeed} km/h";
        }
    }
}
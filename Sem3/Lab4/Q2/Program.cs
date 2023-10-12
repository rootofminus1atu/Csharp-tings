namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Add the following methods to the car class
             * a. DisplayCarInfo – this should output the car information to the console
             * b. ToString – this should return a string which has car information which you should use in a Console.WriteLine statement
             * c.Accelerate – this should increase the speed by 10
             * Use a for loop to increase the car speed in increments of 10 up to 100.
             */

            Car car1 = new Car("Ford", "Focus", 0, 1.6);

            Console.WriteLine(car1.ToString());

            for (int i = 0; i < 10;  i++)
            {
                car1.Accelerate();
            }
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

        public void DisplayCarInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"Make: {Make}\nModel: {Model}\nCurrent Speed: {CurrentSpeed}\nEngine Size: {EngineSize}";
        }

        public void Accelerate()
        {
            CurrentSpeed += 10;
            Console.WriteLine($"Current speed is {CurrentSpeed}");
        }
    }
}
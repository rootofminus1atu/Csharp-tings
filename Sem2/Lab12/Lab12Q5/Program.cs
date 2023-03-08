namespace Lab12Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // employer class
            // also why private?

            Employee someone1 = new Employee("jeff", 18, 900, 90);
            Employee someone2 = new Employee("killer", 18, 900, 90);

            Console.WriteLine(someone1.ToString());
            Console.WriteLine(someone2.ToString());
            Console.WriteLine(Employee.empNum);

        }
    }

    public class Employee
    {
        public string Name;
        public int Age { get; private set; }
        public int HoursWorked;
        public double HourlyRate;

        private int Number;
        public static int empNum = 0;


        public Employee(string name, int age, int hoursWorked, double hourlyRate)
        {
            this.Name = name;

            if (age < 60)
                this.Age = age;
            else
                this.Age = 0;

            this.HoursWorked = hoursWorked;
            this.HourlyRate = hourlyRate;

            empNum++;
            this.Number = empNum;
        }

        public override string ToString()
        {
            return $"Employee #{this.Number}\nName: {this.Name}\nAge: {this.Age}\nHours worked: {this.HoursWorked}\nHourly rate: {this.HourlyRate}";
        }
    }

}
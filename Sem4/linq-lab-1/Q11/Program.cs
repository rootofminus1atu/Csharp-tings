namespace Q11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // and Q12

            var customers = Customer.GetCustomers()
                .Where(c => c.City.ToLower() == "dublin" || c.City.ToLower() == "galway")
                .OrderBy(c => c.Name);

            foreach (var c in customers)
            {
                Console.WriteLine(c);
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string City { get; set; }

        public Customer(string name, string city)
        {
            Name = name;
            City = city;
        }


        public static List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer("Tom", "Dublin"),
                new Customer("Sally", "Galway"),
                new Customer("George", "Cork"),
                new Customer("Molly", "Dublin"),
                new Customer("Joe", "Galway")
            };
        }
    }
}
using System.Text;

namespace Q9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*	
            A program is required to read the sales data of a number of stores that is stored in a comma delimited file sales.txt.  
            The program shall produce a report with the content and format outlined below.  
            The performance description will be determined from the table below

            Total_sales	Performance 
            <1000	“Needs attention”
            1000-1999	“Moderate”
            >2000	“Very good”

            The file has the following format: store_id, total_sales
            For example, the file with the following data will result in the report below. 
            You will have to make a test file in notepad with this data.
            */

            string filePath = @"../../../sales2.txt";
            Stores stores = Stores.ReadFromCsv(filePath);

            string report = stores.ProduceReport();
            Console.WriteLine(report);
        }
    }

    public class Store
    {
        public string Id { get; set; }
        public int Sales { get; set; }


        public Store(string id, int sales)
        {
            Id = id;
            Sales = sales;
        }

        public string GetPerformance() => Sales switch
        {
            var n when n < 1000 => "Needs attention",
            var n when n >= 1000 && n < 2000 => "Moderate",
            var n when n >= 2000 => "Very good",
            _ => "Invalid number of sales"

        };
    }

    public class Stores
    {
        public List<Store> StoreList { get; set; } = new();

        public int Total
        {
            get => StoreList.Select(s => s.Sales).Sum();
        }

        public double Average
        {
            get => StoreList.Select(s => s.Sales).Average();
        }


        private Stores() { }

        public static Stores ReadFromCsv(string filePath)
        {
            Stores stores = new();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                Store store = new(fields[0], int.Parse(fields[1]));

                stores.StoreList.Add(store);
            }

            return stores;
        }

        public string ProduceReport()
        {
            // the 3 indents used to align the data
            const int k1 = -20;
            const int k2 = -14;
            const int k3 = -15;

            StringBuilder report = new();

            report.AppendLine("Sales Report\n");
            report.AppendLine($"{"Store ID",k1}{"Sales",k2}{"Performance",k3}\n");

            foreach (Store store in StoreList)
                report.AppendLine($"{store.Id,k1}{store.Sales.ToString("N0"),k2}{store.GetPerformance(),k3}");

            report.AppendLine();
            report.AppendLine($"Total Sales: {Total:N0}");
            report.AppendLine($"Average Sales: {Average:N0}");

            return report.ToString();
        }
    }
}
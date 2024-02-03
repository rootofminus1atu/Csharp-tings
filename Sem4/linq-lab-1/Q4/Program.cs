using System.IO;

namespace Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var files = new DirectoryInfo(@"c:\windows").GetFiles();

            var query = from item in files
                        where item.Length > 10000
                        orderby item.Length, item.Name
                        select new
                        {
                            item.Name,
                            item.Length,
                            item.CreationTime
                        };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} \t{item.Length} bytes, \t{item.CreationTime}");
            }
        }
    }
}
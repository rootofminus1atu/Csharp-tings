namespace Q8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // and Q9 and Q10

            string[] names = { "Mary", "Joseph", "Michael", "Margaret", "John" };

            var filteredNames = names
                .Where(n => n.Length > 4)
                .OrderBy(n => n)
                .Where(n => n.ToUpper().StartsWith("M"));

            // var filteredNames2 = from n in names
            //                      where n.Length > 4
            //                      orderby n
            //                      where n.ToUpper().StartsWith("M")
            //                      select n;

            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
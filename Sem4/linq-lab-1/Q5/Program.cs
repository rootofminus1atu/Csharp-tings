namespace Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var files = new DirectoryInfo(@"c:\windows").GetFiles();

            var query = files
                .Where(f => f.Length > 10000)
                .OrderByDescending(f => f.Length)
                .ThenByDescending(f => f.Name)
                .Select(f => new
                {
                    f.Name,
                    f.Length,
                    f.CreationTime,
                })
                .ToArray();

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name} \t{item.Length} bytes, \t{item.CreationTime}");
            }
        }
    }

    public class MyFileInfo
    {
        public string Name { get; set; }
        public long Length { get; set; }
        public DateTime CreationTime { get; set; }

        public MyFileInfo(string name, long length, DateTime creationTime)
        {
            Name = name;
            Length = length;
            CreationTime = creationTime;
        }

        public override string ToString()
        {
            return $"{Name,-50}{Length,8:F0} MB {CreationTime.ToShortDateString()}";
        }
    }
}
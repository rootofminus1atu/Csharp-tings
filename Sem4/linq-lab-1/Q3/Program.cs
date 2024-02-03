namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo[] files = new DirectoryInfo(@"c:\windows").GetFiles();

            MyFileInfo[] query = files
                .Where(f => f.Length > 10000)
                .OrderByDescending(f => f.Length)
                .ThenByDescending(f => f.Name)
                .Select(f => new MyFileInfo(f.Name, f.Length, f.CreationTime))
                .ToArray();

            foreach(var item in query)
            {
                Console.WriteLine(item);
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
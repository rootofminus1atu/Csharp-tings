namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this program shouldn't be run multiple times, since the apanded total would most likely be a number above 100
            // which isn't a valid percentage, and this program works by taking the numbers in the file as percentages (not sure if that was the goal)

            string filePath = @"../../../../results.txt";

            string[] lines = File.ReadAllLines(filePath);



            List<int> ints = new();

            foreach (string line in lines)
            {
                int percentage = int.Parse(line);

                int points = PointsFromPercentage(percentage);


                Console.WriteLine($"percentage {percentage} -> points {points}");

                ints.Add(points);
            }

            int total = ints.Sum();



            File.AppendAllText(filePath, $"{Environment.NewLine}The total is: {total}");
            Console.WriteLine($"Total apended to file: {total}");

        }

        static string GradeFromPercentage(int percentage) => percentage switch
        {
            var p when p >= 0 && p < 30 => "H8",
            var p when p >= 30 && p < 40 => "H7",
            var p when p >= 40 && p < 50 => "H6",
            var p when p >= 50 && p < 60 => "H5",
            var p when p >= 60 && p < 70 => "H4",
            var p when p >= 70 && p < 80 => "H3",
            var p when p >= 80 && p < 90 => "H2",
            var p when p >= 90 && p <= 100 => "H1",
            _ => "Invalid percentage"
        };

        static int PointsFromGrade(string grade)
        {
            switch (grade)
            {
                case "H1":
                    return 100;
                case "H2":
                    return 88;
                case "H3":
                    return 77;
                case "H4":
                    return 66;
                case "H5":
                    return 56;
                case "H6":
                    return 46;
                case "H7":
                    return 37;
                case "H8":
                    return 0;
                default:
                    return 0;

            }
        }

        static int PointsFromPercentage(int percentage)
        {
            return PointsFromGrade(GradeFromPercentage(percentage));
        }

    }
}
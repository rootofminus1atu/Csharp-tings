namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"../../../../results.txt";

            string[] lines = File.ReadAllLines(filePath);



            int total = lines
                .Select(line => int.Parse(line))
                .Select(num => PointsFromPercentage(num))
                .Sum();

            Console.WriteLine(total);

        }

        static int PointsFromPercentage(int percentage)
        {
            int[] gradeBoundaries =
            {
                0,
                30,
                40,
                50,
                60,
                70,
                80,
                90,
            };

            Dictionary<string, int> gradeToPoints = new Dictionary<string, int>()
            {
                ["H8"] = 0,
                ["H7"] = 37,
                ["H6"] = 46,
                ["H5"] = 56,
                ["H4"] = 66,
                ["H3"] = 77,
                ["H2"] = 88,
                ["H1"] = 100
            };

            for (int i = 0; i < gradeBoundaries.Length; i++)
            {
                int lower = gradeBoundaries[i];
                int upper = i == gradeBoundaries.Length - 1 ? int.MaxValue : gradeBoundaries[i + 1];

                if (percentage >= lower && percentage < upper)
                {
                    string grade = $"H{gradeBoundaries.Length - i}";
                    int points = gradeToPoints[grade];

                    return points;
                }
            }

            return 0;
        }
    }
}
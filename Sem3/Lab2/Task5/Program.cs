using System.Net.Security;
using System.Text;

namespace Task5
{
    public class SubjectData
    {
        public string Subject { get; set; }
        public char Level { get; set; }
        public int Percentage { get; set; }

        public string Grade { get; set; }
        public int Points { get; set; }

        public SubjectData(string subject, char level, int percentage)
        {
            Subject = subject;
            Level = level;
            Percentage = percentage;
            Grade = CalculateGrade(level, percentage);
            Points = CalculatePoints(level, percentage);
        }

        private int CalculatePoints(char level, int percentage)
        {
            string grade = CalculateGrade(level, percentage);

            int points = CoolerPointsFromGrade(grade);

            return points;
        }

        private string CalculateGrade(char level, int percentage)
        {
            int gradeNum = GradeNumFromPercentage(percentage);
            string grade = level + gradeNum.ToString();

            return grade;
        }

        private int GradeNumFromPercentage(int percentage)
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

            for (int i = 0; i < gradeBoundaries.Length; i++)
            {
                int lower = gradeBoundaries[i];
                int upper = i == gradeBoundaries.Length - 1 ? int.MaxValue : gradeBoundaries[i + 1];

                if (percentage >= lower && percentage < upper)
                {
                    int grade = gradeBoundaries.Length - i;

                    return grade;
                }
            }

            return 8;  // H8 or O8 are the default lowest grades, so 8 is returned
        }

        private int CoolerPointsFromGrade(string grade)
        {
            Dictionary<int, int> HToPoints = new()
            {
                [8] = 0,
                [7] = 37,
                [6] = 46,
                [5] = 56,
                [4] = 66,
                [3] = 77,
                [2] = 88,
                [1] = 100
            };

            Dictionary<int, int> OToPoints = new()
            {
                [8] = 0,
                [7] = 0,
                [6] = 12,
                [5] = 20,
                [4] = 28,
                [3] = 37,
                [2] = 46,
                [1] = 56
            };

            Dictionary<char, Dictionary<int, int>> OHToDict = new()
            {
                ['H'] = HToPoints,
                ['O'] = OToPoints,
            };

            // those dicts could have better names

            char level = grade[0];
            int gradeNum = int.Parse(grade[1].ToString());

            // picks the right dict and uses it with gradeNum
            int points = OHToDict[level][gradeNum];

            return points;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../../report.txt";
            List<string> lines = new();
            int total = 0;

            

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your student number: ");
            string studentNum = Console.ReadLine();



            int maxSubjects = 7;
            for (int i = 0; i < maxSubjects; i++)
            {
                Console.Write("Enter subject: ");
                string subject = Console.ReadLine();

                Console.Write("Enter level (H or O):");
                char level = Console.ReadLine().ToUpper().ToCharArray()[0];  // todo: better conversion

                Console.Write("Enter percentage: ");
                int percentage = int.Parse(Console.ReadLine());



                string grade = CalculateGrade(level, percentage);
                int points = CalculatePoints(level, percentage);
                total += points;

                string line = $"Subject: {subject,-20}Level: {level,-8}Percentage: {percentage}%      Grade: {grade,-8}Points: {points,-8}";

                Console.WriteLine($"\n{line} ({i + 1}/{maxSubjects} done)\n");

                lines.Add(line);
            }


            // generating and writing the report

            string report = GenerateReport(lines, name, studentNum, total);

            Console.WriteLine(report);

            File.WriteAllText(filePath, report);

        }

        static string GenerateReport(List<string> lines, string name, string studentNum, int total)
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"Report for: {name}");
            report.AppendLine($"Student number: {studentNum}");
            report.AppendLine();

            foreach (string line in lines)
                report.AppendLine(line);

            report.AppendLine();
            report.AppendLine($"Total amount of points: {total}");

            return report.ToString();
        }

        static int CalculatePoints(char level,  int percentage)
        {
            string grade = CalculateGrade(level, percentage);

            int points = PointsFromGrade(grade);

            return points;
        }

        static string CalculateGrade(char level, int percentage)
        {
            int gradeNum = GradeNumFromPercentage(percentage);
            string grade = level + gradeNum.ToString();

            return grade;
        }

        static int GradeNumFromPercentage(int percentage)
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

            for (int i = 0; i < gradeBoundaries.Length; i++)
            {
                int lower = gradeBoundaries[i];
                int upper = i == gradeBoundaries.Length - 1 ? int.MaxValue : gradeBoundaries[i + 1];

                if (percentage >= lower && percentage < upper)
                {
                    int grade = gradeBoundaries.Length - i;

                    return grade;
                }
            }

            return 8;  // H8 or O8 are the default lowest grades, so 8 is returned
        }


        /// <summary>
        /// for example "H1", "O8" etc.
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        static int PointsFromGrade(string grade)
        {
            Dictionary<int, int> HToPoints = new()
            {
                [8] = 0,
                [7] = 37,
                [6] = 46,
                [5] = 56,
                [4] = 66,
                [3] = 77,
                [2] = 88,
                [1] = 100
            };

            Dictionary<int, int> OToPoints = new()
            {
                [8] = 0,
                [7] = 0,
                [6] = 12,
                [5] = 20,
                [4] = 28,
                [3] = 37,
                [2] = 46,
                [1] = 56
            };
           
            Dictionary<char, Dictionary<int, int>> OHToDict = new()
            {
                ['H'] = HToPoints,
                ['O'] = OToPoints,
            };

            // those dicts could have better names

            char level = grade[0];
            int gradeNum = int.Parse(grade[1].ToString());

            // picks the right dict and uses it with gradeNum
            int points = OHToDict[level][gradeNum];

            return points;
        }
    }
}
using System.Net.Security;

namespace Task5
{
    public class Data
    {
        public string Subject { get; set; }
        public char Level { get; set; }
        public int Percentage { get; set; }

        public string Grade { get; set; }
        public int Points { get; set; }

        public Data(string subject, char level, int percentage, string grade, int points)
        {
            Subject = subject;
            Level = level;
            Percentage = percentage;
            Grade = grade;
            Points = points;
        }
    }

    internal class Program
    {
        const int k = -20;  // indent


        static void Main(string[] args)
        {
            string name = "Joe";
            string studentNum = "s1";

            // for each
            string subject = "math";
            char level = 'H';
            int percentage = 91;




            List<string> lines = new();

            int maxSubjects = 7;

            for (int i = 0; i < maxSubjects; i++)
            {
                Console.Write("Enter subject name: ");
                subject = Console.ReadLine();

                Console.Write("Enter level (H or O):");
                level = Console.ReadLine().ToUpper().ToCharArray()[0];  // todo: better conversion

                Console.Write("Enter percentage: ");
                percentage = int.Parse(Console.ReadLine());



                string grade = CalculateGrade(level, percentage);
                int points = CalculatePoints(level, percentage);

                string line = $"Subject: {subject}\tlevel: {level}\tpercentage: {percentage}%\tgrade: {grade}\tpoints: {points}";
                Console.WriteLine(line);

                lines.Add(line);
            }

        }

        static int CalculatePoints(char level,  int percentage)
        {
            string grade = CalculateGrade(level, percentage);

            int points = CoolerPointsFromGrade(grade);

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
        static int CoolerPointsFromGrade(string grade)
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
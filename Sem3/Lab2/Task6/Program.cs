using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../../report.txt";

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your student number: ");
            string studentNumber = Console.ReadLine();



            Student student = new Student(name, studentNumber);



            int maxSubjects = 2;
            for (int i = 0; i < maxSubjects; i++)
            {
                Console.Write("Enter subject: ");
                string subjectName = Console.ReadLine();

                Console.Write("Enter level (H or O): ");
                char level = char.ToUpper(Console.ReadLine()[0]);

                Console.Write("Enter percentage: ");
                int percentage = int.Parse(Console.ReadLine());

                student.AddSubject(subjectName, level, percentage);
            }


            string report = student.GenerateReport();
            Console.WriteLine(report);

            File.WriteAllText(filePath, report);

        }
    }

    class Student
    {
        public string Name { get; set; }
        public string StudentNumber { get; set; }
        public List<Subject> Subjects { get; set; } = new();

        public Student(string name, string studentNumber) 
        {
            Name = name;
            StudentNumber = studentNumber;
        }

        public void AddSubject(string subjectName, char level, int percentage)
        {
            Subjects.Add(new Subject(subjectName, level, percentage));
        }

        public string GenerateReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Report for: {Name}");
            report.AppendLine($"Student number: {StudentNumber}");
            report.AppendLine();

            foreach (var subject in Subjects)
                report.AppendLine(subject.ToString());

            report.AppendLine();

            report.AppendLine($"Total amount of points: {GetTotal()}");

            return report.ToString();
        }

        public int GetTotal()
        {
            return Subjects
                .Select(s => s.Points)
                .Sum();
        }
    }

    class Subject
    {
        public string Name { get; set; }
        public char Level { get; set; }
        public int Percentage { get; set; }


        public Subject(string name, char level, int percentage)
        {
            Name = name;
            Level = level;
            Percentage = percentage;
        }

        public override string ToString()
        {
            return $"Subject: {Name,-20}Level: {Level,-8}Percentage: {Percentage}%      Grade: {Grade,-8}Points: {Points,-8}";
        }



        public int Points
        {
            get => CalculatePoints();
        }

        public string Grade
        {
            get => CalculateGrade();
        }

        private int CalculatePoints()
        {
            int points = PointsFromGrade(Grade);

            return points;
        }

        private string CalculateGrade()
        {
            int gradeNum = GradeNumFromPercentage(Percentage);
            string grade = Level + gradeNum.ToString();

            return grade;
        }



        private static int GradeNumFromPercentage(int percentage)
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
        private static int PointsFromGrade(string grade)
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
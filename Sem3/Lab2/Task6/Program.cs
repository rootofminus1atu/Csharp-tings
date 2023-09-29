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

            Student student = new(name, studentNumber);



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

    /// <summary>
    /// A class that contains the info for a Student's final exams results, ie. Name, StudentNumber and a List of Subjects
    /// </summary>
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

        /// <summary>
        /// Adds a Subject based on the subject Name, Level and Percentage to the Subjects List
        /// </summary>
        /// <param name="subjectName"></param>
        /// <param name="level"></param>
        /// <param name="percentage"></param>
        public void AddSubject(string subjectName, char level, int percentage)
        {
            Subjects.Add(new Subject(subjectName, level, percentage));
        }

        /// <summary>
        /// Generates a report based on the Student's info.
        /// <br></br>
        /// A report consists of the Name, StudentNumber, a list of formated Subjects, and additional data about it, for example the total amount of points
        /// </summary>
        /// <returns>The report as a string, that can then be displayed in the console, written to a file, etc.</returns>
        public string GenerateReport()
        {
            StringBuilder report = new();
            report.AppendLine($"Report for: {Name}");
            report.AppendLine($"Student number: {StudentNumber}");
            report.AppendLine();

            foreach (var subject in Subjects)
                report.AppendLine(subject.ToString());

            report.AppendLine();

            report.AppendLine($"Total amount of points: {GetTotal()}");

            return report.ToString();
        }

        /// <summary>
        /// Returns the total amount of points from the Subjects List
        /// </summary>
        /// <returns>The total amount of points from the Subjects List</returns>
        public int GetTotal()
        {
            return Subjects
                .Select(s => s.GetPoints())
                .Sum();
        }
    }

    /// <summary>
    /// A class that contains the info for each subject, ie. the subject Name, Level, Percentage, GetGrade() and GetPoints()
    /// </summary>
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
            return $"Subject: {Name, -20}Level: {Level, -8}Percentage: {Percentage}%      Grade: {GetGrade(), -8}Points: {GetPoints(), -8}";
        }

        /// <summary>
        /// Returns the points associated with a Subject 
        /// <br></br>
        /// For example Subject("Math", 'H', 97).GetPoints() returns 100
        /// </summary>
        /// <returns>The points associated with a Subject</returns>
        public int GetPoints()
        {
            int points = PointsFromGrade(GetGrade());

            return points;
        }

        /// <summary>
        /// Returns the grade associated with a Subject
        /// /// <br></br>
        /// For example Subject("Math", 'H', 97).GetGrade() returns H1
        /// </summary>
        /// <returns>The grade associated with a Subject</returns>
        public string GetGrade()
        {
            int gradeNum = GradeNumFromPercentage(Percentage);
            string grade = Level + gradeNum.ToString();

            return grade;
        }


        /// <summary>
        /// A helper function that converts a given percentage into a CAO grade (for example "H3", "O8" etc.)
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns>A CAO grade (for example "H3", "O8" etc.)</returns>
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
        /// A helper funciton that converts a given grade (for example "H3", "O8" etc.) into the correct number of points
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>The amount of CAO points</returns>
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

            Dictionary<char, Dictionary<int, int>> PointsDict = new()
            {
                ['H'] = HToPoints,
                ['O'] = OToPoints,
            };

            char level = grade[0];
            int gradeNum = int.Parse(grade[1].ToString());

            // picks the right dict and uses it with gradeNum
            int points = PointsDict[level][gradeNum];

            return points;
        }
    }
}
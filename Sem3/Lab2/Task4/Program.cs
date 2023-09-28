namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gradesArr = { "H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8" };

            int[] pointsArr = PointsArrayFromGradesArray(gradesArr);



            foreach (var (grade, points) in gradesArr.Zip(pointsArr))
            {
                Console.WriteLine($"Grade {grade} -> points {points}");
            }



        }

        static int[] PointsArrayFromGradesArray(string[] grades)
        {
            return grades
                .Select(grade => PointsFromGrade(grade))
                .ToArray();
        }

        static string GradeFromPercentage(int percentage)
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
                    string grade = $"H{gradeBoundaries.Length - i}";

                    return grade;
                }
            }

            return "H8";  // wish Option<T> was here
        }

        static int PointsFromGrade(string grade)
        {
            Dictionary<string, int> gradeToPoints = new()
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

            return gradeToPoints[grade];
        }

        static int PointsFromPercentage(int percentage)
        {
            return PointsFromGrade(GradeFromPercentage(percentage));
        }
    }
}
namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Use a switch statement which accepts a grade such as H1 and returns the points.
             */

            Console.Write("Input the grade you got (only higher): ");
            string grade = Console.ReadLine();

            int points = PointsFromGrade(grade);

            Console.WriteLine($"For {grade} you get {points} points");
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
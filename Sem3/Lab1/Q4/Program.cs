﻿namespace Q4
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Add a for loop which will repeat 7 times and ask for results in each of 7 subjects. 
             * Keep a tally of the total number of points and display this at the end.  
             * Normally Leaving Cert results are comprised of 6 subjects. 
             * Amend so that the lowest number of points are discarded.
             */

            List<int> pointsList = new();


            for (int i = 0; i < 2; i++)
            {
                Console.Write("Input percentage: ");
                int percentage = int.Parse(Console.ReadLine());

                Console.Write("Input higher (H) or ordinary (O) level: ");
                string choice = Console.ReadLine().ToUpper();


                int points = PointsFromPercentage(percentage, choice);
                pointsList.Add(points);

                Console.WriteLine($"For {percentage}% and {choice} level you get {points} points");
            }


            int minPoints = pointsList.Min();
            pointsList.Remove(minPoints);
            int total = pointsList.Sum();

            Console.WriteLine($"\nIn total you got {total} points (min value of {minPoints} points was discarded)");
        }

        static string GradeNumFromPercetage(int percentage) => percentage switch
        {
            var p when p >= 0 && p < 30 => "8",
            var p when p >= 30 && p < 40 => "7",
            var p when p >= 40 && p < 50 => "6",
            var p when p >= 50 && p < 60 => "5",
            var p when p >= 60 && p < 70 => "4",
            var p when p >= 70 && p < 80 => "3",
            var p when p >= 80 && p < 90 => "2",
            var p when p >= 90 && p <= 100 => "1",
            _ => "Invalid percentage"
        };

        static string GradeFromPercentage(int percentage, string higherOrOrdinary)
        {
            // higherOrOrdinary can only be H or O, I'd use an enum to control it better
            string output = higherOrOrdinary + GradeNumFromPercetage(percentage);
            return output;
        }






        static int PointsFromGradeHigher(string grade)
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

        static Dictionary<string, int> PointsFromGradeOrdinary = new Dictionary<string, int>()
        {
            ["O1"] = 56,
            ["O2"] = 46,
            ["O3"] = 37,
            ["O4"] = 28,
            ["O5"] = 20,
            ["O6"] = 12,
            ["O7"] = 0,
            ["O8"] = 0,
        };






        static int PointsFromPercentage(int percentage, string higherOrOrdinary)
        {
            // again higherOrOrdinary could be an enum
            string grade = GradeFromPercentage(percentage, higherOrOrdinary);

            if (higherOrOrdinary == "H")
            {
                return PointsFromGradeHigher(grade);
            }
            else if (higherOrOrdinary == "O")
            {
                return PointsFromGradeOrdinary[grade];
            }

            // if something went wrong
            return 0;
        }
    }
}
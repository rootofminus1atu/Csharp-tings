using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bonus
{
    // maybe using separate classes for marks percentages grades etc would be better

    public enum HO
    {
        H,
        O
    }

    internal class Mark
    {
        public int Percentage { get; set; }
        public HO HigherOrOrdinary { get; set; }
        public string Grade { get; set; }
        public int Points { get; set; }


        public Mark() { }

        public Mark(int percentage, HO higherOrOrdinary)
        {
            Percentage = percentage;
            HigherOrOrdinary = higherOrOrdinary;
            Grade = GetGrade(percentage, higherOrOrdinary);
            Points = GetScore(Grade);
        }

        private string GetGrade(int percentage, HO higherOrOrdinary) => higherOrOrdinary switch
        {
            HO.H => $"H{GetGradeNum(percentage)}",
            HO.O => $"O{GetGradeNum(percentage)}",
        };

        private string GetGradeNum(int percentage) => percentage switch
        {
            // I could use intervals in a dict instead
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

        private static Dictionary<string, int> HigherGradeToPoints = new()
        {
            ["H1"] = 100
        };

        private static Dictionary<string, int> OrdinaryGradeToPoints = new()
        {
            ["O1"] = 100
        };
        // yeah I feel like Grade could be its own class
        // 1 => (100 or 56)
        // 2 => (88 or 45) 
        // etc


        private HO HOFromGradeStr(string grade)
        {
            char letter = grade[0];
            // some validaiton

            return letter switch
            {
                'H' => HO.H,
                'O' => HO.O,
            };
            // maybe raise exception instead
        }

        private int GetScore(string grade) => HOFromGradeStr(grade) switch
        {
            HO.H => HigherGradeToPoints[grade],
            HO.O => OrdinaryGradeToPoints[grade],
        };



        public override string ToString()
        {
            return $"Percentage: {Percentage}\t Grade: {Grade}\t Points: {Points}";
        }
    }
}

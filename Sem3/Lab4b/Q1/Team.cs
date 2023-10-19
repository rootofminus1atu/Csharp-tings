using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public enum Result
    {
        Win,
        Draw,
        Lose
    }

    public class Team : IComparable<Team>
    {
        private const int i1 = -15;
        private const int i2 = -7;

        public string Name { get; private set; }
        public int Wins { get; private set; }
        public int Draws { get; private set; }
        public int Losses { get; private set; }
        public List<Player> Players { get; private set; } = new();

        public int Played
        {
            get => Wins + Draws + Losses;
        }
        public int Points
        {
            get => 3 * Wins + Draws;
        }

        public Team(string name)
        {
            Name = name;
        }

        public string DisplayTeamTable()
        {
            return $"{Name,i1}{Points,i2}{Wins,i2}{Draws,i2}{Losses,i2}{Played,i2}";
        }

        public static string GetHeader()
        {
            return $"{"NAME",i1}{"POINTS",i2}{"WINS",i2}{"DRAWS",i2}{"LOSSES",i2}{"PLAYED",i2}";
        }

        public string GetTeamSheet()
        {
            StringBuilder sheet = new();

            sheet.AppendLine($"{Name} Teamsheet");

            foreach (Player player in Players)
            {
                sheet.AppendLine(player.ToString());
            }

            return sheet.ToString();
        }

        public int AddResult(Result result) => result switch
        {
            Result.Win => Wins++,
            Result.Draw => Draws++,
            Result.Lose => Losses++,
            _ => 0
        };

        public int CompareTo(Team other)
        {
            return Points.CompareTo(other.Points);
        }
    }
}

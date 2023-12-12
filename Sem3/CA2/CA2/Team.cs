using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    internal class Team : IComparable<Team>
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public int Points => Players.Select(p => p.Points).Sum();

        public Team(string name, List<Player> players)
        {
            Name = name;
            Players = players;
        }

        public override string ToString()
        {
            return $"{Name} - {Points}";
        }

        public int CompareTo(Team? other)
        {
            return Points.CompareTo(other?.Points);
        }
    }
}

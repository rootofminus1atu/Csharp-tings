using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    /// <summary>
    /// Represents a sports team with a name and a list of players.
    /// </summary>
    internal class Team : IComparable<Team>
    {
        /// <summary>
        /// The name of the team.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of players in the team.
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// The total points scored by the team, which is the sum of points scored by its players.
        /// </summary>
        public int Points => Players.Select(p => p.Points).Sum();


        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class with the specified name and players.
        /// </summary>
        /// <param name="name">The name of the team.</param>
        /// <param name="players">The list of players in the team.</param>
        public Team(string name, List<Player> players)
        {
            Name = name;
            Players = players;
        }

        /// <summary>
        /// Returns a string representation of the team, including its name and total points.
        /// </summary>
        /// <returns>A string representing the team.</returns>
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

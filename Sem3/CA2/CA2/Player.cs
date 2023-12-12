using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    /// <summary>
    /// Represents a player in a sports team with a name, a result record (for example "WWDLLD"), and points.
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The result record of the player, indicating the outcomes of matches played. (for example "WWDLLD")
        /// </summary>
        public string ResultRecord { get; private set; }

        /// <summary>
        /// The total points scored by the player based on the result record.
        /// </summary>
        public int Points => ResultRecord.Select(PointMap).Sum();



        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified name and result record.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="resultRecord">The result record indicating the outcomes of matches played.</param>
        public Player(string name, string resultRecord)
        {
            Name = name;
            ResultRecord = resultRecord;
        }

        /// <summary>
        /// Returns a string representation of the player, including name, result record, and total points.
        /// </summary>
        /// <returns>A string representing the player.</returns>
        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {Points}";
        }

        /// <summary>
        /// Maps a character representing a match outcome (W, D, or L) to the corresponding points (3, 1, or 0).
        /// </summary>
        /// <param name="c">The character representing a match outcome (W, D, or L).</param>
        /// <returns>The points associated with the match outcome.</returns>
        private int PointMap(char c)
        {
            return c switch
            {
                'W' => 3,
                'D' => 1,
                'L' => 0,
                _ => 0
            };
        }


        /// <summary>
        /// Adds a new match result to the player's result record (W, D, or L).
        /// </summary>
        /// <param name="c">The character representing a match outcome (W, D, or L).</param>
        public void AddResult(char c)
        {
            ResultRecord = ResultRecord[1..] + c;
        }

        /// <summary>
        /// Calculates the star rating of the player (0, 1, 2, or 3 stars) based on the total points scored.
        /// </summary>
        /// <returns>The star rating of the player (1, 2, or 3 stars).</returns>
        public int CalculateStars()
        {
            return Points switch
            {
                int n when n >= 1 && n < 6 => 1,
                int n when n >= 6 && n < 11 => 2,
                int n when n >= 11 => 3,
                _ => 0
            };
        }
    }
}

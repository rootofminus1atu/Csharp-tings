using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    internal class Player
    {
        public string Name { get; set; }
        public string ResultRecord { get; set; }
        public int Points => ResultRecord.Select(PointMap).Sum();


        public Player(string name, string resultRecord)
        {
            Name = name;
            ResultRecord = resultRecord;
        }

        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {Points}";
        }

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

        public void AddResult(char c)
        {
            ResultRecord = ResultRecord[1..] + c;
        }
    }
}

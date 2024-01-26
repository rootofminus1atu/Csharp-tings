using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Album
    {
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public int Sales { get; set; }

        public int YearsSinceRelease => DateTime.Now.Year - Released.Year;

        private static readonly Random random = new Random();

        public Album(string name)
        {
            DateTime released = DateTime.Now.AddYears(-random.Next(1, 31));
            int sales = random.Next(10, 1000);

            Name = name;
            Released = released;
            Sales = sales;
        }

        public override string ToString()
        {
            return $"{Name} - {YearsSinceRelease} years since release, worth {Sales:c}";
        }
    }
}

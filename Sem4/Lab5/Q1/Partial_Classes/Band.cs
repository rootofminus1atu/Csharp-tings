using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public partial class Band
    {
        public string BandImagePath => $"/images/{BandImage}";
        public string Repr => ToString();

        public override string ToString()
        {
            return $"{Name} ({YearFormed})";
        }
    }
}

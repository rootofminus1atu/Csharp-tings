using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public partial class Album
    {
        public string AlbumImagePath => $"/images/{AlbumImage}";
        public string Repr => ToString();

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

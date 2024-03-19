using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_attempt
{
    /// <summary>
    /// Represents a thing to say, alongside a HotKey that it'd be associated with.
    /// </summary>
    public class ThingToSay
    {
        public string Text { get; set; }
        public string? HotKey { get; set; }

        public ThingToSay(string text, string? hotKey)
        {
            Text = text;
            HotKey = hotKey;
        }
    }
}

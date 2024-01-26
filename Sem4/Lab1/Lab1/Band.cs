using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    internal abstract class Band : IComparable<Band>
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public List<string> Members { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();

        public string MembersStr => string.Join(", ", Members);


        public Band(string bandName, int yearFormed, List<string> members, List<Album> albums)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            Members = members;
            Albums = albums;
        }

        public override string ToString()
        {
            return $"{BandName}";
        }

        public int CompareTo(Band? other)
        {
            return this.BandName.CompareTo(other?.BandName);
        }

        public string GenerateReport()
        {
            StringBuilder report = new();

            report.AppendLine($"Band: {BandName}");
            report.AppendLine($"Formed: {YearFormed}");
            report.AppendLine($"Members: {MembersStr}");
            report.AppendLine("Albums:");

            foreach (Album a in Albums)
            {
                report.AppendLine($"- {a.Name}, released in {a.Released.Year}, worth {a.Sales:c}");
            }

            return report.ToString();
        }
    }

    internal class RockBand : Band
    {
        public RockBand(string bandName, int yearFormed, List<string> members, List<Album> albums)
            : base(bandName, yearFormed, members, albums) { }

        public override string ToString()
        {
            return $"Rock band: {base.ToString()}";
        }
    }

    internal class PopBand : Band
    {
        public PopBand(string bandName, int yearFormed, List<string> members, List<Album> albums)
            : base(bandName, yearFormed, members, albums) { }

        public override string ToString()
        {
            return $"Pop band: {base.ToString()}";
        }
    }

    internal class IndieBand : Band
    {
        public IndieBand(string bandName, int yearFormed, List<string> members, List<Album> albums)
            : base(bandName, yearFormed, members, albums) { }

        public override string ToString()
        {
            return $"Indie band: {base.ToString()}";
        }
    }

    public static class EnumerableExtension
    {
        /// <summary>
        /// Returns a dev-friendly string representation of an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable.</typeparam>
        /// <param name="list">The enumerable to stringify.</param>
        /// <returns>A string representation of the enumerable.</returns>
        public static string Stringify<T>(this IEnumerable<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }

        /// <summary>
        /// Returns a dev-friendly string representation of an <see cref="IEnumerable{T}"/> with a given delimeter string.
        /// </summary>
        /// <typeparam name="T">The type of items in the enumerable.</typeparam>
        /// <param name="list">The enumerable to stringify.</param>
        /// <param name="delimeter">The delimter.</param>
        /// <returns>A string representation of the enumerable.</returns>
        public static string Stringify<T>(this IEnumerable<T> list, string delimeter)
        {
            return $"[ {string.Join(delimeter, list)} ]";
        }
    }
}

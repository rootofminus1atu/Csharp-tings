using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    public enum MemberType
    {
        Full,
        OffPeak,
        Student
    }


    internal class Member
    {
        public MemberType MemberType { get; set; }
        public string Name { get; set; }
        public DateOnly Date {  get; set; }


        public Member(MemberType memberType, string name, DateOnly date) 
        {
            MemberType = memberType;
            Name = name;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Name}, {MemberType}, {Date.Day}/{Date.Month}/{Date.Year}";
        }
    }
}

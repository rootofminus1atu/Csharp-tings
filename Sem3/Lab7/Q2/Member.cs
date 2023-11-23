using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    enum MemberType
    {
        Full,
        OffPeak,
        Student,
        OAP
    }

    internal class Member
    {
        MemberType MemberType { get; set; }
        public string Name { get; set; }
        public DateTime DateJoined { get; set; }


        public Member(MemberType memberType, string name, DateTime dateJoined)
        {
            MemberType = memberType;
            Name = name;
            DateJoined = dateJoined;
        }

        public override string ToString()
        {
            return $"{MemberType}, {Name}, {DateJoined.Day}/{DateJoined.Month}/{DateJoined.Year}";
        }
    }
}

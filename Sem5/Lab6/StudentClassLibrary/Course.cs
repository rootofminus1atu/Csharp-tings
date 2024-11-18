using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassLibrary
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Lecturer { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

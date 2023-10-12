namespace Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a program named SchoolsDemo that allows a user to enter data about five School objects 
             * and then displays the School objects.  
             * The School class contains properties for the School name and number of students enrolled.
             * 
             * Amend the program so that schools can be displayed in order or enrolment.  
             * We have not covered this yet so you may need to do some research yourself!  Hint – use IComparable.
             * 
             * Now add some code to this which asks the user for minimum enrolment to display.
             */

            List<School> schools = new();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter school name: ");
                string schoolName = Console.ReadLine();

                Console.Write("Enter enrollment: "); 
                int enrollment = int.Parse(Console.ReadLine());

                School newSchool = new(schoolName, enrollment);
                schools.Add(newSchool);
            }

            schools.Sort();

            Console.WriteLine("\nSorted schools:");
            schools.DisplayAll();



            Console.Write("\nEnter the minimum enrollment: ");
            int minEnrollment = int.Parse(Console.ReadLine());

            List<School> schoolsAboveMin = schools
                .Where(s => s.Enrollment >= minEnrollment)
                .ToList();

            Console.WriteLine($"\nSchools with more than {minEnrollment} students:");
            schoolsAboveMin.DisplayAll();
        }
    }

    public class School : IComparable<School>
    {
        public string Name { get; set; }
        public int Enrollment { get; set; }

        public School(string name, int enrollment)
        {
            Name = name;
            Enrollment = enrollment;
        }

        public override string ToString()
        {
            return $"{Name} school has {Enrollment} students";
        }

        public int CompareTo(School other)
        {
            return this.Enrollment.CompareTo(other.Enrollment);
        }
    }

    public static class SchoolExtension
    {
        public static void DisplayAll(this List<School> schools)
        {
            foreach (School school in schools)
            {
                Console.WriteLine(school.ToString());
            }
        }
    }
}
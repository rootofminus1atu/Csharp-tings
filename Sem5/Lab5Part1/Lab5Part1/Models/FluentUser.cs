namespace Lab5Part1.Models
{
    public class FluentUser
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public Title Title { get; set; }

        public string Biography { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}

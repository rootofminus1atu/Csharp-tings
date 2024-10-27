namespace RADLab3Solution.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public DateOnly PublicationDate { get; set; }
        public string? CoverPage { get; set; }

        public Author Author { get; set; }

        public Publisher Publisher { get; set; }


    }
}

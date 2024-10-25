using System.ComponentModel.DataAnnotations;

namespace Rad301_2024_Lab3_books.Models;

public class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Publication { get; set; }
    public int AuthorID { get; set; }
    public int PublisherID { get; set; }
    [DataType(DataType.Date)]
    public DateTime DateOfPublication { get; set; }
    public string CoverPageUrl { get; set; }
}


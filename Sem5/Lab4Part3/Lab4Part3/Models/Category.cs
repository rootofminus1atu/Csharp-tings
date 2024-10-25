using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab4Part3.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        // One-to-many relationship with Product
        public ICollection<Product> Products { get; set; }
    }
}

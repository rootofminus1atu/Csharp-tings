using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab4Part3.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        // Foreign Key for Category
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        // Many-to-many relationship with Supplier
        public ICollection<Supplier> Suppliers { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Lab4Part3.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        public string SupplierName { get; set; }

        public string SupplierAddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        // Many-to-many relationship with Product
        public ICollection<Product> Products { get; set; }
    }
}

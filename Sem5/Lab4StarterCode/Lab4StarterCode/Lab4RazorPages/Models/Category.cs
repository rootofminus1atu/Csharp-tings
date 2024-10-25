using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4RazorPages.Models;
public class Category
{
    public int ID { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}


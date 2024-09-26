using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ProductModel();



            // 6. Create code for the following queries

            // a) List all the Categories
            var sixA = db.Categories.ToList();

            // b) list all the products
            var sixB = db.Products.ToList();

            // c) list products with a quantity <= 100
            var sixcC= db.Products.Where(p => p.QuantityInStock <= 100).ToList();



            // 7. List Products with a Quantity > 120
            var sixD = db.Products.Where(p => p.QuantityInStock > 120).ToList();

            // a) List all the Products together with their total value
            var sevenA = db.Products
                .Select(p => new {
                    product = p,
                    totalValue = 0
                })
                .ToList();

            // b) List all the Products in the Hardware Category (use a join)
            var sevenBQuery = from p in db.Products
                              join c in db.Categories
                              on p.CategoryId equals c.Id
                              where c.Description == "Hardware"
                              select new
                              {
                                  p.Id,
                                  p.Description,
                                  p.QuantityInStock,
                                  p.UnitPrice,
                                  CategoryDescription = c.Description
                              };


            var sevenB = sevenBQuery.ToList();
            // Console.WriteLine(sevenB.ToDebugString());

            // List all the suppliers and their Parts ordered by supplier name (use a join)
            var sevenCQuery = from p in db.Products
                              join ps in db.SuppliersProducts on p.Id equals ps.ProductId
                              join s in db.Suppliers on ps.SupplierId equals s.Id
                              orderby s.SupplierName
                              select new
                              {
                                  supplier = s,
                                  product = p
                              };

            var sevenC = sevenCQuery.ToList();
            Console.WriteLine(sevenC.ToDebugString());

            Console.ReadKey();
        }
    }


    public class  Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }

    public class SupplierProduct
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateFirstSupplied { get; set; }
    }
    public class Supplier 
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }

    public class ProductModel
    {
        public List<Product> Products { get; } = new List<Product>()
        {
            new Product { Id = 1, Description = "9 Inch Nails", QuantityInStock = 200, UnitPrice = 0.1, CategoryId = 1 },
            new Product { Id = 2, Description = "9 Inch Bolts", QuantityInStock = 120, UnitPrice = 0.2, CategoryId = 1 },
            new Product { Id = 3, Description = "Chimney Hoover", QuantityInStock = 10, UnitPrice = 100.30, CategoryId = 2 },
            new Product { Id = 4, Description = "Washing Machine", QuantityInStock = 7, UnitPrice = 399.50, CategoryId = 2 },
        };
        public List<Supplier> Suppliers { get; } = new List<Supplier>()
        {
            new Supplier { Id = 1, SupplierName = "ACME", AddressLine1 = "Collooney", AddressLine2 = "Sligo" },
            new Supplier { Id = 2, SupplierName = "Swift Electric", AddressLine1 = "Finglas", AddressLine2 = "Dublin" },
        };

        public List<Category> Categories { get; } = new List<Category>()
        {
            new Category { Id = 1, Description = "Hardware" },
            new Category { Id = 2, Description = "Electrical Appliances" },
        };

        public List<SupplierProduct> SuppliersProducts { get; } = new List<SupplierProduct>()
        {
            new SupplierProduct { SupplierId = 1, ProductId = 1, DateFirstSupplied = new DateTime(2012, 12, 12) },
            new SupplierProduct { SupplierId = 1, ProductId = 2, DateFirstSupplied = new DateTime(2017, 8, 13) },
            new SupplierProduct { SupplierId = 2, ProductId = 3, DateFirstSupplied = new DateTime(2022, 9, 9) },
            new SupplierProduct { SupplierId = 2, ProductId = 4, DateFirstSupplied = new DateTime(2024, 4, 11) },
        };
    }

    public static class DebugExtensions
    {
        public static string ToDebugString(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}

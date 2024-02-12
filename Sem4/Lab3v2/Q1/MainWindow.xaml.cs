using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuery1_Click(object sender, RoutedEventArgs e)
        {
            var q = from c in db.Customers
                    select c.CompanyName;

            lbxEx1.ItemsSource = q.ToList();
        }

        private void btnEx2_Click(object sender, RoutedEventArgs e)
        {
            var q = from c in db.Customers
                    select c;

            dgEx2.ItemsSource = q.ToList();
        }

        private void btnEx3_Click(object sender, RoutedEventArgs e)
        {
            var q = from o in db.Orders
                    where o.Customer.City.Equals("London")
                    || o.Customer.City.Equals("Paris")
                    || o.Customer.Country.Equals("USA")
                    orderby o.Customer.CompanyName
                    select new
                    {
                        CustomerName = o.Customer.CompanyName,
                        City = o.Customer.City,
                        Address = o.ShipAddress
                    };

            dgEx3.ItemsSource = q.ToList().Distinct();
        }

        private void btnEx4_Click(object sender, RoutedEventArgs e)
        {
            var q = from p in db.Products
                    where p.Category.CategoryName.Equals("Beverages")
                    orderby p.ProductID descending
                    select new
                    {
                        p.ProductID,
                        p.ProductName,
                        p.Category.CategoryName,
                        p.UnitPrice
                    };

            dgEx4.ItemsSource = q.ToList();
        }

        private void btnEx5_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product()
            {
                ProductName = "Kickapoo Jungle Joy Juice",
                UnitPrice = 12.49m,
                CategoryID = 1,
            };

            db.Products.Add(p);
            db.SaveChanges();

            MessageBox.Show("Added! Displaying now...");

            ShowProducts(dgEx5);
        }


        private void ShowProducts(DataGrid dg)
        {
            var q = from p in db.Products
                    where p.Category.CategoryName.Equals("Beverages")
                    orderby p.ProductID descending
                    select new
                    {
                        p.ProductID,
                        p.ProductName,
                        p.Category.CategoryName,
                        p.UnitPrice
                    };

            dg.ItemsSource = q.ToList();
        }

        private void btnEx6_Click(object sender, RoutedEventArgs e)
        {
            Product p1 = db.Products
                .Where(p => p.ProductName.StartsWith("Kick"))
                .Select(p => p)
                .First();

            p1.UnitPrice = 100m;

            db.SaveChanges();
            ShowProducts(dgEx6);
        }

        private void btnEx7_Click(object sender, RoutedEventArgs e)
        {
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;

            foreach (var item in products)
            {
                item.UnitPrice = 100m;
            }

            db.SaveChanges();
            ShowProducts(dgEx7);
        }

        private void btnEx8_Click(object sender, RoutedEventArgs e)
        {
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;

            db.Products.RemoveRange(products);
            db.SaveChanges();
            ShowProducts(dgEx8);
        }

        private void btnEx9_Click(object sender, RoutedEventArgs e)
        {
            var q = db.Customers_By_City("London");

            dgEx9.ItemsSource = q.ToList();
        }
    }
}

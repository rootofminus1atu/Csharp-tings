using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    enum Category
    {
        Travel,
        Entertainment,
        Office
    }


    class Expense
    {
        public Category Category { get; set; }
        public double Cost { get; set; }
        public DateTime When { get; set; }


        public Expense(Category category, double cost, DateTime when)
        {
            Category = category;
            Cost = cost;
            When = when;
        }

        public override string ToString()
        {
            return $"{Category} €{Cost} on {When.Day}/{When.Month}/{When.Year}";
        }

        public static Expense RandomExpense()
        {
            Category randomCategory = GetRandomEnumValue<Category>();
            double randomCost = new Random().NextDouble() * (100 - 0.01) + 0.01;
            double randomCostRounded = Math.Round(randomCost, 2);

            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;
            DateTime randomDate = GetRandomDate(startDate, endDate);

            return new Expense(randomCategory, randomCostRounded, randomDate);
        }

        private static T GetRandomEnumValue<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();
            Random random = new Random();
            return enumValues.ElementAt(random.Next(enumValues.Count()));
        }


        private static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();
            int range = (endDate - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
    }
}

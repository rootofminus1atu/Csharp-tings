using NUnit.Framework;
using Q1;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCanAccessTrue()
        {
            int age = 19;

            bool result = Program.CanAccess(age);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestCanAccessFalse()
        {
            int age = 25;

            bool result = Program.CanAccess(age);

            Assert.IsFalse(result);
        }

        [Test]
        public void ProductCostFine()
        {
            string d1 = "ABC";
            string d2 = "XYZ";
            string d3 = "FR45";
            string d4 = "S34";
            string d5 = "G65";
            string d6 = "F34";

            Assert.AreEqual(10.1, Program.ProductCost(d1));
            Assert.AreEqual(69.34, Program.ProductCost(d2));
            Assert.AreEqual(34, Program.ProductCost(d3));
            Assert.AreEqual(5, Program.ProductCost(d4));
            Assert.AreEqual(5, Program.ProductCost(d5));
            Assert.AreEqual(5, Program.ProductCost(d6));
        }

        [Test]
        public void ProductCostNotFine()
        {
            string desc = "random thing";

            double res = Program.ProductCost(desc);

            Assert.AreEqual(-999, res);
        }

        [Test]
        public void AllTheNinesRandomArray()
        {
            int[] arr = { 1, 2, 3 };

            Program.AllTheNines(arr);

            Assert.That(arr, Is.All.EqualTo(9));
        }

        [Test]
        public void PassCounterRandomArray()
        {
            int[] arr = { 1, 41, 3, 900, 5 };

            int res = Program.PassCounter(arr);

            Assert.That(res, Is.EqualTo(2));
        }

        [Test]
        public void GetBMISimple()
        {
            double height = 2;
            double weight = 70;

            double res = Program.GetBMI(weight, height);

            Assert.That(res, Is.EqualTo(17.5));
        }

        [Test]
        public void SumSimple()
        {
            int res = Program.Sum(2, 5);

            Assert.That(res, Is.EqualTo(8));
        }

        [Test]
        public void SumEqualOdds()
        {
            int res = Program.Sum(3, 3);

            Assert.That(res, Is.EqualTo(3));
        }

        [Test]
        public void SumEqualEvens()
        {
            int res = Program.Sum(4, 4);

            Assert.That(res, Is.EqualTo(0));
        }

        [Test]
        public void SumDecreasingOrder()
        {
            TestDelegate testDelegate = () => Program.Sum(4, 1);

            Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
        }
    }
}
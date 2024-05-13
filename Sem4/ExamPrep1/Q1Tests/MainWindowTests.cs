using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void AddTest()
        {
            int n = 2;
            int m = 3;
            int expected = 5;

            var res = Movie.Add(n, m);

            Assert.AreEqual(expected, res);
        }
    }
}
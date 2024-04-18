using NUnit.Framework;
using q1;
using Moq;

namespace q1_tests
{
    [TestFixture]
    public class InsuranceServiceTests
    {
        private InsuranceService insuranceService;
        private Mock<IDiscountService> mockDiscountService;

        [SetUp]
        public void SetUp()
        {
            mockDiscountService = new Mock<IDiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.8);

            insuranceService = new InsuranceService(mockDiscountService.Object);
        }

        [Test]
        public void Insurance()
        {
            int age = 19;
            string location = "rural";
            double expected = 5;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void Insurance2()
        {
            // location 
            // valid:
            //   "urban"
            //   "rural"
            //

        }
    }
}


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
        public void InsuranceInvalidLocation()
        {
            string location = "mars";
            int age = 20;
            double expected = 0;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void InsuranceInvalidAge()
        {
            string location = "rural";
            int age = 2;
            double expected = 0;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void InsuranceRuralYoung()
        {
            string location = "rural";
            int age = 25;
            double expected = 5;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void InsuranceRuralOld()
        {
            string location = "rural";
            int age = 60;
            double expected = 2;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void InsuranceUrbanYoung()
        {
            string location = "urban";
            int age = 22;
            double expected = 6;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void InsuranceUrbanOld()
        {
            string location = "urban";
            int age = 39;
            double expected = 5;

            double res = insuranceService.CalcPremium(age, location);

            Assert.That(res, Is.EqualTo(expected));
        }
    }
}


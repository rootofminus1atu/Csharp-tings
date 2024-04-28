using System.Security.Claims;
using NUnit.Framework;
using Moq;

namespace q1
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }

    public interface IDiscountService
    {
        double GetDiscount();
    }


    public class InsuranceService
    {
        private readonly IDiscountService discountService;

        public InsuranceService(IDiscountService ds)
        {
            discountService = ds;
        }

        public double CalcPremium(int age, string location)
        {
            double premium = 0;

            if (age < 18)
                return 0;

            if (location != "rural" && location != "urban") 
                return 0;


            if (location == "rural")
	            if ((age >= 18) && (age <= 30))
                    premium = 5.0;
                else // age > 30
                    premium = 2.50;
            else if (location == "urban")
	            if ((age >= 18) && (age <= 35))
                    premium = 6.0;
                else // age > 35
                    premium = 5.0;

            // DiscountService ds = new DiscountService();
            double discount = this.discountService.GetDiscount();
            if (age >= 50)
                premium *= discount;
            return premium;
        }

        public double CalcPremiumBetter(int age, string location)
        {
            double premium = location switch
            {
                "rural" => age switch
                {
                    int n when n >= 18 && n <= 30 => 5.0,
                    int n when n > 30 => 2.5,
                    _ => 0
                },
                "urban" => age switch
                {
                    int n when n >= 18 && n <= 35 => 6.0,
                    int n when n > 35 => 5.0,
                    _ => 0
                },
                _ => 0
            };

            double discount = this.discountService.GetDiscount();

            if (age >= 50)
                premium *= discount;

            return premium;
        }
    }

    /*
    [TestFixture]
    public class InsuranceServiceTests
    {
        [Test]
        public void Insurance()
        {
            Assert.That(false, Is.False);

            //var mockDiscountService = new Mock<IDiscountService>();
            //mockDiscountService.Setup(x => x.GetDiscount()).Returns(0.8);

            //double res = InsuranceService.CalcPremium(19, "rural", mockDiscountService.Object);

            //Assert.That(res, Is.EqualTo(5));
        }
    }
    */

}

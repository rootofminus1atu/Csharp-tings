namespace InsuranceModels
{
	//public interface IPersonservice
	//{
	//	int GetRate();

	//}
	//public class PersonService : IPersonservice
	//{
	//	public int GetRate()
	//	{
	//		//throw new NotImplementedException();
	//		return 0;
	//	}
	//}
    public interface IDiscountService
    {
        public double GetDiscount();
    }

	public class Person
	{
		public int Age { get; set; }
		public string Location { get; set; }
        // Add more properties as required

        //private readonly IDiscountService discountService;

        //public Person(IDiscountService discountService)
        //{
        //    this.discountService = discountService;
        //}

        // Assume CalculateQuote is a method that takes age and location and returns a quote
        public decimal CalculateQuote()
		{
            // Your calculation logic here, can use properties as view linked directly to model
            double premium = Location switch
            {
                "rural" => Age switch
                {
                    int n when n >= 18 && n <= 30 => 5.0,
                    int n when n > 30 => 2.5,
                    _ => 0
                },
                "urban" => Age switch
                {
                    int n when n >= 18 && n <= 35 => 6.0,
                    int n when n > 35 => 5.0,
                    _ => 0
                },
                _ => 0
            };

            //double discount = this.discountService.GetDiscount();

            //if (Age >= 50)
            //    premium *= discount;

            return (decimal)premium;
		}


	}
}

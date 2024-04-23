using InsuranceQuoteApp.Models;
using Microsoft.AspNetCore.Mvc;
using InsuranceModels;
using System.Diagnostics;

// have a using for any referenced projects here

namespace InsuranceQuoteApp.Controllers
{
    public class InsuranceController : Controller
    {
        // Action to display the form
        public IActionResult Index()
        {
            return View();
        }

        // Action to handle form submission
        [HttpPost]
        public IActionResult CalculateQuote(Person person)
        {
            var quote = person.CalculateQuote();  //if using parameters use person.Age,person.Location
            ViewBag.Quote = quote;
          
            return View("QuoteResult", person);

  

		}
	}

}

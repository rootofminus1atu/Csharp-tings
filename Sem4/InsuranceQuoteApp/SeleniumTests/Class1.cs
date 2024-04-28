namespace SeleniumTests
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Chrome;
    using SeleniumExtras.WaitHelpers;
    using System.Diagnostics;

    [TestFixture]
    public class T2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        // for some reason when running the webapp from the console it uses a different port
        private string localhostURL = "http://localhost:5290";

        [SetUp]
        public void SetupTest()
        {
            Trace.WriteLine("bruh");
            driver = new EdgeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.That("", Is.EqualTo(verificationErrors.ToString()));
        }

        [Test]
        public void InvalidLocation()
        {
            int age = 20;
            string location = "mars";
            decimal expected = 0m;

            string res = FillOutFormAndGetResult(age, location);

            Assert.That(res, Is.EqualTo(QuoteInformation(expected)));
        }

        [Test]
        public void RuralAndValidAge()
        {
            int age = 25;
            string location = "rural";
            decimal expected = 5m;

            string res = FillOutFormAndGetResult(age, location);

            Assert.That(res, Is.EqualTo(QuoteInformation(expected)));
        }

        [Test]
        public void RuralAndBoundary()
        {
            int age = 31;
            string location = "rural";
            decimal expected = 2.5m;

            string res = FillOutFormAndGetResult(age, location);

            Assert.That(res, Is.EqualTo(QuoteInformation(expected)));
        }

        [Test]
        public void RuralAndInvalid()
        {
            int age = 2;
            string location = "rural";
            decimal expected = 0m;

            string res = FillOutFormAndGetResult(age, location);

            Assert.That(res, Is.EqualTo(QuoteInformation(expected)));
        }

        [Test]
        public void UrbanAndBoundary()
        {
            int age = 35;
            string location = "urban";
            decimal expected = 6m;

            string res = FillOutFormAndGetResult(age, location);

            Assert.That(res, Is.EqualTo(QuoteInformation(expected)));
        }


        private static string QuoteInformation(decimal quote)
        {
            return $"Your quote is: {quote}";
        }

        private string FillOutFormAndGetResult(int age, string location)
        {
            driver.Navigate().GoToUrl($"{localhostURL}");

            driver.FindElement(By.Name("Age")).Click();
            driver.FindElement(By.Name("Age")).Clear();
            driver.FindElement(By.Name("Age")).SendKeys(age.ToString());

            driver.FindElement(By.Name("Location")).Click();
            driver.FindElement(By.Name("Location")).Clear();
            driver.FindElement(By.Name("Location")).SendKeys(location);

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            string res = driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")).Text;

            return res;
        }
        
        /*
        [Test]
        public void TheT2Test()
        {
            //driver.Navigate().GoToUrl("https://localhost:7254/Insurance/CalculateQuote");
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Privacy'])[2]/following::a[1]")).Click();

            driver.Navigate().GoToUrl($"{localhostURL}"); 

            driver.FindElement(By.Name("Age")).Click();
            driver.FindElement(By.Name("Age")).Clear();
            driver.FindElement(By.Name("Age")).SendKeys("20");

            driver.FindElement(By.Name("Location")).Click();
            driver.FindElement(By.Name("Location")).Clear();
            driver.FindElement(By.Name("Location")).SendKeys("rural");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            // driver.Navigate().GoToUrl("https://localhost:7254/Insurance/CalculateQuote");
            // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")));
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")).Click();
            
            try
            {
                Assert.That("Your quote is: 5", Is.EqualTo(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")).Text));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        */
    }

}


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

    [TestFixture]
    public class T2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
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
        public void TheT2Test()
        {
            //driver.Navigate().GoToUrl("https://localhost:7254/Insurance/CalculateQuote");
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Privacy'])[2]/following::a[1]")).Click();
            driver.Navigate().GoToUrl("https://localhost:7254/Insurance/Index");
            driver.FindElement(By.Name("Age")).Click();
            driver.FindElement(By.Name("Age")).Clear();
            driver.FindElement(By.Name("Age")).SendKeys("1");
            driver.FindElement(By.Name("Age")).Click();
            driver.FindElement(By.Name("Age")).Clear();
            driver.FindElement(By.Name("Age")).SendKeys("2");
            driver.FindElement(By.Name("Age")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=Age | ]]
            driver.FindElement(By.Name("Location")).Click();
            driver.FindElement(By.Name("Location")).Clear();
            driver.FindElement(By.Name("Location")).SendKeys("sligo");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
           // driver.Navigate().GoToUrl("https://localhost:7254/Insurance/CalculateQuote");
            
           // driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            
           
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")));

            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")).Click();
            try
            {
                Assert.That("Your quote is: 50", Is.EqualTo(driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Insurance Quote'])[1]/following::p[1]")).Text));
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
    }

}


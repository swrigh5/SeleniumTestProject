using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{

    [TestFixture]
    class ExplicitWaits
    {
        public IWebDriver driver { get; private set; }


        [SetUp]
        public void setup()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
        }

        [TearDown]
        public void teardown()
        {
            driver.Close();
            driver.Dispose();
        }

        [Test]
        public void ExplicitWait1()
        {
            driver.FindElement(By.XPath("//button")).Click();

            //explicit wait

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            bool Success = wait.Until((d) =>
            {
                return d.FindElement(By.Id("finish")).Displayed;
            });


            Assert.AreEqual("Hello World!", driver.FindElement(By.Id("finish")).Text);

        }


        [Test]
        public void FixedExplicitWait()
        {
            driver.FindElement(By.XPath("//button")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("finish")));

            //expectedConditions deprecated - will need to write on methods for waiting as shown in test1
            //or found in SeleniumExtras.ExpectedConditions
            //https://github.com/DotNewSeleniumTools/DotNetSeleniumExtras
            //https://github.com/SeleniumHQ/selenium/blob/master/dotnet/src/support/UI/ExpectedConditions.cs
        }


        [Test]
        public void FixedExplicitWait2()
        {

        }

        private bool ExpectVisibleText(string id)
        {
            
        }



    }
}

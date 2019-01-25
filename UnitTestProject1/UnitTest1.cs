using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
   
    [TestFixture]
    public class UnitTest1
    {
        public IWebDriver driver { get; private set; }

        [SetUp]
        public void Setup()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void FindElementsClickTest()
        {
            var idElement = driver.FindElement(By.Id("idExample"));
            idElement.Click();
            driver.Navigate().Back();

            idElement = driver.FindElement(By.LinkText("Click me using this link text!"));
            idElement.Click();
            driver.Navigate().Back();
        }


        [Test]
        public void XPathTest()
        {


        }
    }
}
 
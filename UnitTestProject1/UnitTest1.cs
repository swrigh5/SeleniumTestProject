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

        [Test]
        public void TestMethod1()
        {
            
        }
    }
}
 
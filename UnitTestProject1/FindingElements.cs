using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
   
    [TestFixture]
    public class FindingElements
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
            var element = driver.FindElement(By.Id("idExample"));
            element.Click();
            driver.Navigate().Back();

            element = driver.FindElement(By.LinkText("Click me using this link text!"));
            element.Click();
        }


        [Test]
        public void XPathTest()
        {
            var element = driver.FindElement(By.XPath("//*[@class='et_pb_button et_pb_promo_button'][@href='/button-success']"));
            element.Click();
            driver.Navigate().Back();

            element = driver.FindElement(By.XPath("//*[@class='et_pb_button et_pb_promo_button'][@href='https://courses.ultimateqa.com/users/sign_in']"));
            element.Click();
       }


        [Test]
        public void XPathCompoundNegativeTest()
        {
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements;


            Assert.Throws<InvalidSelectorException>(()
                => elements = driver.FindElements(By.ClassName("et_pb_button et_pb_promo_button")));
        }




    }
}
 
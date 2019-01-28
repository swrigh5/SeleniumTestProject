using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    class ManipulatingElements
    {
        public IWebDriver driver { get; private set; }

        [SetUp]
        public void setup()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
        }


        [Test]
        public void test1()
        {
            ///clear name field
            ///type into field
            ///
            ///clear text field
            ///type into field
            ///submit
            
        }

    }
}

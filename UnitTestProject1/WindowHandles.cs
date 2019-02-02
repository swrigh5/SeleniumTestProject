using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium;


namespace UnitTestProject1
{
    [TestFixture]
    class WindowHandles
    {
        public IWebDriver driver { get; private set; }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }



        [Test]
        public void DriverLevelInterrogation()
        {

        }


        [Test]
        public void ElementInterrogation()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/automation/");
            var element = driver.FindElement(By.XPath("//*[@href='http://courses.ultimateqa.com/users/sign_in']"));

            var isEnabled = element.Enabled;
            var isDisplayed = element.Displayed;

        }

    }
}

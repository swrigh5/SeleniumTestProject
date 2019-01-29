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
            //var namefield = driver.FindElement(By.XPath("//*[@id='et_pb_contact_name_0']"));
            var namefield = driver.FindElement(By.Id("et_pb_contact_name_0"));
            namefield.Clear();
            namefield.SendKeys("Stephen Wright");

            var messagefield = driver.FindElement(By.XPath("//*[@id='et_pb_contact_message_0']"));
            messagefield.Clear();
            messagefield.SendKeys("Hello there");

            var submit = driver.FindElement(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"));           
            submit.Click();  
            
        }

    }
}

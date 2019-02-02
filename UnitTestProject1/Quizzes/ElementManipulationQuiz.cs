using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace UnitTestProject1.Quizzes
{
    [TestFixture]
    class ElementManipulationQuiz
    {
        public IWebDriver driver { get; private set; }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


        [Test]
        public void Message2Captcha()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms");

            var contact = driver.FindElement(By.Id("et_pb_contact_name_1"));
            contact.Clear();
            contact.SendKeys("Jeffrey");

            var msg = driver.FindElement(By.Id("et_pb_contact_message_1"));
            msg.Clear();
            msg.SendKeys("Hello there");

            var captchaTxt = driver.FindElement(By.ClassName("et_pb_contact_captcha_question")).Text; 
            var answer = AddStrings(captchaTxt);

            driver
                .FindElement(By.XPath("//*[@class='input et_pb_contact_captcha']"))
                .SendKeys(answer);


            driver
                .FindElements(By.XPath("//*[@class='et_pb_contact_submit et_pb_button']"))[1]
                .Click();      
        }


        private string AddStrings(string captchaText)
        {
            var regex = Regex.Matches(captchaText, @"[1-9][0-9]?");
            int sum = 0;

            foreach (Match value in regex)
            {
                sum += int.Parse(value.Value);
            }

            return sum.ToString();
        }



    }
}

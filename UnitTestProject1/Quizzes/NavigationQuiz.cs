using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace UnitTestProject1.Quizzes
{
    [TestFixture]
    class NavigationQuiz
    {
        public IWebDriver driver { get; private set; }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void CheckForTitles()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/");
            Assert.AreEqual("Home - Ultimate QA", driver.Title);

            driver.FindElement(By.LinkText("Automation Exercises")).Click();
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
        }

        [Test]
        public void ComplicatedPage()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/");
            driver.FindElement(By.LinkText("Automation Exercises")).Click();

            driver.FindElement(By.LinkText("Big page with many elements")).Click();
            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);

            driver.Navigate().Back();
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);
        }

    }
}

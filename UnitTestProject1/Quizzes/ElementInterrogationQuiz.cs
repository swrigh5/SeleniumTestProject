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
    class ElementInterrogationQuiz
    {
        public IWebDriver driver { get; private set; }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

      /// <summary>
      /// Find button by Id
      /// Getattribute("type") and asser that its correct
      /// getcssvalue("letter-spacing") and assert that it equals the correct value
      /// Assert that it's displayed
      /// assert that it's enabled
      /// assert that it's not selected
      /// assert that the text is correct
      /// assert that the tagname is correct
      /// assert that the size height is 21
      /// assert that the location is x=190, y=330
      /// </summary>



        [Test]
        public void ElementInterrogationTest()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/simple-html-elements-for-automation/");
            driver.Manage().Window.Maximize();

            var button = driver.FindElement(By.XPath("//*[@id='button1'][contains(text(), 'Click Me!')]"));

            Assert.AreEqual("submit", button.GetAttribute("type"));
            Assert.AreEqual("normal", button.GetCssValue("letter-spacing"));
            Assert.IsTrue(button.Displayed);
            Assert.IsTrue(button.Enabled);
            Assert.IsFalse(button.Selected);
            Assert.AreEqual("Click Me!", button.Text);
            Assert.AreEqual("button", button.TagName);
            Assert.AreEqual(21, button.Size.Height);
            Assert.AreEqual(190, button.Location.X);
            Assert.AreEqual(330, button.Location.Y);





        }



    }
}

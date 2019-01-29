using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

///Exam
///using only XPath
///-when debugging and testing, make sure that you scroll the element into view, 
///
///Click any radio button
///select one checkbox
///select Audi from the dropdown
///Open tab2 and assert that it is opened. Hint, use .text property when you find the element
///in the HTML table with id, highlight one of the salary cells
///highligh the center section called "highlight me", but you can only highlight the highest level div for that element.
/// The top parent div.
/// Hint, this is the class - 
///     et_pb_column et_pb_column_1_3 et_pb_column10 et_pb_css_mix_blend_mode_passthrough


namespace UnitTestProject1.Exams
{
    [TestFixture]
    class XPath1
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


        private void HighlightElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");
            IJavaScriptExecutor JavaScriptExecutor = driver as IJavaScriptExecutor;
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                "border: 7px solid yellow; border-style: dashed;");

            if (duration <= 0) return;
            Thread.Sleep(TimeSpan.FromSeconds(duration));
            JavaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);
        }


        [Test]
        public void clickAnyRadioButton()
        {
            var element = driver.FindElement(By.XPath("//*[@value='male']"));
            element.Click();

            Assert.That(element.Selected, Is.True);
        }

        [Test]
        public void selectCheckBox()
        {
            var element = driver.FindElement(By.XPath("//*[@value='Bike']"));
            element.Click();
            Assert.That(element.Selected, Is.True);

            element = driver.FindElement(By.XPath("//*[@value='Car']"));
            element.Click();
            Assert.That(element.Selected, Is.True);
        }


        [Test]
        public void selectAudiFromDropDown()
        {
            var element = driver.FindElement(By.XPath("//*[@value='audi']"));
            element.Click();

            Assert.That(element.Displayed, Is.True);          
        }


        [Test]
        public void openTab2()
        {
        

            var element = driver.FindElement(By.XPath("//*[@class='et_pb_tab_1']"));
            element.Click();

            Assert.AreEqual("Tab 2 content", driver.FindElement(By.XPath("//*[@class='et_pb_tab et_pb_tab_1 clearfix et-pb-active-slide']")).Text);
        }


        [Test]
        public void highlightSalary()
        {
            HighlightElementUsingJavaScript(By.XPath("//td[contains(text(), '$150,000+')]"));
        }


        [Test]
        public void highlightMe()
        {

           /// HighlightElementUsingJavaScript(By.ClassName("et_pb_column et_pb_column_1_3  et_pb_column_10 et_pb_css_mix_blend_mode_passthrough"));
            HighlightElementUsingJavaScript(
            By.XPath("//*[@class='et_pb_column et_pb_column_1_3 et_pb_column_10    et_pb_css_mix_blend_mode_passthrough']"));
        }

    }
}

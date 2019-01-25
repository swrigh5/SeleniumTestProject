using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var element = driver.FindElement(By.XPath("//[@value='audi']"));
            element.Click();

            Assert.That(element.Displayed, Is.True);
           

        }


        [Test]
        public void openTab2()
        {

        }


        [Test]
        public void highlightSalary()
        {

        }


        [Test]
        public void highlightMe()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.Quizzes
{
    class DragAndDropQuiz
    {
        private IWebDriver driver { get; set; }

        [SetUp]
        public void setup()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
        }

        [Test]
        public void DragAndDropQuiz1()
        {

            var actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            //assert "moving out!"
            var sourceElement = driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));
            var targetElement = driver.FindElement(By.XPath("//*[@class='squaredotted ui-droppable']"));
         
            var drag = actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Build();

            drag.Perform();

            var message = driver.FindElement(By.XPath("//*[@id='info']"));
            Assert.That(message.Text, Is.EqualTo("moving in!"));

            var drop = actions
                .Release(targetElement)
                .Build();

            drop.Perform();

            message = driver.FindElement(By.XPath("//*[@id='info']"));
            Assert.That(message.Text, Is.EqualTo("dropped!"));
        
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestFixture]
    class MouseAndKeyboardActions
    {
        private IWebDriver driver { get; set; }

        [SetUp]
        public void setup()
        {
            driver = new WebDriverFactory().Create(BrowserType.Chrome);
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
        }

        [Test]
        public void DragAndDropTest1()
        {
            var actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            var sourceElement = driver.FindElement(By.Id("draggable"));
            var targetElement = driver.FindElement(By.Id("droppable"));

            actions.DragAndDrop(sourceElement, targetElement).Perform();


            Assert.That(targetElement.Text, Is.EqualTo("Dropped!"));
        }

        [Test]
        public void DragAndDropTest2()
        {
            var actions = new Actions(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));


            var sourceElement = driver.FindElement(By.Id("draggable"));
            var targetElement = driver.FindElement(By.Id("droppable"));

            var drag = actions
                 .ClickAndHold(sourceElement)
                 .MoveToElement(targetElement)
                 .Release(targetElement)
                 .Build();

            drag.Perform();

            Assert.That(targetElement.Text, Is.EqualTo("Dropped!"));

        }
    }
}

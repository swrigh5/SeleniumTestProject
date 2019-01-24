using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    public enum BrowserType
    {
        Chrome,
        FireFox,
        Edge
    }

    class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.FireFox:
                    throw new NotImplementedException();
                case BrowserType.Edge:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException("No browser exists");
                
            }
               
        }


        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        public IWebDriver GetFireFoxDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver GetEdgeDriver()
        {
            throw new NotImplementedException();
        }


    }
}

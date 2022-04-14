using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Setup
{
    public class AppiumKeywords
    {
        private AppiumDriver<IWebElement> _driver;
        private DefaultWait<AppiumDriver<IWebElement>> _wait;

        public AppiumKeywords(AppiumDriver<IWebElement> driver)
        {
            this._driver = driver;
        }

        public void ClickOnElement(By locator)
        {
            _driver.FindElement(locator).Click();
        }

        public IWebElement WaitAndFindElement(By androidLocator, By iosLocator)
        {
            //_wait=new DefaultWait<AppiumDriver<IWebElement>>(_driver);
            //_wait.Timeout=TimeSpan.FromSeconds(30);
            //_wait.IgnoreExceptionTypes(typeof(Exception));  

            if (_driver.PlatformName.Equals("Android"))
            {
                return _driver.FindElement(androidLocator);
            }
            return _driver.FindElement(iosLocator);
        }

        public ReadOnlyCollection<IWebElement> WaitAndFindElements(By androidLocator, By iosLocator)
        {
            //_wait=new DefaultWait<AppiumDriver<IWebElement>>(_driver);
            //_wait.Timeout=TimeSpan.FromSeconds(30);
            //_wait.IgnoreExceptionTypes(typeof(Exception));  

            if (_driver.PlatformName.Equals("Android"))
            {
                return _driver.FindElements(androidLocator);
            }
            return _driver.FindElements(iosLocator);
        }

        

    }
}

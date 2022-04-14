using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Pages
{
    public class DismissScreen
    {
        private AndroidDriver<IWebElement> _driver;
        private By _dismissLocator = MobileBy.XPath("//*[@text='Dismiss']");

        public DismissScreen(AndroidDriver<IWebElement> driver)
        {
            this._driver = driver;

        }

        public void ClickOnDismiss()
        {
            if (_driver.FindElements(_dismissLocator).Count > 0)
            {
                _driver.FindElement(_dismissLocator).Click();
            }
        }
    }
}

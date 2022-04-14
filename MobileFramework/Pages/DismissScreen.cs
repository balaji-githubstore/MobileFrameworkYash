using MobileFramework.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Pages
{
    public class DismissScreen : AppiumKeywords
    {
        private readonly AppiumDriver<IWebElement> _driver;
 
        public ReadOnlyCollection<IWebElement> _dismissElements  => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Dismiss']"), iosLocator: MobileBy.XPath("//*[@name='Dismiss']"));
        
        public DismissScreen(AppiumDriver<IWebElement> driver):base(driver)
        {
            this._driver = driver;
        }

        public void ClickOnDismiss()
        {
            
            if (_dismissElements.Count > 0)
            {
                _dismissElements[0].Click();
            }
        }

        //_driver.FindElement(MobileBy.AndroidUIAutomator("")).Click();
    }
}

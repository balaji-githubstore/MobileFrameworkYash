using MobileFramework.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Pages
{
    public class WelcomeScreen : AppiumKeywords
    {
        private IWebElement _signInElement => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='Sign in']"),iosLocator: MobileBy.XPath("//*[@name='Sign in']"));


        private AppiumDriver<IWebElement> driver;
        public WelcomeScreen(AppiumDriver<IWebElement> driver):base(driver)
        {
            this.driver = driver;
        }
        public void ClickOnSignIn()
        {
            _signInElement.Click();
        }

    }
}

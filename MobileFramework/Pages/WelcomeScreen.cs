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
    public class WelcomeScreen
    {
        private By _signInLocator = MobileBy.XPath("//*[@text='Sign in']");


        private AndroidDriver<IWebElement> driver;
        public WelcomeScreen(AndroidDriver<IWebElement> driver)
        {
            this.driver = driver;
        }
        public void ClickOnSignIn()
        {
            driver.FindElement(_signInLocator).Click();
        }

    }
}

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
    public class HomeScreen
    {
        private By _homeLocator = MobileBy.AndroidUIAutomator("UiSelector().text(\"Sign in\")");
        private By _signInLocator = MobileBy.XPath("//*[@text='Sign in']");
        

        private AndroidDriver<IWebElement> driver;
        public HomeScreen(AndroidDriver<IWebElement> driver)
        {
            this.driver = driver;
        }

        public bool IsHomeMenuDisplayed()
        {
            return driver.FindElement(_homeLocator).Displayed;
        }

        public void ClickOnHome()
        {
            driver.FindElement(_homeLocator).Click();
        }

        public void ClickOnSearch()
        {

        }
        public void ClickOnBookMark()
        {

        }
        public void ClickOnSettingsIcon()
        {

        }

        public void ClickOnSignIn()
        {
            driver.FindElement(_signInLocator).Click();
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileFramework.Setup;

namespace MobileFramework.Pages
{
    public class HomeScreen : AppiumKeywords
    {
        
       // private IWebElement _searchElement => WaitAndFindElement(androidLocator: new ByChained(By.Id(""), MobileBy.XPath("//*[@text='Sign in")), iosLocator: By.Id(""));

        private IWebElement _homeElement => WaitAndFindElement(androidLocator: MobileBy.AndroidUIAutomator("UiSelector().text(\"Home\")"), iosLocator: By.XPath("//*[@name='Home']"));

        private IWebElement _signInElement => WaitAndFindElement(androidLocator: MobileBy.AndroidUIAutomator("UiSelector().text(\"Sign in\")"), iosLocator: By.XPath("//*[@name='Sign in']"));


        public HomeScreen(AppiumDriver<IWebElement> driver):base(driver)
        {

        }

        public bool IsHomeMenuDisplayed()
        {
            return _homeElement.Displayed;
        }

        public void ClickOnHome()
        {
            _homeElement.Click();
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
            _signInElement.Click();
        }

    }
}

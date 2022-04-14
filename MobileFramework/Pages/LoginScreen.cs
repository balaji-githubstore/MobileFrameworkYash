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
    public class LoginScreen
    {
        private By _signInLocator = MobileBy.XPath("(//*[@text='Sign in'])[2]");
        private By _emailLocator = MobileBy.XPath("//*[@content-desc='Enter an e-mail address or username']");
        private By _passwordLocator = MobileBy.XPath("//*[contains(@text,'Pass')]");
        private By _errorLocator = MobileBy.XPath("//*[contains(@text,'issue')]");


        private AndroidDriver<IWebElement> driver;
        public LoginScreen(AndroidDriver<IWebElement> driver)
        {
            this.driver = driver;
        }

        public void EnterEmailAddress(string email)
        {
            driver.FindElement(_emailLocator).SendKeys(email);
        }
        public void EnterPassword(string password)
        {
            driver.FindElement(_passwordLocator).SendKeys(password);
            
        }
        public void HideKeyboardAndClickOnSignIn()
        {
            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }
            driver.FindElement(_signInLocator).Click();
        }

        public string GetInvalidErrorMessage()
        {
            return driver.FindElement(_errorLocator).Text; 
        }
    }
}

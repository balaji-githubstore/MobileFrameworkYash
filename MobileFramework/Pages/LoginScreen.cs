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
    public class LoginScreen : AppiumKeywords
    {
        private IWebElement _signInElement=>WaitAndFindElement(androidLocator: MobileBy.XPath("(//*[@text='Sign in'])[2]"),iosLocator: MobileBy.XPath("(//*[@name='Sign in'])[2]"));
        private IWebElement _emailElement => WaitAndFindElement(androidLocator: MobileBy.AccessibilityId("Enter an e-mail address or username"), iosLocator: MobileBy.AccessibilityId("//*[contains(@name,'email')]"));
        private IWebElement _passwordElement=>WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@text,'Pass')]"),iosLocator: MobileBy.XPath("//*[contains(@name,'Pass')]"));
        private IWebElement _errorElement=>WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@text,'issue')]"),iosLocator: MobileBy.XPath("//*[contains(@text,'issue')]"));



        private AppiumDriver<IWebElement> driver;
        public LoginScreen(AppiumDriver<IWebElement> driver):base(driver)
        {
            this.driver = driver;
        }

        public void EnterEmailAddress(string email)
        {
            _emailElement.SendKeys(email);
        }
        public void EnterPassword(string password)
        {
            _passwordElement.SendKeys(password);
            
        }
        public void HideKeyboardAndClickOnSignIn()
        {
            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }
           _signInElement.Click();
        }

        public string GetInvalidErrorMessage()
        {
            return _errorElement.Text; 
        }
    }
}

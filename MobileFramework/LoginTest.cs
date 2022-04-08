using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileFramework.Setup;
using MobileFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MobileFramework
{
    [TestClass]
    public class LoginTest : AppiumSetup
    {

        //john,john123,There was an issue signing in
        //peter,peter123,There was an issue signing in

        [TestMethod]
        [DataRow("john", "john123", "There was an issue signing in")]
        [DataRow("peter", "peter123", "There was an issue signing in")]
        public void InvalidCredentialTest(string username,string password,string expectedError)
        {
            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@content-desc='Enter an e-mail address or username']").SendKeys(username);
            driver.FindElementByXPath("//*[contains(@text,'Pass')]").SendKeys(password);
            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }
            driver.FindElementByXPath("(//*[@text='Sign in'])[2]").Click();
            string actualError = driver.FindElementByXPath("//*[contains(@text,'issue')]").Text;

            Assert.AreEqual(expectedError, actualError);

        }

        [TestMethod]
        [DataTestMethod]
        [DynamicData(nameof(DataTransfer.SheetToObject),typeof(DataTransfer),DynamicDataSourceType.Method)]
        public void InvalidCredentialExcelTest(string username, string password, string expectedError)
        {
            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@content-desc='Enter an e-mail address or username']").SendKeys(username);
            driver.FindElementByXPath("//*[contains(@text,'Pass')]").SendKeys(password);
            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }
            driver.FindElementByXPath("(//*[@text='Sign in'])[2]").Click();
            string actualError = driver.FindElementByXPath("//*[contains(@text,'issue')]").Text;

            Assert.AreEqual(expectedError, actualError);

        }

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class LoginTest
    {
        [TestMethod]
        public void InvalidCredentialTest()
        {
            //start the server

            OptionCollector opt = new OptionCollector()
                .AddArguments(GeneralOptionList.OverrideSession())
                .AddArguments(new KeyValuePair<string, string>("--relaxed-security", string.Empty));
            AppiumServiceBuilder builder = new AppiumServiceBuilder().UsingAnyFreePort()
                .WithLogFile(new System.IO.FileInfo("appium_log.txt")).WithArguments(opt);
                //.WithAppiumJS(new System.IO.FileInfo(@"C:\Users\JiDi\AppData\Roaming\npm\node_modules\appium\build\lib\appium.js"));

            AppiumLocalService service = builder.Build(); //uses port - 4723 
            service.Start();

            Console.WriteLine(service.ServiceUrl);
            Console.WriteLine(service.IsRunning);

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            AndroidDriver<IWebElement> driver = new AndroidDriver<IWebElement>(service, option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@text='Sign in']").Click();
            driver.FindElementByXPath("//*[@content-desc='Enter an e-mail address or username']").SendKeys("test@gmail.com");
            driver.FindElementByXPath("//*[contains(@text,'Pass')]").SendKeys("pass@123");

            if (driver.IsKeyboardShown())
            {
                driver.HideKeyboard();
            }

            //*[@text='Sign in' and @index='0']
            driver.FindElementByXPath("(//*[@text='Sign in'])[2]").Click();

            String actualError = driver.FindElementByXPath("//*[contains(@text,'issue')]").Text;
            Console.WriteLine(actualError);

            Assert.AreEqual("There was an issue signing in", actualError);

            Thread.Sleep(5000);
            driver.Quit();

            //stop the server
            service.Dispose();
        }
    }
}
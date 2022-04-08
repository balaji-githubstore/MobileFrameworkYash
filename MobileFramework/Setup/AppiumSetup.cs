using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System;
using System.Collections.Generic;
namespace MobileFramework.Setup
{
    public class AppiumSetup
    {
        private AppiumLocalService _service;
        protected AndroidDriver<IWebElement> driver;

        [TestInitialize]
        public void Setup()
        {
            OptionCollector opt = new OptionCollector()
                  .AddArguments(GeneralOptionList.OverrideSession())
                  .AddArguments(new KeyValuePair<string, string>("--relaxed-security", string.Empty));
            AppiumServiceBuilder builder = new AppiumServiceBuilder().UsingAnyFreePort()
                .WithLogFile(new System.IO.FileInfo("appium_log.txt")).WithArguments(opt);
            //.WithAppiumJS(new System.IO.FileInfo(@"C:\Users\JiDi\AppData\Roaming\npm\node_modules\appium\build\lib\appium.js"));

            _service = builder.Build(); //uses port - 4723 
            _service.Start();

            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("platformName", "android");
            option.AddAdditionalCapability("deviceName", "bala");
            option.AddAdditionalCapability("app", @"C:\Components\khan-academy-7-3-2.apk");

            driver = new AndroidDriver<IWebElement>(_service, option);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver?.Quit();
            _service?.Dispose();
        }

    }
}

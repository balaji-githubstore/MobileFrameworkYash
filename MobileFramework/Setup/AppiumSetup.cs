using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
    [TestClass]
    public class AppiumSetup
    {
        private AppiumLocalService _service;
        protected AndroidDriver<IWebElement> driver;
        public static ExtentReports extent;
        public static ExtentTest test;

        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            //run only once at first
            if (extent == null)
            {
                extent = new ExtentReports();
                ExtentHtmlReporter reporter = new ExtentHtmlReporter(@"C:\Components\");
                
                extent.AttachReporter(reporter);
            }
        }

        [AssemblyCleanup]
        public static void End()
        {
            //run only once at the end
            extent.Flush();
        }

        [TestInitialize]
        public void Setup()
        {
            test= extent.CreateTest(TestContext.TestName);

            OptionCollector opt = new OptionCollector()
                  .AddArguments(GeneralOptionList.OverrideSession())
                  .AddArguments(new KeyValuePair<string, string>("--relaxed-security", string.Empty));
            AppiumServiceBuilder builder = new AppiumServiceBuilder().UsingAnyFreePort()
                .WithLogFile(new System.IO.FileInfo("appium_log.txt")).WithArguments(opt);
            //.WithAppiumJS(new System.IO.FileInfo(@"C:\Users\JiDi\AppData\Roaming\npm\node_modules\appium\build\lib\appium.js"));

            _service = builder.Build();
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
            if(TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                test.Log(Status.Pass, "Test Method Name " + TestContext.TestName + "   " + TestContext.CurrentTestOutcome + " - snapshot below");
            }
            else if(TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                test.Log(Status.Fail, "Test Method Name " + TestContext.TestName + " "+ TestContext.CurrentTestOutcome + " - snapshot below");
            }
            else
            {
                test.Log(Status.Skip, "Test Method Name " + TestContext.TestName + " " + TestContext.CurrentTestOutcome + " - snapshot below");
            }

            

            Screenshot screenshot= driver.GetScreenshot();
            test.AddScreenCaptureFromBase64String(screenshot.AsBase64EncodedString, title: TestContext.TestName);

            driver?.Quit();
            _service?.Dispose();
        }

        

    }
}

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
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
        protected AppiumDriver<IWebElement> driver;
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

        public void ServerStart()
        {
            if (_service == null || !_service.IsRunning)
            {

                //Environment.SetEnvironmentVariable("ANDROID_HOME", @"C:\Users\JiDi\AppData\Local\Android\Sdk");
                //Environment.SetEnvironmentVariable("JAVA_HOME", @" C:\Program Files\Java\jdk1.8.0_291");

                OptionCollector opt = new OptionCollector()
                 .AddArguments(GeneralOptionList.OverrideSession())
                 .AddArguments(new KeyValuePair<string, string>("--relaxed-security", string.Empty));
                AppiumServiceBuilder builder = new AppiumServiceBuilder().UsingAnyFreePort()
                    .WithLogFile(new System.IO.FileInfo("appium_log.txt")).WithArguments(opt);
                //.WithAppiumJS(new System.IO.FileInfo(@"C:\Users\JiDi\AppData\Roaming\npm\node_modules\appium\build\lib\appium.js"));

                _service = builder.Build();
                // _service.Start();
            }

        }

        [TestInitialize]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.TestName);

            string environment = "local";
            string platform = "android";

            if (environment.Equals("cloud"))
            {
                AppiumOptions caps = new AppiumOptions();
                // Set your BrowserStack access credentials
                caps.AddAdditionalCapability("browserstack.user", "dinakaranbalaji1");
                caps.AddAdditionalCapability("browserstack.key", "6yXRE4nK1fyvTHWA2kPD");

                // Set URL of the application under test
                caps.AddAdditionalCapability("app", "bs://c60ad2363b5136bbc60b4e077b645fa3ad9a21de");

                // Specify device and os_version
                caps.AddAdditionalCapability("device", "Samsung Galaxy S10e");
                caps.AddAdditionalCapability("os_version", "9.0");

                // Specify the platform name
                caps.PlatformName = "Android";

                // Set other BrowserStack capabilities
                caps.AddAdditionalCapability("project", "Khan Academy Project - Yash");
                caps.AddAdditionalCapability("build", "Khan Academy Build - Yash");
                caps.AddAdditionalCapability("name", "khan - sign in test - yash");


                driver = new AndroidDriver<IWebElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            else
            {
                //ServerStart();
                AppiumOptions option = new AppiumOptions();
                option.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                option.AddAdditionalCapability(MobileCapabilityType.DeviceName, "bala");
                option.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Components\khan-academy-7-3-2.apk");

                if (platform.ToLower().Equals("android"))
                {
                    //driver = new AndroidDriver<IWebElement>(_service, option);
                    driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);

                }
                else
                {
                    //driver = new IOSDriver<IWebElement>(_service, option);
                    driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), option);
                }


                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //driver.StartRecordingScreen();
            }
        }
            [TestCleanup]
            public void Teardown()
            {

                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                {
                    test.Log(Status.Pass, "Test Method Name " + TestContext.TestName + "   " + TestContext.CurrentTestOutcome + " - snapshot below");
                }
                else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
                {
                    test.Log(Status.Fail, "Test Method Name " + TestContext.TestName + " " + TestContext.CurrentTestOutcome + " - snapshot below");
                }
                else
                {
                    test.Log(Status.Skip, "Test Method Name " + TestContext.TestName + " " + TestContext.CurrentTestOutcome + " - snapshot below");
                }


                Screenshot screenshot = driver.GetScreenshot();
                test.AddScreenCaptureFromBase64String(screenshot.AsBase64EncodedString, title: TestContext.TestName);


                driver?.Quit();
                _service?.Dispose();
            }



        }
    }

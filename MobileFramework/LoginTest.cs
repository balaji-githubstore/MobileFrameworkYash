using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileFramework.Pages;
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
        public void InvalidCredentialTest(string username, string password, string expectedError)
        {

            DismissScreen dismiss=new DismissScreen(driver);
            dismiss.ClickOnDismiss();

            HomeScreen homeScreen=new HomeScreen(driver);
            homeScreen.ClickOnSignIn();


            WelcomeScreen welcomeScreen=new WelcomeScreen(driver);
            welcomeScreen.ClickOnSignIn();
            
            LoginScreen loginScreen=new LoginScreen(driver);
            loginScreen.EnterEmailAddress(username);
            loginScreen.EnterPassword(password);
            loginScreen.HideKeyboardAndClickOnSignIn();

          
            string actualError = loginScreen.GetInvalidErrorMessage();

            Assert.AreEqual(expectedError, actualError);

        }

        [TestMethod]
        [DataTestMethod]
        [DynamicData(nameof(DataTransfer.SheetToObject),typeof(DataTransfer),DynamicDataSourceType.Method)]
        public void InvalidCredentialExcelTest(string username, string password, string expectedError)
        {
            DismissScreen dismiss = new DismissScreen(driver);
            dismiss.ClickOnDismiss();

            HomeScreen homeScreen = new HomeScreen(driver);
            homeScreen.ClickOnSignIn();
            homeScreen.ClickOnSignIn();

            WelcomeScreen welcomeScreen = new WelcomeScreen(driver);
            welcomeScreen.ClickOnSignIn();

            LoginScreen loginScreen = new LoginScreen(driver);
            loginScreen.EnterEmailAddress(username);
            loginScreen.EnterPassword(password);
            loginScreen.HideKeyboardAndClickOnSignIn();


            string actualError = loginScreen.GetInvalidErrorMessage();

            Assert.AreEqual(expectedError, actualError);

        }

    }
}
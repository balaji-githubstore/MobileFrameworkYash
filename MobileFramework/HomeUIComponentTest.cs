using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileFramework.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework
{
    [TestClass]
    public class HomeUIComponentTest : AppiumSetup
    {

        [TestMethod]
        public void UIComponentTest()
        {
            if (driver.FindElementsByXPath("//*[@text='Dismiss']").Count > 0)
            {
                test.Log(Status.Info, "Dismiss present so click on it!!");
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }
            bool homeDisplayed= driver.FindElementByXPath("//*[@text='Home']").Displayed;
            bool searchDisplayed = driver.FindElementByXPath("//*[@text='Home']").Displayed;
            bool bookmarkDisplayed = driver.FindElementByXPath("//*[@text='Bookmarks']").Displayed;

            test.Log(Status.Info, "Home, Search, Bookmark displayed!!!");

            Assert.IsTrue(homeDisplayed,"Assertion on Home Menu Display");
            Assert.IsTrue(searchDisplayed, "Assertion on Search Menu Display");
            Assert.IsTrue(bookmarkDisplayed, "Assertion on BookMark Menu Display");
        }
    }
}

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
                driver.FindElementByXPath("//*[@text='Dismiss']").Click();
            }
            bool homeDisplayed= driver.FindElementByXPath("//*[@text='Home']").Displayed;
            bool searchDisplayed = driver.FindElementByXPath("//*[@text='Home']").Displayed;
            bool bookmarkDisplayed = driver.FindElementByXPath("//*[@text='Bookmarks']").Displayed;

            Assert.IsTrue(homeDisplayed,"Assertion on Home Menu Display");
            Assert.IsTrue(searchDisplayed, "Assertion on Search Menu Display");
            Assert.IsTrue(bookmarkDisplayed, "Assertion on BookMark Menu Display");
        }
    }
}

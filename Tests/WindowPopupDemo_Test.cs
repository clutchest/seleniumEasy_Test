using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using seleniumeasy_Test.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace seleniumeasy_Test.Tests
{
    class WindowPopupDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;
        string twitterLink = "https://twitter.com/intent/follow?screen_name=seleniumeasy";
        string facebookLink = "https://www.facebook.com/seleniumeasy";
        string googleplusLink = "https://accounts.google.com/signin/";

        [SetUp]
        public void SetUp_WindowPopupDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/window-popup-modal-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void SingleWindowPopup()
        {
            //Opens the twitter window popup
            homePage.ClickTwitter();
            //Switch to last opened window - in this case twitter window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.AreEqual(twitterLink, Driver.Url, "Twitter window popup link invalid!");
            Driver.Close();

            //Switch to test site window
            Driver.SwitchTo().Window(Driver.WindowHandles.First());

            //Opens the facebook window popup
            homePage.ClickFacebook();
            //Switch to facebook window popup
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.AreEqual(facebookLink, Driver.Url, "Facebook window popup link invalid!");
            Driver.Close();
        }

        [Test]
        public void MultipleWindowPopup()
        {
            var current = Driver.CurrentWindowHandle;
            //Opens 2 windows
            homePage.ClickTwitterAndFacebook();
            //Should switch to twitter window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            //Check twitter link
            Assert.That(Driver.Url.Contains(twitterLink), "Twitter link invalid!");
            Driver.Close();


            //Should switch to facebook window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.That(Driver.Url.Contains(facebookLink), "Facebook link invalid!");
            Driver.Close();

            //Switch back to selenium page window
            Driver.SwitchTo().Window(current);
            homePage.ClickFollowAll();

            //Switch to facebook window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.That(Driver.Url.Contains(facebookLink), "Facebook link invalid!");
            Driver.Close();

            //Switch to google plus window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.That(Driver.Url.Contains(twitterLink), "Twitter link invalid!");
            Driver.Close();

            //Switch to google plus window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Assert.That(Driver.Url.Contains(googleplusLink), "Google Plus link invalid!");
            Driver.Close();
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}

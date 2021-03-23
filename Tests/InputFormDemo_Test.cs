using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using seleniumeasy_Test.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace seleniumeasy_Test.Tests
{
    class InputFormDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_InputFormDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/input-form-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test] //PRELOŠE
        
        public void SendWhileEmpty()
        {
            //Tests if error messages are displayed at the page load
            if (!homePage.FirstNameMessage.Displayed && !homePage.LastNameMessage.Displayed && !homePage.EmailMessage.Displayed
                && !homePage.PhoneMessage.Displayed && !homePage.AddressMessage.Displayed && !homePage.CityMessage.Displayed
                && !homePage.StateMessage.Displayed && !homePage.ProjectDescriptionMessage.Displayed)
                Assert.Pass();
            else
                Assert.Fail("Invalid: One or more error messages displayed when they shouldnt have been!");

            //Press "Send" and check if error messages displayed
            homePage.ClickFormSend();
            if (homePage.FirstNameMessage.Displayed && homePage.LastNameMessage.Displayed && homePage.EmailMessage.Displayed
                && homePage.PhoneMessage.Displayed && homePage.AddressMessage.Displayed && homePage.CityMessage.Displayed
                && homePage.StateMessage.Displayed && homePage.ProjectDescriptionMessage.Displayed)
                Assert.Pass();
            else
                Assert.Fail("Invalid: One or more error messages NOT displayed!");
        }

    }
}

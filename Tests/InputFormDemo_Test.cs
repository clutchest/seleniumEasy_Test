using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using seleniumeasy_Test.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        [Test]
        public void InputThenSend()
        {
            homePage.FirstName.SendKeys("Fran");
            homePage.ClickFormSend();
            Assert.AreEqual(false, homePage.FirstNameMessage.Displayed, "First name text error! " + homePage.FirstNameMessage.Text);
            homePage.Refresh();
            Thread.Sleep(1000);

            homePage.LastName.SendKeys("Kirby");
            homePage.ClickFormSend();
            Assert.AreEqual(false, homePage.LastNameMessage.Displayed, "Last name text error! " + homePage.LastNameMessage.Text);
            homePage.Refresh();
            Thread.Sleep(1000);

            homePage.Email.SendKeys("frankirby@gmail.com");
            homePage.ClickFormSend();
            Assert.AreEqual(false, homePage.EmailMessage.Displayed, "Email text error! " + homePage.EmailMessage.Text);
            homePage.Refresh();
            Thread.Sleep(1000);

            homePage.Phone.SendKeys("0919391777");
            homePage.ClickFormSend();
            Assert.AreEqual(false, homePage.PhoneMessage.Displayed, "Phone number error! " + homePage.PhoneMessage.Text);
            homePage.Refresh();
            Thread.Sleep(1000);

            homePage.Address.SendKeys("Fulham Road 19");
            homePage.ClickFormSend();
            Assert.AreEqual(false, homePage.AddressMessage.Displayed, "Address text error! " + homePage.AddressMessage.Text);
            homePage.Refresh();
            Thread.Sleep(1000);


        }

    }
}

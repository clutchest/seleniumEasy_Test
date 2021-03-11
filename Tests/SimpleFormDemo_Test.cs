using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using seleniumeasy_Test.Pages;

namespace seleniumeasy_Test.Tests
{
    class SimpleFormDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_SimpleFormDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();

        }

        //For performance maybe unite both tests cos each opens new chrome, but this way is more readable
        [Test]
        public void SingleInputField()
        {
            homePage.EnterMessage("Some message");
            //Compare the entered message to the displayed message and pass the test if equal
            Assert.AreEqual(homePage.MessageField.GetAttribute("value"), homePage.DisplayedMessage.Text, "SingleInputField: Entered and displayed message are not the same");
        }
        
        [Test]
        public void TwoInputFields()
        {
            homePage.AddNumber(754, 51);
            //Compare the sum of entered numbers to expected sum and pass the test if equal
            Assert.AreEqual(homePage.sum.ToString(), homePage.ExpectedSum.Text, "TwoInputFields: Sum of entered numbers and expected sum are not the same");
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }

    }
}

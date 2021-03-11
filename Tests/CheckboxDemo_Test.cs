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
    class CheckboxDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_CheckboxDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void SingleCheckbox()
        {
            //When checkbox is not ticked - assert that text is not displayed
            if(!homePage.Checkbox.Selected)
            Assert.That(!homePage.CheckBoxText.Displayed, "Checkbox text displayed while checkbox is unchecked");

            //Tick the checkbox
            homePage.ClickCheckbox();

            //When checkbox is ticked - assert that text is displayed
            if(homePage.Checkbox.Selected)
            Assert.That(homePage.CheckBoxText.Displayed, "Checkbox text is not displayed while checkbox is checked");

            //Check if valid text is displayed
            string _message = "Success - Check box is checked";

            Assert.AreEqual(_message, homePage.CheckBoxText.Text, "Valid message is not displayed");
        }

        [Test]
        public void MultipleCheckbox()
        {
            string _checked = "Check All";
            string _unchecked = "Uncheck All";

            //Pass the test if correct button text is displayed when one or more checkboxes are ticked
            Assert.AreEqual(_checked, homePage.CheckAll.GetAttribute("value"), "Check All button doesnt display correct message");

            //Tick all checkboxes
            homePage.CheckAll.Click();

            //Pass the test if correct button text is displayed when all checkboxes are ticked
            Assert.AreEqual(_unchecked, homePage.CheckAll.GetAttribute("value"), "Uncheck All button doesnt display correct message");
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }

    }
}

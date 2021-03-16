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
    class DropdownDemo_Test
    {

        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_DropwdownDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void SingleSelectList()
        {
            //Finds the dropdown element
            homePage.DaysDropdown = new SelectElement(Driver.FindElement(By.Id("select-demo")));

            //Check if nothing is selected when the page is loaded
            Assert.That(homePage.DaysDropdown.SelectedOption.Text == "Please select", "Dropdown test failed: Text of the selected option invalid! (index 0)");

            //Calling method from homePage that accepts parameter "index" and tests displayed day and message based on given index 
            homePage.SelectListTest(1);
            homePage.SelectListTest(2);
            homePage.SelectListTest(3);
            homePage.SelectListTest(4);
            homePage.SelectListTest(5);
            homePage.SelectListTest(6);
            homePage.SelectListTest(7);
        }

        [Test]
        public void MultiSelectList()
        {
            //Finds the selected element
            homePage.StatesList = new SelectElement(Driver.FindElement(By.Id("multi-select")));
            
            //Check if nothing is selected when the page is loaded
            homePage.ClickFirstSelected();
            Assert.That(homePage.MultiMessage.Contains("undefined"), "Multiselect dropdown test failed: Nothing should be selected when the page is loaded!");
            
            //Select options one by one and assert everything is working as expected
            homePage.MultiSelectListTest();
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }


    }
}

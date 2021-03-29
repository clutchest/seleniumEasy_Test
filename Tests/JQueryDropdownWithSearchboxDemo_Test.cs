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
    class JQueryDropdownWithSearchboxDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_JQueryDropdownWithSearchbox()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/jquery-dropdown-search-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void JQuerySingleSelect()
        {
            //Inputs the name of country into search bar, selects the displayed country and assert pass if equal
            homePage.SingleSelect("Australia");
            homePage.SingleSelect("Bangladesh");
            homePage.SingleSelect("Denmark");
            homePage.SingleSelect("Hong Kong");
            homePage.SingleSelect("India");
            homePage.SingleSelect("Japan");
            homePage.SingleSelect("Netherlands");
            homePage.SingleSelect("New Zealand");
            homePage.SingleSelect("South Africa");
            homePage.SingleSelect("United States of America");
        }

        [Test]
        public void JQueryMultiSelect()
        {
            homePage.JQueryMultiSelectTest("AL", "Alabama");
            homePage.JQueryMultiSelectTest("AK", "Alaska");
            homePage.JQueryMultiSelectTest("AZ", "Arizona");
            homePage.JQueryMultiSelectTest("AR", "Arkansas");
            homePage.JQueryMultiSelectTest("CA", "California");
            homePage.JQueryMultiSelectTest("CO", "Colorado");
            homePage.JQueryMultiSelectTest("CT", "Connecticut");
            homePage.JQueryMultiSelectTest("DE", "Delaware");
            homePage.JQueryMultiSelectTest("DC", "District Of Columbia");
            homePage.JQueryMultiSelectTest("FL", "Florida");
            homePage.JQueryMultiSelectTest("GA", "Georgia");
            homePage.JQueryMultiSelectTest("HI", "Hawaii");
            homePage.JQueryMultiSelectTest("ID", "Idaho");
            homePage.JQueryMultiSelectTest("IL", "Illinois");
            homePage.JQueryMultiSelectTest("IN", "Indiana");
            homePage.JQueryMultiSelectTest("IA", "Iowa");
            homePage.JQueryMultiSelectTest("KS", "Kansas");
            homePage.JQueryMultiSelectTest("KY", "Kentucky");
            homePage.JQueryMultiSelectTest("LA", "Louisiana");
            homePage.JQueryMultiSelectTest("ME", "Maine");
            homePage.JQueryMultiSelectTest("MD", "Maryland");
            homePage.JQueryMultiSelectTest("MA", "Massachusetts");
            homePage.JQueryMultiSelectTest("MI", "Michigan");
            homePage.JQueryMultiSelectTest("MN", "Minnesota");
            homePage.JQueryMultiSelectTest("MS", "Mississippi");
            homePage.JQueryMultiSelectTest("MO", "Missouri");
            homePage.JQueryMultiSelectTest("MT", "Montana");
            homePage.JQueryMultiSelectTest("NE", "Nebraska");
            homePage.JQueryMultiSelectTest("NV", "Nevada");
            Console.WriteLine("Valid: Every state is addable!");

        }

        [Test]
        public void DropdownWithDisabledValues()
        {
            homePage.DropdownWithDisabled("AS", "American Samoa");
            homePage.DropdownWithDisabled("MP", "Northern Mariana Islands");
            homePage.DropdownWithDisabled("PR", "Puerto Rico");
            homePage.DropdownWithDisabled("VI", "Virgin Islands");
        }


        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
								

                                
}

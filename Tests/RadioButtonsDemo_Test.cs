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
    class RadioButtonsDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_RadioButtonsDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-radiobutton-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void RadioButton()
        {
            //Check gender: Male
            string _male = "Radio button 'Male' is checked";
            homePage.RadioButton_Male.Click();
            homePage.ClickGenderCheck();
            Assert.AreEqual(_male, homePage.GenderCheckResult.Text, "Invalid message displayed when male radio button is selected");

            //Check gender: Female
            string _female = "Radio button 'Female' is checked";
            homePage.RadioButton_Female.Click();
            homePage.ClickGenderCheck();
            Assert.AreEqual(_female, homePage.GenderCheckResult.Text, "Invalid message displayed when female radio button is selected");
        }

        [Test]
        public void GroupRadioButtons()
        {
            string _male = "Sex : Male";
            string _female = "Sex : Female";
            
            //Select "Male"
            homePage.Group_Male.Click();

            //If gender male is selected
            if (homePage.Group_Male.Selected)
            {
                homePage.ClickGetValues();
                Assert.That(homePage.GroupRadioResult.Text.Contains(_male), "Invalid results displayed regarding gender: Male");
            }
            
            //Select "Female"
            homePage.Group_Female.Click();

            //If gender female is selected
            if (homePage.Group_Female.Selected)
            {
                homePage.ClickGetValues();
                Assert.That(homePage.GroupRadioResult.Text.Contains(_female), "Invalid results displayed regarding gender: Female");
            }

            string _group1 = "Age group: 0 - 5";
            string _group2 = "Age group: 5 - 15";
            string _group3 = "Age group: 15 - 50";

            //Select age group 1
            homePage.AgeGroup1.Click();
            
            //If age 0-5 is selected
            if(homePage.AgeGroup1.Selected)
            {
                homePage.ClickGetValues();
                Assert.That(homePage.GroupRadioResult.Text.Contains(_group1), "Invalid results displayed regarding age: Group 1 (age 0-5)");
            }

            //Select age group 2
            homePage.AgeGroup2.Click();

            if(homePage.AgeGroup2.Selected)
            {
                homePage.ClickGetValues();
                Assert.That(homePage.GroupRadioResult.Text.Contains(_group2), "Invalid results displayed regarding age: Group 2 (age 5-15)");
            }

            //Select age group 3
            homePage.AgeGroup3.Click();

            if(homePage.AgeGroup3.Selected)
            {
                homePage.ClickGetValues();
                Assert.That(homePage.GroupRadioResult.Text.Contains(_group3), "Invalid results displayed regarding age: Group 3 (age 15-50)");
            }

        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}

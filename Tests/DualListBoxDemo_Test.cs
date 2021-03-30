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
    class DualListBoxDemo_Test
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
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/bootstrap-dual-list-box-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void ItemsDisplayedAndSelectable()
        {
            foreach (var element in homePage.AllItems)
            {
                //Check if every element is displayed and inactive
                Assert.IsTrue(element.Displayed, "Invalid: Element is not displayed! " + element.Text);
                Assert.IsTrue(!element.GetAttribute("class").Contains("active"), "Invalid: Element is active on page load! " + element.Text);

                //Check if every element is selectable (can become active)
                element.Click();
                Assert.IsTrue(element.GetAttribute("class").Contains("active"), "Invalid: Element cant be selected! " + element.Text);
                Console.WriteLine("Element " + element.Text + " IS SELECTABLE!");
            }
        }

        [Test]
        public void ItemsMovable()
        {
            //Assert pass if items are in the right place
            Assert.IsTrue(homePage.LeftBoxItems.Count == 5, "Invalid: Left box items count error!");
            Assert.IsTrue(homePage.RightBoxItems.Count == 5, "Invalid: Right box items count error!");

            //Select every left box item
            foreach(var element in homePage.LeftBoxItems)
            {
                element.Click();
            }
            //Move items to right box
            homePage.ClickMoveRight();
            //Refresh right box items
            IReadOnlyCollection<IWebElement> RightBoxItems = homePage.RightBoxHolder.FindElements(By.ClassName("list-group-item"));
            //Assert pass if every element from left box is movable to right box
            Assert.IsTrue(homePage.RightBoxItems.Count == 10, "Invalid: One or more items unmovable!");

            //Select every right box item
            foreach (var element in homePage.RightBoxItems)
            {
                if(!element.GetAttribute("class").Contains("active"))
                element.Click();
            }
            //Move items to right box
            homePage.ClickMoveLeft();
            //Assert pass if every element from right box is movable to left box
            IReadOnlyCollection<IWebElement> LeftBoxItems = homePage.LeftBoxHolder.FindElements(By.ClassName("list-group-item"));
            Assert.IsTrue(homePage.LeftBoxItems.Count == 10, "Invalid: One or more items unmovable!");  
    }
        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}

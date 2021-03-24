using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using seleniumeasy_Test.Pages;
using System;

namespace seleniumeasy_Test.Tests
{
    class AjaxFormDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_AjaxFormDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/ajax-form-submit-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }


        [Test]
        public void AjaxSubmit()
        {
            homePage.Description.SendKeys("This is the comment");
            homePage.ClickAjaxSubmit();

            Assert.AreEqual("border: 1px solid rgb(255, 0, 0);", homePage.Title.GetAttribute("style"), "Invalid: Comment name not working as expected!");
            Assert.AreEqual(true, homePage.AjaxSubmitButton.Enabled, "Invalid: Ajax submit button disabled!");

            homePage.Title.SendKeys("Comment name");
            homePage.ClickAjaxSubmit();

            Assert.AreEqual(string.Empty, homePage.Title.GetAttribute("style"), "Invalid: Comment name not working as expected!");

            WebDriverWait WaitProcessing = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            WaitProcessing.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(homePage.AjaxFormMessage,"Ajax Request is Processing!"));
            Assert.AreEqual("Ajax Request is Processing!", homePage.AjaxFormMessage.Text, "Invalid: Ajax request not processing!");


            WebDriverWait WaitSuccessful = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            WaitSuccessful.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(homePage.AjaxFormMessage, "Form submited Successfully!"));
            Assert.AreEqual("Form submited Successfully!", homePage.AjaxFormMessage.Text, "Invalid: Ajax form unsuccessful!");
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}

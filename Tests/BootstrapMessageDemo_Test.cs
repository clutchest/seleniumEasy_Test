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
    class BootstrapMessageDemo_Test
    {
        IWebDriver Driver;
        HomePage homePage;

        [SetUp]
        public void SetUp_BootstrapMessageDemo()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-application-cache"); // to disable cache

            Driver = new ChromeDriver(options);
            homePage = new HomePage(Driver);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/bootstrap-alert-messages-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void SuccessMessage()
        {
            //Displays autocloseable Success message (5 sec)
            homePage.ClickAutocloseSuccess();
            //Find and stores the auto-closeable message
            IWebElement AutocloseSuccessMessage = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-success.alert-autocloseable-success"));
            //Confirm its displayed
            Assert.That(AutocloseSuccessMessage.Displayed, "Invalid: Auto closeable success message not displayed!");
            //Wait for declared duration
            WebDriverWait waitSuccess = new WebDriverWait(Driver, TimeSpan.FromSeconds(7));
            //Or wait for the element to become invisible and stop the wait
            waitSuccess.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-success.alert-autocloseable-success")));
            Assert.AreEqual(false, AutocloseSuccessMessage.Displayed, "Invalid: Auto closeable succes message displayed when it should have been auto-closed !");
            
            
            //Displays Success message
            homePage.ClickNormalSuccess();
            //Find and stores normal success message
            IWebElement SuccessMessage = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-success.alert-normal-success"));
            //Confirms that the message is displayed
            Assert.That(SuccessMessage.Displayed, "Invalid: Normal success message not displayed!");
            IWebElement CloseSuccessMessageBtn = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-success.alert-normal-success > button"));
            CloseSuccessMessageBtn.Click();
            Assert.That(!SuccessMessage.Displayed, "Invalid: Normal success message displayed after close button clicked!");


        }
    }
}

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

        //Below tests could be done much better and easier to read, declare all elements in homepage script

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
            //Confirms that the success message is auto-closed
            Assert.AreEqual(false, AutocloseSuccessMessage.Displayed, "Invalid: Auto closeable success message displayed when it should have been auto-closed !");
            
            
            //Displays Success message
            homePage.ClickNormalSuccess();
            //Find and stores normal success message
            IWebElement SuccessMessage = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-success.alert-normal-success"));
            //Confirms that the message is displayed
            Assert.That(SuccessMessage.Displayed, "Invalid: Normal success message not displayed!");
            IWebElement CloseSuccessMessageBtn = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-success.alert-normal-success > button"));
            CloseSuccessMessageBtn.Click();
            Assert.That(!SuccessMessage.Displayed, "Invalid: Normal success message STILL displayed after close button clicked!");
        }

        [Test]
        public void WarningMessage()
        {
            //Displays autocloseable Warning message (3 sec)
            homePage.ClickAutocloseWarning();
            //Find and stores the auto-closeable warning message
            IWebElement AutocloseWarningMessage = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-warning.alert-autocloseable-warning"));
            //Confirm its displayed
            Assert.That(AutocloseWarningMessage.Displayed, "Invalid: Auto closeable warning message not displayed!");
            //Wait for declared duration
            WebDriverWait waitWarning = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //Or wait for the element to become invisible and stop the wait
            waitWarning.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-warning.alert-autocloseable-warning")));
            //Confirms that the warning message is autoclosed
            Assert.AreEqual(false, AutocloseWarningMessage.Displayed, "Invalid: Auto closeable warning message displayed when it should have been auto-closed!");

            //Displays Warning message
            homePage.ClickNormalWarning();
            //Finds and stores the normal warning message
            IWebElement WarningMessage = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-warning.alert-normal-warning"));
            //Confirms that the message is displayed
            Assert.That(WarningMessage.Displayed, "Invalid: Normal warning message not displayed!");
            IWebElement CloseWarningMessageBtn = Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.col-md-6 > div.alert.alert-warning.alert-normal-warning > button"));
            CloseWarningMessageBtn.Click();
            Assert.That(!WarningMessage.Displayed, "Invalid: Normal warning message STILL displayed after close button clicked");
        }

        [Test]
        public void DangerMessage()
        {
            //Displays autocloseable Danger message (5 sec)
            homePage.ClickAutocloseDanger();
            //Finds and stores the auto-closeable danger message
            IWebElement AutocloseDangerMessage = Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[5]"));
            //Confirm its displayed
            Assert.That(AutocloseDangerMessage.Displayed, "Invalid: Auto closeable danger message not displayed!");
            //Wait for declared duration
            WebDriverWait waitDanger = new WebDriverWait(Driver, TimeSpan.FromSeconds(7));
            //Or wait for the element to become invisible and stop the wait
            waitDanger.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[5]")));
            //Confirms that the danger message is autoclosed
            Assert.AreEqual(false, AutocloseDangerMessage.Displayed, "/html/body/div[2]/div/div[2]/div/div[2]/div[5]");

            //Displays danger message
            homePage.ClickNormalDanger();
            //Finds and stores the normal danger message
            IWebElement DangerMessage = Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[6]"));
            //Confirms that the message is displayed
            Assert.That(DangerMessage.Displayed, "Invalid: Normal danger message not displayed!");
            //Finds the close button of the normal danger message
            IWebElement CloseDangerMessageBtn = Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[6]/button"));
            CloseDangerMessageBtn.Click();
            Assert.That(!DangerMessage.Displayed, "Invalid: Normal danger message STILL displayed after close button clicked");
        }

        [Test]
        public void InfoMessage()
        {
            //Displays autocloseable Info message (6sec)
            homePage.ClickAutocloseInfo();
            //Finds and stores the auto-closeable info message
            IWebElement AutocloseInfoMessage = Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[7]"));
            //Confirm its displayed
            Assert.That(AutocloseInfoMessage.Displayed, "Invalid: Auto closeable info message not displayed!");
            //Wait for declared duration
            WebDriverWait waitInfo = new WebDriverWait(Driver, TimeSpan.FromSeconds(8));
            //Or wait for the element to become invisible and stop the wait
            waitInfo.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[7]")));
            //Confirms that the danger message is autoclosed
            Assert.AreEqual(false, AutocloseInfoMessage.Displayed, "Invalid: Auto closeable info message displayed when it should have been auto-closed");

            //Displays info message
            homePage.ClickNormalInfo();
            //Finds and stores the normal info message
            IWebElement InfoMessage = Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[8]"));
            //Confirms that the message is displayed
            Assert.That(InfoMessage.Displayed, "Invalid: Normal info message not displayed!");
            //Finds the close button of the normal info message
            IWebElement CloseInfoMessageBtn = Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[2]/div[8]/button"));
            //Close the normal info message
            CloseInfoMessageBtn.Click();
            //Confirm that its closed
            Assert.That(!InfoMessage.Displayed, "Invalid: Normal info message STILL displayed after close button clicked!");
        }

        [TearDown]
        public void CloseDriver()
        {
            Driver.Quit();
        }
    }
}

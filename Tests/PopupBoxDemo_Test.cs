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
    class PopupBoxDemo_Test
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
            Driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/javascript-alert-box-demo.html");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            //Decline alert box
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Build().Perform();
        }

        [Test]
        public void AlertBox()
        {
            //Displays the alert
            //homePage.ClickDisplayAlert();
            IWebElement clickAlert = Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > button"));
            clickAlert.Submit();
            
            //Focus on alert box
            var Alert = Driver.SwitchTo().Alert();
            //Alert box text
            string AlertText = Alert.Text;
            //What should alert box text be if its working as expected
            string ExpectedAlertText = "I am an alert box!";

            Assert.AreEqual(ExpectedAlertText, AlertText, "Invalid alert box text is displayed!");
            
            //Accepts the alert
            Alert.Accept();
        }

        [Test]
        public void ConfirmBox()
        {
            string accepted = "You pressed OK!";
            string declined = "You pressed Cancel!";

            //Displays the confirm box
            homePage.ClickDisplayConfirmBox();
            //Focus on confirm box
            IAlert ConfirmBox = Driver.SwitchTo().Alert();
            //Confirm box text
            ConfirmBox.Accept();
            Assert.AreEqual(accepted, homePage.ConfirmText, "Invalid text displayed when confirm box is accepted");

            //Displays the confirm box
            homePage.ClickDisplayConfirmBox();
            //Focus on confirm box
            ConfirmBox = Driver.SwitchTo().Alert();
            ConfirmBox.Dismiss();
            Assert.AreEqual(declined, homePage.ConfirmText, "Invalid text displayed when confirm box is dismissed");
        }

        [Test]
        public void PromptBox()
        {
            //Displays the prompt box
            homePage.ClickPromptBox();
            //Focus on prompt box
            IAlert PromptBox = Driver.SwitchTo().Alert();
            PromptBox.Dismiss();
            Assert.That(!homePage.PromptBox.Displayed, "Error: Prompt box message is displayed!");

            //Displays the prompt box
            homePage.ClickPromptBox();
            //Focus on prompt box
            PromptBox = Driver.SwitchTo().Alert();
            //Inputs the string
            string name = "Name";
            PromptBox.SendKeys(name);
            PromptBox.Accept();
            Assert.That(homePage.PromptBox.Text.Contains(name), "Invalid prompt box message displayed when prompt box is accepted!");
        }
    }
}

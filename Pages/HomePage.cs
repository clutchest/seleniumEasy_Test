using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace seleniumeasy_Test.Pages
{
    class HomePage
    {
        public IWebDriver Driver { get; }
        public HomePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }


        //MAIN ELEMENTS 
        public IWebElement DemoHomeBtn => Driver.FindElement(By.CssSelector("body > div:nth-child(1) > div:nth-child(2) > nav > div > div.navbar-header > div > a"));


        //SIMPLE FORM TEST ELEMENTS
        public int sum;
        public IWebElement MessageField => Driver.FindElement(By.TagName("input"));
        public IWebElement ShowMessageBtn => Driver.FindElement(By.CssSelector("#get-input > button"));
        public IWebElement DisplayedMessage => Driver.FindElement(By.CssSelector("#display"));
        public IWebElement NumberOne => Driver.FindElement(By.Id("sum1"));
        public IWebElement NumberTwo => Driver.FindElement(By.Id("sum2"));
        public IWebElement ExpectedSum => Driver.FindElement(By.Id("displayvalue"));

        //CHECKBOX TEST ELEMENTS
        public IWebElement Checkbox => Driver.FindElement(By.Id("isAgeSelected"));
        public IWebElement CheckBoxText => Driver.FindElement(By.CssSelector("#txtAge"));
        public IWebElement CheckAll => Driver.FindElement(By.CssSelector("#check1"));

        //CLICKS
        public void ClickHome() => DemoHomeBtn.Click(); //Demo home button
        public void ClickCheckbox() => Checkbox.Click();

        //METHODS

        //Single field message input and click "Show Message"
        public void EnterMessage(string message)
        {
            MessageField.SendKeys(message);
            ShowMessageBtn.Click();
        }

        //Inputs two numbers and clicks "Get Total"
        public int AddNumber(int numberOne, int numberTwo)
        {
            NumberOne.SendKeys(numberOne.ToString());
            NumberTwo.SendKeys(numberTwo.ToString());
            Driver.FindElement(By.CssSelector("#gettotal > button")).Click();
            return sum = numberOne + numberTwo;
        }


    }
}

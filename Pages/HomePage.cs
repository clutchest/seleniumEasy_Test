using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using seleniumeasy_Test.Tests;
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

        //RADIO BUTTONS TEST ELEMENTS
        public IWebElement RadioButton_Male => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > label:nth-child(2) > input[type=radio]"));
        public IWebElement RadioButton_Female => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > label:nth-child(3) > input[type=radio]"));
        public IWebElement GenderCheckButton => Driver.FindElement(By.Id("buttoncheck"));
        public IWebElement GenderCheckResult => Driver.FindElement(By.ClassName("radiobutton"));
        public IWebElement GroupRadioResult => Driver.FindElement(By.ClassName("groupradiobutton"));
        public IWebElement GroupRadio_Gender => Driver.FindElement(By.ClassName("radio-inline"));
        public IWebElement GetValuesButton => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > button"));
        public IWebElement Group_Male => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(2) > label:nth-child(2) > input[type=radio]"));
        public IWebElement Group_Female => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(2) > label:nth-child(3) > input[type=radio]"));
        public IWebElement AgeGroup1 => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label:nth-child(2) > input[type=radio]"));
        public IWebElement AgeGroup2 => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label:nth-child(3) > input[type=radio]"));
        public IWebElement AgeGroup3 => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > div:nth-child(3) > label:nth-child(4) > input[type=radio]"));

        //DROPDOWN TEST ELEMENTS
        public IWebElement DropdownMessage => Driver.FindElement(By.ClassName("selected-value"));
        public SelectElement DaysDropdown;
        public SelectElement StatesList;
        public void ClickFirstSelected() => Driver.FindElement(By.Id("printMe")).Click();
        public void ClickAllSelected() => Driver.FindElement(By.Id("printAll")).Click();
        public string MultiMessage => Driver.FindElement(By.ClassName("getall-selected")).Text;

        //CLICKS
        public void ClickCheckbox() => Checkbox.Click();
        public void ClickGenderCheck() => GenderCheckButton.Click();
        public void ClickGetValues() => GetValuesButton.Click();

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

        //Check single select dropdown 
        public void SelectListTest(int index)
        {
            DaysDropdown.SelectByIndex(index);
            string day = DaysDropdown.SelectedOption.Text;
            string message = "Day selected :- " + day;
            Assert.That(DaysDropdown.SelectedOption.Text == day, "Dropdown test failed: Text of the selected option invalid! (" + day + ")");
            Assert.AreEqual(DropdownMessage.Text, message, "Dropdown message test failed: Message text of the selected option invalid! (" + day + ")");
        }

        //Check multi select dropdown list
        public void MultiSelectListTest()
        {
            int count = StatesList.Options.Count;

            for (int i = 0; i < count; i++)
            {
                //Selects the option 
                StatesList.SelectByIndex(i);
                //Calculates the text of the message and stores it
                string option = "First selected option is : " + StatesList.SelectedOption.Text;

                //Updates message
                ClickFirstSelected();
                //Check if texts match
                Assert.AreEqual(option, MultiMessage, "Multiselect dropdown test failed: Texts do not match! (index " + i + ")");
                //Deselects previously selected option in this loop
                StatesList.DeselectByIndex(i);
            }

        }
    }
}

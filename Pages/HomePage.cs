using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        #region //SIMPLE FORM TEST ELEMENTS
        public int sum;
        public IWebElement MessageField => Driver.FindElement(By.TagName("input"));
        public IWebElement ShowMessageBtn => Driver.FindElement(By.CssSelector("#get-input > button"));
        public IWebElement DisplayedMessage => Driver.FindElement(By.CssSelector("#display"));
        public IWebElement NumberOne => Driver.FindElement(By.Id("sum1"));
        public IWebElement NumberTwo => Driver.FindElement(By.Id("sum2"));
        public IWebElement ExpectedSum => Driver.FindElement(By.Id("displayvalue"));
        #endregion

        #region //CHECKBOX TEST ELEMENTS
        public IWebElement Checkbox => Driver.FindElement(By.Id("isAgeSelected"));
        public IWebElement CheckBoxText => Driver.FindElement(By.CssSelector("#txtAge"));
        public IWebElement CheckAll => Driver.FindElement(By.CssSelector("#check1"));
        public void ClickCheckbox() => Checkbox.Click();
        #endregion

        #region //RADIO BUTTONS TEST ELEMENTS
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
        public void ClickGenderCheck() => GenderCheckButton.Click();
        public void ClickGetValues() => GetValuesButton.Click();
        #endregion

        #region //DROPDOWN TEST ELEMENTS
        public IWebElement DropdownMessage => Driver.FindElement(By.ClassName("selected-value"));
        public SelectElement DaysDropdown;
        public SelectElement StatesList;
        public void ClickFirstSelected() => Driver.FindElement(By.Id("printMe")).Click();
        public void ClickAllSelected() => Driver.FindElement(By.Id("printAll")).Click();
        public string MultiMessage => Driver.FindElement(By.ClassName("getall-selected")).Text;
        #endregion

        #region //POPUP BOXES TEST ELEMENTS
        public void ClickDisplayAlert() => Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/button")).Submit();
        public void ClickDisplayConfirmBox() => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(5) > div.panel-body > button")).Submit();
        public string ConfirmText => Driver.FindElement(By.Id("confirm-demo")).Text;
        public void ClickPromptBox() => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(6) > div.panel-body > button")).Submit();
        public IWebElement PromptBox => Driver.FindElement(By.Id("prompt-demo"));
        public void ClickFollowAll() => Driver.FindElement(By.Id("followall")).Click();
        #endregion

        #region //WINDOW POPUP TEST ELEMENTS
        public void ClickTwitter() => Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div/div[2]/div[1]/a")).Click();
        public void ClickFacebook() => Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div/div[2]/div[2]/a")).Click();
        public void ClickTwitterAndFacebook() => Driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div/div[2]/div[1]/a")).Click();
        #endregion

        #region //BOOTSTRAP MESSAGES

        public void ClickAutocloseSuccess() => Driver.FindElement(By.CssSelector("#autoclosable-btn-success")).Click();
        public void ClickNormalSuccess() => Driver.FindElement(By.Id("normal-btn-success")).Click();

        public void ClickAutocloseWarning() => Driver.FindElement(By.Id("autoclosable-btn-warning")).Click();
        public void ClickNormalWarning() => Driver.FindElement(By.Id("normal-btn-warning")).Click();

        public void ClickAutocloseDanger() => Driver.FindElement(By.Id("autoclosable-btn-danger")).Click();
        public void ClickNormalDanger() => Driver.FindElement(By.Id("normal-btn-danger")).Click();

        public void ClickAutocloseInfo() => Driver.FindElement(By.Id("autoclosable-btn-info")).Click();
        public void ClickNormalInfo() => Driver.FindElement(By.Id("normal-btn-info")).Click();
        #endregion

        #region //INPUT FORM ELEMENTS
        public IWebElement FirstName => Driver.FindElement(By.Name("first_name"));
        public IWebElement LastName => Driver.FindElement(By.Name("last_name"));
        public IWebElement Email => Driver.FindElement(By.Name("email"));
        public IWebElement Phone => Driver.FindElement(By.Name("phone"));
        public IWebElement Address => Driver.FindElement(By.Name("address"));
        public IWebElement City => Driver.FindElement(By.Name("city"));
        public SelectElement State => new SelectElement(Driver.FindElement(By.Name("state")));
        public IWebElement ZipCode => Driver.FindElement(By.Name("zip"));
        public IWebElement Website => Driver.FindElement(By.Name("website"));
        public IWebElement ProjectDescription => Driver.FindElement(By.Name("comment"));
        public IList<IWebElement> ErrorMessagesList => Driver.FindElements(By.CssSelector("#contact_form > fieldset > div:nth-child(2) > div > small:nth-child(4)"));
        public void ClickFormSend() => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(14) > div > button")).Click();

        //Error messages
        public IWebElement FirstNameMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(2) > div > small:nth-child(4)"));
        public IWebElement LastNameMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(3) > div > small:nth-child(4)"));
        public IWebElement EmailMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(4) > div > small:nth-child(3)"));
        public IWebElement PhoneMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(5) > div > small:nth-child(3)"));
        public IWebElement AddressMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(6) > div > small:nth-child(4)"));
        public IWebElement CityMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(7) > div > small:nth-child(4)"));
        public IWebElement StateMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(7) > div > small:nth-child(4)"));
        public IWebElement ZipCodeMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(9) > div > small:nth-child(3)"));
        public IWebElement ProjectDescriptionMessage => Driver.FindElement(By.CssSelector("#contact_form > fieldset > div:nth-child(12) > div > small:nth-child(4)"));

        public void Refresh() => Driver.Navigate().Refresh();
        #endregion

        #region //AJAX FORM SUBMIT ELEMENTS
        public IWebElement Title => Driver.FindElement(By.Id("title"));
        public IWebElement Description => Driver.FindElement(By.Id("description"));
        public void ClickAjaxSubmit() => Driver.FindElement(By.CssSelector("#btn-submit")).Click();
        public IWebElement AjaxFormMessage => Driver.FindElement(By.Id("submit-control"));
        public IWebElement AjaxSubmitButton => Driver.FindElement(By.Id("btn-submit"));
        #endregion

        #region //JQUERY DROPDOWN WITH SEARCH ELEMENTS

        //SINGLE
        public SelectElement Dropdown;
        public IReadOnlyCollection<IWebElement> DropdownStates;
        public IWebElement SearchJQuery => Driver.FindElement(By.CssSelector("body > span > span > span.select2-search.select2-search--dropdown > input"));
        public void ClickShowDropdown() => Driver.FindElement(By.ClassName("select2-selection__arrow")).Click();
        public IWebElement Selected => Driver.FindElement(By.ClassName("select2-selection__rendered"));

        //MULTI
        public IWebElement StateSearchbox => Driver.FindElement(By.ClassName("select2-search__field"));
        //<select class>
        public SelectElement Select => new SelectElement(Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div:nth-child(3) > div > div.panel-body > select")));
        public IReadOnlyCollection<IWebElement> SelectedStates => Driver.FindElements(By.ClassName("select2-selection__choice"));

        //WITH DISABLED OPTIONS
        public SelectElement DisabledSelect => new SelectElement(Driver.FindElement(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div:nth-child(4) > div > div.panel-body > select")));
        
        
        #endregion

        #region //DUAL LIST BOX EXAMPLE
        public IReadOnlyCollection<IWebElement> LeftBox => Driver.FindElements(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.dual-list.list-left.col-md-5 > div > ul"));
        public IReadOnlyCollection<IWebElement> RightBox => Driver.FindElements(By.CssSelector("body > div.container-fluid.text-center > div > div.col-md-6.text-left > div > div.dual-list.list-right.col-md-5 > div > ul"));
        

        #endregion


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

        //Hardcoded method for pressing enter key
        public void PressEnter()
        {
            Actions PressEnter = new Actions(Driver);
            PressEnter.SendKeys(Keys.Enter).Build().Perform();
        }
        //Test single select country
        public void SingleSelect(string country)
        {
            ClickShowDropdown();
            SearchJQuery.SendKeys(country);
            PressEnter();
            Assert.AreEqual(country, Selected.GetAttribute("title").ToString(), "Invalid country selected! Involving: " + Selected.GetAttribute("title").ToString()); ;
        }
        //Test multiple select states
        public void JQueryMultiSelectTest(string value, string state)
        {
            Select.SelectByValue(value);
            foreach (IWebElement stater in SelectedStates)
            {
                Assert.AreEqual(stater.GetAttribute("title"), state.ToString(), "Invalid: State not addable! " + stater.GetAttribute("title"));
            }
            Select.DeselectAll();
        }
        //Test dropdown with disabled states
        public void DropdownWithDisabled(string value, string state)
        {
            DisabledSelect.SelectByValue(value);
            Assert.AreEqual(state, DisabledSelect.SelectedOption.Text, "Invalid: Problem with dropdown with disabled values!");
            //Console.WriteLine(DisabledSelect.SelectedOption.GetAttribute("title").ToString());
        }
    }
}

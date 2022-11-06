

using ManoDaktarasPageTesting.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace ParkingCostCalculator.Page
{
    public class ValetParkingErrorMessagePage : BasePage
    {
        private const string pageAddres = "https://www.shino.de/parkcalc/";
        private const string errorMessage = "ERROR! YOUR LEAVING DATE OR TIME IS BEFORE YOUR STARTING DATE OR TIME";

        private IWebElement CalendarEntry => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(2) > td:nth-child(2) > a > img"));
        private IWebElement TwentyFifthDayEntry => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(8) > td:nth-child(3) > font > a"));
        private IWebElement CalendarLeaving => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(3) > td:nth-child(2) > a > img"));
        private IWebElement FourthDayLeaving => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(5) > td:nth-child(3) > font > a"));
        private IWebElement ClickLeavingPM => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(3) > td:nth-child(2) > input[type=radio]:nth-child(5)"));
        private IWebElement ChoosingEntryTime => Driver.FindElement(By.Id("StartingTime"));
        private IWebElement ChoosingLeavingDate => Driver.FindElement(By.Id("LeavingTime"));
        private IWebElement ClickCalculate => Driver.FindElement(By.CssSelector("body > form > input[type=submit]:nth-child(3)"));
        private IWebElement ErrorMessageIs => Driver.FindElement(By.XPath("/html/body/form/table/tbody/tr[4]/td[2]/b"));
        private SelectElement monthSelection => new SelectElement(Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(1) > td > table > tbody > tr > td:nth-child(1) > select")));
        public ValetParkingErrorMessagePage(IWebDriver driver) : base(driver) { }

        public void navigateToPage()
        {
            Driver.Url = pageAddres;
        }
        public void calendarEntryClick()
        {
            CalendarEntry.Click();
        }
        public void TwentyFifthDayEntryClick()
        {
            TwentyFifthDayEntry.Click();
        }

        public void calenderPopUpWindow()
        {
            var originalWindow = Driver.CurrentWindowHandle;

            foreach (var window in Driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    Driver.SwitchTo().Window(window);
                    break;
                }

            }
        }
        public void switchToOriginal()
        {

            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        public void calendarLeavingClick()
        {
            CalendarLeaving.Click();
        }
        public void fourthDayLeavingClick()
        {
            FourthDayLeaving.Click();
        }
        public void clickLeavingPMClick()
        {
            ClickLeavingPM.Click();
        }
        public void choosingparkingEntryTime(string entryTime)
        {
            ChoosingEntryTime.Click();
            ChoosingEntryTime.Clear();
            ChoosingEntryTime.Clear();
            ChoosingEntryTime.SendKeys(entryTime);
        }
        public void choosingParkingLeavingDate(string leavingTime)
        {
            ChoosingLeavingDate.Click();
            ChoosingLeavingDate.Clear();
            ChoosingLeavingDate.Clear();
            ChoosingLeavingDate.SendKeys(leavingTime);
        }
        public void clickingCalculate()
        {
            ClickCalculate.Click();
        }
        public void verifyResult()
        {
           
            Assert.AreEqual(errorMessage, ErrorMessageIs.Text, "estimated Parking Cost is wrong");
        }
        public void selectMonth(string month)
        {
            monthSelection.SelectByText(month);
        }





    }
}



using ManoDaktarasPageTesting.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace ParkingCostCalculator.Page
{
    public class ValetParkingFromFirstDayToTodayPage : BasePage

    {
        private const string pageAddres = "https://www.shino.de/parkcalc/";
        private IWebElement CalendarEntry => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(2) > td:nth-child(2) > a > img"));
        private IWebElement FirtDayEntry => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(4) > td:nth-child(3) > font > a"));
        private IWebElement CalendarLeaving => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(3) > td:nth-child(2) > a > img"));
        private IWebElement TodayDateLeaving => Driver.FindElement(By.LinkText(DateTime.Today.Day.ToString()));
        private IWebElement ClickLeavingPM => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(3) > td:nth-child(2) > input[type=radio]:nth-child(5)"));
        private IWebElement ChoosingEntryTime => Driver.FindElement(By.Id("StartingTime"));
        private IWebElement ChoosingLeavingDate => Driver.FindElement(By.Id("LeavingTime"));
        private IWebElement ClickCalculate => Driver.FindElement(By.CssSelector("body > form > input[type=submit]:nth-child(3)"));
        private IWebElement EstimatedParkingCost => Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(4) > td:nth-child(2) > span.SubHead > b"));
        private SelectElement monthSelection => new SelectElement(Driver.FindElement(By.CssSelector("body > form > table > tbody > tr:nth-child(1) > td > table > tbody > tr > td:nth-child(1) > select")));

        public ValetParkingFromFirstDayToTodayPage(IWebDriver driver) : base(driver) { }

        public void navigateToPage()
        {
            Driver.Url = pageAddres;
        }
        public void calendarEntryClick()
        {
            CalendarEntry.Click();
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

        public void firstEntryDayClick()
        {

            FirtDayEntry.Click();

        }
        public void calendarLeavingClick()
        {
            CalendarLeaving.Click();
        }
        public void todayDateLeavingClick()
        {
            TodayDateLeaving.Click();
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
        public void selectMonth(string month)
        {
            monthSelection.SelectByText(month);
        }
        public void verifyResult(string parkingCost)
        {

            Assert.AreEqual(parkingCost, EstimatedParkingCost.Text, "estimated Parking Cost is wrong");
        }






    }
}

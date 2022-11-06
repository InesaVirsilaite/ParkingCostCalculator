

using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using ParkingCostCalculator.Page;
using MyDemo.Tools;
using NUnit.Framework.Interfaces;
using System;
using ManoDaktarasPageTesting.Test;

namespace ParkingCostCalculator.Test
{
    public class ValetParkingTodayOneHourTest : BaseTest
    {
        [Test]
        [TestCase("8:00", "9:00", "$ 12.00", TestName = "8:00-9:00")]
        [TestCase("9:00", "10:00", "$ 12.00", TestName = "9:00-10:00")]
        [TestCase("10:00", "11:00", "$ 12.00", TestName = "10:00-11:00")]
        [TestCase("11:00", "12:00", "$ 0.00", TestName = "11:00-12:00")]
        [TestCase("12:00", "13:00", "$ 18.00", TestName = "12:00-13:00")]
        public static void ValetParkingTodayForOneHour(string entryTime, string leavingTime, string parkingCost)
        {
            ValetParkingTodayOneHourPage oneHourpage = new ValetParkingTodayOneHourPage(driver);

            oneHourpage.navigateToPage();
            oneHourpage.calendarEntryClick();
            oneHourpage.calenderPopUpWindow();
            oneHourpage.todayEntryDayClick();
            oneHourpage.switchToOriginal();
            oneHourpage.calendarLeavingClick();
            oneHourpage.calenderPopUpWindow();
            oneHourpage.todayDateLeavingClick();
            oneHourpage.switchToOriginal();
            oneHourpage.choosingparkingEntryTime(entryTime);
            oneHourpage.choosingParkingLeavingDate(leavingTime);
            oneHourpage.clickingCalculate();
            oneHourpage.verifyResult(parkingCost);
        }

    }
}

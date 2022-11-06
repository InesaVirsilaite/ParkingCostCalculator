

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
    public class ValetParkingTodayTest : BaseTest
    {
        [Test]
        [TestCase("8:00", "9:00", "$ 12.00", TestName = "8:00-9:00")]
        [TestCase("9:00", "10:00", "$ 12.00", TestName = "9:00-10:00")]
        [TestCase("10:00", "11:00", "$ 12.00", TestName = "10:00-11:00")]
        [TestCase("11:00", "12:00", "$ 0.00", TestName = "11:00-12:00")]
        [TestCase("12:00", "13:00", "$ 18.00", TestName = "12:00-13:00")]
        public static void ValetParkingToday(string entryTime, string leavingTime, string parkingCost)
        {
            ValetParkingTodayPage todayPage = new ValetParkingTodayPage(driver);

            todayPage.navigateToPage();
            todayPage.calendarEntryClick();
            todayPage.calenderPopUpWindow();
            todayPage.todayEntryDayClick();
            todayPage.switchToOriginal();
            todayPage.calendarLeavingClick();
            todayPage.calenderPopUpWindow();
            todayPage.todayDateLeavingClick();
            todayPage.switchToOriginal();
            todayPage.choosingparkingEntryTime(entryTime);
            todayPage.choosingParkingLeavingDate(leavingTime);
            todayPage.clickingCalculate();
            todayPage.verifyResult(parkingCost);
        }

    }
}

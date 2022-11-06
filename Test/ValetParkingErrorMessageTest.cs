

using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using ParkingCostCalculator.Page;
using MyDemo.Tools;
using NUnit.Framework.Interfaces;
using System;
using System.Runtime.CompilerServices;
using ManoDaktarasPageTesting.Test;

namespace ParkingCostCalculator.Test
{
    public class ValetParkingErrorMessageTest : BaseTest
    {
        [Test]
        public static void ValetParkingeErrorMessage()
        {
            
        ValetParkingErrorMessagePage errorPage = new ValetParkingErrorMessagePage(driver);

            errorPage.navigateToPage();
            errorPage.calendarEntryClick();
            errorPage.calenderPopUpWindow();
            errorPage.TwentyFifthDayEntryClick();
            errorPage.switchToOriginal();
            errorPage.calendarLeavingClick();
            errorPage.calenderPopUpWindow();
            errorPage.fourthDayLeavingClick();
            errorPage.switchToOriginal();
            errorPage.clickLeavingPMClick();
            errorPage.choosingparkingEntryTime("8:00");
            errorPage.choosingParkingLeavingDate("10:00");
            errorPage.clickingCalculate();
            errorPage.verifyResult();
        }

    }
}


using MyDemo.Tools;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using System;
using OpenQA.Selenium;
using ParkingCostCalculator.Page;

namespace ManoDaktarasPageTesting.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        protected static ValetParkingErrorMessagePage errorPage;
        protected static ValetParkingFromFirstDayToTodayPage fromfirstdaytotodaypage;
        protected static ValetParkingTodayOneHourPage oneHourpage;
        protected static ValetParkingTodayPage todayPage;
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new EdgeDriver();
            errorPage = new ValetParkingErrorMessagePage(driver);
            fromfirstdaytotodaypage = new ValetParkingFromFirstDayToTodayPage(driver);
            oneHourpage = new ValetParkingTodayOneHourPage(driver);
            todayPage = new ValetParkingTodayPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
           driver.Quit();
        }




    }
}

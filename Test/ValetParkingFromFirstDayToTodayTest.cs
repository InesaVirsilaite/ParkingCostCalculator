


using ParkingCostCalculator.Page;
using NUnit.Framework;
using ManoDaktarasPageTesting.Test;

namespace ParkingCostCalculator.Test
{
    public class ValetParkingFromFirstDayToTodayTest : BaseTest
    {
        [Test]
        [TestCase("8:00", "10:00", "$ 108.00", TestName = "8:00-10:00")]
        [TestCase("8:00", "11:00", "$ 108.00", TestName = "8:00-11:00")]
        [TestCase("8:00", "12:00", "$ 90.00", TestName = "8:00-12:00")]
        [TestCase("8:00", "13:00", "$ 108.00", TestName = "8:00-13:00")]
        [TestCase("8:00", "14:00", "$ 108.00", TestName = "8:00-14:00")]
        public static void valetparkingfirstdaytotoday(string entrytime, string leavingtime, string parkingcost)
        {
            ValetParkingFromFirstDayToTodayPage fromfirstdaytotodaypage = new ValetParkingFromFirstDayToTodayPage(driver);

            fromfirstdaytotodaypage.navigateToPage();
            fromfirstdaytotodaypage.calendarEntryClick();
            fromfirstdaytotodaypage.calenderPopUpWindow();
            fromfirstdaytotodaypage.firstEntryDayClick();
            fromfirstdaytotodaypage.switchToOriginal();
            fromfirstdaytotodaypage.calendarLeavingClick();
            fromfirstdaytotodaypage.calenderPopUpWindow();
            fromfirstdaytotodaypage.todayDateLeavingClick();
            fromfirstdaytotodaypage.switchToOriginal();
            fromfirstdaytotodaypage.choosingparkingEntryTime(entrytime);
            fromfirstdaytotodaypage.choosingParkingLeavingDate(leavingtime);
            fromfirstdaytotodaypage.clickingCalculate();
            fromfirstdaytotodaypage.verifyResult(parkingcost);
        }

    }
}


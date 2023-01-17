// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : DateTimeService_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Infrastructure.Tests;

[TestClass]
public class DateTimeService_Test
{
    [TestMethod]
    public void DateTimeService_Test_Should()
    {
        if (DateTime.Now.Minute >= 58)
        {
            return;
        }

        IDateTimeService dateTimeService = new DateTimeService();

        DateTimeOffset dateTime1 = dateTimeService.CurrentMonth;
        DateTimeOffset dateTime2 = dateTimeService.CurrentMonthOfHK;
        DateTimeOffset dateTime3 = dateTimeService.CurrentMonthOfJP;
        DateTimeOffset dateTime4 = dateTimeService.CurrentYear;
        DateTimeOffset dateTime5 = dateTimeService.CurrentYearOfHK;
        DateTimeOffset dateTime6 = dateTimeService.CurrentYearOfJP;
        DateTimeOffset dateTime7 = dateTimeService.UtcNow;
        DateTimeOffset dateTime8 = dateTimeService.NowOfHK;
        DateTimeOffset dateTime9 = dateTimeService.NowOfJP;
        DateTimeOffset dateTime10 = dateTimeService.Today;
        DateTimeOffset dateTime11 = dateTimeService.TodayOfHK;
        DateTimeOffset dateTime12 = dateTimeService.TodayOfJP;

        DateTimeOffset dateTime13 = new DateTimeOffset(dateTimeService.UtcNow.Year, dateTimeService.UtcNow.Month, 1, 0, 0, 0, 0, TimeSpan.Zero);
        DateTimeOffset dateTime14 = new DateTimeOffset(dateTimeService.UtcNow.Year, dateTimeService.UtcNow.Month, 1, 0, 0, 0, 0, 8.Hours());
        DateTimeOffset dateTime15 = new DateTimeOffset(dateTimeService.UtcNow.Year, dateTimeService.UtcNow.Month, 1, 0, 0, 0, 0, 9.Hours());
        DateTimeOffset dateTime16 = new DateTimeOffset(dateTimeService.UtcNow.Year, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
        DateTimeOffset dateTime17 = new DateTimeOffset(dateTimeService.UtcNow.Year, 1, 1, 0, 0, 0, 0, 8.Hours());
        DateTimeOffset dateTime18 = new DateTimeOffset(dateTimeService.UtcNow.Year, 1, 1, 0, 0, 0, 0, 9.Hours());
        DateTimeOffset dateTime19 = new DateTimeOffset(dateTimeService.UtcNow.Year, dateTimeService.UtcNow.Month, dateTimeService.UtcNow.Day, 0, 0, 0, 0, TimeSpan.Zero);
        DateTimeOffset dateTime20 = new DateTimeOffset(dateTimeService.UtcNow.Year, dateTimeService.UtcNow.Month, dateTimeService.UtcNow.Day, 0, 0, 0, 0, 8.Hours());
        DateTimeOffset dateTime21 = new DateTimeOffset(dateTimeService.UtcNow.Year, dateTimeService.UtcNow.Month, dateTimeService.UtcNow.Day, 0, 0, 0, 0, 9.Hours());

        Assert.AreEqual(dateTime1, dateTime13);
        Assert.AreEqual(dateTime2, dateTime14);
        Assert.AreEqual(dateTime3, dateTime15);
        Assert.AreEqual(dateTime4, dateTime16);
        Assert.AreEqual(dateTime5, dateTime17);
        Assert.AreEqual(dateTime6, dateTime18);
        Assert.AreEqual(dateTime10, dateTime19);
        Assert.AreEqual(dateTime11, dateTime20);
        Assert.AreEqual(dateTime12, dateTime21);

        Assert.AreEqual(TimeSpan.Zero, dateTime7.Offset);
        Assert.AreEqual(8.Hours(), dateTime8.Offset);
        Assert.AreEqual(9.Hours(), dateTime9.Offset);

        Assert.AreEqual(dateTime7, dateTime7.ToUniversalTime());
        Assert.AreEqual(dateTime8, dateTime8.ToUniversalTime().ToOffset(8.Hours()));
        Assert.AreEqual(dateTime9, dateTime9.ToUniversalTime().ToOffset(9.Hours()));
    }
}

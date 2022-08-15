// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeUtility_Test.cs
// CreatedAt        : 2022-08-06
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeUtility_Test
    {
        [TestMethod]
        public void DateTimeUtility_Test_Should()
        {
            if (DateTime.Now.Minute >= 58)
            {
                return;
            }

            DateTimeOffset dateTime1 = DateTimeUtility.CurrentMonth;
            DateTimeOffset dateTime2 = DateTimeUtility.CurrentMonthOfHK;
            DateTimeOffset dateTime3 = DateTimeUtility.CurrentMonthOfJP;
            DateTimeOffset dateTime4 = DateTimeUtility.CurrentYear;
            DateTimeOffset dateTime5 = DateTimeUtility.CurrentYearOfHK;
            DateTimeOffset dateTime6 = DateTimeUtility.CurrentYearOfJP;
            DateTimeOffset dateTime7 = DateTimeUtility.UtcNow;
            DateTimeOffset dateTime8 = DateTimeUtility.NowOfHK;
            DateTimeOffset dateTime9 = DateTimeUtility.NowOfJP;
            DateTimeOffset dateTime10 = DateTimeUtility.Today;
            DateTimeOffset dateTime11 = DateTimeUtility.TodayOfHK;
            DateTimeOffset dateTime12 = DateTimeUtility.TodayOfJP;

            DateTimeOffset dateTime13 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, DateTimeUtility.UtcNow.Month, 1, 0, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTime14 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, DateTimeUtility.UtcNow.Month, 1, 0, 0, 0, 0, 8.Hours());
            DateTimeOffset dateTime15 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, DateTimeUtility.UtcNow.Month, 1, 0, 0, 0, 0, 9.Hours());
            DateTimeOffset dateTime16 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTime17 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, 1, 1, 0, 0, 0, 0, 8.Hours());
            DateTimeOffset dateTime18 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, 1, 1, 0, 0, 0, 0, 9.Hours());
            DateTimeOffset dateTime19 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, DateTimeUtility.UtcNow.Month, DateTimeUtility.UtcNow.Day, 0, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset dateTime20 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, DateTimeUtility.UtcNow.Month, DateTimeUtility.UtcNow.Day, 0, 0, 0, 0, 8.Hours());
            DateTimeOffset dateTime21 = new DateTimeOffset(DateTimeUtility.UtcNow.Year, DateTimeUtility.UtcNow.Month, DateTimeUtility.UtcNow.Day, 0, 0, 0, 0, 9.Hours());

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
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_IsLastDayOfThisMonth_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_IsLastDayOfThisMonth_Should
    {
        [TestMethod]
        public void IsLastDayOfThisMonth_Should()
        {
            Date r = new Date();
            TimeSpan utcOffset = TimeSpan.Zero;
            DateTimeOffset test = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

            Assert.IsTrue(new DateTimeOffset(test.Year, 1, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(2000, 2, 29, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 3, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 4, 30, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 5, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 6, 30, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 7, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 8, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 9, 30, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 10, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 11, 30, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTimeOffset(test.Year, 12, 31, test.Hour, test.Minute, test.Second, utcOffset).IsLastDayOfThisMonth());

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                if (t.Day == 31)
                {
                    Assert.IsTrue(t.IsLastDayOfThisMonth());
                }
            });

            // ????????????????????????????????????????????????????????????????????????
            DateTimeOffset t1 = new DateTimeOffset(2000, 2, 29, 12, 0, 0, TimeSpan.Zero);
            DateTimeOffset t2 = new DateTimeOffset(2000, 2, 29, 12, 0, 0, TimeSpan.FromHours(8));
            DateTimeOffset t3 = new DateTimeOffset(2000, 2, 29, 12, 0, 0, TimeSpan.FromHours(-8));
            Assert.IsTrue(t1.IsLastDayOfThisMonth());
            Assert.IsTrue(t2.IsLastDayOfThisMonth());
            Assert.IsTrue(t3.IsLastDayOfThisMonth());

            DateTimeOffset t4 = new DateTimeOffset(2000, 3, 1, 2, 0, 0, TimeSpan.FromHours(8));
            DateTimeOffset t5 = new DateTimeOffset(2000, 2, 29, 18, 0, 0, TimeSpan.Zero);
            DateTimeOffset t6 = t4.ToUniversalTime();
            Assert.IsTrue(t4 == t5);
            Assert.IsTrue(t4 == t6);

            // t4 t5 t6 ??????????????????
            Assert.IsFalse(t4.IsLastDayOfThisMonth()); // ??????????????????
            Assert.IsTrue(t5.IsLastDayOfThisMonth()); // ??????????????????
            Assert.IsTrue(t6.IsLastDayOfThisMonth()); // ??????????????????

            DateTimeOffset t7 = new DateTimeOffset(2000, 1, 30, 20, 0, 0, TimeSpan.Zero).ToUniversalTime();
            DateTimeOffset t8 = t7.ToHKTime();
            Assert.IsFalse(t7.IsLastDayOfThisMonth()); // ??????????????????
            Assert.IsTrue(t8.IsLastDayOfThisMonth()); // ??????????????????
        }
    }
}

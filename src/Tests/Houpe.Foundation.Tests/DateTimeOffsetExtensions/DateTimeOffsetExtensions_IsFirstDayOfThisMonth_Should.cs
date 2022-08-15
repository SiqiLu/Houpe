// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_IsFirstDayOfThisMonth_Should.cs
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
    public class DateTimeOffsetExtensions_IsFirstDayOfThisMonth_Should
    {
        [TestMethod]
        public void IsFirstDayOfThisMonth_Should()
        {
            Date r = new Date();
            TimeSpan utcOffset = TimeSpan.Zero;
            DateTimeOffset test = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

            Assert.IsTrue(new DateTimeOffset(test.Year, test.Month, 1, test.Hour, test.Minute, test.Second, utcOffset).IsFirstDayOfThisMonth());

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                if (t.Day == 1)
                {
                    Assert.IsTrue(t.IsFirstDayOfThisMonth());
                }
                else
                {
                    Assert.IsFalse(t.IsFirstDayOfThisMonth());
                }
            });

            // 该判断会考虑时区因素，参考时区即为被调用方的时区
            DateTimeOffset t1 = new DateTimeOffset(2000, 2, 1, 12, 0, 0, TimeSpan.Zero);
            DateTimeOffset t2 = new DateTimeOffset(2000, 2, 1, 12, 0, 0, TimeSpan.FromHours(8));
            DateTimeOffset t3 = new DateTimeOffset(2000, 2, 1, 12, 0, 0, TimeSpan.FromHours(-8));
            Assert.IsTrue(t1.IsFirstDayOfThisMonth());
            Assert.IsTrue(t2.IsFirstDayOfThisMonth());
            Assert.IsTrue(t3.IsFirstDayOfThisMonth());

            DateTimeOffset t4 = new DateTimeOffset(2000, 2, 2, 2, 0, 0, TimeSpan.FromHours(8));
            DateTimeOffset t5 = new DateTimeOffset(2000, 2, 1, 18, 0, 0, TimeSpan.Zero);
            DateTimeOffset t6 = t4.ToUniversalTime();
            Assert.IsTrue(t4 == t5);
            Assert.IsTrue(t4 == t6);

            // t4 t5 t6 是相同的时间
            Assert.IsFalse(t4.IsFirstDayOfThisMonth()); // 参考中国时区
            Assert.IsTrue(t5.IsFirstDayOfThisMonth()); // 参考标准时区
            Assert.IsTrue(t6.IsFirstDayOfThisMonth()); // 参考标准时区

            DateTimeOffset t7 = new DateTimeOffset(2000, 1, 31, 20, 0, 0, TimeSpan.Zero).ToUniversalTime();
            DateTimeOffset t8 = t7.ToHKTime();
            Assert.IsFalse(t7.IsFirstDayOfThisMonth()); // 参考标准时区
            Assert.IsTrue(t8.IsFirstDayOfThisMonth()); // 参考中国时区
        }
    }
}

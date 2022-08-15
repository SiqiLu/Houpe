// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_IsInTheDay_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_IsInTheDay_Should
    {
        [TestMethod]
        public void IsInTheDay_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            DateTimeOffset time = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
            DateTimeOffset date = new DateTimeOffset(time.Date, time.Offset);

            Assert.IsTrue(time.IsInTheDay(date));
            Assert.IsTrue(new DateTimeOffset(2000, 1, 1, 0, 0, 0, utcOffset).IsInTheDay(date));
            Assert.IsTrue(new DateTimeOffset(2000, 1, 1, 23, 59, 59, utcOffset).IsInTheDay(date));

            Assert.IsFalse(new DateTimeOffset(2000, 1, 1, 0, 0, 0, utcOffset).AddSeconds(-1).IsInTheDay(date));
            Assert.IsFalse(new DateTimeOffset(2000, 1, 1, 23, 59, 59, utcOffset).AddSeconds(1).IsInTheDay(date));

            Assert.IsFalse(time.IsInTheDay(date.AddDays(1)));
            Assert.IsFalse(time.IsInTheDay(date.AddDays(-1)));

            // IsInTheDay 参考目标时区
            DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, TimeSpan.Zero);

            DateTimeOffset d1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.FromHours(-7));
            DateTimeOffset d3 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.FromHours(-8));
            DateTimeOffset d4 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.FromHours(-9));

            Assert.IsTrue(t1.IsInTheDay(d1));
            Assert.IsTrue(t1.IsInTheDay(d2));
            Assert.IsTrue(t1.IsInTheDay(d3));
            Assert.IsFalse(t1.IsInTheDay(d4));
        }
    }
}

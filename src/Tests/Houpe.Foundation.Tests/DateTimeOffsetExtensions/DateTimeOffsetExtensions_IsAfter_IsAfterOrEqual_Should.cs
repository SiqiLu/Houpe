// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_IsAfter_IsAfterOrEqual_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_IsAfter_IsAfterOrEqual_Should
    {
        [TestMethod]
        public void IsAfter_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset test = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
            TimeSpan tick = new TimeSpan(1);

            Assert.IsTrue(test.Add(tick).IsAfter(test));

            Assert.IsFalse(test.IsAfter(test.Add(tick)));

            Assert.IsFalse(test.IsAfter(test));

            // DateTimeOffset 的大小必须考虑时区
            DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, utcOffset);
            DateTimeOffset t2 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, utcOffset);
            DateTimeOffset t3 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, chinaOffset);
            Assert.IsTrue(t2.IsAfter(t1));
            Assert.IsTrue(t2.IsAfter(t3));
            Assert.IsFalse(t3.IsAfter(t1)); // 这两个时间值应该相等

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                Assert.AreEqual(t > test, t.IsAfter(test));
            });

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.SoonOffset(1, test);
                Assert.IsTrue(t.IsAfter(test));
            });

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.RecentOffset(1, test);
                Assert.IsFalse(t.IsAfter(test));
            });
        }

        [TestMethod]
        public void IsAfter_Redundancy_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            DateTimeOffset source = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
            DateTimeOffset destination = source.AddHours(-1);
            TimeSpan tick = new TimeSpan(1);
            TimeSpan hour = new TimeSpan(0, 1, 0, 0);

            Assert.IsTrue(source.IsAfter(destination));
            Assert.IsTrue(source.IsAfter(destination, tick));
            Assert.IsTrue(source.IsAfter(destination, hour.Add(-tick)));

            Assert.IsFalse(source.IsAfter(destination, hour));

            Assert.IsFalse(source.IsAfter(destination, hour.Add(tick)));
        }

        [TestMethod]
        public void IsAfterOrEqual_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset test = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
            TimeSpan tick = new TimeSpan(1);

            Assert.IsTrue(test.Add(tick).IsAfterOrEqual(test));

            Assert.IsFalse(test.IsAfterOrEqual(test.Add(tick)));

            Assert.IsTrue(test.IsAfterOrEqual(test));

            // DateTimeOffset 的大小必须考虑时区
            DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, utcOffset);
            DateTimeOffset t2 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, utcOffset);
            DateTimeOffset t3 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, chinaOffset);
            Assert.IsTrue(t2.IsAfterOrEqual(t1));
            Assert.IsTrue(t2.IsAfterOrEqual(t3));
            Assert.IsTrue(t3.IsAfterOrEqual(t1)); // 这两个时间值应该相等

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                Assert.AreEqual(t >= test, t.IsAfterOrEqual(test));
            });

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.SoonOffset(1, test);
                Assert.IsTrue(t.IsAfterOrEqual(test));
            });

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.RecentOffset(1, test);
                Assert.IsFalse(t.IsAfterOrEqual(test));
            });

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                Assert.IsTrue(t.IsAfterOrEqual(t));
            });
        }

        [TestMethod]
        public void IsAfterOrEqual_Redundancy_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            DateTimeOffset source = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
            DateTimeOffset destination = source.AddHours(-1);
            TimeSpan tick = new TimeSpan(1);
            TimeSpan hour = new TimeSpan(0, 1, 0, 0);

            Assert.IsTrue(source.IsAfterOrEqual(destination));
            Assert.IsTrue(source.IsAfterOrEqual(destination, tick));
            Assert.IsTrue(source.IsAfterOrEqual(destination, hour.Add(-tick)));

            Assert.IsTrue(source.IsAfterOrEqual(destination, hour));

            Assert.IsFalse(source.IsAfterOrEqual(destination, hour.Add(tick)));
        }
    }
}

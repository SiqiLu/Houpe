// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_IsBefore_IsBeforeOrEqual_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeOffsetExtensions_IsBefore_IsBeforeOrEqual_Should
{
    [TestMethod]
    public void IsBefore_Redundancy_Should()
    {
        TimeSpan utcOffset = TimeSpan.Zero;
        DateTimeOffset source = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
        DateTimeOffset destination = source.AddHours(1);
        TimeSpan tick = new TimeSpan(1);
        TimeSpan hour = new TimeSpan(0, 1, 0, 0);

        Assert.IsTrue(source.IsBefore(destination));
        Assert.IsTrue(source.IsBefore(destination, tick));
        Assert.IsTrue(source.IsBefore(destination, hour.Add(-tick)));

        Assert.IsFalse(source.IsBefore(destination, hour));

        Assert.IsFalse(source.IsBefore(destination, hour.Add(tick)));
    }

    [TestMethod]
    public void IsBefore_Should()
    {
        TimeSpan utcOffset = TimeSpan.Zero;
        TimeSpan chinaOffset = TimeSpan.FromHours(8);
        DateTimeOffset test = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
        TimeSpan tick = new TimeSpan(1);

        Assert.IsTrue(test.Add(-tick).IsBefore(test));

        Assert.IsFalse(test.IsBefore(test.Add(-tick)));

        Assert.IsFalse(test.IsBefore(test));

        // DateTimeOffset 的大小必须考虑时区
        DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, utcOffset);
        DateTimeOffset t2 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, utcOffset);
        DateTimeOffset t3 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, chinaOffset);
        Assert.IsTrue(t1.IsBefore(t2));
        Assert.IsTrue(t3.IsBefore(t2));
        Assert.IsFalse(t3.IsBefore(t1)); // 这两个时间值应该相等

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            Assert.AreEqual(t < test, t.IsBefore(test));
        });

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.SoonOffset(1, test);
            Assert.IsFalse(t.IsBefore(test));
        });

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.RecentOffset(1, test);
            Assert.IsTrue(t.IsBefore(test));
        });
    }

    [TestMethod]
    public void IsBeforeOrEqual_Redundancy_Should()
    {
        TimeSpan utcOffset = TimeSpan.Zero;
        DateTimeOffset source = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
        DateTimeOffset destination = source.AddHours(1);
        TimeSpan tick = new TimeSpan(1);
        TimeSpan hour = new TimeSpan(0, 1, 0, 0);

        Assert.IsTrue(source.IsBeforeOrEqual(destination));
        Assert.IsTrue(source.IsBeforeOrEqual(destination, tick));
        Assert.IsTrue(source.IsBeforeOrEqual(destination, hour.Add(-tick)));

        Assert.IsTrue(source.IsBeforeOrEqual(destination, hour));

        Assert.IsFalse(source.IsBeforeOrEqual(destination, hour.Add(tick)));
    }

    [TestMethod]
    public void IsBeforeOrEqual_Should()
    {
        TimeSpan utcOffset = TimeSpan.Zero;
        TimeSpan chinaOffset = TimeSpan.FromHours(8);
        DateTimeOffset test = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
        TimeSpan tick = new TimeSpan(1);

        Assert.IsTrue(test.Add(-tick).IsBeforeOrEqual(test));

        Assert.IsTrue(test.IsBeforeOrEqual(test.Add(tick)));

        Assert.IsTrue(test.IsBeforeOrEqual(test));

        // DateTimeOffset 的大小必须考虑时区
        DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, utcOffset);
        DateTimeOffset t2 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, utcOffset);
        DateTimeOffset t3 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, chinaOffset);
        Assert.IsTrue(t1.IsBeforeOrEqual(t2));
        Assert.IsTrue(t3.IsBeforeOrEqual(t2));
        Assert.IsTrue(t3.IsBeforeOrEqual(t1)); // 这两个时间值应该相等

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            Assert.AreEqual(t <= test, t.IsBeforeOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.SoonOffset(1, test);
            Assert.IsFalse(t.IsBeforeOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.RecentOffset(1, test);
            Assert.IsTrue(t.IsBeforeOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            Assert.IsTrue(t.IsBeforeOrEqual(t));
        });
    }
}

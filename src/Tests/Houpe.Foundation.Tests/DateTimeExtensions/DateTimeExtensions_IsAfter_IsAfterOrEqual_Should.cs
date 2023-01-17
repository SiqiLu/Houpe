// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsAfter_IsAfterOrEqual_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_IsAfter_IsAfterOrEqual_Should
{
    [TestMethod]
    public void IsAfter_Redundancy_Should()
    {
        DateTime source = new DateTime(2000, 1, 1, 8, 0, 0);
        DateTime destination = source.AddHours(-1);
        TimeSpan tick = new TimeSpan(1);
        TimeSpan hour = new TimeSpan(0, 1, 0, 0);

        Assert.IsTrue(source.IsAfter(destination));
        Assert.IsTrue(source.IsAfter(destination, tick));
        Assert.IsTrue(source.IsAfter(destination, hour.Add(-tick)));

        Assert.IsFalse(source.IsAfter(destination, hour));

        Assert.IsFalse(source.IsAfter(destination, hour.Add(tick)));
    }

    [TestMethod]
    public void IsAfter_Should()
    {
        DateTime test = new DateTime(2000, 1, 1, 8, 0, 0);
        TimeSpan tick = new TimeSpan(1);

        Assert.IsTrue(test.Add(tick).IsAfter(test));

        Assert.IsFalse(test.IsAfter(test.Add(tick)));

        Assert.IsFalse(test.IsAfter(test));

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.AreEqual(t > test, t.IsAfter(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Soon(1, test);
            Assert.IsTrue(t.IsAfter(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Recent(1, test);
            Assert.IsFalse(t.IsAfter(test));
        });
    }

    [TestMethod]
    public void IsAfterOrEqual_Redundancy_Should()
    {
        DateTime source = new DateTime(2000, 1, 1, 8, 0, 0);
        DateTime destination = source.AddHours(-1);
        TimeSpan tick = new TimeSpan(1);
        TimeSpan hour = new TimeSpan(0, 1, 0, 0);

        Assert.IsTrue(source.IsAfterOrEqual(destination));
        Assert.IsTrue(source.IsAfterOrEqual(destination, tick));
        Assert.IsTrue(source.IsAfterOrEqual(destination, hour.Add(-tick)));

        Assert.IsTrue(source.IsAfterOrEqual(destination, hour));

        Assert.IsFalse(source.IsAfterOrEqual(destination, hour.Add(tick)));
    }

    [TestMethod]
    public void IsAfterOrEqual_Should()
    {
        DateTime test = new DateTime(2000, 1, 1, 8, 0, 0);
        TimeSpan tick = new TimeSpan(1);

        Assert.IsTrue(test.Add(tick).IsAfterOrEqual(test));

        Assert.IsFalse(test.IsAfterOrEqual(test.Add(tick)));

        Assert.IsTrue(test.IsAfterOrEqual(test));

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.AreEqual(t >= test, t.IsAfterOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Soon(1, test);
            Assert.IsTrue(t.IsAfterOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Recent(1, test);
            Assert.IsFalse(t.IsAfterOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.IsTrue(t.IsAfterOrEqual(t));
        });
    }
}

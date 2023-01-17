// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsBefore_IsBeforeOrEqual_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_IsBefore_IsBeforeOrEqual_Should
{
    [TestMethod]
    public void IsBefore_Redundancy_Should()
    {
        DateTime source = new DateTime(2000, 1, 1, 8, 0, 0);
        DateTime destination = source.AddHours(1);
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
        DateTime test = new DateTime(2000, 1, 1, 8, 0, 0);
        TimeSpan tick = new TimeSpan(1);

        Assert.IsTrue(test.Add(-tick).IsBefore(test));

        Assert.IsFalse(test.IsBefore(test.Add(-tick)));

        Assert.IsFalse(test.IsBefore(test));

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.AreEqual(t < test, t.IsBefore(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Soon(1, test);
            Assert.IsFalse(t.IsBefore(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Recent(1, test);
            Assert.IsTrue(t.IsBefore(test));
        });
    }

    [TestMethod]
    public void IsBeforeOrEqual_Redundancy_Should()
    {
        DateTime source = new DateTime(2000, 1, 1, 8, 0, 0);
        DateTime destination = source.AddHours(1);
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
        DateTime test = new DateTime(2000, 1, 1, 8, 0, 0);
        TimeSpan tick = new TimeSpan(1);

        Assert.IsTrue(test.Add(-tick).IsBeforeOrEqual(test));

        Assert.IsTrue(test.IsBeforeOrEqual(test.Add(tick)));

        Assert.IsTrue(test.IsBeforeOrEqual(test));

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.AreEqual(t <= test, t.IsBeforeOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Soon(1, test);
            Assert.IsFalse(t.IsBeforeOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Recent(1, test);
            Assert.IsTrue(t.IsBeforeOrEqual(test));
        });

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.IsTrue(t.IsBeforeOrEqual(t));
        });
    }
}

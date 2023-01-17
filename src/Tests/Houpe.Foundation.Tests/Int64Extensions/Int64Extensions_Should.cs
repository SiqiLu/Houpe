// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Int64Extensions_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class Int64Extensions_Should
{
    [TestMethod]
    public void ToDateTimeFromFileTime_Should()
    {
        DateTime testUtcNow = DateTime.UtcNow;
        DateTime testNow = DateTime.Now;

        Assert.AreEqual(testUtcNow, testUtcNow.ToFileTime().ToDateTimeFromFileTime());

        Assert.AreEqual(testNow.ToUniversalTime(), testNow.ToFileTime().ToDateTimeFromFileTime());

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Soon();

            // 转换后的 DateTime, DateTimeKind 一定是 DateTimeKind.Utc
            Assert.AreEqual(DateTimeKind.Utc, t.ToFileTime().ToDateTimeFromFileTime().Kind);
            Assert.AreEqual(t.ToUniversalTime(), t.ToFileTime().ToDateTimeFromFileTime());
        });
    }

    [TestMethod]
    public void ToDateTimeFromTicks_Should()
    {
        DateTime testUtcNow = DateTime.UtcNow;
        DateTime testNow = DateTime.Now;

        Assert.AreEqual(testUtcNow, testUtcNow.Ticks.ToDateTimeFromTicks());

        Assert.AreEqual(testNow, testNow.Ticks.ToDateTimeFromTicks());

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Soon();

            Assert.AreEqual(t.Kind, t.Ticks.ToDateTimeFromTicks(t.Kind).Kind);
            Assert.AreEqual(t, t.Ticks.ToDateTimeFromTicks(t.Kind));
        });
    }

    [TestMethod]
    public void ToDateTimeFromUnixTimestamp_Should()
    {
        // UnixTimestamp 精度只能到秒

        DateTime testUtcNow = DateTime.UtcNow;
        testUtcNow = new DateTime(testUtcNow.Year, testUtcNow.Month, testUtcNow.Day, testUtcNow.Hour, testUtcNow.Minute, testUtcNow.Second, testUtcNow.Kind);
        DateTime testNow = DateTime.Now;
        testNow = new DateTime(testNow.Year, testNow.Month, testNow.Day, testNow.Hour, testNow.Minute, testNow.Second, testNow.Kind);

        Assert.AreEqual(testUtcNow, testUtcNow.ToUnixTimestamp().ToDateTimeFromUnixTimestamp());

        Assert.AreEqual(testNow.ToUniversalTime(), testNow.ToUnixTimestamp().ToDateTimeFromUnixTimestamp());

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Soon();
            t = new DateTime(t.Year, t.Month, t.Day, t.Hour, t.Minute, t.Second, t.Kind);

            // 转换后的 DateTime, DateTimeKind 一定是 DateTimeKind.Utc
            Assert.AreEqual(DateTimeKind.Utc, t.ToUnixTimestamp().ToDateTimeFromUnixTimestamp().Kind);
            Assert.AreEqual(t.ToUniversalTime(), t.ToUnixTimestamp().ToDateTimeFromUnixTimestamp());
        });
    }
}

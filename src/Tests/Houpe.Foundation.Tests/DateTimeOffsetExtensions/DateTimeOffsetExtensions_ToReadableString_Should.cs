// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_ToReadableString_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeOffsetExtensions_ToReadableString_Should
{
    [TestMethod]
    public void ToReadableString_Should()
    {
        TimeSpan utcOffset = TimeSpan.Zero;
        TimeSpan chinaOffset = TimeSpan.FromHours(8);
        DateTimeOffset time1 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
        DateTimeOffset time2 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, chinaOffset);

        Assert.AreEqual("2000-01-01 08:00:00", time1.ToReadableString());
        Assert.AreEqual(time1.ToString("s").Replace('T', ' '), time1.ToReadableString());

        Assert.AreEqual("2000-01-01 08:00:00", time2.ToReadableString());
        Assert.AreEqual(time2.ToString("s").Replace('T', ' '), time2.ToReadableString());

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            Assert.AreEqual(t.ToString("s").Replace('T', ' '), t.ToReadableString());
        });
    }
}

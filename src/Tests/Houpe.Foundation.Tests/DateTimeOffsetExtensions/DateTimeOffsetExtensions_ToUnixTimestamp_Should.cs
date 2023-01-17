// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_ToUnixTimestamp_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeOffsetExtensions_ToUnixTimestamp_Should
{
    [TestMethod]
    public void ToUnixTimestamp_Should()
    {
        TimeSpan utcOffset = TimeSpan.Zero;
        TimeSpan chinaOffset = TimeSpan.FromHours(8);
        DateTimeOffset start = new DateTimeOffset(1970, 1, 1, 0, 0, 0, utcOffset);
        DateTimeOffset time1 = new DateTimeOffset(1970, 1, 1, 0, 0, 0, chinaOffset);

        Assert.AreEqual(0L, start.ToUnixTimestamp());
        Assert.AreEqual(365L * 24L * 60L * 60L, start.AddYears(1).ToUnixTimestamp());

        Assert.AreEqual(-8L * 60L * 60L, time1.ToUnixTimestamp());
        Assert.AreEqual((365L * 24L * 60L * 60L) - (8L * 60L * 60L), time1.AddYears(1).ToUnixTimestamp());
    }
}

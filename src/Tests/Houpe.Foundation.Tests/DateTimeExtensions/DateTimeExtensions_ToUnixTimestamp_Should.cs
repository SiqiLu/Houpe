// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_ToUnixTimestamp_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_ToUnixTimestamp_Should
{
    [TestMethod]
    public void ToUnixTimestamp_Should()
    {
        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        Assert.AreEqual(0L, start.ToUnixTimestamp());
        Assert.AreEqual(365L * 24L * 60L * 60L, start.AddYears(1).ToUnixTimestamp());
    }
}

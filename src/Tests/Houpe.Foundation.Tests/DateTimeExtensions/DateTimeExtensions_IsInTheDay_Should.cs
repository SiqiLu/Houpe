// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsInTheDay_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_IsInTheDay_Should
{
    [TestMethod]
    public void IsInTheDay_Should()
    {
        DateTime time = new DateTime(2000, 1, 1, 8, 0, 0);
        DateTime date = time.Date;

        Assert.IsTrue(time.IsInTheDay(date));
        Assert.IsTrue(new DateTime(2000, 1, 1, 0, 0, 0).IsInTheDay(date));
        Assert.IsTrue(new DateTime(2000, 1, 1, 23, 59, 59).IsInTheDay(date));

        Assert.IsFalse(new DateTime(2000, 1, 1, 0, 0, 0).AddMinutes(-1).IsInTheDay(date));
        Assert.IsFalse(new DateTime(2000, 1, 1, 23, 59, 59).AddMinutes(1).IsInTheDay(date));

        Assert.IsFalse(time.IsInTheDay(date.AddDays(1)));
        Assert.IsFalse(time.IsInTheDay(date.AddDays(-1)));
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_ToJSDate_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_ToJSDate_Should
{
    [TestMethod]
    public void ToJSDate_Should()
    {
        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        Assert.AreEqual(0L, start.ToJSDate());
        Assert.AreEqual(365L * 24L * 60L * 60L * 1000L, start.AddYears(1).ToJSDate());
    }
}

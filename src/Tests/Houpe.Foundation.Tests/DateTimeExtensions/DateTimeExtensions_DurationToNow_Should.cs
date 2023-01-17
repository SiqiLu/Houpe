// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_DurationToNow_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_DurationToNow_Should
{
    [TestMethod]
    public void DurationToNow_Should()
    {
        DateTime t = new DateTime(2000, 1, 1, 8, 0, 0);

        TimeSpan expected = DateTime.Now - t;
        TimeSpan actual = t.DurationToNow();

        Assert.IsTrue(actual - expected < new TimeSpan(0, 0, 0, 1));
        Assert.IsTrue(expected - actual < new TimeSpan(0, 0, 0, 1));
    }
}

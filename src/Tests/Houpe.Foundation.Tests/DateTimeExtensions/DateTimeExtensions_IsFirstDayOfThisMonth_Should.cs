// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsFirstDayOfThisMonth_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_IsFirstDayOfThisMonth_Should
{
    [TestMethod]
    public void IsFirstDayOfThisMonth_Should()
    {
        Date r = new Date();

        DateTime test = r.Between(DateTime.MinValue, DateTime.MaxValue);

        Assert.IsTrue(new DateTime(test.Year, test.Month, 1, test.Hour, test.Minute, test.Second).IsFirstDayOfThisMonth());

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            if (t.Day == 1)
            {
                Assert.IsTrue(t.IsFirstDayOfThisMonth());
            }
            else
            {
                Assert.IsFalse(t.IsFirstDayOfThisMonth());
            }
        });
    }
}

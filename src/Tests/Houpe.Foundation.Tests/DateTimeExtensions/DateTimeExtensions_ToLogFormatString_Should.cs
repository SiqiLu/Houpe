// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_ToLogFormatString_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_ToLogFormatString_Should
{
    [TestMethod]
    public void ToLogFormatString_Should()
    {
        DateTime time = new DateTime(2000, 1, 1, 8, 0, 0);

        Assert.AreEqual("2000-01-01T08:00:00.0000000", time.ToLogFormatString());
        Assert.AreEqual(time.ToString("O"), time.ToLogFormatString());

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
            Assert.AreEqual(t.ToString("O"), t.ToLogFormatString());
        });
    }
}

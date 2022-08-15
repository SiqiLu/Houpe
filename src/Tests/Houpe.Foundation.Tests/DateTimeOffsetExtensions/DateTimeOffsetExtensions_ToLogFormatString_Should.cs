// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_ToLogFormatString_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_ToLogFormatString_Should
    {
        [TestMethod]
        public void ToLogFormatString_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset time1 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);
            DateTimeOffset time2 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, chinaOffset);

            Assert.AreEqual("2000-01-01T08:00:00.0000000+00:00", time1.ToLogFormatString());
            Assert.AreEqual(time1.ToString("O"), time1.ToLogFormatString());

            Assert.AreEqual("2000-01-01T08:00:00.0000000+08:00", time2.ToLogFormatString());
            Assert.AreEqual(time2.ToString("O"), time2.ToLogFormatString());

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                Assert.AreEqual(t.ToString("O"), t.ToLogFormatString());
            });
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_ToJSDate_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_ToJSDate_Should
    {
        [TestMethod]
        public void ToJSDate_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset start = new DateTimeOffset(1970, 1, 1, 0, 0, 0, utcOffset);
            DateTimeOffset time1 = new DateTimeOffset(1970, 1, 1, 0, 0, 0, chinaOffset);

            Assert.AreEqual(0L, start.ToJSDate());
            Assert.AreEqual(365L * 24L * 60L * 60L * 1000L, start.AddYears(1).ToJSDate());

            Assert.AreEqual(-8L * 60L * 60L * 1000L, time1.ToJSDate());
            Assert.AreEqual((365L * 24L * 60L * 60L * 1000L) - (8L * 60L * 60L * 1000L), time1.AddYears(1).ToJSDate());
        }
    }
}

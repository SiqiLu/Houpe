// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_DurationToNow_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_DurationToNow_Should
    {
        [TestMethod]
        public void DurationToNow_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, utcOffset);

            TimeSpan expected1 = DateTimeOffset.Now - t1;
            TimeSpan actual1 = t1.DurationToNow();

            Assert.IsTrue(actual1 - expected1 < new TimeSpan(0, 0, 0, 1));
            Assert.IsTrue(expected1 - actual1 < new TimeSpan(0, 0, 0, 1));

            TimeSpan expected1_1 = DateTimeOffset.UtcNow - t1;
            TimeSpan actual1_1 = t1.DurationToNow();

            Assert.IsTrue(actual1_1 - expected1_1 < new TimeSpan(0, 0, 0, 1));
            Assert.IsTrue(expected1_1 - actual1_1 < new TimeSpan(0, 0, 0, 1));

            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset t2 = new DateTimeOffset(2000, 1, 1, 8, 0, 0, chinaOffset);

            TimeSpan expected2 = DateTimeOffset.Now - t2;
            TimeSpan actual2 = t2.DurationToNow();

            Assert.IsTrue(actual2 - expected2 < new TimeSpan(0, 0, 0, 1));
            Assert.IsTrue(expected2 - actual2 < new TimeSpan(0, 0, 0, 1));

            TimeSpan expected2_1 = DateTimeOffset.UtcNow - t1;
            TimeSpan actual2_1 = t1.DurationToNow();

            Assert.IsTrue(actual2_1 - expected2_1 < new TimeSpan(0, 0, 0, 1));
            Assert.IsTrue(expected2_1 - actual2_1 < new TimeSpan(0, 0, 0, 1));
        }
    }
}

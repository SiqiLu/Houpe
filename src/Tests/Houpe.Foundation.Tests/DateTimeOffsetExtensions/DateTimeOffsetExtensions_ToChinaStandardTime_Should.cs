// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_ToChinaStandardTime_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_ToChinaStandardTime_Should
    {
        [TestMethod]
        public void ToChinaStandardTime_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset time1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, utcOffset);
            DateTimeOffset time2 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, chinaOffset);
            DateTimeOffset time3 = new DateTimeOffset(2000, 1, 1, 20, 0, 0, utcOffset);

            DateTimeOffset result1 = time1.ToHKTime();
            Assert.AreEqual(TimeSpan.FromHours(8), result1.Offset);
            Assert.AreEqual(2000, result1.Year);
            Assert.AreEqual(1, result1.Month);
            Assert.AreEqual(1, result1.Day);
            Assert.AreEqual(20, result1.Hour);
            Assert.AreEqual(0, result1.Minute);
            Assert.AreEqual(0, result1.Second);

            DateTimeOffset result2 = time2.ToHKTime();
            Assert.AreEqual(TimeSpan.FromHours(8), result2.Offset);
            Assert.AreEqual(2000, result2.Year);
            Assert.AreEqual(1, result2.Month);
            Assert.AreEqual(1, result2.Day);
            Assert.AreEqual(12, result2.Hour);
            Assert.AreEqual(0, result2.Minute);
            Assert.AreEqual(0, result2.Second);

            DateTimeOffset result3 = time3.ToHKTime();
            Assert.AreEqual(TimeSpan.FromHours(8), result3.Offset);
            Assert.AreEqual(2000, result3.Year);
            Assert.AreEqual(1, result3.Month);
            Assert.AreEqual(2, result3.Day);
            Assert.AreEqual(4, result3.Hour);
            Assert.AreEqual(0, result3.Minute);
            Assert.AreEqual(0, result3.Second);
        }
    }
}

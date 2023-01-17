// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_ToUTC_Should.cs
// CreatedAt        : 2021-06-25
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeOffsetExtensions_ToUTC_Should
    {
        [TestMethod]
        public void ToUTC_Should()
        {
            TimeSpan utcOffset = TimeSpan.Zero;
            TimeSpan chinaOffset = TimeSpan.FromHours(8);
            DateTimeOffset time1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, utcOffset);
            DateTimeOffset time2 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, chinaOffset);

            DateTimeOffset result1 = time1.ToUTC();
            Assert.AreEqual(TimeSpan.FromHours(0), result1.Offset);
            Assert.AreEqual(2000, result1.Year);
            Assert.AreEqual(1, result1.Month);
            Assert.AreEqual(1, result1.Day);
            Assert.AreEqual(12, result1.Hour);
            Assert.AreEqual(0, result1.Minute);
            Assert.AreEqual(0, result1.Second);

            DateTimeOffset result2 = time2.ToUTC();
            Assert.AreEqual(TimeSpan.FromHours(0), result1.Offset);
            Assert.AreEqual(2000, result2.Year);
            Assert.AreEqual(1, result2.Month);
            Assert.AreEqual(1, result2.Day);
            Assert.AreEqual(4, result2.Hour);
            Assert.AreEqual(0, result2.Minute);
            Assert.AreEqual(0, result2.Second);
        }
    }
}

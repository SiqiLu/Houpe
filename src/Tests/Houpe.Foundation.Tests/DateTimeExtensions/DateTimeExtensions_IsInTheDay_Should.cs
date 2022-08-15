// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsInTheDay_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
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
}

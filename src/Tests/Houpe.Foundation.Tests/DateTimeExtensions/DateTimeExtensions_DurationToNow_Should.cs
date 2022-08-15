// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_DurationToNow_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-25
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
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
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Int64Extensions_Exception.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class Int64Extensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDateTimeFromFileTime_Max_ArgumentOutOfRangeException() => _ = (DateTime.MaxValue.Ticks - Constants.FileTimeOffset + 1).ToDateTimeFromFileTime();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDateTimeFromFileTime_Min_ArgumentOutOfRangeException() => _ = (DateTime.MinValue.Ticks - Constants.FileTimeOffset - 1).ToDateTimeFromFileTime();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDateTimeFromTicks_Max_ArgumentOutOfRangeException() => _ = (DateTime.MaxValue.Ticks + 1).ToDateTimeFromTicks();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDateTimeFromTicks_Min_ArgumentOutOfRangeException() => _ = (DateTime.MinValue.Ticks - 1).ToDateTimeFromTicks();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDateTimeFromTicks_DateTimeKink_ArgumentException() => _ = 100L.ToDateTimeFromTicks(DateTimeKind.Utc + 5);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDateTimeFromUnixTimestamp_Max_ArgumentOutOfRangeException()
        {
            long max = (DateTime.MaxValue.Ticks / 1000 / Constants.MillisecondTicks) - Constants.EpochSeconds;
            _ = (max + 1).ToDateTimeFromUnixTimestamp();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToDateTimeFromUnixTimestamp_Min_ArgumentOutOfRangeException()
        {
            long min = (DateTime.MinValue.Ticks / 1000 / Constants.MillisecondTicks) - Constants.EpochSeconds;
            _ = (min - 1).ToDateTimeFromUnixTimestamp();
        }
    }
}

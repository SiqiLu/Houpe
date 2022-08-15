// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Seconds_Should.cs
// CreatedAt        : 2021-05-06
// LastModifiedAt   : 2021-06-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class IntExtensions_Seconds_Should
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, new TimeSpan(0, 0, 0, 1).Ticks };
            yield return new object[] { 0, new TimeSpan(0, 0, 0, 0).Ticks };
            yield return new object[] { -1, new TimeSpan(0, 0, 0, -1).Ticks };
            yield return new object[] { 1000, new TimeSpan(0, 0, 0, 1000).Ticks };
            yield return new object[] { -1000, new TimeSpan(0, 0, 0, -1000).Ticks };
            yield return new object[] { int.MaxValue, new TimeSpan(0, 0, 0, int.MaxValue).Ticks };
            yield return new object[] { int.MinValue, new TimeSpan(0, 0, 0, int.MinValue).Ticks };
            yield return new object[] { (int)TimeSpan.MaxValue.TotalSeconds, new TimeSpan(0, 0, 0, (int)TimeSpan.MaxValue.TotalSeconds).Ticks };
            yield return new object[] { (int)TimeSpan.MinValue.TotalSeconds, new TimeSpan(0, 0, 0, (int)TimeSpan.MinValue.TotalSeconds).Ticks };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Seconds_DataTest(int input, long expected)
        {
            TimeSpan actual = input.Seconds();
            Assert.AreEqual(new TimeSpan(expected), actual);
        }
    }
}

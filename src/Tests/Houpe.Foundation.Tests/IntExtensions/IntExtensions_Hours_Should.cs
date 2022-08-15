// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Hours_Should.cs
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
    public class IntExtensions_Hours_Should
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, new TimeSpan(0, 1, 0, 0).Ticks };
            yield return new object[] { 0, new TimeSpan(0, 0, 0, 0).Ticks };
            yield return new object[] { -1, new TimeSpan(0, -1, 0, 0).Ticks };
            yield return new object[] { 1000, new TimeSpan(0, 1000, 0, 0).Ticks };
            yield return new object[] { -1000, new TimeSpan(0, -1000, 0, 0).Ticks };
            yield return new object[] { (int)TimeSpan.MaxValue.TotalHours, new TimeSpan(0, (int)TimeSpan.MaxValue.TotalHours, 0, 0).Ticks };
            yield return new object[] { (int)TimeSpan.MinValue.TotalHours, new TimeSpan(0, (int)TimeSpan.MinValue.TotalHours, 0, 0).Ticks };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Hours_DataTest(int input, long expected)
        {
            TimeSpan actual = input.Hours();
            Assert.AreEqual(new TimeSpan(expected), actual);
        }
    }
}

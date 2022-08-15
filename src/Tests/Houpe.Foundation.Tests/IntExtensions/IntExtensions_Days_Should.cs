// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Days_Should.cs
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
    public class IntExtensions_Days_Should
    {
        // 新版本框架的漏洞导致，DynamicData 不支持 TimeSpan 类型
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, new TimeSpan(1, 0, 0, 0).Ticks };
            yield return new object[] { 0, new TimeSpan(0, 0, 0, 0).Ticks };
            yield return new object[] { -1, new TimeSpan(-1, 0, 0, 0).Ticks };
            yield return new object[] { 1000, new TimeSpan(1000, 0, 0, 0).Ticks };
            yield return new object[] { -1000, new TimeSpan(-1000, 0, 0, 0).Ticks };
            yield return new object[] { (int)TimeSpan.MaxValue.TotalDays, new TimeSpan((int)TimeSpan.MaxValue.TotalDays, 0, 0, 0).Ticks };
            yield return new object[] { (int)TimeSpan.MinValue.TotalDays, new TimeSpan((int)TimeSpan.MinValue.TotalDays, 0, 0, 0).Ticks };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void Days_DateTest(int input, long expected)
        {
            TimeSpan actual = input.Days();
            Assert.AreEqual(new TimeSpan(expected), actual);
        }
    }
}

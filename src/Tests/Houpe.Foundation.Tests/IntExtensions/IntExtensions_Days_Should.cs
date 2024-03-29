// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Days_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class IntExtensions_Days_Should
{
    [DataTestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void Days_DateTest(int input, long expected)
    {
        TimeSpan actual = input.Days();
        Assert.AreEqual(new TimeSpan(expected), actual);
    }

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
}

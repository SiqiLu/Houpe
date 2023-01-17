// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Minutes_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class IntExtensions_Minutes_Should
{
    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] { 1, new TimeSpan(0, 0, 1, 0).Ticks };
        yield return new object[] { 0, new TimeSpan(0, 0, 0, 0).Ticks };
        yield return new object[] { -1, new TimeSpan(0, 0, -1, 0).Ticks };
        yield return new object[] { 1000, new TimeSpan(0, 0, 1000, 0).Ticks };
        yield return new object[] { -1000, new TimeSpan(0, 0, -1000, 0).Ticks };
        yield return new object[] { int.MaxValue, new TimeSpan(0, 0, int.MaxValue, 0).Ticks };
        yield return new object[] { int.MinValue, new TimeSpan(0, 0, int.MinValue, 0).Ticks };
        yield return new object[] { (int)TimeSpan.MaxValue.TotalMinutes, new TimeSpan(0, 0, (int)TimeSpan.MaxValue.TotalMinutes, 0).Ticks };
        yield return new object[] { (int)TimeSpan.MinValue.TotalMinutes, new TimeSpan(0, 0, (int)TimeSpan.MinValue.TotalMinutes, 0).Ticks };
    }

    [DataTestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void Minutes_DataTest(int input, long expected)
    {
        TimeSpan actual = input.Minutes();
        Assert.AreEqual(new TimeSpan(expected), actual);
    }
}

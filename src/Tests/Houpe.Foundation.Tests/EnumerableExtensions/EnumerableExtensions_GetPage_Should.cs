// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_GetPage_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class EnumerableExtensions_GetPage_Should
{
    public static readonly int[] TestData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] { 0, 0, -1, 0 };
        yield return new object[] { 0, 1, 0, 1 };
        yield return new object[] { 0, 5, 0, 5 };
        yield return new object[] { 1, 0, -1, 0 };
        yield return new object[] { 1, 1, 1, 1 };
        yield return new object[] { 1, 5, 5, 5 };
        yield return new object[] { 2, 0, -1, 0 };
        yield return new object[] { 2, 1, 2, 1 };
        yield return new object[] { 2, 5, 10, 5 };
        yield return new object[] { 3, 0, -1, 0 };
        yield return new object[] { 3, 1, 3, 1 };
        yield return new object[] { 3, 5, -1, 0 };
        yield return new object[] { 5, 0, -1, 0 };
        yield return new object[] { 5, 1, 5, 1 };
        yield return new object[] { 5, 5, -1, 0 };
        yield return new object[] { int.MaxValue, 0, -1, 0 };
        yield return new object[] { int.MaxValue, 1, -1, 0 };
        yield return new object[] { int.MaxValue, 5, -1, 0 };
        yield return new object[] { 0, int.MaxValue, 0, 15 };
        yield return new object[] { 1, int.MaxValue, -1, 0 };
        yield return new object[] { 5, int.MaxValue, -1, 0 };
    }

    [TestMethod]
    public void GetPage_IEnumerable_Should()
    {
        string testData = "abcde";
        IEnumerable<char> enumerable = testData;

        List<char> result = enumerable.GetPage(1, 3).ToList();

        Assert.AreEqual(2, result.Count);
        Assert.AreEqual('d', result[0]);
        Assert.AreEqual('e', result[1]);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void GetPage_Should(int pageIndex, int pageSize, int expectedIndex, int expectedResultSize)
    {
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        List<int>? result = TestData.GetPage(pageIndex, pageSize)?.ToList();

        Assert.IsNotNull(result);

        if (result.Any())
        {
            int resultIndex = TestData.ToList().FindIndex(i => i == result.First());
            Assert.AreEqual(expectedIndex, resultIndex);
        }

        Assert.AreEqual(expectedResultSize, result.Count);
    }
}

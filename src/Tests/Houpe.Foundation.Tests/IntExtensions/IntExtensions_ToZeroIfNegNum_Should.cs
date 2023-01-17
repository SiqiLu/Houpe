// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_ToZeroIfNegNum_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class Int64Extensions_ToZeroIfNegNum_Should
{
    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] { 1, 1 };
        yield return new object[] { 10, 10 };
        yield return new object[] { -1, 0 };
        yield return new object[] { 0, 0 };
        yield return new object[] { int.MaxValue, int.MaxValue };
        yield return new object[] { int.MinValue, 0 };
    }

    [DataTestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    public void ToZeroIfNegNum_DataTest(int input, int expected) => Assert.AreEqual(expected, input.ToZeroIfNegNum());
}

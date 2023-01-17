// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Days_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class IntExtensions_Days_Exception
{
    [DataTestMethod]
    [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Days_Throw_ArgumentOutOfRangeException(int input) => input.Days();

    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] { (int)TimeSpan.MaxValue.TotalDays + 1 };
        yield return new object[] { (int)TimeSpan.MinValue.TotalDays - 1 };
        yield return new object[] { int.MaxValue };
        yield return new object[] { int.MinValue };
    }
}

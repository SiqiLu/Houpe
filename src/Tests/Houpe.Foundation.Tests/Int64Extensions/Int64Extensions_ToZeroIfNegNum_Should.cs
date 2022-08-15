// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Int64Extensions_ToZeroIfNegNum_Should.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class Int6464Extensions_ToZeroIfNegNum_Should
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 1, 1 };
            yield return new object[] { 10, 10 };
            yield return new object[] { -1, 0 };
            yield return new object[] { 0, 0 };
            yield return new object[] { int.MaxValue, int.MaxValue };
            yield return new object[] { int.MinValue, 0 };
            yield return new object[] { long.MaxValue, long.MaxValue };
            yield return new object[] { long.MinValue, 0 };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ToZeroIfNegNum_DataTest(long input, long expected) => Assert.AreEqual(expected, input.ToZeroIfNegNum());
    }
}

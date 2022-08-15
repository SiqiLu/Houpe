// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Days_Exception.cs
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
    public class IntExtensions_Days_Exception
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { (int)TimeSpan.MaxValue.TotalDays + 1 };
            yield return new object[] { (int)TimeSpan.MinValue.TotalDays - 1 };
            yield return new object[] { int.MaxValue };
            yield return new object[] { int.MinValue };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Days_Throw_ArgumentOutOfRangeException(int input) => input.Days();
    }
}

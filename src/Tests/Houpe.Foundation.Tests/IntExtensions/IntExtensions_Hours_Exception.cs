// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Hours_Exception.cs
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
    public class IntExtensions_Hours_Exception
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { (int)TimeSpan.MaxValue.TotalHours + 1 };
            yield return new object[] { (int)TimeSpan.MinValue.TotalHours - 1 };
            yield return new object[] { int.MaxValue };
            yield return new object[] { int.MinValue };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Hours_Throw_ArgumentOutOfRangeException(int input) => input.Hours();
    }
}

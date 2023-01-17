// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_GetPage_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class EnumerableExtensions_GetPage_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetPage_Null_ArgumentNullException()
    {
        IEnumerable<int>? testDate = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = testDate.GetPage(0, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetPage_PageIndex_Neg_ArgumentOutOfRangeException()
    {
        IEnumerable<int> testDate = new[] { 0, 1, 2 };

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = testDate.GetPage(-1, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void GetPage_PageSize_Neg_ArgumentOutOfRangeException()
    {
        IEnumerable<int> testDate = new[] { 0, 1, 2 };

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = testDate.GetPage(0, -1);
    }
}

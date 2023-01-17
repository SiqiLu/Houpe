// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_ToReadOnlyCollection_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class EnumerableExtensions_ToReadOnlyCollection_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ToReadOnlyCollection_ArgumentNullException()
    {
        IList<string>? testData = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = testData.ToReadOnlyCollection();
    }

    [TestMethod]
    [ExpectedException(typeof(NotSupportedException))]
    public void ToReadOnlyCollection_NotSupportedException()
    {
        IList<string> testData = new List<string> { "0", "1" };
        IList<string> readOnlyData = testData.ToReadOnlyCollection();
        readOnlyData[0] = "2";
    }
}

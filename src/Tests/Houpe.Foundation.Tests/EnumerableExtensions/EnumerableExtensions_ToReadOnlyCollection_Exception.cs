// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_ToReadOnlyCollection_Exception.cs
// CreatedAt        : 2021-05-31
// LastModifiedAt   : 2021-05-31
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class EnumerableExtensions_ToReadOnlyCollection_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToReadOnlyCollection_NotSupportedException()
        {
            IList<string> testData = new List<string> { "0", "1" };
            IList<string> readOnlyData = testData.ToReadOnlyCollection();
            readOnlyData[0] = "2";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToReadOnlyCollection_ArgumentNullException()
        {
            IList<string> testData = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = testData.ToReadOnlyCollection();
        }
    }
}

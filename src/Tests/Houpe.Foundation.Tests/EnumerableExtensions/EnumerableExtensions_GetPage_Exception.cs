// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_GetPage_Exception.cs
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
    public class EnumerableExtensions_GetPage_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPage_Null_ArgumentNullException()
        {
            IEnumerable<int> testDate = null;

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
}

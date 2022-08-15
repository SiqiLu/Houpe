// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : UnicodeExtensions_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class UnicodeExtensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToBytesByUnicode_Exception()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToBytesByUnicode();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByUnicode_Exception()
        {
            byte[] input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByUnicode();
        }
    }
}

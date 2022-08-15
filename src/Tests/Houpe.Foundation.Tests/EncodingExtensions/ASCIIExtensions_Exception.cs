// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ASCIIExtensions_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class ASCIIExtensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToBytesByASCII_Exception()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToBytesByASCII();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByASCII_Exception()
        {
            byte[] input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByASCII();
        }
    }
}

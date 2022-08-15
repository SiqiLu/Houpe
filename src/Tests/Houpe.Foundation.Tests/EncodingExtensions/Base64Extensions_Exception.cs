// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Base64Extensions_Exception.cs
// CreatedAt        : 2021-07-11
// LastModifiedAt   : 2021-07-11
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class Base64Extensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToStringByBase64_Bytes_ArgumentNullException()
        {
            byte[] input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToStringByBase64();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToStringByBase64_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToStringByBase64();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToBytesByBase64_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToBytesByBase64();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DecodeToBytesByBase64_String_FormatException()
        {
            string input = "--BadFormat--";

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToBytesByBase64();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByBase64_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByBase64();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DecodeToStringByBase64_String_FormatException()
        {
            string input = "--BadFormat--";

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByBase64();
        }
    }
}

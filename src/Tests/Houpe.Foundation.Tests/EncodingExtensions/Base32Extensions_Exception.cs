// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Base32Extensions_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class Base32Extensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToStringByBase32_Bytes_ArgumentNullException()
        {
            byte[] input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToStringByBase32();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToStringByBase32_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToStringByBase32();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToBytesByBase32_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToBytesByBase32();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DecodeToBytesByBase32_String_FormatException()
        {
            string input = "--BadFormat--";

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToBytesByBase32();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByBase32_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByBase32();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DecodeToStringByBase32_String_FormatException()
        {
            string input = "--BadFormat--";

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByBase32();
        }
    }
}

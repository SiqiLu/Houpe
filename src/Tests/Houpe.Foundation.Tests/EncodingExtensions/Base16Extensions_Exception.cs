// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Base16Extensions_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class Base16Extensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToStringByBase16_Bytes_ArgumentNullException()
        {
            byte[] input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToStringByBase16();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToStringByBase16_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToStringByBase16();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToBytesByBase16_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToBytesByBase16();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DecodeToBytesByBase16_String_FormatException()
        {
            string input = "12-23-BadFormat";

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToBytesByBase16();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByBase16_String_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByBase16();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DecodeToStringByBase16_String_FormatException()
        {
            string input = "12-23-BadFormat";

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByBase16();
        }
    }
}

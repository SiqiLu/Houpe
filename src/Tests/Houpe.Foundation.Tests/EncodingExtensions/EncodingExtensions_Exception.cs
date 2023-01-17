// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EncodingExtensions_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

#pragma warning disable CS8604
#pragma warning disable CS8625

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class EncodingExtensions_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToBytesByTheEncoding_ArgumentNullException()
        {
            string? input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.EncodeToBytesByTheEncoding(Encoding.UTF8.WebName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodeToBytesByTheEncoding_Null_ArgumentException()
        {
            string input = "Hello world!";

            _ = input.EncodeToBytesByTheEncoding(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeToBytesByTheEncoding_Empty_ArgumentException()
        {
            string input = "Hello world!";

            _ = input.EncodeToBytesByTheEncoding(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeToBytesByTheEncoding_NonexistentEncodingName_ArgumentException()
        {
            string input = "Hello world!";

            _ = input.EncodeToBytesByTheEncoding("NonexistentEncodingName");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByTheEncoding_ArgumentNullException()
        {
            byte[]? input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.DecodeToStringByTheEncoding(Encoding.UTF8.WebName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecodeToStringByTheEncoding_Null_ArgumentException()
        {
            byte[] input = Encoding.UTF8.GetBytes("Hello world!");

            _ = input.DecodeToStringByTheEncoding(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecodeToStringByTheEncoding_Empty_ArgumentException()
        {
            byte[] input = Encoding.UTF8.GetBytes("Hello world!");

            _ = input.DecodeToStringByTheEncoding(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecodeToStringByTheEncoding_NonexistentEncodingName_ArgumentException()
        {
            byte[] input = Encoding.UTF8.GetBytes("Hello world!");

            _ = input.DecodeToStringByTheEncoding("NonexistentEncodingName");
        }
    }
}

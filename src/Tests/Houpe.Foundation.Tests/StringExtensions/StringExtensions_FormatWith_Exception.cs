// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FormatWith_Exception.cs
// CreatedAt        : 2021-06-07
// LastModifiedAt   : 2021-06-27
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_FormatWith_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatWith_Format_ArgumentNullException() => _ = ((string)null).FormatWith("a", "b");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatWith_Args_ArgumentNullException() => _ = "0-{0}-1-{1}-2-{2}".FormatWith((object[])null);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatWith_LessArgument_Exception()
        {
            string actual = "0-{0}-1-{1}-2-{2}".FormatWith("a", "b");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatWith_NoZeroBased_Exception() => _ = "1-{1}-2-{2}".FormatWith(new DateTimeFormatInfo(), "a", "b");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatWith2_Format_ArgumentNullException() => _ = ((string)null).FormatWith(new DateTimeFormatInfo(), "a", "b");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatWith2_Args_ArgumentNullException() => _ = "0-{0}-1-{1}-2-{2}".FormatWith(new DateTimeFormatInfo(), null);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatWith2_LessArgument_Exception()
        {
            string actual = "0-{0}-1-{1}-2-{2}".FormatWith(new DateTimeFormatInfo(), "a", "b");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatWith2_NoZeroBased_Exception() => _ = "1-{1}-2-{2}".FormatWith(new DateTimeFormatInfo(), "a", "b");
    }
}

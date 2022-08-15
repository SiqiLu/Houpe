// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FormatWithValues_Exception.cs
// CreatedAt        : 2021-06-07
// LastModifiedAt   : 2021-06-27
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_FormatWithValues_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatWithValues_Format_ArgumentNullException() => _ = ((string)null).FormatWithValues("a", "b");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FormatWithValues_Args_ArgumentNullException() => _ = "0-{0}-1-{1}-2-{2}".FormatWithValues(null);

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FormatWithValues_LessArgument_Exception()
        {
            string actual = "0-{0}-1-{1}-2-{2}".FormatWithValues("a", "b");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }
    }
}

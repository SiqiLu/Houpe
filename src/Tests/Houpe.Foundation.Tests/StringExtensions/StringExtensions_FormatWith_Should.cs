// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FormatWith_Should.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-27
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_FormatWith_Should
    {
        private static readonly string s_testData = "0-{0}-1-{1}-2-{2}";

        [TestMethod]
        public void FormatWith_Should()
        {
            string actual = s_testData.FormatWith("a", "b", "c");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatWith_MoreArgument_Should()
        {
            string actual = s_testData.FormatWith("a", "b", "c", "d");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatWith2_Should()
        {
            string actual = s_testData.FormatWith(new DateTimeFormatInfo(), "a", "b", "c");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatWith2_MoreArgument_Should()
        {
            string actual = s_testData.FormatWith(new DateTimeFormatInfo(), "a", "b", "c", "d");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }
    }
}

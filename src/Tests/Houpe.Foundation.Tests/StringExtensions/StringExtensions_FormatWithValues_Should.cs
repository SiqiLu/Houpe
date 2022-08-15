// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FormatWithValues_Should.cs
// CreatedAt        : 2021-06-07
// LastModifiedAt   : 2021-06-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_FormatWithValues_Should
    {
        private static readonly string s_testData = "0-{a}-1-{b}-2-{c}";

        [TestMethod]
        public void FormatWithValues_Should()
        {
            string actual = s_testData.FormatWithValues("a", "b", "c");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatWithValues_MoreArgument_Should()
        {
            string actual = s_testData.FormatWithValues("a", "b", "c", "d");
            string expected = "0-a-1-b-2-c";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatWithValues_NoZeroBased_Should()
        {
            string actual = "1-{1}-2-{2}".FormatWithValues("a", "b");

            string expected = "1-a-2-b";

            Assert.AreEqual(expected, actual);
        }
    }
}

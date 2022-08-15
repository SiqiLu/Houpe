// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_Should.cs
// CreatedAt        : 2021-05-31
// LastModifiedAt   : 2022-07-26
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Collections;
using System.Collections.Generic;
using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class EnumerableExtensions_Should
    {
        public static readonly IEnumerable<int> TestData = new[] { 0, 1, 2 };
        public static readonly IEnumerable<int> NullTestData = null;
        public static readonly IEnumerable<int> EmptyTestData = new int[] { };
        public static readonly IEnumerable<string> NullElementTestData = new[] { "0", null, "1", null, "2" };

        [TestMethod]
        public void IsNotNullOrEmpty_Should()
        {
            Assert.IsTrue(TestData.IsNotNullOrEmpty());
            Assert.IsFalse(NullTestData.IsNotNullOrEmpty());
            Assert.IsFalse(EmptyTestData.IsNotNullOrEmpty());

            Assert.IsTrue((TestData as IEnumerable).IsNotNullOrEmpty());
            Assert.IsFalse((NullTestData as IEnumerable).IsNotNullOrEmpty());
            Assert.IsFalse((EmptyTestData as IEnumerable).IsNotNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmpty_Should()
        {
            Assert.IsFalse(TestData.IsNullOrEmpty());
            Assert.IsTrue(NullTestData.IsNullOrEmpty());
            Assert.IsTrue(EmptyTestData.IsNullOrEmpty());

            Assert.IsFalse((TestData as IEnumerable).IsNullOrEmpty());
            Assert.IsTrue((NullTestData as IEnumerable).IsNullOrEmpty());
            Assert.IsTrue((EmptyTestData as IEnumerable).IsNullOrEmpty());
        }

        [TestMethod]
        public void IsNullOrEmpty_IEnumerable_Should()
        {
            string testData = "abcde";
            IEnumerable<char> enumerable = testData;
            Assert.IsFalse(enumerable.IsNullOrEmpty());
        }

        [TestMethod]
        public void ToString_Should()
        {
            Assert.AreEqual("System.Int32[]", TestData.ToString());
            Assert.AreEqual("[0, 1, 2]", TestData.ToString<int>());
            Assert.AreEqual("[1, 2, 3]", TestData.ToString(i => (i + 1).ToString()));
            Assert.AreEqual("[0| 1| 2]", TestData.ToString(null, "| "));
            Assert.AreEqual("0, 1, 2", TestData.ToString(null, ", ", false));

            // Assert.AreEqual("[]", NullTestData.ToString());  // NullReferenceException
            Assert.AreEqual("[]", NullTestData.ToString<int>());
            Assert.AreEqual("null", NullTestData.ToString(null, ", ", false));

            Assert.AreEqual("System.Int32[]", EmptyTestData.ToString());
            Assert.AreEqual("[]", EmptyTestData.ToString<int>());
            Assert.AreEqual("", EmptyTestData.ToString(null, ", ", false));

            Assert.AreEqual("System.String[]", NullElementTestData.ToString());
            Assert.AreEqual("[0, null, 1, null, 2]", NullElementTestData.ToString<string>());
        }
    }
}

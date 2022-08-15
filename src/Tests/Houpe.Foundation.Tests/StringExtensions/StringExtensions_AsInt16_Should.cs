// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsInt16_Should.cs
// CreatedAt        : 2021-06-05
// LastModifiedAt   : 2021-06-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_AsInt16_Should
    {
        [TestMethod]
        public void AsInt16_Success_Should()
        {
            Assert.AreEqual(0, "0".AsInt16());
            Assert.AreEqual(1, "1".AsInt16());
            Assert.AreEqual(-1, "-1".AsInt16());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().AsInt16());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().AsInt16());
        }

        [TestMethod]
        public void AsInt16_Fail_Should()
        {
            short defaultTestData = -1;

            Assert.AreEqual(default, "abcdefg".AsInt16());
            Assert.AreEqual(default, "short".AsInt16());
            Assert.AreEqual(default, "null".AsInt16());
            Assert.AreEqual(default, "1.1".AsInt16());
            Assert.AreEqual(default, "1.9".AsInt16());
            Assert.AreEqual(default, "short.MinValue".AsInt16());
            Assert.AreEqual(default, "short.MinValue".AsInt16());

            Assert.AreEqual(defaultTestData, "abcdefg".AsInt16(defaultTestData));
            Assert.AreEqual(defaultTestData, "short".AsInt16(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsInt16(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.1".AsInt16(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.9".AsInt16(defaultTestData));
            Assert.AreEqual(defaultTestData, "short.MinValue".AsInt16(defaultTestData));
            Assert.AreEqual(defaultTestData, "short.MinValue".AsInt16(defaultTestData));

            Assert.AreEqual(default, ((long)short.MinValue - 1).ToString().AsInt16());
            Assert.AreEqual(default, ((long)short.MaxValue + 1).ToString().AsInt16());
        }
    }
}

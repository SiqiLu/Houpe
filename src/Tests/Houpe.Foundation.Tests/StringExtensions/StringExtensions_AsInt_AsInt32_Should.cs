// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsInt_AsInt32_Should.cs
// CreatedAt        : 2021-06-05
// LastModifiedAt   : 2021-06-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_AsInt_AsInt32_Should
    {
        [TestMethod]
        public void AsInt_Success_Should()
        {
            Assert.AreEqual(0, "0".AsInt());
            Assert.AreEqual(1, "1".AsInt());
            Assert.AreEqual(-1, "-1".AsInt());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsInt());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsInt());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().AsInt());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().AsInt());
        }

        [TestMethod]
        public void AsInt_Fail_Should()
        {
            int defaultTestData = -1;

            Assert.AreEqual(default, "abcdefg".AsInt());
            Assert.AreEqual(default, "int".AsInt());
            Assert.AreEqual(default, "null".AsInt());
            Assert.AreEqual(default, "1.1".AsInt());
            Assert.AreEqual(default, "1.9".AsInt());
            Assert.AreEqual(default, "int.MinValue".AsInt());
            Assert.AreEqual(default, "int.MinValue".AsInt());

            Assert.AreEqual(defaultTestData, "abcdefg".AsInt(defaultTestData));
            Assert.AreEqual(defaultTestData, "int".AsInt(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsInt(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.1".AsInt(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.9".AsInt(defaultTestData));
            Assert.AreEqual(defaultTestData, "int.MinValue".AsInt(defaultTestData));
            Assert.AreEqual(defaultTestData, "int.MinValue".AsInt(defaultTestData));

            Assert.AreEqual(default, ((long)int.MinValue - 1).ToString().AsInt());
            Assert.AreEqual(default, ((long)int.MaxValue + 1).ToString().AsInt());
        }

        [TestMethod]
        public void AsInt32_Success_Should()
        {
            Assert.AreEqual(0, "0".AsInt32());
            Assert.AreEqual(1, "1".AsInt32());
            Assert.AreEqual(-1, "-1".AsInt32());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsInt32());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsInt32());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().AsInt32());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().AsInt32());
        }

        [TestMethod]
        public void AsInt32_Fail_Should()
        {
            int defaultTestData = -1;

            Assert.AreEqual(default, "abcdefg".AsInt32());
            Assert.AreEqual(default, "int".AsInt32());
            Assert.AreEqual(default, "null".AsInt32());
            Assert.AreEqual(default, "1.1".AsInt32());
            Assert.AreEqual(default, "1.9".AsInt32());
            Assert.AreEqual(default, "int.MinValue".AsInt32());
            Assert.AreEqual(default, "int.MinValue".AsInt32());

            Assert.AreEqual(defaultTestData, "abcdefg".AsInt32(defaultTestData));
            Assert.AreEqual(defaultTestData, "int".AsInt32(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsInt32(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.1".AsInt32(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.9".AsInt32(defaultTestData));
            Assert.AreEqual(defaultTestData, "int.MinValue".AsInt32(defaultTestData));
            Assert.AreEqual(defaultTestData, "int.MinValue".AsInt32(defaultTestData));

            Assert.AreEqual(default, ((long)int.MinValue - 1).ToString().AsInt32());
            Assert.AreEqual(default, ((long)int.MaxValue + 1).ToString().AsInt32());
        }
    }
}

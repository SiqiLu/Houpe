// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsLong_AsInt64_Should.cs
// CreatedAt        : 2021-06-05
// LastModifiedAt   : 2021-06-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_AsLong_AsInt64_Should
    {
        [TestMethod]
        public void AsLong_Success_Should()
        {
            Assert.AreEqual(0, "0".AsLong());
            Assert.AreEqual(1, "1".AsLong());
            Assert.AreEqual(-1, "-1".AsLong());
            Assert.AreEqual(long.MaxValue, long.MaxValue.ToString().AsLong());
            Assert.AreEqual(long.MinValue, long.MinValue.ToString().AsLong());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsLong());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsLong());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().AsLong());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().AsLong());
        }

        [TestMethod]
        public void AsLong_Fail_Should()
        {
            long defaultTestData = -1L;

            Assert.AreEqual(default, "abcdefg".AsLong());
            Assert.AreEqual(default, "int".AsLong());
            Assert.AreEqual(default, "null".AsLong());
            Assert.AreEqual(default, "1.1".AsLong());
            Assert.AreEqual(default, "1.9".AsLong());
            Assert.AreEqual(default, "long.MinValue".AsLong());
            Assert.AreEqual(default, "long.MinValue".AsLong());

            // ReSharper disable RedundantTypeArgumentsOfMethod
            Assert.AreEqual(defaultTestData, "abcdefg".AsLong(defaultTestData));
            Assert.AreEqual(defaultTestData, "int".AsLong(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsLong(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.1".AsLong(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.9".AsLong(defaultTestData));
            Assert.AreEqual(defaultTestData, "long.MinValue".AsLong(defaultTestData));
            Assert.AreEqual(defaultTestData, "long.MinValue".AsLong(defaultTestData));

            // ReSharper restore RedundantTypeArgumentsOfMethod

            Assert.AreEqual(default, ((double)long.MinValue - 1).ToString(CultureInfo.InvariantCulture).AsLong());
            Assert.AreEqual(default, ((double)long.MaxValue + 1).ToString(CultureInfo.InvariantCulture).AsLong());
        }

        [TestMethod]
        public void AsInt64_Success_Should()
        {
            Assert.AreEqual(0, "0".AsInt64());
            Assert.AreEqual(1, "1".AsInt64());
            Assert.AreEqual(-1, "-1".AsInt64());
            Assert.AreEqual(long.MaxValue, long.MaxValue.ToString().AsInt64());
            Assert.AreEqual(long.MinValue, long.MinValue.ToString().AsInt64());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsInt64());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsInt64());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().AsInt64());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().AsInt64());
        }

        [TestMethod]
        public void AsInt64_Fail_Should()
        {
            long defaultTestData = -1L;

            Assert.AreEqual(default, "abcdefg".AsInt64());
            Assert.AreEqual(default, "int".AsInt64());
            Assert.AreEqual(default, "null".AsInt64());
            Assert.AreEqual(default, "1.1".AsInt64());
            Assert.AreEqual(default, "1.9".AsInt64());
            Assert.AreEqual(default, "long.MinValue".AsInt64());
            Assert.AreEqual(default, "long.MinValue".AsInt64());

            // ReSharper disable RedundantTypeArgumentsOfMethod
            Assert.AreEqual(defaultTestData, "abcdefg".AsInt64(defaultTestData));
            Assert.AreEqual(defaultTestData, "int".AsInt64(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsInt64(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.1".AsInt64(defaultTestData));
            Assert.AreEqual(defaultTestData, "1.9".AsInt64(defaultTestData));
            Assert.AreEqual(defaultTestData, "long.MinValue".AsInt64(defaultTestData));
            Assert.AreEqual(defaultTestData, "long.MinValue".AsInt64(defaultTestData));

            // ReSharper restore RedundantTypeArgumentsOfMethod

            Assert.AreEqual(default, ((double)long.MinValue - 1).ToString(CultureInfo.InvariantCulture).AsInt64());
            Assert.AreEqual(default, ((double)long.MaxValue + 1).ToString(CultureInfo.InvariantCulture).AsInt64());
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToLong_ToInt64_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToLong_ToInt64_Should
    {
        [TestMethod]
        public void ToLong_Should()
        {
            Assert.AreEqual(0, "0".ToLong());
            Assert.AreEqual(1, "1".ToLong());
            Assert.AreEqual(-1, "-1".ToLong());
            Assert.AreEqual(long.MaxValue, long.MaxValue.ToString().ToLong());
            Assert.AreEqual(long.MinValue, long.MinValue.ToString().ToLong());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToLong());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToLong());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().ToLong());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().ToLong());
        }

        [TestMethod]
        public void ToInt64_Should()
        {
            Assert.AreEqual(0, "0".ToInt64());
            Assert.AreEqual(1, "1".ToInt64());
            Assert.AreEqual(-1, "-1".ToInt64());
            Assert.AreEqual(long.MaxValue, long.MaxValue.ToString().ToInt64());
            Assert.AreEqual(long.MinValue, long.MinValue.ToString().ToInt64());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToInt64());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToInt64());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().ToInt64());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().ToInt64());
        }
    }
}

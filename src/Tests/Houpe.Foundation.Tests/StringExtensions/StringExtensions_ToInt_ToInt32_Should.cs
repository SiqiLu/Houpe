// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToInt_ToInt32_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToInt_ToInt32_Should
    {
        [TestMethod]
        public void ToInt_Should()
        {
            Assert.AreEqual(0, "0".ToInt());
            Assert.AreEqual(1, "1".ToInt());
            Assert.AreEqual(-1, "-1".ToInt());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToInt());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToInt());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().ToInt());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().ToInt());
        }

        [TestMethod]
        public void ToInt32_Should()
        {
            Assert.AreEqual(0, "0".ToInt32());
            Assert.AreEqual(1, "1".ToInt32());
            Assert.AreEqual(-1, "-1".ToInt32());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToInt32());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToInt32());
            Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().ToInt32());
            Assert.AreEqual(short.MinValue, short.MinValue.ToString().ToInt32());
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsInt16_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsInt16_Should
    {
        [TestMethod]
        public void IsInt16_True_Should()
        {
            Assert.AreEqual(true, "0".IsInt16());
            Assert.AreEqual(true, "1".IsInt16());
            Assert.AreEqual(true, "-1".IsInt16());
            Assert.AreEqual(true, short.MaxValue.ToString().IsInt16());
            Assert.AreEqual(true, short.MinValue.ToString().IsInt16());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                short s = r.Short();
                Assert.IsTrue(s.ToString().IsInt16());
            });
        }

        [TestMethod]
        public void IsInt16_False_Should()
        {
            Assert.AreEqual(false, "abcdefg".IsInt16());
            Assert.AreEqual(false, "short".IsInt16());
            Assert.AreEqual(false, "null".IsInt16());
            Assert.AreEqual(false, "1.1".IsInt16());
            Assert.AreEqual(false, "1.9".IsInt16());
            Assert.AreEqual(false, "short.MinValue".IsInt16());
            Assert.AreEqual(false, "short.MinValue".IsInt16());

            Assert.AreEqual(false, "abcdefg".IsInt16());
            Assert.AreEqual(false, "short".IsInt16());
            Assert.AreEqual(false, "null".IsInt16());
            Assert.AreEqual(false, "1.1".IsInt16());
            Assert.AreEqual(false, "1.9".IsInt16());
            Assert.AreEqual(false, "short.MinValue".IsInt16());
            Assert.AreEqual(false, "short.MinValue".IsInt16());

            Assert.AreEqual(false, ((long)short.MinValue - 1).ToString().IsInt16());
            Assert.AreEqual(false, ((long)short.MaxValue + 1).ToString().IsInt16());
        }
    }
}

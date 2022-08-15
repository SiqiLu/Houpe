// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsBoolean_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsBoolean_Should
    {
        [TestMethod]
        public void IsBoolean_True_Should()
        {
            Assert.IsTrue("false".IsBoolean());
            Assert.IsTrue("False".IsBoolean());
            Assert.IsTrue("fAlSe".IsBoolean());
            Assert.IsTrue("true".IsBoolean());
            Assert.IsTrue("True".IsBoolean());
            Assert.IsTrue("tRuE".IsBoolean());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                bool b = r.Bool();
                Assert.IsTrue(b.ToString().IsBoolean());
            });
        }

        [TestMethod]
        public void IsBoolean_False_Should()
        {
            Assert.IsFalse("abcdefg".IsBoolean());
            Assert.IsFalse("bool".IsBoolean());
            Assert.IsFalse("null".IsBoolean());
            Assert.IsFalse("-1".IsBoolean());
            Assert.IsFalse("1".IsBoolean());
            Assert.IsFalse("0".IsBoolean());
            Assert.IsFalse("T".IsBoolean());
            Assert.IsFalse("F".IsBoolean());
            Assert.IsFalse("t".IsBoolean());
            Assert.IsFalse("f".IsBoolean());

            Assert.IsFalse("abcdefg".IsBoolean());
            Assert.IsFalse("bool".IsBoolean());
            Assert.IsFalse("null".IsBoolean());
            Assert.IsFalse("-1".IsBoolean());
            Assert.IsFalse("1".IsBoolean());
            Assert.IsFalse("0".IsBoolean());
            Assert.IsFalse("T".IsBoolean());
            Assert.IsFalse("F".IsBoolean());
            Assert.IsFalse("t".IsBoolean());
            Assert.IsFalse("f".IsBoolean());

            Assert.IsFalse("abcdefg".IsBoolean());
            Assert.IsFalse("bool".IsBoolean());
            Assert.IsFalse("null".IsBoolean());
            Assert.IsFalse("-1".IsBoolean());
            Assert.IsFalse("1".IsBoolean());
            Assert.IsFalse("0".IsBoolean());
            Assert.IsFalse("T".IsBoolean());
            Assert.IsFalse("F".IsBoolean());
            Assert.IsFalse("t".IsBoolean());
            Assert.IsFalse("f".IsBoolean());
        }
    }
}

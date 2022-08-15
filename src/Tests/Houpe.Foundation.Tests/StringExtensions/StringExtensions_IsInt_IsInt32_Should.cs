// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsInt_IsInt32_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsInt_IsInt32_Should
    {
        [TestMethod]
        public void IsInt_True_Should()
        {
            Assert.IsTrue("0".IsInt());
            Assert.IsTrue("1".IsInt());
            Assert.IsTrue("-1".IsInt());
            Assert.IsTrue(int.MaxValue.ToString().IsInt());
            Assert.IsTrue(int.MinValue.ToString().IsInt());
            Assert.IsTrue(short.MaxValue.ToString().IsInt());
            Assert.IsTrue(short.MinValue.ToString().IsInt());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                int i = r.Int();
                Assert.IsTrue(i.ToString().IsInt());
            });
        }

        [TestMethod]
        public void IsInt_False_Should()
        {
            Assert.IsFalse("abcdefg".IsInt());
            Assert.IsFalse("int".IsInt());
            Assert.IsFalse("null".IsInt());
            Assert.IsFalse("1.1".IsInt());
            Assert.IsFalse("1.9".IsInt());
            Assert.IsFalse("int.MinValue".IsInt());
            Assert.IsFalse("int.MinValue".IsInt());

            // ReSharper disable RedundantTypeArgumentsOfMethod
            Assert.IsFalse("abcdefg".IsInt());
            Assert.IsFalse("int".IsInt());
            Assert.IsFalse("null".IsInt());
            Assert.IsFalse("1.1".IsInt());
            Assert.IsFalse("1.9".IsInt());
            Assert.IsFalse("int.MinValue".IsInt());
            Assert.IsFalse("int.MinValue".IsInt());

            // ReSharper restore RedundantTypeArgumentsOfMethod

            Assert.AreEqual(default, ((long)int.MinValue - 1).ToString().IsInt());
            Assert.AreEqual(default, ((long)int.MaxValue + 1).ToString().IsInt());
        }

        [TestMethod]
        public void IsInt32_True_Should()
        {
            Assert.IsTrue("0".IsInt32());
            Assert.IsTrue("1".IsInt32());
            Assert.IsTrue("-1".IsInt32());
            Assert.IsTrue(int.MaxValue.ToString().IsInt32());
            Assert.IsTrue(int.MinValue.ToString().IsInt32());
            Assert.IsTrue(short.MaxValue.ToString().IsInt32());
            Assert.IsTrue(short.MinValue.ToString().IsInt32());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                int i = r.Int();
                Assert.IsTrue(i.ToString().IsInt32());
            });
        }

        [TestMethod]
        public void IsInt32_False_Should()
        {
            Assert.IsFalse("abcdefg".IsInt32());
            Assert.IsFalse("int".IsInt32());
            Assert.IsFalse("null".IsInt32());
            Assert.IsFalse("1.1".IsInt32());
            Assert.IsFalse("1.9".IsInt32());
            Assert.IsFalse("int.MinValue".IsInt32());
            Assert.IsFalse("int.MinValue".IsInt32());

            // ReSharper disable RedundantTypeArgumentsOfMethod
            Assert.IsFalse("abcdefg".IsInt32());
            Assert.IsFalse("int".IsInt32());
            Assert.IsFalse("null".IsInt32());
            Assert.IsFalse("1.1".IsInt32());
            Assert.IsFalse("1.9".IsInt32());
            Assert.IsFalse("int.MinValue".IsInt32());
            Assert.IsFalse("int.MinValue".IsInt32());

            // ReSharper restore RedundantTypeArgumentsOfMethod

            Assert.AreEqual(default, ((long)int.MinValue - 1).ToString().IsInt32());
            Assert.AreEqual(default, ((long)int.MaxValue + 1).ToString().IsInt32());
        }
    }
}

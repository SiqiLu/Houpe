// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsFloat_IsSingle_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Globalization;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsFloat_IsSingle_Should
    {
        [TestMethod]
        public void IsFloat_True_Should()
        {
            Assert.IsTrue("0".IsFloat());
            Assert.IsTrue("1".IsFloat());
            Assert.IsTrue("-1".IsFloat());

            Assert.IsTrue("0".IsFloat());
            Assert.IsTrue("1".IsFloat());
            Assert.IsTrue("-1".IsFloat());
            Assert.IsTrue(int.MaxValue.ToString().IsFloat());
            Assert.IsTrue(int.MinValue.ToString().IsFloat());

            Assert.IsTrue("1.1".IsFloat());
            Assert.IsTrue("-1.1".IsFloat());
            Assert.IsTrue("1.9".IsFloat());
            Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsFloat());
            Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).IsFloat());
            Assert.IsTrue(float.MaxValue.ToString(CultureInfo.InvariantCulture).IsFloat());
            Assert.IsTrue(float.MinValue.ToString(CultureInfo.InvariantCulture).IsFloat());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                float f = r.Float();
                Assert.IsTrue(f.ToString(CultureInfo.InvariantCulture).IsFloat());
            });
        }

        [TestMethod]
        public void IsFloat_False_Should()
        {
            Assert.IsFalse("abcdefg".IsFloat());
            Assert.IsFalse("float".IsFloat());
            Assert.IsFalse("null".IsFloat());
            Assert.IsFalse("1.1.1".IsFloat());
            Assert.IsFalse("1.9.9".IsFloat());
            Assert.IsFalse("float.MinValue".IsFloat());
            Assert.IsFalse("float.MinValue".IsFloat());

            Assert.IsFalse("abcdefg".IsFloat());
            Assert.IsFalse("float".IsFloat());
            Assert.IsFalse("null".IsFloat());
            Assert.IsFalse("1.1.1".IsFloat());
            Assert.IsFalse("1.9.9".IsFloat());
            Assert.IsFalse("float.MinValue".IsFloat());
            Assert.IsFalse("float.MinValue".IsFloat());
        }

        [TestMethod]
        public void IsSingle_True_Should()
        {
            Assert.IsTrue("0".IsSingle());
            Assert.IsTrue("1".IsSingle());
            Assert.IsTrue("-1".IsSingle());

            Assert.IsTrue("0".IsSingle());
            Assert.IsTrue("1".IsSingle());
            Assert.IsTrue("-1".IsSingle());
            Assert.IsTrue(int.MaxValue.ToString().IsSingle());
            Assert.IsTrue(int.MinValue.ToString().IsSingle());

            Assert.IsTrue("1.1".IsSingle());
            Assert.IsTrue("-1.1".IsSingle());
            Assert.IsTrue("1.9".IsSingle());
            Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsSingle());
            Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).IsSingle());
            Assert.IsTrue(float.MaxValue.ToString(CultureInfo.InvariantCulture).IsSingle());
            Assert.IsTrue(float.MinValue.ToString(CultureInfo.InvariantCulture).IsSingle());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                // ReSharper disable once BuiltInTypeReferenceStyle
                Single s = r.Float();
                Assert.IsTrue(s.ToString(CultureInfo.InvariantCulture).IsSingle());
            });
        }

        [TestMethod]
        public void IsSingle_False_Should()
        {
            Assert.IsFalse("abcdefg".IsSingle());
            Assert.IsFalse("float".IsSingle());
            Assert.IsFalse("null".IsSingle());
            Assert.IsFalse("1.1.1".IsSingle());
            Assert.IsFalse("1.9.9".IsSingle());
            Assert.IsFalse("float.MinValue".IsSingle());
            Assert.IsFalse("float.MinValue".IsSingle());

            Assert.IsFalse("abcdefg".IsSingle());
            Assert.IsFalse("float".IsSingle());
            Assert.IsFalse("null".IsSingle());
            Assert.IsFalse("1.1.1".IsSingle());
            Assert.IsFalse("1.9.9".IsSingle());
            Assert.IsFalse("float.MinValue".IsSingle());
            Assert.IsFalse("float.MinValue".IsSingle());
        }
    }
}

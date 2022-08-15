// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsLong_IsInt64_Should.cs
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
    public class StringExtensions_IsLong_IsInt64_Should
    {
        [TestMethod]
        public void IsLong_True_Should()
        {
            Assert.AreEqual(true, "0".IsLong());
            Assert.AreEqual(true, "1".IsLong());
            Assert.AreEqual(true, "-1".IsLong());
            Assert.AreEqual(true, long.MaxValue.ToString().IsLong());
            Assert.AreEqual(true, long.MinValue.ToString().IsLong());
            Assert.AreEqual(true, int.MaxValue.ToString().IsLong());
            Assert.AreEqual(true, int.MinValue.ToString().IsLong());
            Assert.AreEqual(true, short.MaxValue.ToString().IsLong());
            Assert.AreEqual(true, short.MinValue.ToString().IsLong());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                long l = r.Long();
                Assert.IsTrue(l.ToString().IsLong());
            });
        }

        [TestMethod]
        public void IsLong_False_Should()
        {
            Assert.AreEqual(false, "abcdefg".IsLong());
            Assert.AreEqual(false, "int".IsLong());
            Assert.AreEqual(false, "null".IsLong());
            Assert.AreEqual(false, "1.1".IsLong());
            Assert.AreEqual(false, "1.9".IsLong());
            Assert.AreEqual(false, "long.MinValue".IsLong());
            Assert.AreEqual(false, "long.MinValue".IsLong());

            Assert.AreEqual(false, "abcdefg".IsLong());
            Assert.AreEqual(false, "int".IsLong());
            Assert.AreEqual(false, "null".IsLong());
            Assert.AreEqual(false, "1.1".IsLong());
            Assert.AreEqual(false, "1.9".IsLong());
            Assert.AreEqual(false, "long.MinValue".IsLong());
            Assert.AreEqual(false, "long.MinValue".IsLong());

            Assert.AreEqual(false, ((double)long.MinValue - 1).ToString(CultureInfo.InvariantCulture).IsLong());
            Assert.AreEqual(false, ((double)long.MaxValue + 1).ToString(CultureInfo.InvariantCulture).IsLong());
        }

        [TestMethod]
        public void IsInt64_True_Should()
        {
            Assert.AreEqual(true, "0".IsInt64());
            Assert.AreEqual(true, "1".IsInt64());
            Assert.AreEqual(true, "-1".IsInt64());
            Assert.AreEqual(true, long.MaxValue.ToString().IsInt64());
            Assert.AreEqual(true, long.MinValue.ToString().IsInt64());
            Assert.AreEqual(true, int.MaxValue.ToString().IsInt64());
            Assert.AreEqual(true, int.MinValue.ToString().IsInt64());
            Assert.AreEqual(true, short.MaxValue.ToString().IsInt64());
            Assert.AreEqual(true, short.MinValue.ToString().IsInt64());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                // ReSharper disable once BuiltInTypeReferenceStyle
                Int64 l = r.Long();
                Assert.IsTrue(l.ToString().IsInt64());
            });
        }

        [TestMethod]
        public void IsInt64_False_Should()
        {
            Assert.AreEqual(false, "abcdefg".IsInt64());
            Assert.AreEqual(false, "int".IsInt64());
            Assert.AreEqual(false, "null".IsInt64());
            Assert.AreEqual(false, "1.1".IsInt64());
            Assert.AreEqual(false, "1.9".IsInt64());
            Assert.AreEqual(false, "long.MinValue".IsInt64());
            Assert.AreEqual(false, "long.MinValue".IsInt64());

            Assert.AreEqual(false, "abcdefg".IsInt64());
            Assert.AreEqual(false, "int".IsInt64());
            Assert.AreEqual(false, "null".IsInt64());
            Assert.AreEqual(false, "1.1".IsInt64());
            Assert.AreEqual(false, "1.9".IsInt64());
            Assert.AreEqual(false, "long.MinValue".IsInt64());
            Assert.AreEqual(false, "long.MinValue".IsInt64());

            Assert.AreEqual(false, ((double)long.MinValue - 1).ToString(CultureInfo.InvariantCulture).IsInt64());
            Assert.AreEqual(false, ((double)long.MaxValue + 1).ToString(CultureInfo.InvariantCulture).IsInt64());
        }
    }
}

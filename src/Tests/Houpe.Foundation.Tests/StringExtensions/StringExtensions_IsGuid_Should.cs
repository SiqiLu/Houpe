// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsGuid_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsGuid_Should
    {
        [TestMethod]
        public void IsGuid_True_Should()
        {
            Guid testData = Guid.NewGuid();

            Assert.IsTrue(testData.ToString("N").IsGuid());
            Assert.IsTrue(testData.ToString("N").ToUpperInvariant().IsGuid());

            Assert.IsTrue(testData.ToString("D").IsGuid("D"));
            Assert.IsTrue(testData.ToString("B").IsGuid("B"));
            Assert.IsTrue(testData.ToString("P").IsGuid("P"));

            Assert.IsTrue(Guid.Empty.ToString("N").IsGuid());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                Guid g = r.Guid();
                Assert.IsTrue(g.ToString("N").IsGuid());
            });
        }

        [TestMethod]
        public void IsGuid_False_Should()
        {
            Assert.IsFalse("abcdefg".IsGuid());
            Assert.IsFalse("guid".IsGuid());
            Assert.IsFalse("null".IsGuid());
            Assert.IsFalse("1".IsGuid());
            Assert.IsFalse("0".IsGuid());
            Assert.IsFalse("Guid.Empty".IsGuid());
        }
    }
}

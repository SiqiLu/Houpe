// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : GuidExtensions_ToGuidString_Should.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class GuidExtensions_ToGuidString_Should
    {
        [TestMethod]
        public void ToGuidString_Should()
        {
            Guid testData = new Guid("D899A0B5-0FCE-4C95-8EFF-89A2013634F8");
            Assert.AreEqual("D899A0B50FCE4C958EFF89A2013634F8", testData.ToGuidString());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                Guid g = r.Guid();
                Assert.AreEqual(g.ToString("N").ToUpperInvariant(), g.ToGuidString());
            });
        }
    }
}

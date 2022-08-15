// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsCMCellphone_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsCMCellphone_Should
    {
        [TestMethod]
        public void IsCMCellphone_True_Should()
        {
            Assert.IsTrue("13012345678".IsCMCellphone());
            Assert.IsTrue("+8613012345678".IsCMCellphone());

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                string number = r.Int(100000000, 999999999).ToString();
                Assert.IsTrue(("13" + number).IsCMCellphone());
                Assert.IsTrue(("14" + number).IsCMCellphone());
                Assert.IsTrue(("15" + number).IsCMCellphone());
                Assert.IsTrue(("16" + number).IsCMCellphone());
                Assert.IsTrue(("17" + number).IsCMCellphone());
                Assert.IsTrue(("18" + number).IsCMCellphone());
                Assert.IsTrue(("19" + number).IsCMCellphone());
                Assert.IsTrue(("10" + number).IsCMCellphone());

                Assert.IsTrue(("+8613" + number).IsCMCellphone());
                Assert.IsTrue(("+8614" + number).IsCMCellphone());
                Assert.IsTrue(("+8615" + number).IsCMCellphone());
                Assert.IsTrue(("+8616" + number).IsCMCellphone());
                Assert.IsTrue(("+8617" + number).IsCMCellphone());
                Assert.IsTrue(("+8618" + number).IsCMCellphone());
                Assert.IsTrue(("+8619" + number).IsCMCellphone());
                Assert.IsTrue(("+8610" + number).IsCMCellphone());
            });
        }

        [TestMethod]
        public void IsCMCellphone_False_Should()
        {
            Assert.IsFalse("1301234567".IsCMCellphone());
            Assert.IsFalse("130123456789".IsCMCellphone());
            Assert.IsFalse("1301234567a".IsCMCellphone());
            Assert.IsFalse("12012345678".IsCMCellphone());
            Assert.IsFalse("+8512012345678".IsCMCellphone());
            Assert.IsFalse("8512012345678".IsCMCellphone());
        }
    }
}

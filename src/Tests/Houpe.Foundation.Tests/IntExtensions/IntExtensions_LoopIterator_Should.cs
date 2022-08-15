// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_LoopIterator_Should.cs
// CreatedAt        : 2022-08-05
// LastModifiedAt   : 2022-08-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class IntExtensions_LoopIterator_Should
    {
        [TestMethod]
        public void IntExtensions_LoopIterator_Do_Index_Action_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            times.Times().Do(i =>
            {
                Assert.AreEqual(i, result);
                result++;
            });

            Assert.AreEqual(times, result);
        }

        [TestMethod]
        public void IntExtensions_LoopIterator_Do_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            times.Times().Do(() => result++);

            Assert.AreEqual(times, result);
        }
    }
}

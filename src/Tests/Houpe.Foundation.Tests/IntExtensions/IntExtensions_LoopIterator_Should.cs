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

            times.Times().Do((Action)(() => result++));

            Assert.AreEqual(times, result);
        }

        [TestMethod]
        public void IntExtensions_LoopIterator_Do_TResult_Index_Func_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            IList<int> results = times.Times().Do(i =>
            {
                Assert.AreEqual(i, result);
                result++;
                return i;
            }).ToList();

            Assert.AreEqual(times, result);
            Assert.AreEqual((0 + times - 1) * times / 2, results.Sum());
        }

        [TestMethod]
        public void IntExtensions_LoopIterator_Do_TResult_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            IList<int> results = times.Times().Do(() => ++result).ToList();

            Assert.AreEqual(times, result);
            Assert.AreEqual((1 + times) * times / 2, results.Sum());
        }

        [TestMethod]
        public async Task IntExtensions_LoopIterator_DoAsync_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            await times.Times().DoAsync(async () =>
            {
                if (result % 37 == 0)
                {
                    await Task.Delay(1);
                }

                result++;
            });

            Assert.AreEqual(times, result);
        }

        [TestMethod]
        public async Task IntExtensions_LoopIterator_DoAsync_TResult_Index_Func_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            IList<int> results = (await times.Times().DoAsync(async i =>
            {
                Assert.AreEqual(i, result);
                if (i % 37 == 0)
                {
                    await Task.Delay(1);
                }

                result++;
                return i;
            })).ToList();

            Assert.AreEqual(times, result);
            Assert.AreEqual((0 + times - 1) * times / 2, results.Sum());
        }

        [TestMethod]
        public async Task IntExtensions_LoopIterator_DoAsync_TResult_Should()
        {
            int result = 0;
            Randomizer r = new Randomizer();
            int times = r.Number(0, 10000);

            IList<int> results = (await times.Times().DoAsync(async () =>
            {
                if (result % 37 == 0)
                {
                    await Task.Delay(1);
                }

                return ++result;
            })).ToList();

            Assert.AreEqual(times, result);
            Assert.AreEqual((1 + times) * times / 2, results.Sum());
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_Times_Test.cs
// CreatedAt        : 2021-05-06
// LastModifiedAt   : 2021-05-31
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class IntExtensions_Times_Test
    {
        [TestMethod]
        public void Times_Input10_Should()
        {
            int input = 10;

            int n = 0;

            input.Times().Do(() => n++);

            Assert.AreEqual(10, n);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Times_InputNeg_Exception()
        {
            int input = -1;
            int _ = 0;
            input.Times().Do(() => _++);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Times_InputMinValue_Exception()
        {
            int input = int.MinValue;
            int _ = 0;
            input.Times().Do(() => _++);
        }
    }
}

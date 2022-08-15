// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_LoopIterator_Exception.cs
// CreatedAt        : 2022-08-06
// LastModifiedAt   : 2022-08-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class IntExtensions_LoopIterator_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntExtensions_LoopIterator_Do_ArgumentNullException() => 10.Times().Do((Action)null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntExtensions_LoopIterator_Do_Index_Action_ArgumentNullException() => 10.Times().Do((Action<int>)null);
    }
}

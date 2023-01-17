// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IntExtensions_LoopIterator_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8625
#pragma warning disable CS8600

namespace Houpe.Foundation.Tests;

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

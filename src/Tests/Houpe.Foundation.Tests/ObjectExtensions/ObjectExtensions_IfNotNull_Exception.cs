// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_IfNotNull_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8600
#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class ObjectExtensions_IfNotNull_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IfNotNull_Action_ArgumentNullException() => "Hello World!".IfNotNull(null);

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IfNotNull_Func_ArgumentNullException() => _ = "Hello World!".IfNotNull((Func<string, string>)null);
}

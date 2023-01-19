// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_Stringfied_Exception.cs
// CreatedAt        : 2023-01-19
// LastModifiedAt   : 2023-01-19
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class ObjectExtensions_Stringfied_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Stringfied_Value_ArgumentNullException() => ((object?)null).Stringified();
}

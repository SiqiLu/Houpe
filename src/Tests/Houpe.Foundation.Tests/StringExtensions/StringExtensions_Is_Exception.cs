// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_Is_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_Is_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IsCMCellphone_ArgumentNullException() => _ = ((string?)null).IsCMCellphone();

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IsEmail_ArgumentNullException() => _ = ((string?)null).IsEmail();

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IsIPAddress_ArgumentNullException() => _ = ((string?)null).IsIPAddress();
}

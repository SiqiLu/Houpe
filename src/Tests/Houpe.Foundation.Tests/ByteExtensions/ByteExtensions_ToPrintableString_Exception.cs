// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ByteExtensions_ToPrintableString_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class ByteExtensions_ToPrintableString_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ToPrintableString_Exception()
    {
        byte[]? input = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        string _ = input.ToPrintableString();
    }
}

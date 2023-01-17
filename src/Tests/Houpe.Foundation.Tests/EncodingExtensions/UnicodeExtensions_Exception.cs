// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : UnicodeExtensions_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class UnicodeExtensions_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void DecodeToStringByUnicode_Exception()
    {
        byte[]? input = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = input.DecodeToStringByUnicode();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void EncodeToBytesByUnicode_Exception()
    {
        string? input = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = input.EncodeToBytesByUnicode();
    }
}

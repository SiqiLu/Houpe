// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : UTF8Extensions_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class UTF8Extensions_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void DecodeToStringByUTF8_Exception()
    {
        byte[]? input = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = input.DecodeToStringByUTF8();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void EncodeToBytesByUTF8_Exception()
    {
        string? input = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = input.EncodeToBytesByUTF8();
    }
}

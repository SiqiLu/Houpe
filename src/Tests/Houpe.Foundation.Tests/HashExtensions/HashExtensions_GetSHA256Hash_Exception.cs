// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : HashExtensions_GetSHA256Hash_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class HashExtensions_GetSHA256Hash_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetSHA256Hash_ArgumentNullException()
    {
        string? input = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = input.GetSHA256Hash();
    }
}

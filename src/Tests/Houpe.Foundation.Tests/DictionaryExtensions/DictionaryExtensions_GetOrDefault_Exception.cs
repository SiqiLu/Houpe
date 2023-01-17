// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DictionaryExtensions_GetOrDefault_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8600
#pragma warning disable CS8604
#pragma warning disable CS8620

namespace Houpe.Foundation.Tests;

[TestClass]
public class DictionaryExtensions_GetOrDefault_Exception
{
    [TestMethod]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetOrDefault_Dictionary_ArgumentNullException()
    {
        Dictionary<Guid, string> testData = null;
        _ = testData.GetOrDefault(Guid.NewGuid(), "foo");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GetOrDefault_Key_ArgumentNullException()
    {
        Dictionary<string, string> testData = new Dictionary<string, string>();
        _ = testData.GetOrDefault(null, "foo");
    }
}

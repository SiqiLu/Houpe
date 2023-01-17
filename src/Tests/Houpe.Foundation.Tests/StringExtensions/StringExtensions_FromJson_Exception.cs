// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FromJson_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_FromJson_Exception
{
    [TestMethod]
    [ExpectedException(typeof(JsonException))]
    public void FromJson_BadFormatException() => _ = "{}-".FromJson<TestClass>();

    [TestMethod]
    [ExpectedException(typeof(JsonException))]
    public void FromJson_WithJsonOptions_BadFormatException() => _ = "{}-".FromJson<TestClass>(JsonOptions.DataJsonOptions);

    #region Nested type: TestClass

    public class TestClass
    {
    }

    #endregion
}

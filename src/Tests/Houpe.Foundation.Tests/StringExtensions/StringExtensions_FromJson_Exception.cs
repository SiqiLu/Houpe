// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FromJson_Exception.cs
// CreatedAt        : 2021-06-07
// LastModifiedAt   : 2022-08-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
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
}

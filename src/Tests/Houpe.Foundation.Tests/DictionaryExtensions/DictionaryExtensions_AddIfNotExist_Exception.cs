// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DictionaryExtensions_AddIfNotExist_Exception.cs
// CreatedAt        : 2021-07-03
// LastModifiedAt   : 2021-07-03
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DictionaryExtensions_AddIfNotExist_Exception
    {
        [TestMethod]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionaryExtensions_Dictionary_ArgumentNullException()
        {
            Dictionary<Guid, string> testData = null;
            testData.AddIfNotExist(Guid.NewGuid(), "foo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DictionaryExtensions_Key_ArgumentNullException()
        {
            Dictionary<string, string> testData = new Dictionary<string, string>();
            testData.AddIfNotExist(null, "foo");
        }
    }
}

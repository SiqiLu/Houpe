// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DictionaryExtensions_AddIfNotExist_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DictionaryExtensions_AddIfNotExist_Should
{
    [TestMethod]
    public void AddIfNotExist_Should()
    {
        IDictionary<string, string> testDictionary = new Dictionary<string, string> { { "1", "a" }, { "2", "b" }, { "3", "c" } };

        testDictionary.AddIfNotExist("1", "A");

        Assert.AreEqual(3, testDictionary.Count);
        Assert.AreEqual(true, testDictionary.ContainsKey("1"));
        Assert.AreEqual("a", testDictionary["1"]);

        testDictionary.AddIfNotExist("4", "A");

        Assert.AreEqual(4, testDictionary.Count);
        Assert.AreEqual(true, testDictionary.ContainsKey("4"));
        Assert.AreEqual("A", testDictionary["4"]);
    }
}

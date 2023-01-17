// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DictionaryExtensions_GetOrDefault_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DictionaryExtensions_GetOrDefault_Should
{
    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyDoesNotExist()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key3", "default");

        // Assert
        Assert.AreEqual("default", result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyDoesNotExist_AndDefaultValueIsEmpty()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key3", string.Empty);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyDoesNotExist_AndDefaultValueIsEmptyString()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key3", string.Empty);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyDoesNotExist_AndDefaultValueIsNull()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        // ReSharper disable once RedundantArgumentDefaultValue
        string? result = dictionary.GetOrDefault("key3", null);

        // Assert
        Assert.AreEqual(null, result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyDoesNotExist_AndDefaultValueIsWhitespace()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key3", " ");

        // Assert
        Assert.AreEqual(" ", result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyExists_AndDefaultValueIsEmpty()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key1", string.Empty);

        // Assert
        Assert.AreEqual("value1", result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyExists_AndDefaultValueIsEmptyString()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key1", string.Empty);

        // Assert
        Assert.AreEqual("value1", result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyExists_AndDefaultValueIsNull()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        // ReSharper disable once RedundantArgumentDefaultValue
        string? result = dictionary.GetOrDefault("key1", null);

        // Assert
        Assert.AreEqual("value1", result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnDefaultValue_WhenKeyExists_AndDefaultValueIsWhitespace()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key1", " ");

        // Assert
        Assert.AreEqual("value1", result);
    }

    [TestMethod]
    public void GetOrDefault_ReturnValue_WhenKeyExists()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" } };

        // Act
        string? result = dictionary.GetOrDefault("key1", "default");

        // Assert
        Assert.AreEqual("value1", result);
    }
}

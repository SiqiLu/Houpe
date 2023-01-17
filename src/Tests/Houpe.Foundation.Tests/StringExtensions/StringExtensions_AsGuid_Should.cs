// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsGuid_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_AsGuid_Should
{
    [TestMethod]
    public void AsGuid_Fail_Should()
    {
        Guid testDefaultData = Guid.NewGuid();

        Assert.AreEqual(default, "abcdefg".AsGuid());
        Assert.AreEqual(default, "guid".AsGuid());
        Assert.AreEqual(default, "null".AsGuid());
        Assert.AreEqual(default, "1".AsGuid());
        Assert.AreEqual(default, "0".AsGuid());
        Assert.AreEqual(default, "Guid.Empty".AsGuid());

        Assert.AreEqual(Guid.Empty, "abcdefg".AsGuid());
        Assert.AreEqual(Guid.Empty, "guid".AsGuid());
        Assert.AreEqual(Guid.Empty, "null".AsGuid());
        Assert.AreEqual(Guid.Empty, "1".AsGuid());
        Assert.AreEqual(Guid.Empty, "0".AsGuid());
        Assert.AreEqual(Guid.Empty, "Guid.Empty".AsGuid());

        // ReSharper disable RedundantArgumentDefaultValue
        Assert.AreEqual(Guid.Empty, "abcdefg".AsGuid("N", null));
        Assert.AreEqual(Guid.Empty, "guid".AsGuid("N", null));
        Assert.AreEqual(Guid.Empty, "null".AsGuid("N", null));
        Assert.AreEqual(Guid.Empty, "1".AsGuid("N", null));
        Assert.AreEqual(Guid.Empty, "0".AsGuid("N", null));
        Assert.AreEqual(Guid.Empty, "Guid.Empty".AsGuid("N", null));

        // ReSharper restore RedundantArgumentDefaultValue

        Assert.AreEqual(testDefaultData, "abcdefg".AsGuid("N", testDefaultData));
        Assert.AreEqual(testDefaultData, "guid".AsGuid("N", testDefaultData));
        Assert.AreEqual(testDefaultData, "null".AsGuid("N", testDefaultData));
        Assert.AreEqual(testDefaultData, "1".AsGuid("N", testDefaultData));
        Assert.AreEqual(testDefaultData, "0".AsGuid("N", testDefaultData));
        Assert.AreEqual(testDefaultData, "Guid.Empty".AsGuid("N", testDefaultData));
    }

    [TestMethod]
    public void AsGuid_Success_Should()
    {
        Guid testData = Guid.NewGuid();

        Assert.AreEqual(testData, testData.ToString().AsGuid("D"));

        Assert.AreEqual(testData, testData.ToString("N").AsGuid());
        Assert.AreEqual(testData, testData.ToString("N").ToUpperInvariant().AsGuid());

        Assert.AreEqual(testData, testData.ToString("D").AsGuid("D"));
        Assert.AreEqual(testData, testData.ToString("B").AsGuid("B"));
        Assert.AreEqual(testData, testData.ToString("P").AsGuid("P"));
        Assert.AreEqual(testData, testData.ToString("X").AsGuid("X"));

        Assert.AreEqual(Guid.Empty, Guid.Empty.ToString("N").AsGuid());
    }
}

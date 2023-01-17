// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToGuid_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToGuid_Should
{
    [TestMethod]
    public void ToGuid_Should()
    {
        Guid testData = Guid.NewGuid();

        Assert.AreEqual(testData, testData.ToString().ToGuid("D"));

        Assert.AreEqual(testData, testData.ToString("N").ToGuid());
        Assert.AreEqual(testData, testData.ToString("N").ToUpperInvariant().ToGuid());

        Assert.AreEqual(testData, testData.ToString("D").ToGuid("D"));
        Assert.AreEqual(testData, testData.ToString("B").ToGuid("B"));
        Assert.AreEqual(testData, testData.ToString("P").ToGuid("P"));
        Assert.AreEqual(testData, testData.ToString("X").ToGuid("X"));

        Assert.AreEqual(Guid.Empty, Guid.Empty.ToString("N").ToGuid());
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : NullableExtensions_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class NullableExtensions_Should
{
    [TestMethod]
    public void IsFalse_Should()
    {
        Assert.AreEqual(false, ((bool?)true).IsFalse());
        Assert.AreEqual(true, ((bool?)false).IsFalse());
        Assert.AreEqual(false, ((bool?)null).IsFalse());
    }

    [TestMethod]
    public void IsFalseOrNull_Should()
    {
        Assert.AreEqual(false, ((bool?)true).IsFalseOrNull());
        Assert.AreEqual(true, ((bool?)false).IsFalseOrNull());
        Assert.AreEqual(true, ((bool?)null).IsFalseOrNull());
    }

    [TestMethod]
    public void IsTrue_Should()
    {
        Assert.AreEqual(true, ((bool?)true).IsTrue());
        Assert.AreEqual(false, ((bool?)false).IsTrue());
        Assert.AreEqual(false, ((bool?)null).IsTrue());
    }

    [TestMethod]
    public void IsTrueOrNull_Should()
    {
        Assert.AreEqual(true, ((bool?)true).IsTrueOrNull());
        Assert.AreEqual(false, ((bool?)false).IsTrueOrNull());
        Assert.AreEqual(true, ((bool?)null).IsTrueOrNull());
    }
}

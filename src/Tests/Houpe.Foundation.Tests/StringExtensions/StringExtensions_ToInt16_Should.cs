// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToInt16_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToInt16_Should
{
    [TestMethod]
    public void ToInt16_Should()
    {
        Assert.AreEqual(0, "0".ToInt16());
        Assert.AreEqual(1, "1".ToInt16());
        Assert.AreEqual(-1, "-1".ToInt16());
        Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().ToInt16());
        Assert.AreEqual(short.MinValue, short.MinValue.ToString().ToInt16());
    }
}

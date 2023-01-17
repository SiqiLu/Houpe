// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDouble_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToDouble_Should
{
    [TestMethod]
    public void ToDouble_Should()
    {
        Assert.AreEqual(0, "0".ToDouble());
        Assert.AreEqual(1, "1".ToDouble());
        Assert.AreEqual(-1, "-1".ToDouble());

        Assert.AreEqual(0d, "0".ToDouble());
        Assert.AreEqual(1d, "1".ToDouble());
        Assert.AreEqual(-1d, "-1".ToDouble());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToDouble());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToDouble());

        Assert.AreEqual(1.1d, "1.1".ToDouble());
        Assert.AreEqual(-1.1d, "-1.1".ToDouble());
        Assert.AreEqual(1.9d, "1.9".ToDouble());
        Assert.AreEqual(long.MaxValue, long.MaxValue.ToString(CultureInfo.InvariantCulture).ToDouble());
        Assert.AreEqual(long.MinValue, long.MinValue.ToString(CultureInfo.InvariantCulture).ToDouble());
        Assert.AreEqual(double.MaxValue, double.MaxValue.ToString(CultureInfo.InvariantCulture).ToDouble());
        Assert.AreEqual(double.MinValue, double.MinValue.ToString(CultureInfo.InvariantCulture).ToDouble());
    }
}

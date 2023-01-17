// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsDouble_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_AsDouble_Should
{
    [TestMethod]
    public void AsDouble_Fail_Should()
    {
        double defaultTestData = -1d;

        Assert.AreEqual(default, "abcdefg".AsDouble());
        Assert.AreEqual(default, "double".AsDouble());
        Assert.AreEqual(default, "null".AsDouble());
        Assert.AreEqual(default, "1.1.1".AsDouble());
        Assert.AreEqual(default, "1.9.9".AsDouble());
        Assert.AreEqual(default, "double.MinValue".AsDouble());
        Assert.AreEqual(default, "double.MinValue".AsDouble());

        Assert.AreEqual(defaultTestData, "abcdefg".AsDouble(defaultTestData));
        Assert.AreEqual(defaultTestData, "double".AsDouble(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".AsDouble(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.1.1".AsDouble(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.9.9".AsDouble(defaultTestData));
        Assert.AreEqual(defaultTestData, "double.MinValue".AsDouble(defaultTestData));
        Assert.AreEqual(defaultTestData, "double.MinValue".AsDouble(defaultTestData));
    }

    [TestMethod]
    public void AsDouble_Success_Should()
    {
        Assert.AreEqual(0, "0".AsDouble());
        Assert.AreEqual(1, "1".AsDouble());
        Assert.AreEqual(-1, "-1".AsDouble());

        Assert.AreEqual(0d, "0".AsDouble());
        Assert.AreEqual(1d, "1".AsDouble());
        Assert.AreEqual(-1d, "-1".AsDouble());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsDouble());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsDouble());

        Assert.AreEqual(1.1d, "1.1".AsDouble());
        Assert.AreEqual(-1.1d, "-1.1".AsDouble());
        Assert.AreEqual(1.9d, "1.9".AsDouble());
        Assert.AreEqual(long.MaxValue, long.MaxValue.ToString(CultureInfo.InvariantCulture).AsDouble());
        Assert.AreEqual(long.MinValue, long.MinValue.ToString(CultureInfo.InvariantCulture).AsDouble());
        Assert.AreEqual(double.MaxValue, double.MaxValue.ToString(CultureInfo.InvariantCulture).AsDouble());
        Assert.AreEqual(double.MinValue, double.MinValue.ToString(CultureInfo.InvariantCulture).AsDouble());
    }
}

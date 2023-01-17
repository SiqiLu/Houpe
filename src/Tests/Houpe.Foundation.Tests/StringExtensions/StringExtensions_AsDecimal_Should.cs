// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsDecimal_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_AsDecimal_Should
{
    [TestMethod]
    public void As_Decimal_Fail_Should()
    {
        decimal defaultTestData = -1m;

        Assert.AreEqual(default, "abcdefg".AsDecimal());
        Assert.AreEqual(default, "decimal".AsDecimal());
        Assert.AreEqual(default, "null".AsDecimal());
        Assert.AreEqual(default, "1.1.1".AsDecimal());
        Assert.AreEqual(default, "1.9.9".AsDecimal());
        Assert.AreEqual(default, "decimal.MinValue".AsDecimal());
        Assert.AreEqual(default, "decimal.MinValue".AsDecimal());

        Assert.AreEqual(defaultTestData, "abcdefg".AsDecimal(defaultTestData));
        Assert.AreEqual(defaultTestData, "decimal".AsDecimal(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".AsDecimal(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.1.1".AsDecimal(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.9.9".AsDecimal(defaultTestData));
        Assert.AreEqual(defaultTestData, "decimal.MinValue".AsDecimal(defaultTestData));
        Assert.AreEqual(defaultTestData, "decimal.MinValue".AsDecimal(defaultTestData));
    }

    [TestMethod]
    public void AsDecimal_Success_Should()
    {
        Assert.AreEqual(0, "0".AsDecimal());
        Assert.AreEqual(1, "1".AsDecimal());
        Assert.AreEqual(-1, "-1".AsDecimal());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsDecimal());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsDecimal());

        Assert.AreEqual(new decimal(0), "0".AsDecimal());
        Assert.AreEqual(new decimal(1), "1".AsDecimal());
        Assert.AreEqual(new decimal(-1), "-1".AsDecimal());
        Assert.AreEqual(new decimal(int.MaxValue), int.MaxValue.ToString().AsDecimal());
        Assert.AreEqual(new decimal(int.MinValue), int.MinValue.ToString().AsDecimal());

        Assert.AreEqual(new decimal(1.1), "1.1".AsDecimal());
        Assert.AreEqual(new decimal(-1.1), "-1.1".AsDecimal());
        Assert.AreEqual(new decimal(1.9), "1.9".AsDecimal());
        Assert.AreEqual(new decimal(long.MaxValue), long.MaxValue.ToString(CultureInfo.InvariantCulture).AsDecimal());
        Assert.AreEqual(new decimal(long.MinValue), long.MinValue.ToString(CultureInfo.InvariantCulture).AsDecimal());
        Assert.AreEqual(decimal.MaxValue, decimal.MaxValue.ToString(CultureInfo.InvariantCulture).AsDecimal());
        Assert.AreEqual(decimal.MinValue, decimal.MinValue.ToString(CultureInfo.InvariantCulture).AsDecimal());
    }
}

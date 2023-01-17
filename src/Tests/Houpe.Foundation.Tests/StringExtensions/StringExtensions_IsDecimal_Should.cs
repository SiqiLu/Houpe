// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsDecimal_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_IsDecimal_Should
{
    [TestMethod]
    public void IsDecimal_False_Should()
    {
        Assert.IsFalse("abcdefg".IsDecimal());
        Assert.IsFalse("decimal".IsDecimal());
        Assert.IsFalse("null".IsDecimal());
        Assert.IsFalse("1.1.1".IsDecimal());
        Assert.IsFalse("1.9.9".IsDecimal());
        Assert.IsFalse("decimal.MinValue".IsDecimal());
        Assert.IsFalse("decimal.MinValue".IsDecimal());

        Assert.IsFalse("abcdefg".IsDecimal());
        Assert.IsFalse("decimal".IsDecimal());
        Assert.IsFalse("null".IsDecimal());
        Assert.IsFalse("1.1.1".IsDecimal());
        Assert.IsFalse("1.9.9".IsDecimal());
        Assert.IsFalse("decimal.MinValue".IsDecimal());
        Assert.IsFalse("decimal.MinValue".IsDecimal());
    }

    [TestMethod]
    public void IsDecimal_True_Should()
    {
        Assert.IsTrue("0".IsDecimal());
        Assert.IsTrue("1".IsDecimal());
        Assert.IsTrue("-1".IsDecimal());
        Assert.IsTrue(int.MaxValue.ToString().IsDecimal());
        Assert.IsTrue(int.MinValue.ToString().IsDecimal());

        Assert.IsTrue("0".IsDecimal());
        Assert.IsTrue("1".IsDecimal());
        Assert.IsTrue("-1".IsDecimal());
        Assert.IsTrue(int.MaxValue.ToString().IsDecimal());
        Assert.IsTrue(int.MinValue.ToString().IsDecimal());

        Assert.IsTrue("1.1".IsDecimal());
        Assert.IsTrue("-1.1".IsDecimal());
        Assert.IsTrue("1.9".IsDecimal());
        Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsDecimal());
        Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).IsDecimal());
        Assert.IsTrue(decimal.MaxValue.ToString(CultureInfo.InvariantCulture).IsDecimal());
        Assert.IsTrue(decimal.MinValue.ToString(CultureInfo.InvariantCulture).IsDecimal());

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            decimal d = r.Decimal();
            Assert.IsTrue(d.ToString(CultureInfo.InvariantCulture).IsDecimal());
        });
    }
}

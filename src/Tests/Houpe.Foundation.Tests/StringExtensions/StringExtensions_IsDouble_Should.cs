// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsDouble_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_IsDouble_Should
{
    [TestMethod]
    public void IsDouble_False_Should()
    {
        Assert.IsFalse("abcdefg".IsDouble());
        Assert.IsFalse("double".IsDouble());
        Assert.IsFalse("null".IsDouble());
        Assert.IsFalse("1.1.1".IsDouble());
        Assert.IsFalse("1.9.9".IsDouble());
        Assert.IsFalse("double.MinValue".IsDouble());
        Assert.IsFalse("double.MinValue".IsDouble());

        Assert.IsFalse("abcdefg".IsDouble());
        Assert.IsFalse("double".IsDouble());
        Assert.IsFalse("null".IsDouble());
        Assert.IsFalse("1.1.1".IsDouble());
        Assert.IsFalse("1.9.9".IsDouble());
        Assert.IsFalse("double.MinValue".IsDouble());
        Assert.IsFalse("double.MinValue".IsDouble());
    }

    [TestMethod]
    public void IsDouble_True_Should()
    {
        Assert.IsTrue("0".IsDouble());
        Assert.IsTrue("1".IsDouble());
        Assert.IsTrue("-1".IsDouble());

        Assert.IsTrue("0".IsDouble());
        Assert.IsTrue("1".IsDouble());
        Assert.IsTrue("-1".IsDouble());
        Assert.IsTrue(int.MaxValue.ToString().IsDouble());
        Assert.IsTrue(int.MinValue.ToString().IsDouble());

        Assert.IsTrue("1.1".IsDouble());
        Assert.IsTrue("-1.1".IsDouble());
        Assert.IsTrue("1.9".IsDouble());
        Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).IsDouble());
        Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).IsDouble());
        Assert.IsTrue(double.MaxValue.ToString(CultureInfo.InvariantCulture).IsDouble());
        Assert.IsTrue(double.MinValue.ToString(CultureInfo.InvariantCulture).IsDouble());

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            double d = r.Double();
            Assert.IsTrue(d.ToString(CultureInfo.InvariantCulture).IsDouble());
        });
    }
}

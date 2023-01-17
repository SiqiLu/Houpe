// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsFloat_AsSingle_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_AsFloat_AsSingle_Should
{
    [TestMethod]
    public void AsFloat_Fail_Should()
    {
        float defaultTestData = -1f;

        Assert.AreEqual(default, "abcdefg".AsFloat());
        Assert.AreEqual(default, "float".AsFloat());
        Assert.AreEqual(default, "null".AsFloat());
        Assert.AreEqual(default, "1.1.1".AsFloat());
        Assert.AreEqual(default, "1.9.9".AsFloat());
        Assert.AreEqual(default, "float.MinValue".AsFloat());
        Assert.AreEqual(default, "float.MinValue".AsFloat());

        Assert.AreEqual(defaultTestData, "abcdefg".AsFloat(defaultTestData));
        Assert.AreEqual(defaultTestData, "float".AsFloat(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".AsFloat(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.1.1".AsFloat(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.9.9".AsFloat(defaultTestData));
        Assert.AreEqual(defaultTestData, "float.MinValue".AsFloat(defaultTestData));
        Assert.AreEqual(defaultTestData, "float.MinValue".AsFloat(defaultTestData));
    }

    [TestMethod]
    public void AsFloat_Success_Should()
    {
        Assert.AreEqual(0, "0".AsFloat());
        Assert.AreEqual(1, "1".AsFloat());
        Assert.AreEqual(-1, "-1".AsFloat());

        Assert.AreEqual(0f, "0".AsFloat());
        Assert.AreEqual(1f, "1".AsFloat());
        Assert.AreEqual(-1f, "-1".AsFloat());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsFloat());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsFloat());

        Assert.AreEqual(1.1f, "1.1".AsFloat());
        Assert.AreEqual(-1.1f, "-1.1".AsFloat());
        Assert.AreEqual(1.9f, "1.9".AsFloat());
        Assert.AreEqual(long.MaxValue, long.MaxValue.ToString(CultureInfo.InvariantCulture).AsFloat());
        Assert.AreEqual(long.MinValue, long.MinValue.ToString(CultureInfo.InvariantCulture).AsFloat());
        Assert.AreEqual(float.MaxValue, float.MaxValue.ToString(CultureInfo.InvariantCulture).AsFloat());
        Assert.AreEqual(float.MinValue, float.MinValue.ToString(CultureInfo.InvariantCulture).AsFloat());
    }

    [TestMethod]
    public void AsSingle_Fail_Should()
    {
        float defaultTestData = -1f;

        Assert.AreEqual(default, "abcdefg".AsSingle());
        Assert.AreEqual(default, "float".AsSingle());
        Assert.AreEqual(default, "null".AsSingle());
        Assert.AreEqual(default, "1.1.1".AsSingle());
        Assert.AreEqual(default, "1.9.9".AsSingle());
        Assert.AreEqual(default, "float.MinValue".AsSingle());
        Assert.AreEqual(default, "float.MinValue".AsSingle());

        Assert.AreEqual(defaultTestData, "abcdefg".AsSingle(defaultTestData));
        Assert.AreEqual(defaultTestData, "float".AsSingle(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".AsSingle(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.1.1".AsSingle(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.9.9".AsSingle(defaultTestData));
        Assert.AreEqual(defaultTestData, "float.MinValue".AsSingle(defaultTestData));
        Assert.AreEqual(defaultTestData, "float.MinValue".AsSingle(defaultTestData));
    }

    [TestMethod]
    public void AsSingle_Success_Should()
    {
        Assert.AreEqual(0, "0".AsSingle());
        Assert.AreEqual(1, "1".AsSingle());
        Assert.AreEqual(-1, "-1".AsSingle());

        Assert.AreEqual(0f, "0".AsSingle());
        Assert.AreEqual(1f, "1".AsSingle());
        Assert.AreEqual(-1f, "-1".AsSingle());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().AsSingle());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().AsSingle());

        Assert.AreEqual(1.1f, "1.1".AsSingle());
        Assert.AreEqual(-1.1f, "-1.1".AsSingle());
        Assert.AreEqual(1.9f, "1.9".AsSingle());
        Assert.AreEqual(long.MaxValue, long.MaxValue.ToString(CultureInfo.InvariantCulture).AsSingle());
        Assert.AreEqual(long.MinValue, long.MinValue.ToString(CultureInfo.InvariantCulture).AsSingle());
        Assert.AreEqual(float.MaxValue, float.MaxValue.ToString(CultureInfo.InvariantCulture).AsSingle());
        Assert.AreEqual(float.MinValue, float.MinValue.ToString(CultureInfo.InvariantCulture).AsSingle());
    }
}

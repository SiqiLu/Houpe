// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsBoolean_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_AsBoolean_Should
{
    [TestMethod]
    public void As_Boolean_Fail_Should()
    {
        Assert.AreEqual(default, "abcdefg".AsBoolean());
        Assert.AreEqual(default, "bool".AsBoolean());
        Assert.AreEqual(default, "null".AsBoolean());
        Assert.AreEqual(default, "-1".AsBoolean());
        Assert.AreEqual(default, "1".AsBoolean());
        Assert.AreEqual(default, "0".AsBoolean());
        Assert.AreEqual(default, "T".AsBoolean());
        Assert.AreEqual(default, "F".AsBoolean());
        Assert.AreEqual(default, "t".AsBoolean());
        Assert.AreEqual(default, "f".AsBoolean());

        // ReSharper disable RedundantArgumentDefaultValue
        Assert.AreEqual(false, "abcdefg".AsBoolean(false));
        Assert.AreEqual(false, "bool".AsBoolean(false));
        Assert.AreEqual(false, "null".AsBoolean(false));
        Assert.AreEqual(false, "-1".AsBoolean(false));
        Assert.AreEqual(false, "1".AsBoolean(false));
        Assert.AreEqual(false, "0".AsBoolean(false));
        Assert.AreEqual(false, "T".AsBoolean(false));
        Assert.AreEqual(false, "F".AsBoolean(false));
        Assert.AreEqual(false, "t".AsBoolean(false));
        Assert.AreEqual(false, "f".AsBoolean(false));

        // ReSharper restore RedundantArgumentDefaultValue

        Assert.AreEqual(true, "abcdefg".AsBoolean(true));
        Assert.AreEqual(true, "bool".AsBoolean(true));
        Assert.AreEqual(true, "null".AsBoolean(true));
        Assert.AreEqual(true, "-1".AsBoolean(true));
        Assert.AreEqual(true, "1".AsBoolean(true));
        Assert.AreEqual(true, "0".AsBoolean(true));
        Assert.AreEqual(true, "T".AsBoolean(true));
        Assert.AreEqual(true, "F".AsBoolean(true));
        Assert.AreEqual(true, "t".AsBoolean(true));
        Assert.AreEqual(true, "f".AsBoolean(true));
    }

    [TestMethod]
    public void AsBoolean_Success_Should()
    {
        Assert.AreEqual(false, "false".AsBoolean());
        Assert.AreEqual(false, "False".AsBoolean());
        Assert.AreEqual(false, "fAlSe".AsBoolean());
        Assert.AreEqual(true, "true".AsBoolean());
        Assert.AreEqual(true, "True".AsBoolean());
        Assert.AreEqual(true, "tRuE".AsBoolean());
    }
}

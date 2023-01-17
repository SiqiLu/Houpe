// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FormatWith_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_FormatWith_Should
{
    private static readonly string s_testData = "0-{0}-1-{1}-2-{2}";

    [TestMethod]
    public void FormatWith_MoreArgument_Should()
    {
        string actual = s_testData.FormatWith("a", "b", "c", "d");
        string expected = "0-a-1-b-2-c";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormatWith_Should()
    {
        string actual = s_testData.FormatWith("a", "b", "c");
        string expected = "0-a-1-b-2-c";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormatWith2_MoreArgument_Should()
    {
        string actual = s_testData.FormatWith(new DateTimeFormatInfo(), "a", "b", "c", "d");
        string expected = "0-a-1-b-2-c";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormatWith2_Should()
    {
        string actual = s_testData.FormatWith(new DateTimeFormatInfo(), "a", "b", "c");
        string expected = "0-a-1-b-2-c";

        Assert.AreEqual(expected, actual);
    }
}

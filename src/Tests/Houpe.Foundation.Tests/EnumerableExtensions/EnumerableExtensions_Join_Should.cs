// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_Join_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class EnumerableExtensions_Join_Should
{
    private static readonly IEnumerable<int> s_testIntData = new[] { 0, 1, 2, 3 };
    private static readonly IEnumerable<string> s_testStringData = new[] { "0", "1", "2", "3" };

    [TestMethod]
    public void Join_Should()
    {
        string? result1 = s_testIntData.Join();
        string? result2 = s_testIntData.Join(" ");
        string? result3 = s_testStringData.Join();
        string? result4 = s_testStringData.Join("|");

        string? result5 = (null as IEnumerable<string>).Join();
        string? result6 = (null as IEnumerable<string>).Join(";");
        string? result7 = (null as IEnumerable<string>).Join(null);

        string? result8 = new List<string>().Join();

        string expected1 = "0,1,2,3";
        string expected2 = "0 1 2 3";
        string expected3 = "0,1,2,3";
        string expected4 = "0|1|2|3";

        string? expected5 = null;
        string? expected6 = null;
        string? expected7 = null;
        string expected8 = "";

        Assert.AreEqual(expected1, result1);
        Assert.AreEqual(expected2, result2);
        Assert.AreEqual(expected3, result3);
        Assert.AreEqual(expected4, result4);

        // ReSharper disable once ExpressionIsAlwaysNull
        Assert.AreEqual(expected5, result5);
        Assert.AreEqual(expected6, result6);
        Assert.AreEqual(expected7, result7);
        Assert.AreEqual(expected8, result8);
    }
}

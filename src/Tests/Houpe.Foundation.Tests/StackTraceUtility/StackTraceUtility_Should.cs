// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StackTraceUtility_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StackTraceUtility_Should
{
    [TestMethod]
    public void StackTraceUtility_GetCurrentClassName_Should()
    {
        string result = StackTraceUtility.GetCurrentClassName();
        Assert.AreEqual("Houpe.Foundation.Tests.StackTraceUtility_Should", result);

        Assert.AreEqual("Houpe.Foundation.StackTraceUtility", StackTraceUtility.GetCurrentClassName(0));
        Assert.AreEqual("", StackTraceUtility.GetCurrentClassName(-1));
        Assert.AreEqual("", StackTraceUtility.GetCurrentClassName(-2));
        Assert.AreEqual("", StackTraceUtility.GetCurrentClassName(int.MaxValue));
    }

    [TestMethod]
    public void StackTraceUtility_GetCurrentMethodName_Should()
    {
        string result = StackTraceUtility.GetCurrentMethodName();
        Assert.AreEqual("StackTraceUtility_GetCurrentMethodName_Should", result);

        Assert.AreEqual("GetCurrentMethodName", StackTraceUtility.GetCurrentMethodName(0));
        Assert.AreEqual("", StackTraceUtility.GetCurrentMethodName(-1));
        Assert.AreEqual("", StackTraceUtility.GetCurrentMethodName(-2));
        Assert.AreEqual("", StackTraceUtility.GetCurrentMethodName(int.MaxValue));
    }
}

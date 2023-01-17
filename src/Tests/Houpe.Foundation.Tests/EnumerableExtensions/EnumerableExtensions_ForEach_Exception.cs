// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_ForEach_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8604

namespace Houpe.Foundation.Tests;

[TestClass]
public class EnumerableExtensions_ForEach_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ForEach_Action_Action_Null_ArgumentNullException()
    {
        IEnumerable<int> testData = new List<int>();
        Action<int>? testAction = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        testData.ForEach(testAction);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ForEach_Action_Null_ArgumentNullException()
    {
        IEnumerable<int>? testData = null;
        int intResult = 0;

        // ReSharper disable once ExpressionIsAlwaysNull
        testData.ForEach(i =>
        {
            intResult = intResult + i;

            // ReSharper disable once RedundantJumpStatement
            return;
        });
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public async Task ForEach_Async_Func_Action_Null_ArgumentNullException_Async()
    {
        IEnumerable<int> testData = new List<int>();
        Func<int, Task>? testAction = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        await testData.ForEach(testAction);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public async Task ForEach_Async_Func_Null_ArgumentNullException_Async()
    {
        IEnumerable<int>? testData = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        await testData.ForEach(async _ => await Task.Delay(1));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public async Task ForEach_Async_Func_T_Action_Null_ArgumentNullException_Async()
    {
        IEnumerable<int> testData = new List<int>();
        Func<int, Task<string>>? testAction = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = await testData.ForEach(testAction);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public async Task ForEach_Async_Func_T_Null_ArgumentNullException_Async()
    {
        IEnumerable<int>? testData = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = await testData.ForEach(async i =>
        {
            await Task.Delay(1);
            return i.ToString();
        });
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ForEach_Func_Action_Null_ArgumentNullException()
    {
        IEnumerable<int> testData = new List<int>();
        Func<int, string>? testAction = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = testData.ForEach(testAction);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ForEach_Func_Null_ArgumentNullException()
    {
        IEnumerable<int>? testData = null;

        // ReSharper disable once ExpressionIsAlwaysNull
        _ = testData.ForEach(i => i.ToString());
    }
}

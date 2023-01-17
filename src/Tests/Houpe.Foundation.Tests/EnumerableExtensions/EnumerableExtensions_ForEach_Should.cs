// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumerableExtensions_ForEach_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class EnumerableExtensions_ForEach_Should
{
    public static readonly int[] s_testIntData = { 1, 2, 3, 4, 5 };
    public static readonly string[] s_testStringData = { "a", "b", "c", "d", "e" };

    [TestMethod]
    public void ForEach_Action_Empty_Should()
    {
        IEnumerable<int> testData = new List<int>();
        int intResult = 0;
        testData.ForEach(i =>
        {
            intResult += i;

            // ReSharper disable once RedundantJumpStatement
            return;
        });

        int intExpected = 0;
        int testDataLength = 0;

        Assert.AreEqual(intExpected, intResult);
        Assert.AreEqual(testDataLength, testData.ToList().Count);
    }

    [TestMethod]
    public void ForEach_Action_IEnumerable_Should()
    {
        // not Array
        // not IList<T>
        string testData = "abcde";
        string stringResult = "";
        IEnumerable<char> enumerable = testData;

        enumerable.ForEach(s =>
        {
            stringResult += s;

            // ReSharper disable once RedundantJumpStatement
            return;
        });

        string expected = "abcde";

        Assert.AreEqual(expected, stringResult);
    }

    [TestMethod]
    public void ForEach_Action_Should()
    {
        int intResult = 0;
        string stringResult = "";
        s_testIntData.ForEach(i =>
        {
            intResult += i;

            // ReSharper disable once RedundantJumpStatement
            return;
        });

        s_testStringData.ForEach(s =>
        {
            stringResult += s;

            // ReSharper disable once RedundantJumpStatement
            return;
        });
        int intExpected = 15;

        // ReSharper disable once StringLiteralTypo
        string stringExpected = "abcde";

        Assert.AreEqual(intExpected, intResult);
        Assert.AreEqual(stringExpected, stringResult);
    }

    [TestMethod]
    public async Task ForEach_Async_Func_Empty_Should_Async()
    {
        IEnumerable<int> testData = new List<int>();
        int intResult = 0;
        await testData.ForEach(async i =>
        {
            intResult += i;

            await Task.Delay(1);

            // ReSharper disable once RedundantJumpStatement
            return;
        });

        int intExpected = 0;
        int testDataLength = 0;

        Assert.AreEqual(intExpected, intResult);
        Assert.AreEqual(testDataLength, testData.ToList().Count);
    }

    [TestMethod]
    public async Task ForEach_Async_Func_IEnumerable_Should_Async()
    {
        // not Array
        // not IList<T>
        string testData = "abcde";
        IEnumerable<char> enumerable = testData;
        string stringResult = "";

        await enumerable.ForEach(async s =>
        {
            stringResult = stringResult + s + "-";

            await Task.Delay(1);

            // ReSharper disable once RedundantJumpStatement
            return;
        });

        string stringExpected = "a-b-c-d-e-";

        Assert.AreEqual(stringExpected, stringResult);
    }

    [TestMethod]
    public async Task ForEach_Async_Func_Should_Async()
    {
        int intResult = 0;
        string stringResult = "";
        await s_testIntData.ForEach(async i =>
        {
            intResult += i;

            await Task.Delay(1);

            // ReSharper disable once RedundantJumpStatement
            return;
        });

        await s_testStringData.ForEach(async s =>
        {
            stringResult += s;

            await Task.Delay(1);

            // ReSharper disable once RedundantJumpStatement
            return;
        });
        int intExpected = 15;

        // ReSharper disable once StringLiteralTypo
        string stringExpected = "abcde";

        Assert.AreEqual(intExpected, intResult);
        Assert.AreEqual(stringExpected, stringResult);
    }

    [TestMethod]
    public async Task ForEach_Async_Func_T_Empty_Should_Async()
    {
        IEnumerable<int> testData = new List<int>();
        IEnumerable<string> actual = await testData.ForEach(async i =>
        {
            await Task.Delay(1);
            return i.ToString();
        });

        Assert.AreEqual(0, actual.Count());
    }

    [TestMethod]
    public async Task ForEach_Async_Func_T_IEnumerable_Should_Async()
    {
        // not Array
        // not IList<T>
        string testData = "abcde";
        IEnumerable<char> enumerable = testData;

        IList<string> actual = (await enumerable.ForEach(async s =>
        {
            await Task.Delay(1);
            return s + "1";
        })).ToList();

        IList<string> expected = new List<string> { "a1", "b1", "c1", "d1", "e1" };

        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [TestMethod]
    public async Task ForEach_Async_Func_T_Should_Async()
    {
        IList<int> actual1 = (await s_testIntData.ForEach(async i =>
        {
            await Task.Delay(1);
            return i + 1;
        })).ToList();

        IList<string> actual2 = (await s_testIntData.ForEach(async i =>
        {
            await Task.Delay(1);
            return (i + 1).ToString();
        })).ToList();

        IList<string> actual3 = (await s_testStringData.ForEach(async s =>
        {
            await Task.Delay(1);
            return s + "1";
        })).ToList();

        IList<int> expected1 = new List<int> { 2, 3, 4, 5, 6 };
        IList<string> expected2 = new List<string> { "2", "3", "4", "5", "6" };
        IList<string> expected3 = new List<string> { "a1", "b1", "c1", "d1", "e1" };

        CollectionAssert.AreEqual(expected1.ToArray(), actual1.ToArray());
        CollectionAssert.AreEqual(expected2.ToArray(), actual2.ToArray());
        CollectionAssert.AreEqual(expected3.ToArray(), actual3.ToArray());
    }

    [TestMethod]
    public void ForEach_Func_Empty_Should()
    {
        IEnumerable<int> testData = new List<int>();
        IEnumerable<string> actual = testData.ForEach(i => i.ToString());

        Assert.AreEqual(0, actual.Count());
    }

    [TestMethod]
    public void ForEach_Func_IEnumerable_Should()
    {
        // not Array
        // not IList<T>
        string testData = "abcde";
        IEnumerable<char> enumerable = testData;

        IList<string> actual = enumerable.ForEach(s => s + "1").ToList();

        IList<string> expected = new List<string> { "a1", "b1", "c1", "d1", "e1" };

        CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
    }

    [TestMethod]
    public void ForEach_Func_Should()
    {
        IList<int> actual1 = s_testIntData.ForEach(i => i + 1).ToList();
        IList<string> actual2 = s_testIntData.ForEach(i => (i + 1).ToString()).ToList();
        IList<string> actual3 = s_testStringData.ForEach(s => s + "1").ToList();

        IList<int> expected1 = new List<int> { 2, 3, 4, 5, 6 };
        IList<string> expected2 = new List<string> { "2", "3", "4", "5", "6" };
        IList<string> expected3 = new List<string> { "a1", "b1", "c1", "d1", "e1" };

        CollectionAssert.AreEqual(expected1.ToArray(), actual1.ToArray());
        CollectionAssert.AreEqual(expected2.ToArray(), actual2.ToArray());
        CollectionAssert.AreEqual(expected3.ToArray(), actual3.ToArray());
    }
}

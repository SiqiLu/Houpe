// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_Stringified_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class ObjectExtensions_Stringified_Should
{
    [TestMethod]
    public void Stringified_Should()
    {
        Assert.AreEqual("null", ((object?)null).Stringified());
        Assert.AreEqual("\"Hello World!\"", "Hello World!".Stringified());
        Assert.AreEqual("'H'", 'H'.Stringified());

        Assert.AreEqual("[1,2,3]", new List<int> { 1, 2, 3 }.Stringified());
        Assert.AreEqual("[\"1\",\"2\",\"3\"]", new List<string> { "1", "2", "3" }.Stringified());
        Assert.AreEqual("['1','2','3']", new List<char> { '1', '2', '3' }.Stringified());

        Assert.AreEqual("[[\"1_1\",\"1_2\",\"1_3\"],[\"2_1\",\"2_2\",\"2_3\"],[\"3_1\",\"3_2\",\"3_3\"]]",
            new List<List<string>> { new List<string> { "1_1", "1_2", "1_3" }, new List<string> { "2_1", "2_2", "2_3" }, new List<string> { "3_1", "3_2", "3_3" } }
                .Stringified());

        // Stringified 的对象出现循环引用，则会出现内部一场，最终只会返回 ToString() 的结果。
        // ReSharper disable once UseObjectOrCollectionInitializer
        List<object> testData = new List<object> { "1" };
        testData.Add(testData);
        Assert.AreEqual("System.Collections.Generic.List`1[System.Object]", testData.Stringified());
    }
}

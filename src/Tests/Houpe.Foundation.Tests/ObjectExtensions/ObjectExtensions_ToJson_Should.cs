// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_ToJson_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Houpe.Foundation.Tests;

[TestClass]
public class ObjectExtensions_ToJson_Should
{
    [TestMethod]
    public void ToJson_Should()
    {
        Assert.AreEqual(null, ((object?)null).ToJson());
        Assert.AreEqual("defaultValue", ((object?)null).ToJson("defaultValue"));

        List<string> testData1 = new List<string> { "1", "2", "3" };
        Assert.AreEqual(JsonSerializer.Serialize(testData1), testData1.ToJson());
        Assert.AreEqual("[\"1\",\"2\",\"3\"]", testData1.ToJson());

        // ReSharper disable once UseObjectOrCollectionInitializer
        // 如果数据中存在循环引用，就需要将 JsonOptions 中的 ReferenceHandler 设置为 ReferenceHandler.Preserve 才能够支持
        List<object> testData2 = new List<object> { "1", testData1 };
        testData2.Add(testData2);
        Assert.AreEqual("System.Collections.Generic.List`1[System.Object]", testData2.ToJson());
        Assert.AreEqual(JsonSerializer.Serialize(testData2, JsonOptions.DataJsonOptions), testData2.ToJson(JsonOptions.DataJsonOptions));
    }
}

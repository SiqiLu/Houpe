// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_ToJson_Exception.cs
// CreatedAt        : 2023-01-19
// LastModifiedAt   : 2023-01-19
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class ObjectExtensions_ToJson_Exception
{
    [TestMethod]
    [ExpectedException(typeof(JsonException))]
    public void ToJson_JsonException()
    {
        List<string> testData1 = new List<string> { "1", "2", "3" };

        // ReSharper disable once UseObjectOrCollectionInitializer
        // 如果数据中存在循环引用，就需要将 JsonOptions 中的 ReferenceHandler 设置为 ReferenceHandler.Preserve 才能够支持
        List<object> testData2 = new List<object> { "1", testData1 };
        testData2.Add(testData2);
        Assert.AreEqual(JsonSerializer.Serialize(testData2, JsonOptions.DataJsonOptions), testData2.ToJson(JsonOptions.DataJsonOptions));

        _ = testData2.ToJson();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ToJson_Value_ArgumentNullException() => ((object?)null).ToJson();
}

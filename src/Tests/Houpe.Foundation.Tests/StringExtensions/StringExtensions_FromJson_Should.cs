// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FromJson_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_FromJson_Should
{
    [TestMethod]
    public void FromJson_TestObject_Should()
    {
        TestClass? testClass1 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>();
        Assert.IsNotNull(testClass1);
        Assert.AreEqual(1, testClass1.IntProperty);
        Assert.AreEqual("2", testClass1.StringProperty);

        TestClass? testClass2 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>(JsonOptions.DataJsonOptions);
        Assert.IsNotNull(testClass2);
        Assert.AreEqual(1, testClass2.IntProperty);
        Assert.AreEqual("2", testClass2.StringProperty);

        TestClass? testClass3 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>(JsonOptions.LogJsonOptions);
        Assert.IsNotNull(testClass3);
        Assert.AreEqual(1, testClass3.IntProperty);
        Assert.AreEqual("2", testClass3.StringProperty);

        TestClass? testClass4 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>(JsonOptions.WebApiJsonOptions);
        Assert.IsNotNull(testClass4);
        Assert.AreEqual(1, testClass4.IntProperty);
        Assert.AreEqual("2", testClass4.StringProperty);
    }

    #region Nested type: TestClass

    public class TestClass
    {
        public int IntProperty { get; init; }

        public string? StringProperty { get; init; }

        public static TestClass GetTestData() => new TestClass { IntProperty = 1, StringProperty = "2" };
    }

    #endregion
}

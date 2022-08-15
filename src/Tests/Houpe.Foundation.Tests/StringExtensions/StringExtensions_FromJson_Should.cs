// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_FromJson_Should.cs
// CreatedAt        : 2021-06-07
// LastModifiedAt   : 2022-08-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_FromJson_Should
    {
        [TestMethod]
        public void FromJson_Empty_Should()
        {
            TestClass testClass1 = string.Empty.FromJson<TestClass>();
            Assert.IsNull(testClass1);
            Assert.AreEqual(default, testClass1);

            TestClass testClass2 = string.Empty.FromJson<TestClass>(JsonOptions.DataJsonOptions);
            Assert.IsNull(testClass2);
            Assert.AreEqual(default, testClass2);

            TestClass testClass3 = string.Empty.FromJson<TestClass>(JsonOptions.LogJsonOptions);
            Assert.IsNull(testClass3);
            Assert.AreEqual(default, testClass3);

            TestClass testClass4 = string.Empty.FromJson<TestClass>(JsonOptions.WebApiJsonOptions);
            Assert.IsNull(testClass4);
            Assert.AreEqual(default, testClass4);
        }

        [TestMethod]
        public void FromJson_Null_Should()
        {
            TestClass testClass1 = ((string)null).FromJson<TestClass>();
            Assert.IsNull(testClass1);
            Assert.AreEqual(default, testClass1);

            TestClass testClass2 = ((string)null).FromJson<TestClass>(JsonOptions.DataJsonOptions);
            Assert.IsNull(testClass2);
            Assert.AreEqual(default, testClass2);

            TestClass testClass3 = ((string)null).FromJson<TestClass>(JsonOptions.LogJsonOptions);
            Assert.IsNull(testClass3);
            Assert.AreEqual(default, testClass3);

            TestClass testClass4 = ((string)null).FromJson<TestClass>(JsonOptions.WebApiJsonOptions);
            Assert.IsNull(testClass4);
            Assert.AreEqual(default, testClass4);
        }

        [TestMethod]
        public void FromJson_EmptyObject_Should()
        {
            TestClass testClass1 = "{}".FromJson<TestClass>();
            Assert.IsNotNull(testClass1);
            Assert.AreEqual(default, testClass1.IntProperty);
            Assert.AreEqual(default, testClass1.StringProperty);

            TestClass testClass2 = "{}".FromJson<TestClass>(JsonOptions.DataJsonOptions);
            Assert.IsNotNull(testClass2);
            Assert.AreEqual(default, testClass2.IntProperty);
            Assert.AreEqual(default, testClass2.StringProperty);

            TestClass testClass3 = "{}".FromJson<TestClass>(JsonOptions.LogJsonOptions);
            Assert.IsNotNull(testClass3);
            Assert.AreEqual(default, testClass3.IntProperty);
            Assert.AreEqual(default, testClass3.StringProperty);

            TestClass testClass4 = "{}".FromJson<TestClass>(JsonOptions.WebApiJsonOptions);
            Assert.IsNotNull(testClass4);
            Assert.AreEqual(default, testClass4.IntProperty);
            Assert.AreEqual(default, testClass4.StringProperty);
        }

        [TestMethod]
        public void FromJson_TestObject_Should()
        {
            TestClass testClass1 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>();
            Assert.IsNotNull(testClass1);
            Assert.AreEqual(1, testClass1.IntProperty);
            Assert.AreEqual("2", testClass1.StringProperty);

            TestClass testClass2 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>(JsonOptions.DataJsonOptions);
            Assert.IsNotNull(testClass2);
            Assert.AreEqual(1, testClass2.IntProperty);
            Assert.AreEqual("2", testClass2.StringProperty);

            TestClass testClass3 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>(JsonOptions.LogJsonOptions);
            Assert.IsNotNull(testClass3);
            Assert.AreEqual(1, testClass3.IntProperty);
            Assert.AreEqual("2", testClass3.StringProperty);

            TestClass testClass4 = JsonConvert.SerializeObject(TestClass.GetTestData()).FromJson<TestClass>(JsonOptions.WebApiJsonOptions);
            Assert.IsNotNull(testClass4);
            Assert.AreEqual(1, testClass4.IntProperty);
            Assert.AreEqual("2", testClass4.StringProperty);
        }

        #region Nested type: TestClass

        public class TestClass
        {
            public int IntProperty { get; set; }

            public string StringProperty { get; set; }

            public static TestClass GetTestData() => new TestClass { IntProperty = 1, StringProperty = "2" };
        }

        #endregion
    }
}

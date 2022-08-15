// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : EnumTest.cs
// CreatedAt        : 2021-05-31
// LastModifiedAt   : 2022-08-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests.Enum
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        [SuppressMessage("ReSharper", "RedundantCast")]
        [SuppressMessage("ReSharper", "EqualExpressionComparison")]
        public void EnumTest_CompareTo_Equals_Should()
        {
            // 任意值都比 null 值大
            Assert.IsTrue(TestEnumType.EDefault > (TestEnumType)null);
            Assert.IsTrue(TestEnumType.E1 > (TestEnumType)null);
            Assert.IsTrue(TestEnumType.E2 > (TestEnumType)null);

            // Enum 值的大小，取决其 Code 值的大小，即为 int 值的比较
            Assert.IsTrue(TestEnumType.E1 == TestEnumType.Get(1));
            Assert.IsTrue(TestEnumType.E2 > TestEnumType.E1);
            Assert.IsTrue(TestEnumType.E3 > TestEnumType.E2);

            Assert.IsTrue(TestEnumType.E1 == TestEnumType.Get(1));
            Assert.IsTrue(TestEnumType.E4 == TestEnumType.Get(4));
            Assert.IsFalse(TestEnumType.E4 == TestEnumType.E3);

            Assert.IsTrue(TestEnumType.E2 > TestEnumType.E1);
            Assert.IsTrue(TestEnumType.E4 > TestEnumType.E3);
            Assert.IsFalse(TestEnumType.E2 > TestEnumType.E3);

            Assert.IsTrue(TestEnumType.E1 >= TestEnumType.Get(1));
            Assert.IsTrue(TestEnumType.E4 >= TestEnumType.E3);
            Assert.IsFalse(TestEnumType.E2 >= TestEnumType.E3);

            Assert.IsTrue(TestEnumType.E1 != TestEnumType.Get(2));
            Assert.IsTrue(TestEnumType.E4 != TestEnumType.E3);
            Assert.IsFalse(TestEnumType.E2 != TestEnumType.Get(2));

            Assert.IsTrue(TestEnumType.E1 < TestEnumType.Get(2));
            Assert.IsTrue(TestEnumType.E3 < TestEnumType.E4);
            Assert.IsFalse(TestEnumType.E2 < TestEnumType.Get(2));

            Assert.IsTrue(TestEnumType.E1 <= TestEnumType.Get(1));
            Assert.IsTrue(TestEnumType.E3 <= TestEnumType.E4);
            Assert.IsFalse(TestEnumType.E2 <= TestEnumType.E1);

            // null test
            // ==
            Assert.IsTrue((TestEnumType)null == (TestEnumType)null);
            Assert.IsFalse((TestEnumType)TestEnumType.EDefault == (TestEnumType)null);
            Assert.IsFalse((TestEnumType)null == (TestEnumType)TestEnumType.EDefault);

            // !=
            Assert.IsFalse((TestEnumType)null != (TestEnumType)null);
            Assert.IsTrue((TestEnumType)TestEnumType.EDefault != (TestEnumType)null);
            Assert.IsTrue((TestEnumType)null != (TestEnumType)TestEnumType.EDefault);

            // >
            Assert.IsFalse((TestEnumType)null > (TestEnumType)null);
            Assert.IsTrue((TestEnumType)TestEnumType.EDefault > (TestEnumType)null);
            Assert.IsFalse((TestEnumType)null > (TestEnumType)TestEnumType.EDefault);

            // >=
            Assert.IsTrue((TestEnumType)null >= (TestEnumType)null);
            Assert.IsTrue((TestEnumType)TestEnumType.EDefault >= (TestEnumType)null);
            Assert.IsFalse((TestEnumType)null >= (TestEnumType)TestEnumType.EDefault);

            // <
            Assert.IsFalse((TestEnumType)null < (TestEnumType)null);
            Assert.IsFalse((TestEnumType)TestEnumType.EDefault < (TestEnumType)null);
            Assert.IsTrue((TestEnumType)null < (TestEnumType)TestEnumType.EDefault);

            // <=
            Assert.IsTrue((TestEnumType)null <= (TestEnumType)null);
            Assert.IsFalse((TestEnumType)TestEnumType.EDefault <= (TestEnumType)null);
            Assert.IsTrue((TestEnumType)null <= (TestEnumType)TestEnumType.EDefault);
        }

        [TestMethod]
        public void EnumTest_CompareTo_Should()
        {
            Assert.AreEqual(1, TestEnumType.E2.CompareTo(null));
            Assert.AreEqual(0, TestEnumType.E2.CompareTo(TestEnumType.E2));

            Assert.IsTrue(TestEnumType.E2.CompareTo(TestEnumType.E3) < 0);
            Assert.IsTrue(TestEnumType.E2.CompareTo(TestEnumType.E1) > 0);
        }

        [TestMethod]
        public void EnumTest_Default_Get_Should()
        {
            Assert.IsNotNull(TestEnumType.Default);
            Assert.AreEqual(TestEnumType.EDefault, TestEnumType.Default);
            Assert.AreEqual("0", TestEnumType.Default.Value);
            Assert.AreEqual("0", TestEnumType.Default.Value);

            Assert.IsNotNull(TestEnumType1.Default);
            Assert.AreEqual(TestEnumType1.E0, TestEnumType1.Default);
            Assert.AreEqual("0", TestEnumType1.Default.Value);
            Assert.AreEqual("0", TestEnumType1.Default.Value);

            Assert.IsNull(TestEnumType2.Default);
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "RedundantCast")]
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        public void EnumTest_Equals_Should()
        {
            Assert.IsTrue(TestEnumType.Default.Equals((EnumClass<TestEnumType>)TestEnumType.EDefault));
            Assert.IsTrue(TestEnumType.Default.Equals((TestEnumType)TestEnumType.EDefault));

            Assert.IsFalse(TestEnumType.Default.Equals((EnumClass<TestEnumType>)null));
            Assert.IsFalse(TestEnumType.Default.Equals((TestEnumType)null));

            Assert.IsFalse(TestEnumType.Default.Equals((object)null));
            Assert.IsFalse(TestEnumType.Default.Equals((object)"null"));
            Assert.IsTrue(TestEnumType.Default.Equals((object)TestEnumType.EDefault));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumCodeException))]
        public void EnumTest_GetByCode_Exception() => _ = TestEnumType.Get(-1);

        [TestMethod]
        public void EnumTest_GetByCode_Should()
        {
            Assert.AreEqual(TestEnumType.EDefault, TestEnumType.Get(0));
            Assert.AreEqual(TestEnumType.E4, TestEnumType.Get(4));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumValueException))]
        public void EnumTest_GetByValue_Exception() => _ = TestEnumType.Get("-1");

        [TestMethod]
        public void EnumTest_GetByValue_Should()
        {
            Assert.AreEqual(TestEnumType.EDefault, TestEnumType.Get("0"));
            Assert.AreEqual(TestEnumType.E4, TestEnumType.Get("4"));
        }

        [TestMethod]
        public void EnumTest_GetHashCode_Should()
        {
            // GetHashCode 即为 Code 值
            Assert.AreEqual(0, TestEnumType.EDefault.GetHashCode());
            Assert.AreEqual(TestEnumType.EDefault.Code, TestEnumType.EDefault.GetHashCode());
            Assert.AreEqual(1, TestEnumType.E1.GetHashCode());
            Assert.AreEqual(TestEnumType.E1.Code, TestEnumType.E1.GetHashCode());
            Assert.AreEqual(4, TestEnumType.E4.GetHashCode());
            Assert.AreEqual(TestEnumType.E4.Code, TestEnumType.E4.GetHashCode());
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public void EnumTest_ImplicitOperator_Should()
        {
            Assert.AreEqual(TestEnumType.EDefault.Value, (string)TestEnumType.EDefault);
            Assert.AreEqual(TestEnumType.E1.Value, (string)TestEnumType.E1);
            Assert.AreEqual(TestEnumType.E2.Value, (string)TestEnumType.E2);

            Assert.AreEqual(TestEnumType.EDefault.Code, (int)TestEnumType.EDefault);
            Assert.AreEqual(TestEnumType.E1.Code, (int)TestEnumType.E1);
            Assert.AreEqual(TestEnumType.E2.Code, (int)TestEnumType.E2);
        }

        [TestMethod]
        public void EnumTest_InvalidEnumCodeException_Test()
        {
            InvalidEnumCodeException exception1 = new InvalidEnumCodeException(7, typeof(TestEnumType), "Message:{InitCode}, {EnumType}.");
            Assert.AreEqual(7, exception1.InitCode);
            Assert.AreEqual(typeof(TestEnumType), exception1.EnumType);
            Assert.AreEqual($"Message:{7}, {typeof(TestEnumType).FullName}.", exception1.Message);

            InvalidEnumCodeException exception2 = new InvalidEnumCodeException(6, typeof(TestEnumType1), "Message:{InitCode}, {EnumType}.", exception1);
            Assert.AreEqual(6, exception2.InitCode);
            Assert.AreEqual(typeof(TestEnumType1), exception2.EnumType);
            Assert.AreEqual(exception1, exception2.InnerException);
            Assert.AreEqual($"Message:{6}, {typeof(TestEnumType1).FullName}.", exception2.Message);
        }

        [TestMethod]
        public void EnumTest_InvalidEnumValueException_Test()
        {
            InvalidEnumValueException exception1 = new InvalidEnumValueException("7", typeof(TestEnumType), "Message:{InitValue}, {EnumType}.");
            Assert.AreEqual("7", exception1.InitValue);
            Assert.AreEqual(typeof(TestEnumType), exception1.EnumType);
            Assert.AreEqual($"Message:{7}, {typeof(TestEnumType).FullName}.", exception1.Message);

            InvalidEnumValueException exception2 = new InvalidEnumValueException("6", typeof(TestEnumType1), "Message:{InitValue}, {EnumType}.", exception1);
            Assert.AreEqual("6", exception2.InitValue);
            Assert.AreEqual(typeof(TestEnumType1), exception2.EnumType);
            Assert.AreEqual(exception1, exception2.InnerException);
            Assert.AreEqual($"Message:{6}, {typeof(TestEnumType1).FullName}.", exception2.Message);
        }

        [TestMethod]
        public void EnumTest_IsAvailableCode_Should()
        {
            // 0 1 2 3 4 是合法值
            Assert.IsTrue(TestEnumType.IsAvailableCode(0));
            Assert.IsTrue(TestEnumType.IsAvailableCode(1));
            Assert.IsTrue(TestEnumType.IsAvailableCode(TestEnumType.E2));
            Assert.IsTrue(TestEnumType.IsAvailableCode(TestEnumType.E3.Code));
            Assert.IsTrue(TestEnumType.IsAvailableCode(TestEnumType.E4.Code));
            Assert.IsFalse(TestEnumType.IsAvailableCode(-1));
            Assert.IsFalse(TestEnumType.IsAvailableCode(int.MinValue));
            Assert.IsFalse(TestEnumType.IsAvailableCode(int.MaxValue));
        }

        [TestMethod]
        public void EnumTest_IsAvailableValue_Should()
        {
            // 0 1 2 3 4 是合法值
            Assert.IsTrue(TestEnumType.IsAvailableValue("0"));
            Assert.IsTrue(TestEnumType.IsAvailableValue("1"));
            Assert.IsTrue(TestEnumType.IsAvailableValue(TestEnumType.E2));
            Assert.IsTrue(TestEnumType.IsAvailableValue(TestEnumType.E3.Value));
            Assert.IsTrue(TestEnumType.IsAvailableValue(TestEnumType.E4.Value));
            Assert.IsFalse(TestEnumType.IsAvailableValue("-1"));
            Assert.IsFalse(TestEnumType.IsAvailableValue(int.MinValue.ToString()));
            Assert.IsFalse(TestEnumType.IsAvailableValue(int.MaxValue.ToString()));
        }

        [TestMethod]
        public void EnumTest_IsDefault_Should()
        {
            Assert.IsTrue(TestEnumType.EDefault.IsDefault());
            Assert.IsFalse(TestEnumType.E1.IsDefault());
            Assert.IsFalse(TestEnumType.E4.IsDefault());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumCodeException))]
        public void EnumTest_Operator_Exception() => _ = TestEnumType.E3 + TestEnumType.E4;

        [TestMethod]
        public void EnumTest_Operator_Should()
        {
            Assert.AreEqual(TestEnumType.EDefault, TestEnumType.EDefault + TestEnumType.EDefault);
            Assert.AreEqual(TestEnumType.E4, TestEnumType.E1 + TestEnumType.E3);

            Assert.AreEqual(TestEnumType.EDefault, TestEnumType.EDefault - TestEnumType.EDefault);
            Assert.AreEqual(TestEnumType.E2, TestEnumType.E3 - TestEnumType.E1);
        }

        [TestMethod]
        public void EnumTest_Parse_Should()
        {
            Assert.AreEqual(true, TestEnumType.Parse(0, out TestEnumType testEnum));
            Assert.AreEqual(TestEnumType.EDefault, testEnum);

            Assert.AreEqual(true, TestEnumType.Parse(4, out TestEnumType testEnum1));
            Assert.AreEqual(TestEnumType.E4, testEnum1);

            Assert.AreEqual(false, TestEnumType.Parse(-1, out TestEnumType testEnum2));
            Assert.AreEqual(null, testEnum2);

            Assert.AreEqual(true, TestEnumType.Parse("0", out TestEnumType testEnum3));
            Assert.AreEqual(TestEnumType.EDefault, testEnum3);

            Assert.AreEqual(true, TestEnumType.Parse("4", out TestEnumType testEnum4));
            Assert.AreEqual(TestEnumType.E4, testEnum4);

            Assert.AreEqual(false, TestEnumType.Parse("-1", out TestEnumType testEnum5));
            Assert.AreEqual(null, testEnum5);

            Assert.AreEqual(false, TestEnumType.Parse(null, out TestEnumType testEnum6));
            Assert.AreEqual(null, testEnum6);
        }

        [TestMethod]
        public void EnumTest_ToString_Should()
        {
            // GetHashCode 即为 Code 值
            Assert.AreEqual("0", TestEnumType.EDefault.ToString());
            Assert.AreEqual(TestEnumType.EDefault.Value, TestEnumType.EDefault.ToString());
            Assert.AreEqual("1", TestEnumType.E1.ToString());
            Assert.AreEqual(TestEnumType.E1.Value, TestEnumType.E1.ToString());
            Assert.AreEqual("4", TestEnumType.E4.ToString());
            Assert.AreEqual(TestEnumType.E4.Value, TestEnumType.E4.ToString());
        }

        #region Nested type: TestEnumType

        public class TestEnumType : EnumClass<TestEnumType>
        {
            public static readonly TestEnumType E1 = Initialize(new TestEnumType(1, "1"));
            public static readonly TestEnumType E2 = Initialize(new TestEnumType(2, "2"));
            public static readonly TestEnumType E3 = Initialize(new TestEnumType(3, "3"));
            public static readonly TestEnumType E4 = Initialize(new TestEnumType(4, "4"));
            public static readonly TestEnumType EDefault = SetDefaultEnum(new TestEnumType(0, "0"));

            protected TestEnumType(int code, string value) : base(code, value)
            {
            }
        }

        #endregion

        #region Nested type: TestEnumType1

        public class TestEnumType1 : EnumClass<TestEnumType1>
        {
            public static readonly TestEnumType1 E0 = Initialize(new TestEnumType1(0, "0"));
            public static readonly TestEnumType1 E1 = Initialize(new TestEnumType1(1, "1"));
            public static readonly TestEnumType1 E2 = Initialize(new TestEnumType1(2, "2"));
            public static readonly TestEnumType1 E3 = Initialize(new TestEnumType1(3, "3"));
            public static readonly TestEnumType1 E4 = Initialize(new TestEnumType1(4, "4"));

            protected TestEnumType1(int code, string value) : base(code, value)
            {
            }
        }

        #endregion

        #region Nested type: TestEnumType2

        public class TestEnumType2 : EnumClass<TestEnumType2>
        {
            public static readonly TestEnumType2 E1 = Initialize(new TestEnumType2(1, "1"));
            public static readonly TestEnumType2 E2 = Initialize(new TestEnumType2(2, "2"));
            public static readonly TestEnumType2 E3 = Initialize(new TestEnumType2(3, "3"));
            public static readonly TestEnumType2 E4 = Initialize(new TestEnumType2(4, "4"));

            protected TestEnumType2(int code, string value) : base(code, value)
            {
            }
        }

        #endregion
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_Is_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_Is_Should
{
    [TestMethod]
    public void Is_AnyType_False_Should() => Assert.IsFalse("abcdefg".Is<TestClass>());

    [TestMethod]
    public void Is_Boolean_False_Should()
    {
        Assert.IsFalse("abcdefg".Is<bool>());
        Assert.IsFalse("bool".Is<bool>());
        Assert.IsFalse("null".Is<bool>());
        Assert.IsFalse("-1".Is<bool>());
        Assert.IsFalse("1".Is<bool>());
        Assert.IsFalse("0".Is<bool>());
        Assert.IsFalse("T".Is<bool>());
        Assert.IsFalse("F".Is<bool>());
        Assert.IsFalse("t".Is<bool>());
        Assert.IsFalse("f".Is<bool>());

        Assert.IsFalse("abcdefg".Is<bool>());
        Assert.IsFalse("bool".Is<bool>());
        Assert.IsFalse("null".Is<bool>());
        Assert.IsFalse("-1".Is<bool>());
        Assert.IsFalse("1".Is<bool>());
        Assert.IsFalse("0".Is<bool>());
        Assert.IsFalse("T".Is<bool>());
        Assert.IsFalse("F".Is<bool>());
        Assert.IsFalse("t".Is<bool>());
        Assert.IsFalse("f".Is<bool>());

        Assert.IsFalse("abcdefg".Is<bool>());
        Assert.IsFalse("bool".Is<bool>());
        Assert.IsFalse("null".Is<bool>());
        Assert.IsFalse("-1".Is<bool>());
        Assert.IsFalse("1".Is<bool>());
        Assert.IsFalse("0".Is<bool>());
        Assert.IsFalse("T".Is<bool>());
        Assert.IsFalse("F".Is<bool>());
        Assert.IsFalse("t".Is<bool>());
        Assert.IsFalse("f".Is<bool>());
    }

    [TestMethod]
    public void Is_Boolean_True_Should()
    {
        Assert.IsTrue("false".Is<bool>());
        Assert.IsTrue("False".Is<bool>());
        Assert.IsTrue("fAlSe".Is<bool>());
        Assert.IsTrue("true".Is<bool>());
        Assert.IsTrue("True".Is<bool>());
        Assert.IsTrue("tRuE".Is<bool>());

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            bool b = r.Bool();
            Assert.IsTrue(b.ToString().Is<bool>());
        });
    }

    [TestMethod]
    public void Is_DateTime_False_Should()
    {
        Assert.IsFalse("abcdefg".Is<DateTime>());
        Assert.IsFalse("2001".Is<DateTime>());
        Assert.IsFalse("null".Is<DateTime>());
        Assert.IsFalse("2001--01--01".Is<DateTime>());
        Assert.IsFalse("default".Is<DateTime>());

        Assert.IsFalse("abcdefg".Is<DateTime>());
        Assert.IsFalse("2001".Is<DateTime>());
        Assert.IsFalse("null".Is<DateTime>());
        Assert.IsFalse("2001--01--01".Is<DateTime>());
        Assert.IsFalse("default".Is<DateTime>());
    }

    [TestMethod]
    public void Is_DateTime_True_Should()
    {
        DateTime testDateTime = new DateTime(2000, 1, 1, 12, 30, 30, DateTimeKind.Utc);

        Assert.IsTrue("2000-01-01 12:30:30".Is<DateTime>());

        // 01/01/2000 12:30:30
        Assert.IsTrue(testDateTime.ToString(CultureInfo.InvariantCulture).Is<DateTime>());

        Assert.IsTrue("2000-01-01".Is<DateTime>());

        // Saturday, January 1, 2000
        // 1 / 1 / 2000
        Assert.IsTrue(testDateTime.ToLongDateString().Is<DateTime>());
        Assert.IsTrue(testDateTime.ToShortDateString().Is<DateTime>());

        Assert.IsTrue("12:30:30".Is<DateTime>());

        // 如果不指定，转换后的 DataTimeKind 为 Unspecified
        Assert.IsTrue("2000-01-01 12:30:30".Is<DateTime>());
        Assert.IsTrue("2000-01-01T12:30:30".Is<DateTime>());
        Assert.IsTrue("1/1/2000 12:30:30 PM".Is<DateTime>());
        Assert.IsTrue("Saturday, January 1, 2000 12:30:30 PM".Is<DateTime>());
        Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss").Is<DateTime>()); // 2000-01-01 12:30:30
        Assert.IsTrue(testDateTime.ToString("s").Is<DateTime>()); // 2000-01-01T12:30:30
        Assert.IsTrue(testDateTime.ToString("G").Is<DateTime>()); // 1/1/2000 12:30:30 PM
        Assert.IsTrue(testDateTime.ToString("F").Is<DateTime>()); // Saturday, January 1, 2000 12:30:30 PM
        Assert.IsTrue(testDateTime.ToString("U").Is<DateTime>()); // Saturday, January 1, 2000 12:30:30 PM

        // 如果指定，转换后的 DataTimeKind 为 Local，并且时间也会由于时区指定而发生变化
        Assert.IsTrue("2000-01-01T12:30:30.0000000Z".Is<DateTime>());
        Assert.IsTrue("Sat, 01 Jan 2000 12:30:30 GMT".Is<DateTime>());
        Assert.IsTrue("2000-01-01 12:30:30Z".Is<DateTime>());
        Assert.IsTrue("2000-01-01 12:30:30 PM +00".Is<DateTime>());
        Assert.IsTrue(testDateTime.ToString("O").Is<DateTime>()); // 2000-01-01T12:30:30.0000000Z
        Assert.IsTrue(testDateTime.ToString("R").Is<DateTime>()); // Sat, 01 Jan 2000 12:30:30 GMT
        Assert.IsTrue(testDateTime.ToString("u").Is<DateTime>()); // 2000-01-01 12:30:30Z
        Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").Is<DateTime>()); // 2000-01-01 12:30:30 PM +00

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTime t = r.Soon();
            Assert.IsTrue(t.ToString(CultureInfo.InvariantCulture).Is<DateTime>());
        });
    }

    [TestMethod]
    public void Is_DateTimeOffset_False_Should()
    {
        Assert.IsFalse("abcdefg".Is<DateTimeOffset>());
        Assert.IsFalse("2001".Is<DateTimeOffset>());
        Assert.IsFalse("null".Is<DateTimeOffset>());
        Assert.IsFalse("2001--01--01".Is<DateTimeOffset>());
        Assert.IsFalse("default".Is<DateTimeOffset>());
    }

    [TestMethod]
    public void Is_DateTimeOffset_True_Should()
    {
        DateTimeOffset testDateTime = new DateTimeOffset(2000, 1, 1, 12, 30, 30, new TimeSpan(0, 8, 0, 0)); // 东八区 北京时区

        // 默认填充东八区的时区信息
        Assert.IsTrue("2000-01-01 12:30:30".Is<DateTimeOffset>());

        // 01/01/2000 12:30:30
        Assert.IsTrue(testDateTime.ToString(CultureInfo.InvariantCulture).Is<DateTimeOffset>());
        Assert.IsTrue("2000-01-01".Is<DateTimeOffset>());
        Assert.IsTrue("12:30:30".Is<DateTimeOffset>());

        // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset，在这里即为东八区 Offset
        Assert.IsTrue("2000-01-01 12:30:30".Is<DateTimeOffset>());
        Assert.IsTrue("2000-01-01T12:30:30".Is<DateTimeOffset>());
        Assert.IsTrue("1/1/2000 12:30:30 PM".Is<DateTimeOffset>());
        Assert.IsTrue("Saturday, January 1, 2000 12:30:30 PM".Is<DateTimeOffset>());
        Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss").Is<DateTimeOffset>()); // 2000-01-01 12:30:30
        Assert.IsTrue(testDateTime.ToString("s").Is<DateTimeOffset>()); // 2000-01-01T12:30:30
        Assert.IsTrue(testDateTime.ToString("G").Is<DateTimeOffset>()); // 1/1/2000 12:30:30 PM
        Assert.IsTrue(testDateTime.ToString("F").Is<DateTimeOffset>()); // Saturday, January 1, 2000 12:30:30 PM

        // 如果是带时区信息，DateTimeOffset 会完整保留时区信息和调整小时数
        Assert.IsTrue("2000-01-01T12:30:30.0000000+08:00".Is<DateTimeOffset>());
        Assert.IsTrue("Sat, 01 Jan 2000 4:30:30 GMT".Is<DateTimeOffset>());
        Assert.IsTrue("2000-01-01 4:30:30Z".Is<DateTimeOffset>());
        Assert.IsTrue("2000-01-01 12:30:30 PM +08".Is<DateTimeOffset>());
        Assert.IsTrue(testDateTime.ToString("O").Is<DateTimeOffset>()); // 2000-01-01T12:30:30.0000000+08:00
        Assert.IsTrue(testDateTime.ToString("R").Is<DateTimeOffset>()); // Sat, 01 Jan 2000 4:30:30 GMT
        Assert.IsTrue(testDateTime.ToString("u").Is<DateTimeOffset>()); // 2000-01-01 4:30:30Z
        Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").Is<DateTimeOffset>()); // 2000-01-01 12:30:30 PM +08

        Date r = new Date();

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.SoonOffset();
            Assert.IsTrue(t.ToString(CultureInfo.InvariantCulture).Is<DateTimeOffset>());
        });
    }

    [TestMethod]
    public void Is_Decimal_False_Should()
    {
        Assert.IsFalse("abcdefg".Is<decimal>());
        Assert.IsFalse("decimal".Is<decimal>());
        Assert.IsFalse("null".Is<decimal>());
        Assert.IsFalse("1.1.1".Is<decimal>());
        Assert.IsFalse("1.9.9".Is<decimal>());
        Assert.IsFalse("decimal.MinValue".Is<decimal>());
        Assert.IsFalse("decimal.MinValue".Is<decimal>());

        Assert.IsFalse("abcdefg".Is<decimal>());
        Assert.IsFalse("decimal".Is<decimal>());
        Assert.IsFalse("null".Is<decimal>());
        Assert.IsFalse("1.1.1".Is<decimal>());
        Assert.IsFalse("1.9.9".Is<decimal>());
        Assert.IsFalse("decimal.MinValue".Is<decimal>());
        Assert.IsFalse("decimal.MinValue".Is<decimal>());
    }

    [TestMethod]
    public void Is_Decimal_True_Should()
    {
        Assert.IsTrue("0".Is<decimal>());
        Assert.IsTrue("1".Is<decimal>());
        Assert.IsTrue("-1".Is<decimal>());
        Assert.IsTrue(int.MaxValue.ToString().Is<decimal>());
        Assert.IsTrue(int.MinValue.ToString().Is<decimal>());

        Assert.IsTrue("0".Is<decimal>());
        Assert.IsTrue("1".Is<decimal>());
        Assert.IsTrue("-1".Is<decimal>());
        Assert.IsTrue(int.MaxValue.ToString().Is<decimal>());
        Assert.IsTrue(int.MinValue.ToString().Is<decimal>());

        Assert.IsTrue("1.1".Is<decimal>());
        Assert.IsTrue("-1.1".Is<decimal>());
        Assert.IsTrue("1.9".Is<decimal>());
        Assert.IsTrue(long.MaxValue.ToString(CultureInfo.InvariantCulture).Is<decimal>());
        Assert.IsTrue(long.MinValue.ToString(CultureInfo.InvariantCulture).Is<decimal>());
        Assert.IsTrue(decimal.MaxValue.ToString(CultureInfo.InvariantCulture).Is<decimal>());
        Assert.IsTrue(decimal.MinValue.ToString(CultureInfo.InvariantCulture).Is<decimal>());

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            decimal d = r.Decimal();
            Assert.IsTrue(d.ToString(CultureInfo.InvariantCulture).Is<decimal>());
        });
    }

    [TestMethod]
    public void Is_Guid_False_Should()
    {
        Assert.IsFalse("abcdefg".Is<Guid>());
        Assert.IsFalse("guid".Is<Guid>());
        Assert.IsFalse("null".Is<Guid>());
        Assert.IsFalse("1".Is<Guid>());
        Assert.IsFalse("0".Is<Guid>());
        Assert.IsFalse("Guid.Empty".Is<Guid>());
    }

    [TestMethod]
    public void Is_Guid_True_Should()
    {
        Guid testData = Guid.NewGuid();

        Assert.IsTrue(testData.ToString("N").Is<Guid>());
        Assert.IsTrue(testData.ToString("N").ToUpperInvariant().Is<Guid>());

        Assert.IsTrue(testData.ToString("D").Is<Guid>());
        Assert.IsTrue(testData.ToString("B").Is<Guid>());
        Assert.IsTrue(testData.ToString("P").Is<Guid>());

        Assert.IsTrue(Guid.Empty.ToString().Is<Guid>());

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            Guid g = r.Guid();
            Assert.IsTrue(g.ToString().Is<Guid>());
        });
    }

    [TestMethod]
    public void Is_Int_False_Should()
    {
        Assert.IsFalse("abcdefg".Is<int>());
        Assert.IsFalse("int".Is<int>());
        Assert.IsFalse("null".Is<int>());
        Assert.IsFalse("1.1".Is<int>());
        Assert.IsFalse("1.9".Is<int>());
        Assert.IsFalse("int.MinValue".Is<int>());
        Assert.IsFalse("int.MinValue".Is<int>());

        // ReSharper disable RedundantTypeArgumentsOfMethod
        Assert.IsFalse("abcdefg".Is<int>());
        Assert.IsFalse("int".Is<int>());
        Assert.IsFalse("null".Is<int>());
        Assert.IsFalse("1.1".Is<int>());
        Assert.IsFalse("1.9".Is<int>());
        Assert.IsFalse("int.MinValue".Is<int>());
        Assert.IsFalse("int.MinValue".Is<int>());

        // ReSharper restore RedundantTypeArgumentsOfMethod

        Assert.AreEqual(default, ((long)int.MinValue - 1).ToString().Is<int>());
        Assert.AreEqual(default, ((long)int.MaxValue + 1).ToString().Is<int>());
    }

    [TestMethod]
    public void Is_Int_True_Should()
    {
        Assert.IsTrue("0".Is<int>());
        Assert.IsTrue("1".Is<int>());
        Assert.IsTrue("-1".Is<int>());
        Assert.IsTrue(int.MaxValue.ToString().Is<int>());
        Assert.IsTrue(int.MinValue.ToString().Is<int>());
        Assert.IsTrue(short.MaxValue.ToString().Is<int>());
        Assert.IsTrue(short.MinValue.ToString().Is<int>());

        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            int i = r.Int();
            Assert.IsTrue(i.ToString().Is<int>());
        });
    }

    #region Nested type: TestClass

    public class TestClass : IEquatable<TestClass>
    {
        public string? Value { get; init; }

        #region IEquatable<TestClass> Members

        public bool Equals(TestClass? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value == other.Value;
        }

        #endregion

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((TestClass)obj);
        }

        public override int GetHashCode() => Value != null ? Value.GetHashCode() : 0;
    }

    #endregion
}

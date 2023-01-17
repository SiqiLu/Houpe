// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_As_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_As_Should
{
    [TestMethod]
    public void As_AnyType_Fail_Should()
    {
        Assert.AreEqual(default, "abcdefg".As<TestClass1>());
        Assert.AreEqual(default, "abcdefg".As<TestClass2>());
        Assert.AreEqual(default, "abcdefg".As<TestClass3>());
    }

    [TestMethod]
    public void As_AnyType_Success_Should()
    {
        Randomizer r = new Randomizer();

        100.Times().Do(() =>
        {
            string testData = r.Utf16String(1, 100);
            Assert.AreEqual(testData, testData.As<string>());
        });
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
    [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
    public void As_Boolean_Fail_Should()
    {
        Assert.AreEqual(default, "abcdefg".As<bool>());
        Assert.AreEqual(default, "bool".As<bool>());
        Assert.AreEqual(default, "null".As<bool>());
        Assert.AreEqual(default, "-1".As<bool>());
        Assert.AreEqual(default, "1".As<bool>());
        Assert.AreEqual(default, "0".As<bool>());
        Assert.AreEqual(default, "T".As<bool>());
        Assert.AreEqual(default, "F".As<bool>());
        Assert.AreEqual(default, "t".As<bool>());
        Assert.AreEqual(default, "f".As<bool>());

        Assert.AreEqual(false, "abcdefg".As<bool>(false));
        Assert.AreEqual(false, "bool".As<bool>(false));
        Assert.AreEqual(false, "null".As<bool>(false));
        Assert.AreEqual(false, "-1".As<bool>(false));
        Assert.AreEqual(false, "1".As<bool>(false));
        Assert.AreEqual(false, "0".As<bool>(false));
        Assert.AreEqual(false, "T".As<bool>(false));
        Assert.AreEqual(false, "F".As<bool>(false));
        Assert.AreEqual(false, "t".As<bool>(false));
        Assert.AreEqual(false, "f".As<bool>(false));

        Assert.AreEqual(true, "abcdefg".As<bool>(true));
        Assert.AreEqual(true, "bool".As<bool>(true));
        Assert.AreEqual(true, "null".As<bool>(true));
        Assert.AreEqual(true, "-1".As<bool>(true));
        Assert.AreEqual(true, "1".As<bool>(true));
        Assert.AreEqual(true, "0".As<bool>(true));
        Assert.AreEqual(true, "T".As<bool>(true));
        Assert.AreEqual(true, "F".As<bool>(true));
        Assert.AreEqual(true, "t".As<bool>(true));
        Assert.AreEqual(true, "f".As<bool>(true));
    }

    [TestMethod]
    public void As_Boolean_Success_Should()
    {
        Assert.AreEqual(false, "false".As<bool>());
        Assert.AreEqual(false, "False".As<bool>());
        Assert.AreEqual(false, "fAlSe".As<bool>());
        Assert.AreEqual(true, "true".As<bool>());
        Assert.AreEqual(true, "True".As<bool>());
        Assert.AreEqual(true, "tRuE".As<bool>());
    }

    [TestMethod]
    public void As_DateTime_Fail_Should()
    {
        DateTime defaultTestData = DateTime.Now;

        Assert.AreEqual(default, "abcdefg".As<DateTime>());
        Assert.AreEqual(default, "2001".As<DateTime>());
        Assert.AreEqual(default, "null".As<DateTime>());
        Assert.AreEqual(default, "2001--01--01".As<DateTime>());
        Assert.AreEqual(default, "default".As<DateTime>());

        Assert.AreEqual(defaultTestData, "abcdefg".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "2001".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "2001--01--01".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "default".As(defaultTestData));
    }

    [TestMethod]
    public void As_DateTime_Success_Should()
    {
        DateTime testDateTime = new DateTime(2000, 1, 1, 12, 30, 30, DateTimeKind.Utc);

        Assert.AreEqual(testDateTime, "2000-01-01 12:30:30".As<DateTime>());

        // 01/01/2000 12:30:30
        Assert.AreEqual(testDateTime, testDateTime.ToString(CultureInfo.InvariantCulture).As<DateTime>());

        Assert.AreEqual(testDateTime.Date, "2000-01-01".As<DateTime>().Date);

        // Saturday, January 1, 2000
        // 1 / 1 / 2000
        Assert.AreEqual(testDateTime.Date, testDateTime.ToLongDateString().As<DateTime>().Date);
        Assert.AreEqual(testDateTime.Date, testDateTime.ToShortDateString().As<DateTime>().Date);

        Assert.AreEqual(testDateTime.TimeOfDay, "12:30:30".As<DateTime>().TimeOfDay);

        // 12:30:30 PM
        // 12:30 PM
        Assert.AreEqual(testDateTime.TimeOfDay, testDateTime.ToLongTimeString().As<DateTime>().TimeOfDay);
        Assert.AreEqual(testDateTime.Hour, testDateTime.ToShortTimeString().As<DateTime>().Hour);
        Assert.AreEqual(testDateTime.Minute, testDateTime.ToShortTimeString().As<DateTime>().Minute);

        // 如果不指定，转换后的 DataTimeKind 为 Unspecified
        Assert.AreEqual(DateTimeKind.Unspecified, "2000-01-01 12:30:30".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, "2000-01-01T12:30:30".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, "1/1/2000 12:30:30 PM".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, "Saturday, January 1, 2000 12:30:30 PM".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").As<DateTime>().Kind); // 2000-01-01 12:30:30
        Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("s").As<DateTime>().Kind); // 2000-01-01T12:30:30
        Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("G").As<DateTime>().Kind); // 1/1/2000 12:30:30 PM
        Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("F").As<DateTime>().Kind); // Saturday, January 1, 2000 12:30:30 PM
        Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("U").As<DateTime>().Kind); // Saturday, January 1, 2000 12:30:30 PM

        // 即使未指定 DataTimeKind，转化后的时间的小时数依旧是 12
        Assert.AreEqual(12, "2000-01-01 12:30:30".As<DateTime>().Hour);
        Assert.AreEqual(12, "2000-01-01T12:30:30".As<DateTime>().Hour);
        Assert.AreEqual(12, "1/1/2000 12:30:30 PM".As<DateTime>().Hour);
        Assert.AreEqual(12, "Saturday, January 1, 2000 12:30:30 PM".As<DateTime>().Hour);
        Assert.AreEqual(12, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").As<DateTime>().Hour); // 2000-01-01 12:30:30
        Assert.AreEqual(12, testDateTime.ToString("s").As<DateTime>().Hour); // 2000-01-01T12:30:30
        Assert.AreEqual(12, testDateTime.ToString("G").As<DateTime>().Hour); // 1/1/2000 12:30:30 PM
        Assert.AreEqual(12, testDateTime.ToString("F").As<DateTime>().Hour); // Saturday, January 1, 2000 12:30:30 PM
        Assert.AreEqual(12, testDateTime.ToString("U").As<DateTime>().Hour); // Saturday, January 1, 2000 12:30:30 PM

        // 由于未指定 DataTimeKind，所以在标准时概念上已经不是相等的时间了，如果本地时区是 UTC，则相等，否则则不相等的
        if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.Zero)
        {
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".As<DateTime>().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".As<DateTime>().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".As<DateTime>().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".As<DateTime>().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").As<DateTime>().ToUniversalTime()); // 2000-01-01 12:30:30
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").As<DateTime>().ToUniversalTime()); // 2000-01-01T12:30:30
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").As<DateTime>().ToUniversalTime()); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").As<DateTime>().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("U").As<DateTime>().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
        }
        else
        {
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".As<DateTime>().ToUniversalTime());
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".As<DateTime>().ToUniversalTime());
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".As<DateTime>().ToUniversalTime());
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".As<DateTime>().ToUniversalTime());
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").As<DateTime>().ToUniversalTime()); // 2000-01-01 12:30:30
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").As<DateTime>().ToUniversalTime()); // 2000-01-01T12:30:30
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").As<DateTime>().ToUniversalTime()); // 1/1/2000 12:30:30 PM
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").As<DateTime>().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
            Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("U").As<DateTime>().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
        }

        // 如果指定，转换后的 DataTimeKind 为 Local，并且时间也会由于时区指定而发生变化，并且即使指定的是 UTC 时区，DataTimeKind 也会被设置为 Local
        Assert.AreEqual(DateTimeKind.Local, "2000-01-01T12:30:30.0000000Z".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Local, "Sat, 01 Jan 2000 12:30:30 GMT".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Local, "2000-01-01 12:30:30Z".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Local, "2000-01-01 12:30:30 PM +00".As<DateTime>().Kind);
        Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("O").As<DateTime>().Kind); // 2000-01-01T12:30:30.0000000Z
        Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("R").As<DateTime>().Kind); // Sat, 01 Jan 2000 12:30:30 GMT
        Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("u").As<DateTime>().Kind); // 2000-01-01 12:30:30Z
        Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").As<DateTime>().Kind); // 2000-01-01 12:30:30 PM +00

        // 由于转换后的 DataTimeKind 为 Local，时间部分也会由于时区指定而发生变化，转化后的时间的小时数为本地时间，如果 东八区，则为 20（北京时区，东八区）
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01T12:30:30.0000000Z".As<DateTime>().Hour);
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "Sat, 01 Jan 2000 12:30:30 GMT".As<DateTime>().Hour);
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01 12:30:30Z".As<DateTime>().Hour);
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01 12:30:30 PM +00".As<DateTime>().Hour);
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("O").As<DateTime>().Hour); // 2000-01-01T12:30:30.0000000Z
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("R").As<DateTime>().Hour); // Sat, 01 Jan 2000 12:30:30 GMT
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("u").As<DateTime>().Hour); // 2000-01-01 12:30:30Z
        Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").As<DateTime>().Hour); // 2000-01-01 12:30:30 PM +00

        if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.Zero)
        {
            Assert.AreEqual(testDateTime, "2000-01-01T12:30:30.0000000Z".As<DateTime>());
            Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 12:30:30 GMT".As<DateTime>());
            Assert.AreEqual(testDateTime, "2000-01-01 12:30:30Z".As<DateTime>());
            Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 PM +00".As<DateTime>());
            Assert.AreEqual(testDateTime, testDateTime.ToString("O").As<DateTime>()); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(testDateTime, testDateTime.ToString("R").As<DateTime>()); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(testDateTime, testDateTime.ToString("u").As<DateTime>()); // 2000-01-01 12:30:30Z
            Assert.AreEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").As<DateTime>()); // 2000-01-01 12:30:30 PM +00
        }
        else
        {
            // 由于转换后的 DataTimeKind 为 Local，所以在 DateTime 类型下已经不相等
            Assert.AreNotEqual(testDateTime, "2000-01-01T12:30:30.0000000Z".As<DateTime>());
            Assert.AreNotEqual(testDateTime, "Sat, 01 Jan 2000 12:30:30 GMT".As<DateTime>());
            Assert.AreNotEqual(testDateTime, "2000-01-01 12:30:30Z".As<DateTime>());
            Assert.AreNotEqual(testDateTime, "2000-01-01 12:30:30 PM +00".As<DateTime>());
            Assert.AreNotEqual(testDateTime, testDateTime.ToString("O").As<DateTime>()); // 2000-01-01T12:30:30.0000000Z
            Assert.AreNotEqual(testDateTime, testDateTime.ToString("R").As<DateTime>()); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreNotEqual(testDateTime, testDateTime.ToString("u").As<DateTime>()); // 2000-01-01 12:30:30Z
            Assert.AreNotEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").As<DateTime>()); // 2000-01-01 12:30:30 PM +00
        }

        // 即使转换后的 DataTimeKind 为 Local，在标准时概念上依旧是相等的时间
        Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30.0000000Z".As<DateTime>().ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), "Sat, 01 Jan 2000 12:30:30 GMT".As<DateTime>().ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30Z".As<DateTime>().ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30 PM +00".As<DateTime>().ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("O").As<DateTime>().ToUniversalTime()); // 2000-01-01T12:30:30.0000000Z
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("R").As<DateTime>().ToUniversalTime()); // Sat, 01 Jan 2000 12:30:30 GMT
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("u").As<DateTime>().ToUniversalTime()); // 2000-01-01 12:30:30Z
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").As<DateTime>().ToUniversalTime()); // 2000-01-01 12:30:30 PM +00
    }

    [TestMethod]
    public void As_DateTimeOffset_Fail_Should()
    {
        Assert.AreEqual(default, "abcdefg".As<DateTimeOffset>());
        Assert.AreEqual(default, "2001".As<DateTimeOffset>());
        Assert.AreEqual(default, "null".As<DateTimeOffset>());
        Assert.AreEqual(default, "2001--01--01".As<DateTimeOffset>());
        Assert.AreEqual(default, "default".As<DateTimeOffset>());
    }

    [TestMethod]
    public void As_DateTimeOffset_Success_Should()
    {
        DateTimeOffset testDateTime = new DateTimeOffset(2000, 1, 1, 12, 30, 30, new TimeSpan(0, 9, 0, 0)); // 东九区

        // 01/01/2000 12:30:30
        Assert.AreEqual(testDateTime, testDateTime.ToString(CultureInfo.InvariantCulture).As<DateTimeOffset>());
        Assert.AreEqual(testDateTime.Date, "2000-01-01".As<DateTimeOffset>().Date);
        Assert.AreEqual(testDateTime.TimeOfDay, "12:30:30".As<DateTimeOffset>().TimeOfDay);

        // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "2000-01-01 12:30:30".As<DateTimeOffset>().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "2000-01-01T12:30:30".As<DateTimeOffset>().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "1/1/2000 12:30:30 PM".As<DateTimeOffset>().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "Saturday, January 1, 2000 12:30:30 PM".As<DateTimeOffset>().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").As<DateTimeOffset>().Offset); // 2000-01-01 12:30:30
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("s").As<DateTimeOffset>().Offset); // 2000-01-01T12:30:30
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("G").As<DateTimeOffset>().Offset); // 1/1/2000 12:30:30 PM
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("F").As<DateTimeOffset>().Offset); // Saturday, January 1, 2000 12:30:30 PM

        // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset，测试数据为东九区时间
        TimeSpan offset = TimeZoneInfo.Local.BaseUtcOffset - testDateTime.Offset;
        Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".As<DateTimeOffset>().Add(offset).ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".As<DateTimeOffset>().Add(offset).ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".As<DateTimeOffset>().Add(offset).ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".As<DateTimeOffset>().Add(offset).ToUniversalTime());
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").As<DateTimeOffset>().Add(offset).ToUniversalTime()); // 2000-01-01 12:30:30
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").As<DateTimeOffset>().Add(offset).ToUniversalTime()); // 2000-01-01T12:30:30
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").As<DateTimeOffset>().Add(offset).ToUniversalTime()); // 1/1/2000 12:30:30 PM
        Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").As<DateTimeOffset>().Add(offset).ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM

        // 如果是带时区信息，DateTimeOffset 会完整保留时区信息和调整小时数
        Assert.AreEqual(testDateTime, "2000-01-01T11:30:30.0000000+08:00".As<DateTimeOffset>());
        Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 3:30:30 GMT".As<DateTimeOffset>());
        Assert.AreEqual(testDateTime, "2000-01-01 3:30:30Z".As<DateTimeOffset>());
        Assert.AreEqual(testDateTime, "2000-01-01 11:30:30 AM +08".As<DateTimeOffset>());

        Assert.AreEqual(testDateTime, "2000-01-01T12:30:30.0000000+09:00".As<DateTimeOffset>());
        Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 3:30:30 GMT".As<DateTimeOffset>());
        Assert.AreEqual(testDateTime, "2000-01-01 3:30:30Z".As<DateTimeOffset>());
        Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 PM +09".As<DateTimeOffset>());

        // DateTimeOffset ToString 部分格式化后的字符串会带时区信息
        Assert.AreEqual(testDateTime, testDateTime.ToString("O").As<DateTimeOffset>()); // 2000-01-01T12:30:30.0000000+09:00
        Assert.AreEqual(testDateTime, testDateTime.ToString("R").As<DateTimeOffset>()); // Sat, 01 Jan 2000 3:30:30 GMT
        Assert.AreEqual(testDateTime, testDateTime.ToString("u").As<DateTimeOffset>()); // 2000-01-01 3:30:30Z
        Assert.AreEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").As<DateTimeOffset>()); // 2000-01-01 12:30:30 PM +09
    }

    [TestMethod]
    public void As_Decimal_Fail_Should()
    {
        decimal defaultTestData = -1m;

        Assert.AreEqual(default, "abcdefg".As<decimal>());
        Assert.AreEqual(default, "decimal".As<decimal>());
        Assert.AreEqual(default, "null".As<decimal>());
        Assert.AreEqual(default, "1.1.1".As<decimal>());
        Assert.AreEqual(default, "1.9.9".As<decimal>());
        Assert.AreEqual(default, "decimal.MinValue".As<decimal>());
        Assert.AreEqual(default, "decimal.MinValue".As<decimal>());

        Assert.AreEqual(defaultTestData, "abcdefg".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "decimal".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.1.1".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.9.9".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "decimal.MinValue".As(defaultTestData));
        Assert.AreEqual(defaultTestData, "decimal.MinValue".As(defaultTestData));
    }

    [TestMethod]
    public void As_Decimal_Success_Should()
    {
        Assert.AreEqual(0, "0".As<decimal>());
        Assert.AreEqual(1, "1".As<decimal>());
        Assert.AreEqual(-1, "-1".As<decimal>());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().As<decimal>());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().As<decimal>());

        Assert.AreEqual(new decimal(0), "0".As<decimal>());
        Assert.AreEqual(new decimal(1), "1".As<decimal>());
        Assert.AreEqual(new decimal(-1), "-1".As<decimal>());
        Assert.AreEqual(new decimal(int.MaxValue), int.MaxValue.ToString().As<decimal>());
        Assert.AreEqual(new decimal(int.MinValue), int.MinValue.ToString().As<decimal>());

        Assert.AreEqual(new decimal(1.1), "1.1".As<decimal>());
        Assert.AreEqual(new decimal(-1.1), "-1.1".As<decimal>());
        Assert.AreEqual(new decimal(1.9), "1.9".As<decimal>());
        Assert.AreEqual(new decimal(long.MaxValue), long.MaxValue.ToString(CultureInfo.InvariantCulture).As<decimal>());
        Assert.AreEqual(new decimal(long.MinValue), long.MinValue.ToString(CultureInfo.InvariantCulture).As<decimal>());
        Assert.AreEqual(decimal.MaxValue, decimal.MaxValue.ToString(CultureInfo.InvariantCulture).As<decimal>());
        Assert.AreEqual(decimal.MinValue, decimal.MinValue.ToString(CultureInfo.InvariantCulture).As<decimal>());
    }

    [TestMethod]
    public void As_Guid_Fail_Should()
    {
        Assert.AreEqual(default, "abcdefg".As<Guid>());
        Assert.AreEqual(default, "guid".As<Guid>());
        Assert.AreEqual(default, "null".As<Guid>());
        Assert.AreEqual(default, "1".As<Guid>());
        Assert.AreEqual(default, "0".As<Guid>());
        Assert.AreEqual(default, "Guid.Empty".As<Guid>());
    }

    [TestMethod]
    public void As_Guid_Success_Should()
    {
        Guid testData = Guid.NewGuid();

        Assert.AreEqual(testData, testData.ToString("N").As<Guid>());
        Assert.AreEqual(testData, testData.ToString("N").ToUpperInvariant().As<Guid>());

        Assert.AreEqual(testData, testData.ToString("D").As<Guid>());
        Assert.AreEqual(testData, testData.ToString("B").As<Guid>());
        Assert.AreEqual(testData, testData.ToString("P").As<Guid>());

        Assert.AreEqual(Guid.Empty, Guid.Empty.ToString().As<Guid>());
    }

    [TestMethod]
    public void As_Int_Fail_Should()
    {
        int defaultTestData = -1;

        Assert.AreEqual(default, "abcdefg".As<int>());
        Assert.AreEqual(default, "int".As<int>());
        Assert.AreEqual(default, "null".As<int>());
        Assert.AreEqual(default, "1.1".As<int>());
        Assert.AreEqual(default, "1.9".As<int>());
        Assert.AreEqual(default, "int.MinValue".As<int>());
        Assert.AreEqual(default, "int.MinValue".As<int>());

        // ReSharper disable RedundantTypeArgumentsOfMethod
        Assert.AreEqual(defaultTestData, "abcdefg".As<int>(defaultTestData));
        Assert.AreEqual(defaultTestData, "int".As<int>(defaultTestData));
        Assert.AreEqual(defaultTestData, "null".As<int>(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.1".As<int>(defaultTestData));
        Assert.AreEqual(defaultTestData, "1.9".As<int>(defaultTestData));
        Assert.AreEqual(defaultTestData, "int.MinValue".As<int>(defaultTestData));
        Assert.AreEqual(defaultTestData, "int.MinValue".As<int>(defaultTestData));

        // ReSharper restore RedundantTypeArgumentsOfMethod

        Assert.AreEqual(default, ((long)int.MinValue - 1).ToString().As<int>());
        Assert.AreEqual(default, ((long)int.MaxValue + 1).ToString().As<int>());
    }

    [TestMethod]
    public void As_Int_Success_Should()
    {
        Assert.AreEqual(0, "0".As<int>());
        Assert.AreEqual(1, "1".As<int>());
        Assert.AreEqual(-1, "-1".As<int>());
        Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().As<int>());
        Assert.AreEqual(int.MinValue, int.MinValue.ToString().As<int>());
        Assert.AreEqual(short.MaxValue, short.MaxValue.ToString().As<int>());
        Assert.AreEqual(short.MinValue, short.MinValue.ToString().As<int>());
    }

    #region Nested type: TestClass1

    [ExcludeFromCodeCoverage]
    public class TestClass1 : IEquatable<TestClass1>
    {
        public string? Value { get; init; }

        #region IEquatable<TestClass1> Members

        public bool Equals(TestClass1? other)
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

            return Equals((TestClass1)obj);
        }

        public override int GetHashCode() => Value != null ? Value.GetHashCode() : 0;
    }

    #endregion

    #region Nested type: TestClass2

    [ExcludeFromCodeCoverage]
    public class TestClass2 : IEquatable<TestClass2>
    {
        public string? Value { get; init; }

        #region IEquatable<TestClass2> Members

        public bool Equals(TestClass2? other)
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

            return Equals((TestClass2)obj);
        }

        public override int GetHashCode() => Value != null ? Value.GetHashCode() : 0;

        public static explicit operator TestClass2(string s) => new TestClass2 { Value = s };
    }

    #endregion

    #region Nested type: TestClass3

    [ExcludeFromCodeCoverage]
    public class TestClass3 : IEquatable<TestClass3>
    {
        public string? Value { get; init; }

        #region IEquatable<TestClass3> Members

        public bool Equals(TestClass3? other)
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

            return Equals((TestClass3)obj);
        }

        public override int GetHashCode() => Value != null ? Value.GetHashCode() : 0;

        public static explicit operator TestClass3(string s) => new TestClass3 { Value = s };
    }

    #endregion
}

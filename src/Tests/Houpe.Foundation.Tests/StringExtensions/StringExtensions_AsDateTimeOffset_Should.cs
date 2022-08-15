// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsDateTimeOffset_Should.cs
// CreatedAt        : 2021-06-04
// LastModifiedAt   : 2022-07-29
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Globalization;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_AsDateTimeOffset_Should
    {
        [TestMethod]
        public void AsDateTimeOffset_Success_Should()
        {
            DateTimeOffset testDateTime = new DateTimeOffset(2000, 1, 1, 12, 30, 30, new TimeSpan(0, 9, 0, 0)); // 东九区

            // 01/01/2000 12:30:30
            Assert.AreEqual(testDateTime, testDateTime.ToString(CultureInfo.InvariantCulture).AsDateTimeOffset());
            Assert.AreEqual(testDateTime.Date, "2000-01-01".AsDateTimeOffset().Date);
            Assert.AreEqual(testDateTime.TimeOfDay, "12:30:30".AsDateTimeOffset().TimeOfDay);

            // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "2000-01-01 12:30:30".AsDateTimeOffset().Offset);
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "2000-01-01T12:30:30".AsDateTimeOffset().Offset);
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "1/1/2000 12:30:30 PM".AsDateTimeOffset().Offset);
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "Saturday, January 1, 2000 12:30:30 PM".AsDateTimeOffset().Offset);
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").AsDateTimeOffset().Offset); // 2000-01-01 12:30:30
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("s").AsDateTimeOffset().Offset); // 2000-01-01T12:30:30
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("G").AsDateTimeOffset().Offset); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("F").AsDateTimeOffset().Offset); // Saturday, January 1, 2000 12:30:30 PM

            // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset，测试数据为东九区时间
            TimeSpan offset = TimeZoneInfo.Local.BaseUtcOffset - testDateTime.Offset;
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".AsDateTimeOffset().Add(offset).ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".AsDateTimeOffset().Add(offset).ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".AsDateTimeOffset().Add(offset).ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".AsDateTimeOffset().Add(offset).ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").AsDateTimeOffset().Add(offset).ToUniversalTime()); // 2000-01-01 12:30:30
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").AsDateTimeOffset().Add(offset).ToUniversalTime()); // 2000-01-01T12:30:30
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").AsDateTimeOffset().Add(offset).ToUniversalTime()); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").AsDateTimeOffset().Add(offset).ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM

            // 如果是带时区信息，DateTimeOffset 会完整保留时区信息和调整小时数
            Assert.AreEqual(testDateTime, "2000-01-01T11:30:30.0000000+08:00".AsDateTimeOffset());
            Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 3:30:30 GMT".AsDateTimeOffset());
            Assert.AreEqual(testDateTime, "2000-01-01 3:30:30Z".AsDateTimeOffset());
            Assert.AreEqual(testDateTime, "2000-01-01 11:30:30 AM +08".AsDateTimeOffset());

            Assert.AreEqual(testDateTime, "2000-01-01T12:30:30.0000000+09:00".AsDateTimeOffset());
            Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 3:30:30 GMT".AsDateTimeOffset());
            Assert.AreEqual(testDateTime, "2000-01-01 3:30:30Z".AsDateTimeOffset());
            Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 PM +09".AsDateTimeOffset());

            // DateTimeOffset ToString 部分格式化后的字符串会带时区信息
            Assert.AreEqual(testDateTime, testDateTime.ToString("O").AsDateTimeOffset()); // 2000-01-01T12:30:30.0000000+09:00
            Assert.AreEqual(testDateTime, testDateTime.ToString("R").AsDateTimeOffset()); // Sat, 01 Jan 2000 3:30:30 GMT
            Assert.AreEqual(testDateTime, testDateTime.ToString("u").AsDateTimeOffset()); // 2000-01-01 3:30:30Z
            Assert.AreEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").AsDateTimeOffset()); // 2000-01-01 12:30:30 PM +09

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTimeOffset testData = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                string testData1 = testData.ToString("O");
                string testData2 = testData.ToString("R");
                string testData3 = testData.ToString("u");
                string testData4 = testData.ToString("yyyy-MM-dd HH:mm:ss tt zz");
                Assert.AreEqual(testData1.As<DateTimeOffset>(), testData1.AsDateTimeOffset());
                Assert.AreEqual(testData2.As<DateTimeOffset>(), testData2.AsDateTimeOffset());
                Assert.AreEqual(testData3.As<DateTimeOffset>(), testData3.AsDateTimeOffset());
                Assert.AreEqual(testData4.As<DateTimeOffset>(), testData4.AsDateTimeOffset());
            });
        }

        [TestMethod]
        public void AsDateTimeOffset_Fail_Should()
        {
            DateTimeOffset defaultTestData = DateTimeOffset.Now;

            Assert.AreEqual(default, "abcdefg".AsDateTimeOffset());
            Assert.AreEqual(default, "2001".AsDateTimeOffset());
            Assert.AreEqual(default, "null".AsDateTimeOffset());
            Assert.AreEqual(default, "2001--01--01".AsDateTimeOffset());
            Assert.AreEqual(default, "default".AsDateTimeOffset());

            Assert.AreEqual(defaultTestData, "abcdefg".AsDateTimeOffset(defaultTestData));
            Assert.AreEqual(defaultTestData, "2001".AsDateTimeOffset(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsDateTimeOffset(defaultTestData));
            Assert.AreEqual(defaultTestData, "2001--01--01".AsDateTimeOffset(defaultTestData));
            Assert.AreEqual(defaultTestData, "default".AsDateTimeOffset(defaultTestData));
        }
    }
}

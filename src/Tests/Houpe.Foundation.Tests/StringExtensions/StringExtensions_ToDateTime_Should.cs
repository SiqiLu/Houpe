// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDateTime_Should.cs
// CreatedAt        : 2022-08-16
// LastModifiedAt   : 2022-08-16
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToDateTime_Should
    {
        [TestMethod]
        public void ToDateTime_Should()
        {
            DateTime testDateTime = new DateTime(2000, 1, 1, 12, 30, 30, DateTimeKind.Utc);

            Assert.AreEqual(testDateTime, "2000-01-01 12:30:30".ToDateTime());

            // 01/01/2000 12:30:30
            Assert.AreEqual(testDateTime, testDateTime.ToString(CultureInfo.InvariantCulture).ToDateTime());

            Assert.AreEqual(testDateTime.Date, "2000-01-01".ToDateTime().Date);

            // Saturday, January 1, 2000
            // 1 / 1 / 2000
            Assert.AreEqual(testDateTime.Date, testDateTime.ToLongDateString().ToDateTime().Date);
            Assert.AreEqual(testDateTime.Date, testDateTime.ToShortDateString().ToDateTime().Date);

            Assert.AreEqual(testDateTime.TimeOfDay, "12:30:30".ToDateTime().TimeOfDay);

            // 12:30:30 PM
            // 12:30 PM
            Assert.AreEqual(testDateTime.TimeOfDay, testDateTime.ToLongTimeString().ToDateTime().TimeOfDay);
            Assert.AreEqual(testDateTime.Hour, testDateTime.ToShortTimeString().ToDateTime().Hour);
            Assert.AreEqual(testDateTime.Minute, testDateTime.ToShortTimeString().ToDateTime().Minute);

            // 如果不指定，转换后的 DataTimeKind 为 Unspecified
            Assert.AreEqual(DateTimeKind.Unspecified, "2000-01-01 12:30:30".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, "2000-01-01T12:30:30".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, "1/1/2000 12:30:30 PM".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, "Saturday, January 1, 2000 12:30:30 PM".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTime().Kind); // 2000-01-01 12:30:30
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("s").ToDateTime().Kind); // 2000-01-01T12:30:30
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("G").ToDateTime().Kind); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("F").ToDateTime().Kind); // Saturday, January 1, 2000 12:30:30 PM
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("U").ToDateTime().Kind); // Saturday, January 1, 2000 12:30:30 PM

            // 即使未指定 DataTimeKind，转化后的时间的小时数依旧是 12
            Assert.AreEqual(12, "2000-01-01 12:30:30".ToDateTime().Hour);
            Assert.AreEqual(12, "2000-01-01T12:30:30".ToDateTime().Hour);
            Assert.AreEqual(12, "1/1/2000 12:30:30 PM".ToDateTime().Hour);
            Assert.AreEqual(12, "Saturday, January 1, 2000 12:30:30 PM".ToDateTime().Hour);
            Assert.AreEqual(12, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTime().Hour); // 2000-01-01 12:30:30
            Assert.AreEqual(12, testDateTime.ToString("s").ToDateTime().Hour); // 2000-01-01T12:30:30
            Assert.AreEqual(12, testDateTime.ToString("G").ToDateTime().Hour); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(12, testDateTime.ToString("F").ToDateTime().Hour); // Saturday, January 1, 2000 12:30:30 PM
            Assert.AreEqual(12, testDateTime.ToString("U").ToDateTime().Hour); // Saturday, January 1, 2000 12:30:30 PM

            // 由于未指定 DataTimeKind，所以在标准时概念上已经不是相等的时间了，如果本地时区是 UTC，则有可能相等，但是在北京时区是（东八区）不相等的
            if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.Zero)
            {
                Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".ToDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".ToDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".ToDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".ToDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTime().ToUniversalTime()); // 2000-01-01 12:30:30
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").ToDateTime().ToUniversalTime()); // 2000-01-01T12:30:30
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").ToDateTime().ToUniversalTime()); // 1/1/2000 12:30:30 PM
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").ToDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("U").ToDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
            }
            else
            {
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".ToDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".ToDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".ToDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".ToDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTime().ToUniversalTime()); // 2000-01-01 12:30:30
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").ToDateTime().ToUniversalTime()); // 2000-01-01T12:30:30
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").ToDateTime().ToUniversalTime()); // 1/1/2000 12:30:30 PM
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").ToDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("U").ToDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
            }

            // 如果指定，转换后的 DataTimeKind 为 Local，并且时间也会由于时区指定而发生变化
            Assert.AreEqual(DateTimeKind.Local, "2000-01-01T12:30:30.0000000Z".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, "Sat, 01 Jan 2000 12:30:30 GMT".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, "2000-01-01 12:30:30Z".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, "2000-01-01 12:30:30 PM +00".ToDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("O").ToDateTime().Kind); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("R").ToDateTime().Kind); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("u").ToDateTime().Kind); // 2000-01-01 12:30:30Z
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").ToDateTime().Kind); // 2000-01-01 12:30:30 PM +00

            // 由于转换后的 DataTimeKind 为 Local，时间部分也会由于时区指定而发生变化，转化后的时间的小时数为本地时间，如果 东八区，则为 20（北京时区，东八区）
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01T12:30:30.0000000Z".ToDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "Sat, 01 Jan 2000 12:30:30 GMT".ToDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01 12:30:30Z".ToDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01 12:30:30 PM +00".ToDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("O").ToDateTime().Hour); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("R").ToDateTime().Hour); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("u").ToDateTime().Hour); // 2000-01-01 12:30:30Z
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").ToDateTime().Hour); // 2000-01-01 12:30:30 PM +00

            if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.Zero)
            {
                Assert.AreEqual(testDateTime, "2000-01-01T12:30:30.0000000Z".ToDateTime());
                Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 12:30:30 GMT".ToDateTime());
                Assert.AreEqual(testDateTime, "2000-01-01 12:30:30Z".ToDateTime());
                Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 PM +00".ToDateTime());
                Assert.AreEqual(testDateTime, testDateTime.ToString("O").ToDateTime()); // 2000-01-01T12:30:30.0000000Z
                Assert.AreEqual(testDateTime, testDateTime.ToString("R").ToDateTime()); // Sat, 01 Jan 2000 12:30:30 GMT
                Assert.AreEqual(testDateTime, testDateTime.ToString("u").ToDateTime()); // 2000-01-01 12:30:30Z
                Assert.AreEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").ToDateTime()); // 2000-01-01 12:30:30 PM +00
            }
            else
            {
                // 由于转换后的 DataTimeKind 为 Local，所以在 DateTime 类型下已经不相等
                Assert.AreNotEqual(testDateTime, "2000-01-01T12:30:30.0000000Z".ToDateTime());
                Assert.AreNotEqual(testDateTime, "Sat, 01 Jan 2000 12:30:30 GMT".ToDateTime());
                Assert.AreNotEqual(testDateTime, "2000-01-01 12:30:30Z".ToDateTime());
                Assert.AreNotEqual(testDateTime, "2000-01-01 12:30:30 PM +00".ToDateTime());
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("O").ToDateTime()); // 2000-01-01T12:30:30.0000000Z
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("R").ToDateTime()); // Sat, 01 Jan 2000 12:30:30 GMT
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("u").ToDateTime()); // 2000-01-01 12:30:30Z
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").ToDateTime()); // 2000-01-01 12:30:30 PM +00
            }

            // 即使转换后的 DataTimeKind 为 Local，在标准时概念上依旧是相等的时间
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30.0000000Z".ToDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "Sat, 01 Jan 2000 12:30:30 GMT".ToDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30Z".ToDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30 PM +00".ToDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("O").ToDateTime().ToUniversalTime()); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("R").ToDateTime().ToUniversalTime()); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("u").ToDateTime().ToUniversalTime()); // 2000-01-01 12:30:30Z
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").ToDateTime().ToUniversalTime()); // 2000-01-01 12:30:30 PM +00
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_AsDateTime_Should.cs
// CreatedAt        : 2022-08-16
// LastModifiedAt   : 2022-08-16
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Globalization;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_AsDateTime_Should
    {
        [TestMethod]
        public void AsDateTime_Fail_Should()
        {
            DateTime defaultTestData = DateTime.Now;

            Assert.AreEqual(default, "abcdefg".AsDateTime());
            Assert.AreEqual(default, "2001".AsDateTime());
            Assert.AreEqual(default, "null".AsDateTime());
            Assert.AreEqual(default, "2001--01--01".AsDateTime());
            Assert.AreEqual(default, "default".AsDateTime());

            Assert.AreEqual(defaultTestData, "abcdefg".AsDateTime(defaultTestData));
            Assert.AreEqual(defaultTestData, "2001".AsDateTime(defaultTestData));
            Assert.AreEqual(defaultTestData, "null".AsDateTime(defaultTestData));
            Assert.AreEqual(defaultTestData, "2001--01--01".AsDateTime(defaultTestData));
            Assert.AreEqual(defaultTestData, "default".AsDateTime(defaultTestData));
        }

        [TestMethod]
        public void AsDateTime_Success_Should()
        {
            DateTime testDateTime = new DateTime(2000, 1, 1, 12, 30, 30, DateTimeKind.Utc);

            Assert.AreEqual(testDateTime, "2000-01-01 12:30:30".AsDateTime());

            // 01/01/2000 12:30:30
            Assert.AreEqual(testDateTime, testDateTime.ToString(CultureInfo.InvariantCulture).AsDateTime());

            Assert.AreEqual(testDateTime.Date, "2000-01-01".AsDateTime().Date);

            // Saturday, January 1, 2000
            // 1 / 1 / 2000
            Assert.AreEqual(testDateTime.Date, testDateTime.ToLongDateString().AsDateTime().Date);
            Assert.AreEqual(testDateTime.Date, testDateTime.ToShortDateString().AsDateTime().Date);

            Assert.AreEqual(testDateTime.TimeOfDay, "12:30:30".AsDateTime().TimeOfDay);

            // 12:30:30 PM
            // 12:30 PM
            Assert.AreEqual(testDateTime.TimeOfDay, testDateTime.ToLongTimeString().AsDateTime().TimeOfDay);
            Assert.AreEqual(testDateTime.Hour, testDateTime.ToShortTimeString().AsDateTime().Hour);
            Assert.AreEqual(testDateTime.Minute, testDateTime.ToShortTimeString().AsDateTime().Minute);

            // ?????????????????????????????? DataTimeKind ??? Unspecified
            Assert.AreEqual(DateTimeKind.Unspecified, "2000-01-01 12:30:30".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, "2000-01-01T12:30:30".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, "1/1/2000 12:30:30 PM".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, "Saturday, January 1, 2000 12:30:30 PM".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").AsDateTime().Kind); // 2000-01-01 12:30:30
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("s").AsDateTime().Kind); // 2000-01-01T12:30:30
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("G").AsDateTime().Kind); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("F").AsDateTime().Kind); // Saturday, January 1, 2000 12:30:30 PM
            Assert.AreEqual(DateTimeKind.Unspecified, testDateTime.ToString("U").AsDateTime().Kind); // Saturday, January 1, 2000 12:30:30 PM

            // ??????????????? DataTimeKind?????????????????????????????????????????? 12
            Assert.AreEqual(12, "2000-01-01 12:30:30".AsDateTime().Hour);
            Assert.AreEqual(12, "2000-01-01T12:30:30".AsDateTime().Hour);
            Assert.AreEqual(12, "1/1/2000 12:30:30 PM".AsDateTime().Hour);
            Assert.AreEqual(12, "Saturday, January 1, 2000 12:30:30 PM".AsDateTime().Hour);
            Assert.AreEqual(12, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").AsDateTime().Hour); // 2000-01-01 12:30:30
            Assert.AreEqual(12, testDateTime.ToString("s").AsDateTime().Hour); // 2000-01-01T12:30:30
            Assert.AreEqual(12, testDateTime.ToString("G").AsDateTime().Hour); // 1/1/2000 12:30:30 PM
            Assert.AreEqual(12, testDateTime.ToString("F").AsDateTime().Hour); // Saturday, January 1, 2000 12:30:30 PM
            Assert.AreEqual(12, testDateTime.ToString("U").AsDateTime().Hour); // Saturday, January 1, 2000 12:30:30 PM

            // ??????????????? DataTimeKind???????????????????????????????????????????????????????????????????????????????????? UTC????????????????????????????????????
            if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.Zero)
            {
                Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".AsDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".AsDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".AsDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".AsDateTime().ToUniversalTime());
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").AsDateTime().ToUniversalTime()); // 2000-01-01 12:30:30
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").AsDateTime().ToUniversalTime()); // 2000-01-01T12:30:30
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").AsDateTime().ToUniversalTime()); // 1/1/2000 12:30:30 PM
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").AsDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
                Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("U").AsDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
            }
            else
            {
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30".AsDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30".AsDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "1/1/2000 12:30:30 PM".AsDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), "Saturday, January 1, 2000 12:30:30 PM".AsDateTime().ToUniversalTime());
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss").AsDateTime().ToUniversalTime()); // 2000-01-01 12:30:30
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("s").AsDateTime().ToUniversalTime()); // 2000-01-01T12:30:30
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("G").AsDateTime().ToUniversalTime()); // 1/1/2000 12:30:30 PM
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("F").AsDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
                Assert.AreNotEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("U").AsDateTime().ToUniversalTime()); // Saturday, January 1, 2000 12:30:30 PM
            }

            // ??????????????????????????? DataTimeKind ??? Local????????????????????????????????????????????????????????????????????????????????? UTC ?????????DataTimeKind ?????????????????? Local
            Assert.AreEqual(DateTimeKind.Local, "2000-01-01T12:30:30.0000000Z".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, "Sat, 01 Jan 2000 12:30:30 GMT".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, "2000-01-01 12:30:30Z".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, "2000-01-01 12:30:30 PM +00".AsDateTime().Kind);
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("O").AsDateTime().Kind); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("R").AsDateTime().Kind); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("u").AsDateTime().Kind); // 2000-01-01 12:30:30Z
            Assert.AreEqual(DateTimeKind.Local, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").AsDateTime().Kind); // 2000-01-01 12:30:30 PM +00

            // ?????????????????? DataTimeKind ??? Local??????????????????????????????????????????????????????????????????????????????????????????????????????????????? ?????????????????? 20??????????????????????????????
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01T12:30:30.0000000Z".AsDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "Sat, 01 Jan 2000 12:30:30 GMT".AsDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01 12:30:30Z".AsDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, "2000-01-01 12:30:30 PM +00".AsDateTime().Hour);
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("O").AsDateTime().Hour); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("R").AsDateTime().Hour); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("u").AsDateTime().Hour); // 2000-01-01 12:30:30Z
            Assert.AreEqual(12 + TimeZoneInfo.Local.BaseUtcOffset.Hours, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").AsDateTime().Hour); // 2000-01-01 12:30:30 PM +00

            if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.Zero)
            {
                Assert.AreEqual(testDateTime, "2000-01-01T12:30:30.0000000Z".AsDateTime());
                Assert.AreEqual(testDateTime, "Sat, 01 Jan 2000 12:30:30 GMT".AsDateTime());
                Assert.AreEqual(testDateTime, "2000-01-01 12:30:30Z".AsDateTime());
                Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 PM +00".AsDateTime());
                Assert.AreEqual(testDateTime, testDateTime.ToString("O").AsDateTime()); // 2000-01-01T12:30:30.0000000Z
                Assert.AreEqual(testDateTime, testDateTime.ToString("R").AsDateTime()); // Sat, 01 Jan 2000 12:30:30 GMT
                Assert.AreEqual(testDateTime, testDateTime.ToString("u").AsDateTime()); // 2000-01-01 12:30:30Z
                Assert.AreEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").AsDateTime()); // 2000-01-01 12:30:30 PM +00       
            }
            else
            {
                // ?????????????????? DataTimeKind ??? Local???????????? DateTime ????????????????????????
                Assert.AreNotEqual(testDateTime, "2000-01-01T12:30:30.0000000Z".AsDateTime());
                Assert.AreNotEqual(testDateTime, "Sat, 01 Jan 2000 12:30:30 GMT".AsDateTime());
                Assert.AreNotEqual(testDateTime, "2000-01-01 12:30:30Z".AsDateTime());
                Assert.AreNotEqual(testDateTime, "2000-01-01 12:30:30 PM +00".AsDateTime());
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("O").AsDateTime()); // 2000-01-01T12:30:30.0000000Z
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("R").AsDateTime()); // Sat, 01 Jan 2000 12:30:30 GMT
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("u").AsDateTime()); // 2000-01-01 12:30:30Z
                Assert.AreNotEqual(testDateTime, testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").AsDateTime()); // 2000-01-01 12:30:30 PM +00    
            }

            // ?????????????????? DataTimeKind ??? Local????????????????????????????????????????????????
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01T12:30:30.0000000Z".AsDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "Sat, 01 Jan 2000 12:30:30 GMT".AsDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30Z".AsDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), "2000-01-01 12:30:30 PM +00".AsDateTime().ToUniversalTime());
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("O").AsDateTime().ToUniversalTime()); // 2000-01-01T12:30:30.0000000Z
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("R").AsDateTime().ToUniversalTime()); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("u").AsDateTime().ToUniversalTime()); // 2000-01-01 12:30:30Z
            Assert.AreEqual(testDateTime.ToUniversalTime(), testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").AsDateTime().ToUniversalTime()); // 2000-01-01 12:30:30 PM +00

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTime testData = r.Between(DateTime.MinValue, DateTime.MaxValue);
                string testData1 = testData.ToString("O");
                string testData2 = testData.ToString("R");
                string testData3 = testData.ToString("u");
                string testData4 = testData.ToString("yyyy-MM-dd HH:mm:ss tt zz");
                Assert.AreEqual(testData1.As<DateTime>(), testData1.AsDateTime());
                Assert.AreEqual(testData2.As<DateTime>(), testData2.AsDateTime());
                Assert.AreEqual(testData3.As<DateTime>(), testData3.AsDateTime());
                Assert.AreEqual(testData4.As<DateTime>(), testData4.AsDateTime());
            });
        }
    }
}

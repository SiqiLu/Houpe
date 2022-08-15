// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsDateTime_Should.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Globalization;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_IsDateTime_Should
    {
        [TestMethod]
        public void IsDateTime_True_Should()
        {
            DateTime testDateTime = new DateTime(2000, 1, 1, 12, 30, 30, DateTimeKind.Utc);

            Assert.IsTrue("2000-01-01 12:30:30".IsDateTime());

            // 01/01/2000 12:30:30
            Assert.IsTrue(testDateTime.ToString(CultureInfo.InvariantCulture).IsDateTime());

            Assert.IsTrue("2000-01-01".IsDateTime());

            // Saturday, January 1, 2000
            // 1 / 1 / 2000
            Assert.IsTrue(testDateTime.ToLongDateString().IsDateTime());
            Assert.IsTrue(testDateTime.ToShortDateString().IsDateTime());

            Assert.IsTrue("12:30:30".IsDateTime());

            // 如果不指定，转换后的 DataTimeKind 为 Unspecified
            Assert.IsTrue("2000-01-01 12:30:30".IsDateTime());
            Assert.IsTrue("2000-01-01T12:30:30".IsDateTime());
            Assert.IsTrue("1/1/2000 12:30:30 PM".IsDateTime());
            Assert.IsTrue("Saturday, January 1, 2000 12:30:30 PM".IsDateTime());
            Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss").IsDateTime()); // 2000-01-01 12:30:30
            Assert.IsTrue(testDateTime.ToString("s").IsDateTime()); // 2000-01-01T12:30:30
            Assert.IsTrue(testDateTime.ToString("G").IsDateTime()); // 1/1/2000 12:30:30 PM
            Assert.IsTrue(testDateTime.ToString("F").IsDateTime()); // Saturday, January 1, 2000 12:30:30 PM
            Assert.IsTrue(testDateTime.ToString("U").IsDateTime()); // Saturday, January 1, 2000 12:30:30 PM

            // 如果指定，转换后的 DataTimeKind 为 Local，并且时间也会由于时区指定而发生变化
            Assert.IsTrue("2000-01-01T12:30:30.0000000Z".IsDateTime());
            Assert.IsTrue("Sat, 01 Jan 2000 12:30:30 GMT".IsDateTime());
            Assert.IsTrue("2000-01-01 12:30:30Z".IsDateTime());
            Assert.IsTrue("2000-01-01 12:30:30 PM +00".IsDateTime());
            Assert.IsTrue(testDateTime.ToString("O").IsDateTime()); // 2000-01-01T12:30:30.0000000Z
            Assert.IsTrue(testDateTime.ToString("R").IsDateTime()); // Sat, 01 Jan 2000 12:30:30 GMT
            Assert.IsTrue(testDateTime.ToString("u").IsDateTime()); // 2000-01-01 12:30:30Z
            Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").IsDateTime()); // 2000-01-01 12:30:30 PM +00

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTime t = r.Soon();
                Assert.IsTrue(t.ToString(CultureInfo.InvariantCulture).IsDateTime());
            });
        }

        [TestMethod]
        public void IsDateTime_False_Should()
        {
            Assert.IsFalse("abcdefg".IsDateTime());
            Assert.IsFalse("2001".IsDateTime());
            Assert.IsFalse("null".IsDateTime());
            Assert.IsFalse("2001--01--01".IsDateTime());
            Assert.IsFalse("default".IsDateTime());

            Assert.IsFalse("abcdefg".IsDateTime());
            Assert.IsFalse("2001".IsDateTime());
            Assert.IsFalse("null".IsDateTime());
            Assert.IsFalse("2001--01--01".IsDateTime());
            Assert.IsFalse("default".IsDateTime());
        }
    }
}

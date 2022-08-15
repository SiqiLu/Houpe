// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsDateTimeOffset_Should.cs
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
    public class StringExtensions_IsDateTimeOffset_Should
    {
        [TestMethod]
        public void IsDateTimeOffset_True_Should()
        {
            DateTimeOffset testDateTime = new DateTimeOffset(2000, 1, 1, 12, 30, 30, new TimeSpan(0, 8, 0, 0)); // 东八区 北京时区

            // 默认填充东八区的时区信息
            Assert.IsTrue("2000-01-01 12:30:30".IsDateTimeOffset());

            // 01/01/2000 12:30:30
            Assert.IsTrue(testDateTime.ToString(CultureInfo.InvariantCulture).IsDateTimeOffset());
            Assert.IsTrue("2000-01-01".IsDateTimeOffset());
            Assert.IsTrue("12:30:30".IsDateTimeOffset());

            // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset，在这里即为东八区 Offset
            Assert.IsTrue("2000-01-01 12:30:30".IsDateTimeOffset());
            Assert.IsTrue("2000-01-01T12:30:30".IsDateTimeOffset());
            Assert.IsTrue("1/1/2000 12:30:30 PM".IsDateTimeOffset());
            Assert.IsTrue("Saturday, January 1, 2000 12:30:30 PM".IsDateTimeOffset());
            Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss").IsDateTimeOffset()); // 2000-01-01 12:30:30
            Assert.IsTrue(testDateTime.ToString("s").IsDateTimeOffset()); // 2000-01-01T12:30:30
            Assert.IsTrue(testDateTime.ToString("G").IsDateTimeOffset()); // 1/1/2000 12:30:30 PM
            Assert.IsTrue(testDateTime.ToString("F").IsDateTimeOffset()); // Saturday, January 1, 2000 12:30:30 PM

            // 如果是带时区信息，DateTimeOffset 会完整保留时区信息和调整小时数
            Assert.IsTrue("2000-01-01T12:30:30.0000000+08:00".IsDateTimeOffset());
            Assert.IsTrue("Sat, 01 Jan 2000 4:30:30 GMT".IsDateTimeOffset());
            Assert.IsTrue("2000-01-01 4:30:30Z".IsDateTimeOffset());
            Assert.IsTrue("2000-01-01 12:30:30 PM +08".IsDateTimeOffset());
            Assert.IsTrue(testDateTime.ToString("O").IsDateTimeOffset()); // 2000-01-01T12:30:30.0000000+08:00
            Assert.IsTrue(testDateTime.ToString("R").IsDateTimeOffset()); // Sat, 01 Jan 2000 4:30:30 GMT
            Assert.IsTrue(testDateTime.ToString("u").IsDateTimeOffset()); // 2000-01-01 4:30:30Z
            Assert.IsTrue(testDateTime.ToString("yyyy-MM-dd HH:mm:ss tt zz").IsDateTimeOffset()); // 2000-01-01 12:30:30 PM +08

            Date r = new Date();

            100.Times().Do(() =>
            {
                DateTimeOffset t = r.SoonOffset();
                Assert.IsTrue(t.ToString(CultureInfo.InvariantCulture).IsDateTimeOffset());
            });
        }

        [TestMethod]
        public void IsDateTimeOffset_False_Should()
        {
            Assert.IsFalse("abcdefg".IsDateTimeOffset());
            Assert.IsFalse("2001".IsDateTimeOffset());
            Assert.IsFalse("null".IsDateTimeOffset());
            Assert.IsFalse("2001--01--01".IsDateTimeOffset());
            Assert.IsFalse("default".IsDateTimeOffset());
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDateTimeOffset_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToDateTimeOffset_Should
{
    [TestMethod]
    public void ToDateTimeOffset_Should()
    {
        DateTimeOffset testDateTime = new DateTimeOffset(2000, 1, 1, 12, 30, 30, new TimeSpan(0, 8, 0, 0)); // 东八区 北京时区

        // 默认填充东八区的时区信息
        Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 +08:00".ToDateTimeOffset());

        // 01/01/2000 12:30:30

        Assert.AreEqual(testDateTime.Date, "2000-01-01".ToDateTimeOffset().Date);
        Assert.AreEqual(testDateTime.TimeOfDay, "12:30:30".ToDateTimeOffset().TimeOfDay);

        // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "2000-01-01 12:30:30".ToDateTimeOffset().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "2000-01-01T12:30:30".ToDateTimeOffset().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "1/1/2000 12:30:30 PM".ToDateTimeOffset().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, "Saturday, January 1, 2000 12:30:30 PM".ToDateTimeOffset().Offset);
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("yyyy-MM-dd HH:mm:ss").ToDateTimeOffset().Offset); // 2000-01-01 12:30:30
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("s").ToDateTimeOffset().Offset); // 2000-01-01T12:30:30
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("G").ToDateTimeOffset().Offset); // 1/1/2000 12:30:30 PM
        Assert.AreEqual(TimeZoneInfo.Local.BaseUtcOffset, testDateTime.ToString("F").ToDateTimeOffset().Offset); // Saturday, January 1, 2000 12:30:30 PM

        // 如果不指定，转换后的 TimeSpan 为 本地时区 Offset
        Assert.AreEqual(testDateTime, "2000-01-01T12:30:30.0000000 +08:00".ToDateTimeOffset());
        Assert.AreEqual(testDateTime, "2000-01-01 12:30:30 +08:00".ToDateTimeOffset());
        Assert.AreEqual(testDateTime, "2000-01-01T12:30:30 +08:00".ToDateTimeOffset());
        Assert.AreEqual(testDateTime, "1/1/2000 12:30:30 PM +08:00".ToDateTimeOffset());
        Assert.AreEqual(testDateTime, "Saturday, January 1, 2000 12:30:30 PM +08:00".ToDateTimeOffset());
        Assert.AreEqual(testDateTime, (testDateTime.ToString("yyyy-MM-dd HH:mm:ss") + " +08:00").ToDateTimeOffset()); // 2000-01-01 12:30:30
        Assert.AreEqual(testDateTime, (testDateTime.ToString("s") + " +08:00").ToDateTimeOffset()); // 2000-01-01T12:30:30
        Assert.AreEqual(testDateTime, (testDateTime.ToString("G") + " +08:00").ToDateTimeOffset()); // 1/1/2000 12:30:30 PM
        Assert.AreEqual(testDateTime, (testDateTime.ToString("F") + " +08:00").ToDateTimeOffset()); // Saturday, January 1, 2000 12:30:30 PM
    }
}

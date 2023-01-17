// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_ToChinaStandardTime_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeExtensions_ToChinaStandardTime_Should
{
    [TestMethod]
    public void ToChinaStandardTime_Should()
    {
        DateTime time1 = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Unspecified);
        DateTime time2 = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Local);
        DateTime time3 = new DateTime(2000, 1, 1, 12, 0, 0, DateTimeKind.Utc);

        if (TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Hours == 8)
        {
            // 测试时区是东八区
            DateTime result1 = time1.ToChinaStandardTime();
            Assert.AreEqual(DateTimeKind.Local, result1.Kind);
            Assert.AreEqual(2000, result1.Year);
            Assert.AreEqual(1, result1.Month);
            Assert.AreEqual(1, result1.Day);
            Assert.AreEqual(12, result1.Hour);
            Assert.AreEqual(0, result1.Minute);
            Assert.AreEqual(0, result1.Second);

            DateTime result2 = time2.ToChinaStandardTime();
            Assert.AreEqual(DateTimeKind.Local, result2.Kind);
            Assert.AreEqual(2000, result2.Year);
            Assert.AreEqual(1, result2.Month);
            Assert.AreEqual(1, result2.Day);
            Assert.AreEqual(12, result2.Hour);
            Assert.AreEqual(0, result2.Minute);
            Assert.AreEqual(0, result2.Second);
        }

        DateTime result3 = time3.ToChinaStandardTime();
        Assert.AreEqual(DateTimeKind.Local, result3.Kind);
        Assert.AreEqual(2000, result3.Year);
        Assert.AreEqual(1, result3.Month);
        Assert.AreEqual(1, result3.Day);
        Assert.AreEqual(20, result3.Hour);
        Assert.AreEqual(0, result3.Minute);
        Assert.AreEqual(0, result3.Second);
    }
}

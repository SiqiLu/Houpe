// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeOffsetExtensions_IsFirstDayOfThisYear_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class DateTimeOffsetExtensions_IsFirstDayOfThisYear_Should
{
    [TestMethod]
    public void IsFirstDayOfThisYear_Should()
    {
        Date r = new Date();
        TimeSpan utcOffset = TimeSpan.Zero;
        DateTimeOffset test = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

        Assert.IsTrue(new DateTimeOffset(test.Year, 1, 1, test.Hour, test.Minute, test.Second, utcOffset).IsFirstDayOfThisYear());

        100.Times().Do(() =>
        {
            DateTimeOffset t = r.BetweenOffset(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
            if (t.Day == 1 && t.Month == 1)
            {
                Assert.IsTrue(t.IsFirstDayOfThisYear());
            }
            else
            {
                Assert.IsFalse(t.IsFirstDayOfThisYear());
            }
        });

        // 该判断会考虑时区因素，参考时区即为被调用方的时区
        DateTimeOffset t1 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.Zero);
        DateTimeOffset t2 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.FromHours(8));
        DateTimeOffset t3 = new DateTimeOffset(2000, 1, 1, 12, 0, 0, TimeSpan.FromHours(-8));
        Assert.IsTrue(t1.IsFirstDayOfThisYear());
        Assert.IsTrue(t2.IsFirstDayOfThisYear());
        Assert.IsTrue(t3.IsFirstDayOfThisYear());

        DateTimeOffset t4 = new DateTimeOffset(2000, 1, 2, 2, 0, 0, TimeSpan.FromHours(8));
        DateTimeOffset t5 = new DateTimeOffset(2000, 1, 1, 18, 0, 0, TimeSpan.Zero);
        DateTimeOffset t6 = t4.ToUniversalTime();
        Assert.IsTrue(t4 == t5);
        Assert.IsTrue(t4 == t6);

        // t4 t5 t6 是相同的时间
        Assert.IsFalse(t4.IsFirstDayOfThisYear()); // 参考中国时区
        Assert.IsTrue(t5.IsFirstDayOfThisYear()); // 参考标准时区
        Assert.IsTrue(t6.IsFirstDayOfThisYear()); // 参考标准时区

        DateTimeOffset t7 = new DateTimeOffset(1999, 12, 31, 20, 0, 0, TimeSpan.Zero).ToUniversalTime();
        DateTimeOffset t8 = t7.ToHKTime();
        Assert.IsFalse(t7.IsFirstDayOfThisYear()); // 参考标准时区
        Assert.IsTrue(t8.IsFirstDayOfThisYear()); // 参考中国时区
    }
}

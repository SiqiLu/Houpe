// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsLastDayOfThisMonth_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeExtensions_IsLastDayOfThisMonth_Should
    {
        [TestMethod]
        public void IsLastDayOfThisMonth_Should()
        {
            Date r = new Date();

            DateTime test = r.Between(DateTime.MinValue, DateTime.MaxValue);

            Assert.IsTrue(new DateTime(test.Year, 1, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(2000, 2, 29, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 3, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 4, 30, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 5, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 6, 30, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 7, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 8, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 9, 30, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 10, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 11, 30, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());
            Assert.IsTrue(new DateTime(test.Year, 12, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisMonth());

            100.Times().Do(() =>
            {
                DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
                if (t.Day == 31)
                {
                    Assert.IsTrue(t.IsLastDayOfThisMonth());
                }
            });
        }
    }
}

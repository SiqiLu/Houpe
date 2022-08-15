// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsLastDayOfThisYear_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class DateTimeExtensions_IsLastDayOfThisYear_Should
    {
        [TestMethod]
        public void IsLastDayOfThisYear_Should()
        {
            Date r = new Date();

            DateTime test = r.Between(DateTime.MinValue, DateTime.MaxValue);

            Assert.IsTrue(new DateTime(test.Year, 12, 31, test.Hour, test.Minute, test.Second).IsLastDayOfThisYear());

            100.Times().Do(() =>
            {
                DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
                if (t.Month == 12 && t.Day == 31)
                {
                    Assert.IsTrue(t.IsLastDayOfThisYear());
                }
                else
                {
                    Assert.IsFalse(t.IsLastDayOfThisYear());
                }
            });
        }
    }
}

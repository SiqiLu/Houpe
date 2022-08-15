// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : DateTimeExtensions_IsFirstDayOfThisYear_Should.cs
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
    public class DateTimeExtensions_IsFirstDayOfThisYear_Should
    {
        [TestMethod]
        public void IsFirstDayOfThisYear_Should()
        {
            Date r = new Date();

            DateTime test = r.Between(DateTime.MinValue, DateTime.MaxValue);

            Assert.IsTrue(new DateTime(test.Year, 1, 1, test.Hour, test.Minute, test.Second).IsFirstDayOfThisYear());

            100.Times().Do(() =>
            {
                DateTime t = r.Between(DateTime.MinValue, DateTime.MaxValue);
                if (t.Day == 1 && t.Month == 1)
                {
                    Assert.IsTrue(t.IsFirstDayOfThisYear());
                }
                else
                {
                    Assert.IsFalse(t.IsFirstDayOfThisYear());
                }
            });
        }
    }
}

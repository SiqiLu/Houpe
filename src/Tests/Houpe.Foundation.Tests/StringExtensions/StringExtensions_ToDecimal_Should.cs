// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDecimal_Should.cs
// CreatedAt        : 2021-06-23
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToDecimal_Should
    {
        [TestMethod]
        public void ToDecimal_Should()
        {
            Assert.AreEqual(0, "0".ToDecimal());
            Assert.AreEqual(1, "1".ToDecimal());
            Assert.AreEqual(-1, "-1".ToDecimal());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToDecimal());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToDecimal());

            Assert.AreEqual(new decimal(0), "0".ToDecimal());
            Assert.AreEqual(new decimal(1), "1".ToDecimal());
            Assert.AreEqual(new decimal(-1), "-1".ToDecimal());
            Assert.AreEqual(new decimal(int.MaxValue), int.MaxValue.ToString().ToDecimal());
            Assert.AreEqual(new decimal(int.MinValue), int.MinValue.ToString().ToDecimal());

            Assert.AreEqual(new decimal(1.1), "1.1".ToDecimal());
            Assert.AreEqual(new decimal(-1.1), "-1.1".ToDecimal());
            Assert.AreEqual(new decimal(1.9), "1.9".ToDecimal());
            Assert.AreEqual(new decimal(long.MaxValue), long.MaxValue.ToString(CultureInfo.InvariantCulture).ToDecimal());
            Assert.AreEqual(new decimal(long.MinValue), long.MinValue.ToString(CultureInfo.InvariantCulture).ToDecimal());
            Assert.AreEqual(decimal.MaxValue, decimal.MaxValue.ToString(CultureInfo.InvariantCulture).ToDecimal());
            Assert.AreEqual(decimal.MinValue, decimal.MinValue.ToString(CultureInfo.InvariantCulture).ToDecimal());
        }
    }
}

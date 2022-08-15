// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToFloat_ToSingle_Should.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToFloat_ToSingle_Should
    {
        [TestMethod]
        public void ToFloat_Should()
        {
            Assert.AreEqual(0, "0".ToFloat());
            Assert.AreEqual(1, "1".ToFloat());
            Assert.AreEqual(-1, "-1".ToFloat());

            Assert.AreEqual(0f, "0".ToFloat());
            Assert.AreEqual(1f, "1".ToFloat());
            Assert.AreEqual(-1f, "-1".ToFloat());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToFloat());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToFloat());

            Assert.AreEqual(1.1f, "1.1".ToFloat());
            Assert.AreEqual(-1.1f, "-1.1".ToFloat());
            Assert.AreEqual(1.9f, "1.9".ToFloat());
            Assert.AreEqual(long.MaxValue, long.MaxValue.ToString(CultureInfo.InvariantCulture).ToFloat());
            Assert.AreEqual(long.MinValue, long.MinValue.ToString(CultureInfo.InvariantCulture).ToFloat());
            Assert.AreEqual(float.MaxValue, float.MaxValue.ToString(CultureInfo.InvariantCulture).ToFloat());
            Assert.AreEqual(float.MinValue, float.MinValue.ToString(CultureInfo.InvariantCulture).ToFloat());
        }

        [TestMethod]
        public void ToSingle_Should()
        {
            Assert.AreEqual(0, "0".ToSingle());
            Assert.AreEqual(1, "1".ToSingle());
            Assert.AreEqual(-1, "-1".ToSingle());

            Assert.AreEqual(0f, "0".ToSingle());
            Assert.AreEqual(1f, "1".ToSingle());
            Assert.AreEqual(-1f, "-1".ToSingle());
            Assert.AreEqual(int.MaxValue, int.MaxValue.ToString().ToSingle());
            Assert.AreEqual(int.MinValue, int.MinValue.ToString().ToSingle());

            Assert.AreEqual(1.1f, "1.1".ToSingle());
            Assert.AreEqual(-1.1f, "-1.1".ToSingle());
            Assert.AreEqual(1.9f, "1.9".ToSingle());
            Assert.AreEqual(long.MaxValue, long.MaxValue.ToString(CultureInfo.InvariantCulture).ToSingle());
            Assert.AreEqual(long.MinValue, long.MinValue.ToString(CultureInfo.InvariantCulture).ToSingle());
            Assert.AreEqual(float.MaxValue, float.MaxValue.ToString(CultureInfo.InvariantCulture).ToSingle());
            Assert.AreEqual(float.MinValue, float.MinValue.ToString(CultureInfo.InvariantCulture).ToSingle());
        }
    }
}

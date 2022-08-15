// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToBoolean_Should.cs
// CreatedAt        : 2021-06-23
// LastModifiedAt   : 2021-06-23
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToBoolean_Should
    {
        [TestMethod]
        public void ToBoolean_Should()
        {
            Assert.AreEqual(false, "false".ToBoolean());
            Assert.AreEqual(false, "False".ToBoolean());
            Assert.AreEqual(false, "fAlSe".ToBoolean());
            Assert.AreEqual(true, "true".ToBoolean());
            Assert.AreEqual(true, "True".ToBoolean());
            Assert.AreEqual(true, "tRuE".ToBoolean());
        }
    }
}

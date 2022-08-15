// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_IfNotNull_Should.cs
// CreatedAt        : 2021-06-26
// LastModifiedAt   : 2021-06-26
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class ObjectExtensions_IfNotNull_Should
    {
        [TestMethod]
        public void IfNotNull_Action_Should()
        {
#pragma warning disable IDE0053 // Use expression body for lambda expressions
            ((object)null).IfNotNull(o => { _ = o + "World!"; });
            "Hello".IfNotNull(s => { _ = s + " World!"; });
#pragma warning restore IDE0053 // Use expression body for lambda expressions
        }

        [TestMethod]
        public void IfNotNull_Func_Should()
        {
            string result1 = ((object)null).IfNotNull(s => s + " World!");
            string result2 = ((object)null).IfNotNull(s => s + " World!", "defaultTestValue");
            string result3 = "Hello".IfNotNull(s => s + " World!");
            string result4 = "Hello".IfNotNull(s => s + " World!", "defaultTestValue");

            Assert.AreEqual(null, result1);
            Assert.AreEqual("defaultTestValue", result2);
            Assert.AreEqual("Hello World!", result3);
            Assert.AreEqual("Hello World!", result4);
        }
    }
}

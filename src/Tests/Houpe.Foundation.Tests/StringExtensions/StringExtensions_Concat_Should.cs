// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_Concat_Should.cs
// CreatedAt        : 2021-06-05
// LastModifiedAt   : 2021-06-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_Concat_Should
    {
        [TestMethod]
        public void Concat_Should()
        {
            Assert.AreEqual("Hello World!", "Hello ".Concat("World!"));
            Assert.AreEqual("World!", string.Empty.Concat("World!"));
            Assert.AreEqual("Hello ", "Hello ".Concat(string.Empty));
            Assert.AreEqual("Hello ", "Hello ".Concat(null));

            // null 值可以成功调用扩展函数，只要函数中没有 null check，就可以继续执行
            Assert.AreEqual("World!", ((string)null).Concat("World!"));
        }
    }
}

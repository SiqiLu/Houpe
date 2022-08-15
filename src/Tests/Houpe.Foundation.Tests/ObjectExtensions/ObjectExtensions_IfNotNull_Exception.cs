// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ObjectExtensions_IfNotNull_Exception.cs
// CreatedAt        : 2021-06-26
// LastModifiedAt   : 2021-06-26
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class ObjectExtensions_IfNotNull_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNotNull_Action_ArgumentNullException() => "Hello World!".IfNotNull(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfNotNull_Func_ArgumentNullException() => _ = "Hello World!".IfNotNull((Func<string, string>)null);
    }
}

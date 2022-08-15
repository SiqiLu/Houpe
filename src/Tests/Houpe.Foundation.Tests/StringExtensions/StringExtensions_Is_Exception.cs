// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_Is_Exception.cs
// CreatedAt        : 2021-06-18
// LastModifiedAt   : 2021-06-18
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_Is_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsCMCellphone_ArgumentNullException() => _ = ((string)null).IsCMCellphone();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsEmail_ArgumentNullException() => _ = ((string)null).IsEmail();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsIPAddress_ArgumentNullException() => _ = ((string)null).IsIPAddress();
    }
}

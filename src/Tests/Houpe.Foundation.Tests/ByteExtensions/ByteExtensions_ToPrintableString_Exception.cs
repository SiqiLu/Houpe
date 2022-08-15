// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ByteExtensions_ToPrintableString_Exception.cs
// CreatedAt        : 2021-05-16
// LastModifiedAt   : 2021-05-16
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class ByteExtensions_ToPrintableString_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToPrintableString_Exception()
        {
            byte[] input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            string _ = input.ToPrintableString();
        }
    }
}

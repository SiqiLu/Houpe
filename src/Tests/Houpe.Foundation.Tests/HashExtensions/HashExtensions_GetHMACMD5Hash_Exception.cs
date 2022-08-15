// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : HashExtensions_GetHMACMD5Hash_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class HashExtensions_GetHMACMD5Hash_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHMACMD5Hash_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.GetHMACMD5Hash();
        }
    }
}

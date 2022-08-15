// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : HashExtensions_GetHMACSHA512Hash_Exception.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-27
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class HashExtensions_GetHMACSHA512Hash_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHMACSHA512Hash_ArgumentNullException()
        {
            string input = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            _ = input.GetHMACSHA512Hash();
        }
    }
}

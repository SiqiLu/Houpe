// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToGuid_Exception.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToGuid_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToGuid_Null_ArgumentException() => _ = ((string)null).ToGuid();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToGuid_Empty_ArgumentException() => _ = string.Empty.ToGuid();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToGuid_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<Guid>> testActions = new List<Func<Guid>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToGuid());
            testActions.Add(() => "guid".ToGuid());
            testActions.Add(() => "null".ToGuid());
            testActions.Add(() => "1".ToGuid());
            testActions.Add(() => "0".ToGuid());
            testActions.Add(() => "Guid.Empty".ToGuid());

            testActions.ForEach(func =>
            {
                try
                {
                    _ = func.Invoke();
                    throw new InternalTestFailureException("Does not throw ExpectedException(typeof(FormatException)).");
                }
                catch (FormatException)
                {
                    // ignore
                }
            });

            throw new FormatException();
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDateTime_Exception.cs
// CreatedAt        : 2021-06-23
// LastModifiedAt   : 2021-06-23
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToDateTime_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDateTime_Null_ArgumentException() => _ = ((string)null).ToDateTime();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDateTime_Empty_ArgumentException() => _ = string.Empty.ToDateTime();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToDateTime_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<DateTime>> testActions = new List<Func<DateTime>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToDateTime());
            testActions.Add(() => "2001".ToDateTime());
            testActions.Add(() => "null".ToDateTime());
            testActions.Add(() => "2001--01--01".ToDateTime());
            testActions.Add(() => "default".ToDateTime());

            testActions.Add(() => "abcdefg".ToDateTime());
            testActions.Add(() => "2001".ToDateTime());
            testActions.Add(() => "null".ToDateTime());
            testActions.Add(() => "2001--01--01".ToDateTime());
            testActions.Add(() => "default".ToDateTime());

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

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDateTimeOffset_Exception.cs
// CreatedAt        : 2022-08-16
// LastModifiedAt   : 2022-08-16
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToDateTimeOffset_Exception
    {
        [TestMethod]
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        [ExpectedException(typeof(FormatException))]
        public void ToDateTimeOffset_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<DateTimeOffset>> testActions = new List<Func<DateTimeOffset>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToDateTimeOffset());
            testActions.Add(() => "2001".ToDateTimeOffset());
            testActions.Add(() => "null".ToDateTimeOffset());
            testActions.Add(() => "2001--01--01".ToDateTimeOffset());
            testActions.Add(() => "default".ToDateTimeOffset());

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDateTimeOffset_S_Empty_ArgumentException() => _ = string.Empty.ToDateTimeOffset();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDateTimeOffset_S_Null_ArgumentException() => _ = ((string)null).ToDateTimeOffset();
    }
}

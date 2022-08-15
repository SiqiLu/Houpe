// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToBoolean_Exception.cs
// CreatedAt        : 2021-06-23
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToBoolean_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToBoolean_ArgumentNullException() => _ = ((string)null).ToBoolean();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToBoolean_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<bool>> testActions = new List<Func<bool>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToBoolean());
            testActions.Add(() => "bool".ToBoolean());
            testActions.Add(() => "null".ToBoolean());
            testActions.Add(() => "-1".ToBoolean());
            testActions.Add(() => "1".ToBoolean());
            testActions.Add(() => "0".ToBoolean());
            testActions.Add(() => "T".ToBoolean());
            testActions.Add(() => "F".ToBoolean());
            testActions.Add(() => "t".ToBoolean());
            testActions.Add(() => "f".ToBoolean());

            testActions.Add(() => "abcdefg".ToBoolean());
            testActions.Add(() => "bool".ToBoolean());
            testActions.Add(() => "null".ToBoolean());
            testActions.Add(() => "-1".ToBoolean());
            testActions.Add(() => "1".ToBoolean());
            testActions.Add(() => "0".ToBoolean());
            testActions.Add(() => "T".ToBoolean());
            testActions.Add(() => "F".ToBoolean());
            testActions.Add(() => "t".ToBoolean());
            testActions.Add(() => "f".ToBoolean());

            testActions.Add(() => "abcdefg".ToBoolean());
            testActions.Add(() => "bool".ToBoolean());
            testActions.Add(() => "null".ToBoolean());
            testActions.Add(() => "-1".ToBoolean());
            testActions.Add(() => "1".ToBoolean());
            testActions.Add(() => "0".ToBoolean());
            testActions.Add(() => "T".ToBoolean());
            testActions.Add(() => "F".ToBoolean());
            testActions.Add(() => "t".ToBoolean());
            testActions.Add(() => "f".ToBoolean());

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

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDouble_Exception.cs
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
    public class StringExtensions_ToDouble_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDouble_Null_ArgumentException() => _ = ((string)null).ToDouble();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDouble_Empty_ArgumentException() => _ = string.Empty.ToDouble();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToDouble_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<double>> testActions = new List<Func<double>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToDouble());
            testActions.Add(() => "double".ToDouble());
            testActions.Add(() => "null".ToDouble());
            testActions.Add(() => "1.1.1".ToDouble());
            testActions.Add(() => "1.9.9".ToDouble());
            testActions.Add(() => "double.MinValue".ToDouble());
            testActions.Add(() => "double.MinValue".ToDouble());

            testActions.Add(() => "abcdefg".ToDouble());
            testActions.Add(() => "double".ToDouble());
            testActions.Add(() => "null".ToDouble());
            testActions.Add(() => "1.1.1".ToDouble());
            testActions.Add(() => "1.9.9".ToDouble());
            testActions.Add(() => "double.MinValue".ToDouble());
            testActions.Add(() => "double.MinValue".ToDouble());

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

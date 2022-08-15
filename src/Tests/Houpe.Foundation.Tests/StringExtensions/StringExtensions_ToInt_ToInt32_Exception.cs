// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToInt_ToInt32_Exception.cs
// CreatedAt        : 2021-06-24
// LastModifiedAt   : 2021-06-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class StringExtensions_ToInt_ToInt32_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_Null_ArgumentException() => _ = ((string)null).ToInt();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_Empty_ArgumentException() => _ = string.Empty.ToInt();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToInt_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<int>> testActions = new List<Func<int>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToInt());
            testActions.Add(() => "int".ToInt());
            testActions.Add(() => "null".ToInt());
            testActions.Add(() => "1.1".ToInt());
            testActions.Add(() => "1.9".ToInt());
            testActions.Add(() => "int.MinValue".ToInt());
            testActions.Add(() => "int.MinValue".ToInt());

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
        [ExpectedException(typeof(OverflowException))]
        public void ToInt_OverflowException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
            List<Func<int>> testActions = new List<Func<int>>();
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => ((long)int.MinValue - 1).ToString().ToInt());
            testActions.Add(() => ((long)int.MaxValue + 1).ToString().ToInt());

            testActions.ForEach(func =>
            {
                try
                {
                    _ = func.Invoke();
                    throw new InternalTestFailureException("Does not throw ExpectedException(typeof(FormatException)).");
                }
                catch (OverflowException)
                {
                    // ignore
                }
            });

            throw new OverflowException();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt32_Null_ArgumentException() => _ = ((string)null).ToInt32();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt32_Empty_ArgumentException() => _ = string.Empty.ToInt32();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
        public void ToInt32_FormatException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable IDE0049 // Simplify Names
            List<Func<Int32>> testActions = new List<Func<Int32>>();
#pragma warning restore IDE0049 // Simplify Names
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => "abcdefg".ToInt32());
            testActions.Add(() => "int".ToInt32());
            testActions.Add(() => "null".ToInt32());
            testActions.Add(() => "1.1".ToInt32());
            testActions.Add(() => "1.9".ToInt32());
            testActions.Add(() => "int.MinValue".ToInt32());
            testActions.Add(() => "int.MinValue".ToInt32());

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
        [ExpectedException(typeof(OverflowException))]
        [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
        public void ToInt32_OverflowException()
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable IDE0049 // Simplify Names
            List<Func<Int32>> testActions = new List<Func<Int32>>();
#pragma warning restore IDE0049 // Simplify Names
#pragma warning restore IDE0028 // Simplify collection initialization

            testActions.Add(() => ((long)int.MinValue - 1).ToString().ToInt32());
            testActions.Add(() => ((long)int.MaxValue + 1).ToString().ToInt32());

            testActions.ForEach(func =>
            {
                try
                {
                    _ = func.Invoke();
                    throw new InternalTestFailureException("Does not throw ExpectedException(typeof(FormatException)).");
                }
                catch (OverflowException)
                {
                    // ignore
                }
            });

            throw new OverflowException();
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToInt16_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToInt16_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToInt16_Empty_ArgumentException() => _ = string.Empty.ToInt16();

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
    public void ToInt16_FormatException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable IDE0049 // Simplify Names
        List<Func<Int16>> testActions = new List<Func<Int16>>();
#pragma warning restore IDE0049 // Simplify Names
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => "abcdefg".ToInt16());
        testActions.Add(() => "short".ToInt16());
        testActions.Add(() => "null".ToInt16());
        testActions.Add(() => "1.1".ToInt16());
        testActions.Add(() => "1.9".ToInt16());
        testActions.Add(() => "short.MinValue".ToInt16());
        testActions.Add(() => "short.MinValue".ToInt16());

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
    public void ToInt16_Null_ArgumentException() => _ = ((string?)null).ToInt16();

    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
    public void ToInt16_OverflowException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable IDE0049 // Simplify Names
        List<Func<Int16>> testActions = new List<Func<Int16>>();
#pragma warning restore IDE0049 // Simplify Names
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => ((long)short.MinValue - 1).ToString().ToInt16());
        testActions.Add(() => ((long)short.MaxValue + 1).ToString().ToInt16());

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

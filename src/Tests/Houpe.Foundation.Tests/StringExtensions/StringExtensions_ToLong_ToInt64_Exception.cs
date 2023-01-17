// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToLong_ToInt64_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToLong_ToInt64_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToInt64_Empty_ArgumentException() => _ = string.Empty.ToInt64();

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
    public void ToInt64_FormatException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable IDE0049 // Simplify Names
        List<Func<Int64>> testActions = new List<Func<Int64>>();
#pragma warning restore IDE0049 // Simplify Names
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => "abcdefg".ToInt64());
        testActions.Add(() => "int".ToInt64());
        testActions.Add(() => "null".ToInt64());
        testActions.Add(() => "1.1".ToInt64());
        testActions.Add(() => "1.9".ToInt64());
        testActions.Add(() => "long.MinValue".ToInt64());
        testActions.Add(() => "long.MinValue".ToInt64());

        testActions.Add(() => ((double)long.MinValue - 1).ToString(CultureInfo.InvariantCulture).ToInt64());
        testActions.Add(() => ((double)long.MaxValue + 1).ToString(CultureInfo.InvariantCulture).ToInt64());

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
    public void ToInt64_Null_ArgumentException() => _ = ((string?)null).ToInt64();

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToLong_Empty_ArgumentException() => _ = string.Empty.ToLong();

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ToLong_FormatException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
        List<Func<long>> testActions = new List<Func<long>>();
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => "abcdefg".ToLong());
        testActions.Add(() => "int".ToLong());
        testActions.Add(() => "null".ToLong());
        testActions.Add(() => "1.1".ToLong());
        testActions.Add(() => "1.9".ToLong());
        testActions.Add(() => "long.MinValue".ToLong());
        testActions.Add(() => "long.MinValue".ToLong());

        testActions.Add(() => ((double)long.MinValue - 1).ToString(CultureInfo.InvariantCulture).ToLong());
        testActions.Add(() => ((double)long.MaxValue + 1).ToString(CultureInfo.InvariantCulture).ToLong());

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
    public void ToLong_Null_ArgumentException() => _ = ((string?)null).ToLong();
}

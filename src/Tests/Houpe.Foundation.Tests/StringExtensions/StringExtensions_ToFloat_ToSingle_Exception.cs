// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToFloat_ToSingle_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToFloat_ToSingle_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToFloat_Empty_ArgumentException() => _ = string.Empty.ToFloat();

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ToFloat_FormatException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
        List<Func<float>> testActions = new List<Func<float>>();
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => "abcdefg".ToFloat());
        testActions.Add(() => "float".ToFloat());
        testActions.Add(() => "null".ToFloat());
        testActions.Add(() => "1.1.1".ToFloat());
        testActions.Add(() => "1.9.9".ToFloat());
        testActions.Add(() => "float.MinValue".ToFloat());
        testActions.Add(() => "float.MinValue".ToFloat());

        testActions.Add(() => "abcdefg".ToFloat());
        testActions.Add(() => "float".ToFloat());
        testActions.Add(() => "null".ToFloat());
        testActions.Add(() => "1.1.1".ToFloat());
        testActions.Add(() => "1.9.9".ToFloat());
        testActions.Add(() => "float.MinValue".ToFloat());
        testActions.Add(() => "float.MinValue".ToFloat());

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
    public void ToFloat_Null_ArgumentException() => _ = ((string?)null).ToFloat();

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToSingle_Empty_ArgumentException() => _ = string.Empty.ToSingle();

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    [SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
    public void ToSingle_FormatException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable IDE0049 // Simplify Names
        List<Func<Single>> testActions = new List<Func<Single>>();
#pragma warning restore IDE0049 // Simplify Names
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => "abcdefg".ToSingle());
        testActions.Add(() => "float".ToSingle());
        testActions.Add(() => "null".ToSingle());
        testActions.Add(() => "1.1.1".ToSingle());
        testActions.Add(() => "1.9.9".ToSingle());
        testActions.Add(() => "float.MinValue".ToSingle());
        testActions.Add(() => "float.MinValue".ToSingle());

        testActions.Add(() => "abcdefg".ToSingle());
        testActions.Add(() => "float".ToSingle());
        testActions.Add(() => "null".ToSingle());
        testActions.Add(() => "1.1.1".ToSingle());
        testActions.Add(() => "1.9.9".ToSingle());
        testActions.Add(() => "float.MinValue".ToSingle());
        testActions.Add(() => "float.MinValue".ToSingle());

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
    public void ToSingle_Null_ArgumentException() => _ = ((string?)null).ToSingle();
}

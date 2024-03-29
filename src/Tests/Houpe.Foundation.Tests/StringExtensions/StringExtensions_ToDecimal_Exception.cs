// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_ToDecimal_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8625

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_ToDecimal_Exception
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToDecimal_Empty_ArgumentException() => _ = string.Empty.ToDecimal();

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void ToDecimal_FormatException()
    {
        // ReSharper disable once UseObjectOrCollectionInitializer
#pragma warning disable IDE0028 // Simplify collection initialization
        List<Func<decimal>> testActions = new List<Func<decimal>>();
#pragma warning restore IDE0028 // Simplify collection initialization

        testActions.Add(() => "abcdefg".ToDecimal());
        testActions.Add(() => "decimal".ToDecimal());
        testActions.Add(() => "null".ToDecimal());
        testActions.Add(() => "1.1.1".ToDecimal());
        testActions.Add(() => "1.9.9".ToDecimal());
        testActions.Add(() => "decimal.MinValue".ToDecimal());
        testActions.Add(() => "decimal.MinValue".ToDecimal());

        testActions.Add(() => "abcdefg".ToDecimal());
        testActions.Add(() => "decimal".ToDecimal());
        testActions.Add(() => "null".ToDecimal());
        testActions.Add(() => "1.1.1".ToDecimal());
        testActions.Add(() => "1.9.9".ToDecimal());
        testActions.Add(() => "decimal.MinValue".ToDecimal());
        testActions.Add(() => "decimal.MinValue".ToDecimal());

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
    public void ToDecimal_Null_ArgumentException() => _ = ((string?)null).ToDecimal();
}

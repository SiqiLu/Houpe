// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ExceptionExtensions_FlattenToAggregateException_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Houpe.Foundation.Tests;

[TestClass]
public class ExceptionExtensions_FlattenToAggregateException_Should
{
    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void FlattenToAggregateException_Should()
    {
        try
        {
            throw new ReflectionTypeLoadException(new[] { "1".GetType(), 1.GetType() },
                new Exception[] { new CannotUnloadAppDomainException("TestMessage1"), new CannotUnloadAppDomainException("TestMessage2") });
        }
        catch (ReflectionTypeLoadException e)
        {
            e.FlattenToAggregateException();
        }
    }
}

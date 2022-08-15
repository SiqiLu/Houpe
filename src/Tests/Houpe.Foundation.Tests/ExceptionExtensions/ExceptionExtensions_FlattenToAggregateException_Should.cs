// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ExceptionExtensions_FlattenToAggregateException_Should.cs
// CreatedAt        : 2022-08-05
// LastModifiedAt   : 2022-08-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
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
}

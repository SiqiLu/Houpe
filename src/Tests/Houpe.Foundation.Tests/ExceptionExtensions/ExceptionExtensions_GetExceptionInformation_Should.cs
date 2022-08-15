// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ExceptionExtensions_GetExceptionInformation_Should.cs
// CreatedAt        : 2021-06-27
// LastModifiedAt   : 2022-08-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class ExceptionExtensions_GetExceptionInformation_Should
    {
        [TestMethod]
        public void GetApplicationExceptionInformation_Should()
        {
            string information;

            try
            {
                throw new ApplicationException("Test Exception");
            }
            catch (Exception e)
            {
                information = e.GetExceptionInformation();
            }

            Assert.IsTrue(information.Contains("Type:"));
            Assert.IsTrue(information.Contains("Message:"));
            Assert.IsTrue(information.Contains("DataJson:"));
            Assert.IsTrue(information.Contains("Stacktrace:"));
        }
    }
}

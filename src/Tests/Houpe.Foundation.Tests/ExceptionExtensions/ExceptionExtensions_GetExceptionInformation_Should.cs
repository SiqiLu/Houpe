// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ExceptionExtensions_GetExceptionInformation_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

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

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsIPAddress_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_IsIPAddress_Should
{
    [TestMethod]
    public void IsIPAddress_False_Should()
    {
        Assert.IsFalse("300.0.0.1".IsIPAddress());
        Assert.IsFalse("172.0.0".IsIPAddress());
        Assert.IsFalse("172.0.0.1.1".IsIPAddress());
        Assert.IsFalse("172.0.-1.1".IsIPAddress());
    }

    [TestMethod]
    public void IsIPAddress_True_Should()
    {
        Assert.IsTrue("172.0.0.1".IsIPAddress());

        Internet i = new Internet();

        100.Times().Do(() =>
        {
            string ipAddress = i.Ip();
            Assert.IsTrue(ipAddress.IsIPAddress(), ipAddress);
        });
    }
}

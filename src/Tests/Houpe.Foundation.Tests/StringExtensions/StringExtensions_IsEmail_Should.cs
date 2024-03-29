// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : StringExtensions_IsEmail_Should.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests;

[TestClass]
public class StringExtensions_IsEmail_Should
{
    [TestMethod]
    public void IsEmail_False_Should()
    {
        Assert.IsFalse("abc_abc.com".IsEmail());
        Assert.IsFalse("abc@abc_com".IsEmail());
        Assert.IsFalse("abc@@abc.com".IsEmail());
    }

    [TestMethod]
    public void IsEmail_True_Should()
    {
        Assert.IsTrue("abc@abc.com".IsEmail());

        Internet i = new Internet();

        100.Times().Do(() =>
        {
            string email = i.Email();
            Assert.IsTrue(email.IsEmail(), email);
        });
    }
}

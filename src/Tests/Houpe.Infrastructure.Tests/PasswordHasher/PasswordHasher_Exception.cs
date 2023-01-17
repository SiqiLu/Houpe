// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : PasswordHasher_Exception.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable CS8625

namespace Houpe.Infrastructure.Tests;

[TestClass]
public class PasswordHasher_Exception
{
    public static readonly string TestData = "12345";

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void PasswordHasher_BadOptions_InvalidOperationException()
    {
        IPasswordHasher hasher = new PasswordHasher(new PasswordHasherOptions { IterationCount = -1 });

        string _ = hasher.HashPassword(TestData);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void PasswordHasher_HashPassword_ArgumentNullException()
    {
        IPasswordHasher hasher = new PasswordHasher();
        string _ = hasher.HashPassword(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void PasswordHasher_VerifyHashedPassword_HashedPassword_ArgumentNullException()
    {
        IPasswordHasher hasher = new PasswordHasher();
        PasswordVerificationResult _ = hasher.VerifyHashedPassword(null, "12345");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void PasswordHasher_VerifyHashedPassword_ProvidedPassword_ArgumentNullException()
    {
        IPasswordHasher hasher = new PasswordHasher();
        PasswordVerificationResult _ = hasher.VerifyHashedPassword("12345", null);
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : PasswordHasher_Exception.cs
// CreatedAt        : 2022-07-24
// LastModifiedAt   : 2022-07-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Infrastructure.Tests
{
    [TestClass]
    public class PasswordHasher_Exception
    {
        public static readonly string TestData = "12345";

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PasswordHasher_BadOptions_InvalidOperationException()
        {
            IPasswordHasher hasher = new PasswordHasher(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions { IterationCount = -1 }));

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
}

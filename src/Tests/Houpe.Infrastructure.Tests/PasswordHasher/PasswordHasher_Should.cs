// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : PasswordHasher_Should.cs
// CreatedAt        : 2021-07-14
// LastModifiedAt   : 2022-07-24
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using Bogus;
using Houpe.Foundation;
using Houpe.Foundation.Dynamic;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Infrastructure.Tests
{
    [TestClass]
    public class PasswordHasher_Should
    {
        [TestMethod]
        public void PasswordHasher_Options_Should()
        {
            PasswordHasherOptions options1 = new PasswordHasherOptions();
            PasswordHasherOptions options2 = new PasswordHasherOptions();

            options2.IterationCount = 10000;
            options2.AsDynamic().Rng = options1.AsDynamic().Rng;

            IPasswordHasher hasher1 = new PasswordHasher(new OptionsWrapper<PasswordHasherOptions>(options1));
            IPasswordHasher hasher2 = new PasswordHasher(new OptionsWrapper<PasswordHasherOptions>(options2));
            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                string password = r.Utf16String(6, 100);
                string hashedPassword = hasher1.HashPassword(password);
                PasswordVerificationResult result = hasher2.VerifyHashedPassword(hashedPassword, password);

                Assert.AreEqual(PasswordVerificationResult.Success, result);
            });
        }

        [TestMethod]
        public void PasswordHasher_HashPassword_Should()
        {
            IPasswordHasher hasher = new PasswordHasher();
            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                string password = r.Utf16String(6, 100);
                string hashedPassword = hasher.HashPassword(password);
                PasswordVerificationResult result = hasher.VerifyHashedPassword(hashedPassword, password);

                Assert.AreEqual(PasswordVerificationResult.Success, result);
            });
        }

        [TestMethod]
        public void PasswordHasher_VerifyHashedPassword_Should()
        {
            IPasswordHasher hasher = new PasswordHasher();

            Assert.AreEqual(PasswordVerificationResult.Failed, hasher.VerifyHashedPassword("", ""));
            Assert.AreEqual(PasswordVerificationResult.Failed, hasher.VerifyHashedPassword("", "12345"));
            Assert.AreEqual(PasswordVerificationResult.Failed, hasher.VerifyHashedPassword(hasher.HashPassword("12345"), ""));
            Assert.AreEqual(PasswordVerificationResult.Failed, hasher.VerifyHashedPassword(hasher.HashPassword("123"), "45"));
        }

        [TestMethod]
        public void PasswordHasher_VerifyHashedPassword_DifferentIterationCount_Should()
        {
            PasswordHasherOptions options1 = new PasswordHasherOptions { IterationCount = 1000 };
            PasswordHasherOptions options2 = new PasswordHasherOptions { IterationCount = 1 };
            PasswordHasherOptions options3 = new PasswordHasherOptions { IterationCount = 100000 };

            options2.AsDynamic().Rng = options1.AsDynamic().Rng;
            options3.AsDynamic().Rng = options1.AsDynamic().Rng;

            IPasswordHasher hasher1 = new PasswordHasher(new OptionsWrapper<PasswordHasherOptions>(options1));
            IPasswordHasher hasher2 = new PasswordHasher(new OptionsWrapper<PasswordHasherOptions>(options2));
            IPasswordHasher hasher3 = new PasswordHasher(new OptionsWrapper<PasswordHasherOptions>(options3));

            Randomizer r = new Randomizer();

            100.Times().Do(() =>
            {
                string password = r.Utf16String(6, 100);
                string hashedPassword = hasher1.HashPassword(password);
                PasswordVerificationResult result1 = hasher1.VerifyHashedPassword(hashedPassword, password);
                PasswordVerificationResult result2 = hasher2.VerifyHashedPassword(hashedPassword, password);
                PasswordVerificationResult result3 = hasher3.VerifyHashedPassword(hashedPassword, password);

                Assert.AreEqual(PasswordVerificationResult.Success, result1);
                Assert.AreEqual(PasswordVerificationResult.Success, result2); // 创建使用更高的 IterationCount，较低的 IterationCount PasswordHasher 直接验证成功，而不提示需要降低 IterationCount
                Assert.AreEqual(PasswordVerificationResult.SuccessRehashNeeded, result3); // 创建使用较低的 IterationCount，更高的 IterationCount PasswordHasher 可以通过验证，并且提示需要提高 IterationCount
            });
        }
    }
}

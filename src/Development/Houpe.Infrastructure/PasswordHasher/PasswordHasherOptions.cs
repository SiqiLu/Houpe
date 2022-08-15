// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure
// File             : PasswordHasherOptions.cs
// CreatedAt        : 2021-07-14
// LastModifiedAt   : 2021-07-14
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Security.Cryptography;

namespace Houpe.Infrastructure
{
    /// <summary>
    ///     Specifies options for password hashing.
    /// </summary>
    public class PasswordHasherOptions
    {
        private static readonly RandomNumberGenerator s_defaultRng = RandomNumberGenerator.Create(); // secure PRNG

        /// <summary>
        ///     Gets or sets the number of iterations used when hashing passwords using PBKDF2.
        /// </summary>
        /// <value>
        ///     The number of iterations used when hashing passwords using PBKDF2.
        /// </value>
        /// <remarks>
        ///     This value is only used when the compatibility mode is set to 'V3'.
        ///     The value must be a positive integer. The default value is 10,000.
        /// </remarks>
        public int IterationCount { get; set; } = 10000;

        // for unit testing
        internal RandomNumberGenerator Rng { get; set; } = s_defaultRng;
    }
}

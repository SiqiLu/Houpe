// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : PasswordVerificationResult.cs
// CreatedAt        : 2023-01-14
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

namespace Houpe.Infrastructure;

/// <summary>
///     Specifies the results for password verification.
/// </summary>
public enum PasswordVerificationResult
{
    /// <summary>
    ///     Indicates password verification unsuccessfully.
    /// </summary>
    Failed = 0,

    /// <summary>
    ///     Indicates password verification was successful.
    /// </summary>
    Success = 1,

    /// <summary>
    ///     Indicates password verification was successful however the password was encoded using a deprecated algorithm
    ///     and should be rehashed and updated.
    /// </summary>
    SuccessRehashNeeded = 2
}

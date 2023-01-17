// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : HashExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Houpe.Foundation;

/// <summary>
///     针对 <see cref="System.String" /> 关于 <see cref="System.Security.Cryptography.HashAlgorithm" /> 的扩展方法。
/// </summary>
[SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
public static class HashExtensions
{
    private static readonly byte[] s_hmacKey = "Houpe.Foundation.HMACKey".EncodeToBytesByUTF8();

    /// <summary>
    ///     使用 <see cref="System.Security.Cryptography.HMACMD5" /> 算法计算指定字符串的哈希值。
    /// </summary>
    /// <param name="s">指定字符串。</param>
    /// <returns>指定字符串的哈希值。</returns>
    public static string GetHMACMD5Hash(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        HMACMD5 md5 = new HMACMD5(s_hmacKey);
        byte[] hashBytes = md5.ComputeHash(s.EncodeToBytesByUTF8());
        return hashBytes.ToPrintableString();
    }

    /// <summary>
    ///     使用 <see cref="System.Security.Cryptography.HMACSHA256" /> 算法计算指定字符串的哈希值。
    /// </summary>
    /// <param name="s">指定字符串。</param>
    /// <returns>指定字符串的哈希值。</returns>
    public static string GetHMACSHA256Hash(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        HMACSHA256 sha256 = new HMACSHA256(s_hmacKey);
        byte[] hashBytes = sha256.ComputeHash(s.EncodeToBytesByUTF8());
        return hashBytes.ToPrintableString();
    }

    /// <summary>
    ///     使用 <see cref="System.Security.Cryptography.HMACSHA512" /> 算法计算指定字符串的哈希值。
    /// </summary>
    /// <param name="s">指定字符串。</param>
    /// <returns>指定字符串的哈希值。</returns>
    public static string GetHMACSHA512Hash(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        HMACSHA512 sha512 = new HMACSHA512(s_hmacKey);
        byte[] hashBytes = sha512.ComputeHash(s.EncodeToBytesByUTF8());
        return hashBytes.ToPrintableString();
    }

    /// <summary>
    ///     使用 <see cref="System.Security.Cryptography.MD5" /> 算法计算指定字符串的哈希值。
    /// </summary>
    /// <param name="s">指定字符串。</param>
    /// <returns>指定字符串的哈希值。</returns>
    public static string GetMD5Hash(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] hashBytes = MD5.HashData(s.EncodeToBytesByUTF8());
        return hashBytes.ToPrintableString();
    }

    /// <summary>
    ///     使用 <see cref="System.Security.Cryptography.SHA256" /> 算法计算指定字符串的哈希值。
    /// </summary>
    /// <param name="s">指定字符串。</param>
    /// <returns>指定字符串的哈希值。</returns>
    public static string GetSHA256Hash(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] hashBytes = SHA256.HashData(s.EncodeToBytesByUTF8());
        return hashBytes.ToPrintableString();
    }

    /// <summary>
    ///     使用 <see cref="System.Security.Cryptography.SHA512" /> 算法计算指定字符串的哈希值。
    /// </summary>
    /// <param name="s">指定字符串。</param>
    /// <returns>指定字符串的哈希值。</returns>
    public static string GetSHA512Hash(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] hashBytes = SHA512.HashData(s.EncodeToBytesByUTF8());
        return hashBytes.ToPrintableString();
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ASCIIExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Houpe.Foundation;

/// <summary>
///     针对 <see cref="System.String" /> 和 <see cref="System.Byte" /> 关于 <see cref="System.Text.Encoding.ASCII" /> 的扩展方法。
/// </summary>
[SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
public static class ASCIIExtensions
{
    /// <summary>
    ///     使用 <see cref="System.Text.Encoding.ASCII" /> 将指定字节数组中的所有字节解码为一个字符串。
    /// </summary>
    /// <param name="bytes">包含要解码的字节序列的字节数组。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="T:System.ArgumentException">字节数组中包含无效的 ASCII 码位。</exception>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="bytes" /> 为 null。
    /// </exception>
    /// <exception cref="T:System.Text.DecoderFallbackException">发生回退（请参见.NET Framework 中的字符编码以获得完整的解释）－和－<see cref="P:System.Text.Encoding.DecoderFallback" /> 设置为 <see cref="T:System.Text.DecoderExceptionFallback" />。</exception>
    public static string DecodeToStringByASCII(this byte[] bytes)
    {
        ArgumentNullException.ThrowIfNull(bytes);

        return Encoding.ASCII.GetString(bytes.FixBom());
    }

    /// <summary>
    ///     使用 <see cref="System.Text.Encoding.ASCII" /> 将指定字符串中的所有字符编码为一个字节序列。
    /// </summary>
    /// <param name="s">包含要编码的字符的字符串。</param>
    /// <returns>包含对指定的字符集进行编码结果的 <see cref="T:System.Byte[]" />。</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
    /// <exception cref="T:System.Text.DecoderFallbackException">
    ///     发生回退（请参见.NET Framework 中的字符编码以获得完整的解释）－和－
    ///     <see
    ///         cref="P:System.Text.Encoding.DecoderFallback" />
    ///     设置为 <see cref="T:System.Text.DecoderExceptionFallback" />。
    /// </exception>
    public static byte[] EncodeToBytesByASCII(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        return Encoding.ASCII.GetBytes(s);
    }
}

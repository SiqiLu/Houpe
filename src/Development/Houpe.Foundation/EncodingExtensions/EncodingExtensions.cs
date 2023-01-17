// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : EncodingExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Houpe.Foundation;

/// <summary>
///     针对 <see cref="System.String" /> 和 <see cref="System.Byte" /> 关于 <see cref="System.Text.Encoding" /> 的扩展方法。
/// </summary>
[SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
public static class EncodingExtensions
{
    /// <summary>
    ///     使用指定的编码将指定字节数组中的所有字节解码为一个字符串。
    /// </summary>
    /// <param name="bytes">包含要解码的字节序列的字节数组。</param>
    /// <param name="encodingName">指定编码的代码页名称。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="T:System.ArgumentException">字节数组中包含无效的 UTF8 码位。</exception>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="bytes" /> 为 null。
    /// </exception>
    /// <exception cref="System.ArgumentException">
    ///     <paramref name="encodingName" /> 不是有效的代码页名称。
    /// </exception>
    /// <exception cref="T:System.Text.DecoderFallbackException">发生回退（请参见.NET Framework 中的字符编码以获得完整的解释）－和－<see cref="P:System.Text.Encoding.DecoderFallback" /> 设置为 <see cref="T:System.Text.DecoderExceptionFallback" />。</exception>
    public static string DecodeToStringByTheEncoding(this byte[] bytes, string encodingName)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        ArgumentException.ThrowIfNullOrEmpty(encodingName);

        return Encoding.GetEncoding(encodingName).GetString(bytes.FixBom());
    }

    /// <summary>
    ///     使用指定的编码将指定字符串中的所有字符编码为一个字节序列。
    /// </summary>
    /// <param name="s">包含要编码的字符的字符串。</param>
    /// <param name="encodingName">
    ///     指定编码的代码页名称。
    ///     <see
    ///         href="https://msdn.microsoft.com/zh-cn/library/system.text.encoding.webname(v=vs.110).aspx">
    ///         WebName
    ///     </see>
    ///     属性返回的值是有效的。可能的值都在
    ///     <see
    ///         href="https://msdn.microsoft.com/zh-cn/library/system.text.encoding(v=vs.110).aspx">
    ///         Encoding
    ///     </see>
    ///     类主题中出现的表的“名称”一列中列了出来。
    /// </param>
    /// <returns>包含对指定的字符集进行编码结果的 <see cref="T:System.Byte[]" />。</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="encodingName" /> 不是有效的代码页名称。
    /// </exception>
    /// <exception cref="T:System.Text.DecoderFallbackException">
    ///     发生回退（请参见.NET Framework 中的字符编码以获得完整的解释）－和－
    ///     <see
    ///         cref="P:System.Text.Encoding.DecoderFallback" />
    ///     设置为 <see cref="T:System.Text.DecoderExceptionFallback" />。
    /// </exception>
    public static byte[] EncodeToBytesByTheEncoding(this string s, string encodingName)
    {
        ArgumentNullException.ThrowIfNull(s);
        ArgumentException.ThrowIfNullOrEmpty(encodingName);

        Encoding encoding = Encoding.GetEncoding(encodingName);
        return encoding.GetBytes(s);
    }
}

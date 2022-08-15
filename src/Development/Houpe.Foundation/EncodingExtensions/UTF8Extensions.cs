// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : UTF8Extensions.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Houpe.Foundation
{
    /// <summary>
    ///     针对 <see cref="System.String" /> 和 <see cref="System.Byte"/> 关于 <see cref="System.Text.Encoding.UTF8"/> 的扩展方法。
    /// </summary>
    [SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
    public static class UTF8Extensions
    {
        /// <summary>
        ///     使用 <see cref="System.Text.Encoding.UTF8" /> 将指定字符串中的所有字符编码为一个字节序列。
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
        public static byte[] EncodeToBytesByUTF8(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        ///     使用 <see cref="System.Text.Encoding.UTF8" /> 将指定字节数组中的所有字节解码为一个字符串。
        /// </summary>
        /// <param name="bytes">包含要解码的字节序列的字节数组。</param>
        /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
        /// <exception cref="T:System.ArgumentException">字节数组中包含无效的 UTF8 码位。</exception>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="bytes" /> 为 null。
        /// </exception>
        /// <exception cref="T:System.Text.DecoderFallbackException">发生回退（请参见.NET Framework 中的字符编码以获得完整的解释）－和－<see cref="P:System.Text.Encoding.DecoderFallback" /> 设置为 <see cref="T:System.Text.DecoderExceptionFallback" />。</exception>
        public static string DecodeToStringByUTF8(this byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes), Resource.ArgumentNull_Array);
            }

            return Encoding.UTF8.GetString(bytes.FixBom());
        }
    }
}

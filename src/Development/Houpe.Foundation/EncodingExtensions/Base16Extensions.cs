// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Base16Extensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Houpe.Foundation;

/// <summary>
///     针对 <see cref="System.String" /> 和 <see cref="System.Byte" /> 关于 Base16 Encoding 的扩展方法。
/// </summary>
/// <remarks>
///     Base16编码使用16个ASCII可打印字符（数字0-9和字母A-F）对任意字节数据进行编码。
///     Base16先获取输入字符串每个字节的二进制值（不足8比特在高位补0），然后将其串联进来，
///     再按照4比特一组进行切分，将每组二进制数分别转换成十进制。
///     可以看到8比特数据按照4比特切分刚好是两组，所以Base16不可能用到填充符号“=”。
///     Base16编码后的数据量是原数据的两倍：1000比特数据需要250个字符（即 250*8=2000 比特）。
///     换句话说：Base16使用两个ASCII字符去编码原数据中的一个字节数据。
///     Base16编码是一个标准的十六进制字符串（注意是字符串而不是数值），更易被人类和计算机使用，
///     因为它并不包含任何控制字符，以及Base64和Base32中的“=”符号。
///     输入的非ASCII字符，使用UTF-8字符集。
/// </remarks>
[SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
public static class Base16Extensions
{
    /// <summary>
    ///     使用 Base16 算法将指定字符串中的所有字节解码为一个字节数组。
    /// </summary>
    /// <param name="s">包含要解码的字符的字符串。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="T:System.Byte[]" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="s" /> 为 null。
    /// </exception>
    public static byte[] DecodeToBytesByBase16(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        s = s.Replace("-", "").Replace(" ", "");
        byte[] raw = new byte[s.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);
        }

        return raw;
    }

    /// <summary>
    ///     使用 Base16 算法将指定字符串中的所有字符解码为一个字符串。
    /// </summary>
    /// <param name="s">包含要解码的字符的字符串。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="s" /> 为 null。
    /// </exception>
    public static string DecodeToStringByBase16(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] bytes = s.DecodeToBytesByBase16();
        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    ///     使用 Base16 算法将指定字节数组中的所有字节解码为一个字符串。
    /// </summary>
    /// <param name="bytes">包含要编码的字节序列的字节数组。</param>
    /// <returns>包含指定字节序列编码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="bytes" /> 为 null。
    /// </exception>
    public static string EncodeToStringByBase16(this byte[] bytes)
    {
        ArgumentNullException.ThrowIfNull(bytes);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            _ = sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
    }

    /// <summary>
    ///     使用 Base16 算法将指定字符串中的所有字符编码为一个BASE16字符串。
    /// </summary>
    /// <param name="s">包含要编码的字符的字符串。</param>
    /// <returns>包含指定字节序列编码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="s" /> 为 null。
    /// </exception>
    public static string EncodeToStringByBase16(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] bytes = Encoding.UTF8.GetBytes(s);

        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            _ = sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
    }
}

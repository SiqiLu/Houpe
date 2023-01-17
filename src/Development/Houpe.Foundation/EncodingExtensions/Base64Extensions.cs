// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Base64Extensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Houpe.Foundation;

/// <summary>
///     针对 <see cref="System.String" /> 和 <see cref="System.Byte" /> 关于 Base64 Encoding 的扩展方法。
/// </summary>
/// <remarks>
///     Base64编码是使用64个可打印ASCII字符（A-Z、a-z、0-9、+、/）将任意字节序列数据编码成ASCII字符串，另有“=”符号用作后缀用途。
///     Base64将输入字符串按字节切分，取得每个字节对应的二进制值（若不足8比特则高位补0），然后将这些二进制数值串联起来，
///     再按照6比特一组进行切分（因为2^6=64），最后一组若不足6比特则末尾补0。将每组二进制值转换成十进制，
///     然后在上述表格中找到对应的符号并串联起来就是Base64编码结果。
///     由于二进制数据是按照8比特一组进行传输，因此Base64按照6比特一组切分的二进制数据必须是24比特的倍数（6和8的最小公倍数）。
///     24比特就是3个字节，若原字节序列数据长度不是3的倍数时且剩下1个输入数据，则在编码结果后加2个=；若剩下2个输入数据，
///     则在编码结果后加1个=。
///     完整的Base64定义可见RFC1421和RFC2045。因为Base64算法是将3个字节原数据编码为4个字节新数据，
///     所以Base64编码后的数据比原始数据略长，为原来的4/3。在电子邮件中，根据RFC822规定，每76个字符，还需要加上一个回车换行。
///     可以估算编码后数据长度大约为原长的135.1%。
///     Base64可用于任意数据的底层二进制数据编码，以应用于只能传输ASCII字符的场合。
///     不过最常用于文本数据的处理传输，例如在MIME格式的电子邮件中，Base64可以用来编码邮件内容，
///     方便在不同语言计算机间传输而不乱码，注意是传输而不是显示，
///     例如在西欧地区计算机上使用utf-8编码即可正常显示中文（安装有对应字库），但是它未必能正常传输中文，
///     这时转换为Base64便无此顾虑。
///     Base64编码若无特别说明，通常约定非ASCII字符按照UTF-8字符集进行编码处理。
/// </remarks>
[SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
public static class Base64Extensions
{
    /// <summary>
    ///     使用 Base64 算法将指定字符串中的所有字节解码为一个字节数组。
    /// </summary>
    /// <param name="s">包含要解码的字符的字符串。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="T:System.Byte[]" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="s" /> 为 null。
    /// </exception>
    public static byte[] DecodeToBytesByBase64(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        return Convert.FromBase64String(s);
    }

    /// <summary>
    ///     使用 Base64 算法将指定字符串中的所有字符解码为一个字符串。
    /// </summary>
    /// <param name="s">包含要解码的字符的字符串。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="s" /> 为 null。
    /// </exception>
    public static string DecodeToStringByBase64(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] bytes = s.DecodeToBytesByBase64();
        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    ///     使用 Base32 算法将指定字节数组中的所有字节解码为一个字符串。
    /// </summary>
    /// <param name="bytes">包含要编码的字节序列的字节数组。</param>
    /// <returns>包含指定字节序列编码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="bytes" /> 为 null。
    /// </exception>
    public static string EncodeToStringByBase64(this byte[] bytes)
    {
        ArgumentNullException.ThrowIfNull(bytes);

        return Convert.ToBase64String(bytes.FixBom());
    }

    /// <summary>
    ///     使用 Base64 算法将指定字符串中的所有字符编码为一个BASE16字符串。
    /// </summary>
    /// <param name="s">包含要编码的字符的字符串。</param>
    /// <returns>包含指定字节序列编码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="s" /> 为 null。
    /// </exception>
    public static string EncodeToStringByBase64(this string s)
    {
        ArgumentNullException.ThrowIfNull(s);

        byte[] bytes = Encoding.UTF8.GetBytes(s);

        return bytes.EncodeToStringByBase64();
    }
}

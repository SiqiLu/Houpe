// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ByteExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;

namespace Houpe.Foundation;

/// <summary>
///     <see cref="System.Byte" /> 的扩展类。
/// </summary>
[SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
public static class ByteExtensions
{
    /// <summary>
    ///     使用十六进制将指定字节数组中的所有字节解码为一个字符串。
    /// </summary>
    /// <param name="bytes">包含要解码的字节序列的字节数组。</param>
    /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="bytes" /> 为 null。
    /// </exception>
    public static string ToPrintableString(this byte[] bytes)
    {
        ArgumentNullException.ThrowIfNull(bytes);

        return bytes.EncodeToStringByBase16().ToUpperInvariant();
    }

    [ExcludeFromCodeCoverage]
    internal static byte[] FixBom(this byte[] valueToFix)
    {
        //see BOM - Byte Order Mark : http://en.wikipedia.org/wiki/Byte_order_mark
        //    http://www.verious.com/qa/-239-187-191-characters-appended-to-the-beginning-of-each-file/
        //    http://social.msdn.microsoft.com/Forums/en-US/8956758d-9814-4bd4-9812-e82903640b2f/recieving-239187191-character-symbols-when-loading-text-files-not-containing-them
        if (valueToFix.Length > 3 && valueToFix[0] == '\xEF' && valueToFix[1] == '\xBB' && valueToFix[2] == '\xBF')
        {
            int size = valueToFix.Length - 3;
            byte[] value = new byte[size];
            Array.Copy(valueToFix, 3, value, 0, size);
            return value;
        }

        return valueToFix;
    }
}

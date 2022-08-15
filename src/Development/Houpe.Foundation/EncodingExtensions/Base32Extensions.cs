// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Base32Extensions.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2022-08-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Houpe.Foundation
{
    /// <summary>
    ///     针对 <see cref="System.String" /> 和 <see cref="System.Byte"/> 关于 Base32 Encoding 的扩展方法。
    /// </summary>
    /// <remarks>
    /// Base32编码是使用32个可打印字符（字母A-Z和数字2-7）对任意字节数据进行编码的方案，
    /// 编码后的字符串不用区分大小写并排除了容易混淆的字符，可以方便地由人类使用并由计算机处理。
    /// Base32将任意字符串按照字节进行切分，并将每个字节对应的二进制值（不足8比特高位补0）串联起来，按照5比特一组进行切分，并将每组二进制值转换成十进制来对应32个可打印字符中的一个。
    /// 
    /// 由于数据的二进制传输是按照8比特一组进行（即一个字节），因此Base32按5比特切分的二进制数据必须是40比特的倍数（5和8的最小公倍数）。例如输入单字节字符“%”，它对应的二进制值是“100101”，前面补两个0变成“00100101”（二进制值不足8比特的都要在高位加0直到8比特），从左侧开始按照5比特切分成两组：“00100”和“101”，后一组不足5比特，则在末尾填充0直到5比特，变成“00100”和“10100”，这两组二进制数分别转换成十进制数，通过上述表格即可找到其对应的可打印字符“E”和“U”，但是这里只用到两组共10比特，还差30比特达到40比特，按照5比特一组还需6组，则在末尾填充6个“=”。填充“=”符号的作用是方便一些程序的标准化运行，大多数情况下不添加也无关紧要，而且，在URL中使用时必须去掉“=”符号。
    /// 
    /// 与Base64相比，Base32具有许多优点：
    /// 适合不区分大小写的文件系统，更利于人类口语交流或记忆。
    /// 结果可以用作文件名，因为它不包含路径分隔符 “/”等符号。
    /// 排除了视觉上容易混淆的字符，因此可以准确的人工录入。（例如，RFC4648符号集忽略了数字“1”、“8”和“0”，因为它们可能与字母“I”，“B”和“O”混淆）。
    /// 排除填充符号“=”的结果可以包含在URL中，而不编码任何字符。
    /// 
    /// Base32也比Base16有优势：
    /// Base32比Base16占用的空间更小。（1000比特数据Base32需要200个字符，而Base16则为250个字符）
    /// 
    /// Base32的缺点：
    /// 
    /// Base32比Base64多占用大约20％的空间。因为Base32使用8个ASCII字符去编码原数据中的5个字节数据，而Base64是使用4个ASCII字符去编码原数据中的3个字节数据。
    /// 本页Base32编码方案符合RFC4648文档描述。输入字符集为UTF-8编码。
    /// </remarks>
    [SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
    public static class Base32Extensions
    {
        private const int Mask = 31;
        private const int Shift = 5;
        private static readonly char[] s_digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".ToCharArray();

        /// <summary>
        ///     使用 Base32 算法将指定字节数组中的所有字节解码为一个字符串。
        /// </summary>
        /// <param name="bytes">包含要编码的字节序列的字节数组。</param>
        /// <returns>包含指定字节序列编码结果的 <see cref="System.String" />。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="bytes" /> 为 null。
        /// </exception>
        public static string EncodeToStringByBase32(this byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes), Resource.ArgumentNull_Array);
            }

            return ToBase32String(bytes);
        }

        /// <summary>
        ///     使用 Base32 算法将指定字符串中的所有字符编码为一个BASE16字符串。
        /// </summary>
        /// <param name="s">包含要编码的字符的字符串。</param>
        /// <returns>包含指定字节序列编码结果的 <see cref="System.String" />。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="s" /> 为 null。
        /// </exception>
        public static string EncodeToStringByBase32(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            byte[] bytes = Encoding.UTF8.GetBytes(s);

            return ToBase32String(bytes);
        }

        /// <summary>
        ///     使用 Base32 算法将指定字符串中的所有字节解码为一个字节数组。
        /// </summary>
        /// <param name="s">包含要解码的字符的字符串。</param>
        /// <returns>包含指定字节序列解码结果的 <see cref="T:System.Byte[]" />。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="s" /> 为 null。
        /// </exception>
        public static byte[] DecodeToBytesByBase32(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s), Resource.ArgumentNull_Array);
            }

            return FromBase32String(s);
        }

        /// <summary>
        ///     使用 Base32 算法将指定字符串中的所有字符解码为一个字符串。
        /// </summary>
        /// <param name="s">包含要解码的字符的字符串。</param>
        /// <returns>包含指定字节序列解码结果的 <see cref="System.String" />。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="s" /> 为 null。
        /// </exception>
        public static string DecodeToStringByBase32(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            byte[] bytes = s.DecodeToBytesByBase32();
            return Encoding.UTF8.GetString(bytes);
        }

        [ExcludeFromCodeCoverage]
        private static byte[] FromBase32String(string encoded)
        {
            if (encoded == null)
            {
                throw new ArgumentNullException(nameof(encoded));
            }

            // Remove whitespace and padding. Note: the padding is used as hint
            // to determine how many bits to decode from the last incomplete chunk
            // Also, canonicalize to all upper case
            encoded = encoded.Trim().TrimEnd('=').ToUpper();
            if (encoded.Length == 0)
            {
                return new byte[0];
            }

            int outLength = encoded.Length * Shift / 8;
            byte[] result = new byte[outLength];
            int buffer = 0;
            int next = 0;
            int bitsLeft = 0;
            foreach (char c in encoded)
            {
                int charValue = CharToInt(c);
                if (charValue < 0)
                {
                    throw new FormatException("Illegal character: `" + c + "`");
                }

                buffer <<= Shift;
                buffer |= charValue & Mask;
                bitsLeft += Shift;
                if (bitsLeft >= 8)
                {
                    result[next++] = (byte)(buffer >> (bitsLeft - 8));
                    bitsLeft -= 8;
                }
            }

            return result;
        }

        private static string ToBase32String(byte[] data, bool padOutput = true) => ToBase32String(data, 0, data.Length, padOutput);

        [ExcludeFromCodeCoverage]
        private static string ToBase32String(byte[] data, int offset, int length, bool padOutput = true)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (offset + length > data.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (length == 0)
            {
                return "";
            }

            // SHIFT is the number of bits per output character, so the length of the
            // output is the length of the input multiplied by 8/SHIFT, rounded up.
            // The computation below will fail, so don't do it.
            if (length >= 1 << 28)
            {
                throw new ArgumentOutOfRangeException(nameof(data));
            }

            int outputLength = ((length * 8) + Shift - 1) / Shift;
            StringBuilder result = new StringBuilder(outputLength);

            int last = offset + length;
            int buffer = data[offset++];
            int bitsLeft = 8;
            while (bitsLeft > 0 || offset < last)
            {
                if (bitsLeft < Shift)
                {
                    if (offset < last)
                    {
                        buffer <<= 8;
                        buffer |= data[offset++] & 0xff;
                        bitsLeft += 8;
                    }
                    else
                    {
                        int pad = Shift - bitsLeft;
                        buffer <<= pad;
                        bitsLeft += pad;
                    }
                }

                int index = Mask & (buffer >> (bitsLeft - Shift));
                bitsLeft -= Shift;
                _ = result.Append(s_digits[index]);
            }

            if (padOutput)
            {
                int padding = 8 - (result.Length % 8);
                if (padding > 0)
                {
                    _ = result.Append('=', padding == 8 ? 0 : padding);
                }
            }

            return result.ToString();
        }

        [ExcludeFromCodeCoverage]
        private static int CharToInt(char c) =>
            c switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                'D' => 3,
                'E' => 4,
                'F' => 5,
                'G' => 6,
                'H' => 7,
                'I' => 8,
                'J' => 9,
                'K' => 10,
                'L' => 11,
                'M' => 12,
                'N' => 13,
                'O' => 14,
                'P' => 15,
                'Q' => 16,
                'R' => 17,
                'S' => 18,
                'T' => 19,
                'U' => 20,
                'V' => 21,
                'W' => 22,
                'X' => 23,
                'Y' => 24,
                'Z' => 25,
                '2' => 26,
                '3' => 27,
                '4' => 28,
                '5' => 29,
                '6' => 30,
                '7' => 31,
                _ => -1
            };
    }
}

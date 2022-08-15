// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : IDGenerator.cs
// CreatedAt        : 2021-07-13
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Linq;

namespace Houpe.Foundation
{
    /// <summary>
    ///     可以用于生成标识值。
    /// </summary>
    public static class IDGenerator
    {
        /// <summary>
        ///     使用两个 <see cref="ulong" /> 生成 <see cref="System.Guid" />。
        /// </summary>
        public static Guid BuildGuid(ulong a, ulong b) => new Guid((uint)(a & 0xffffffff),
            (ushort)(a >> 32),
            (ushort)(a >> 48),
            (byte)b,
            (byte)(b >> 8),
            (byte)(b >> 16),
            (byte)(b >> 24),
            (byte)(b >> 32),
            (byte)(b >> 40),
            (byte)(b >> 48),
            (byte)(b >> 56));

        /// <summary>
        ///     使用 <see cref="string" /> 生成 <see cref="System.Guid" />。
        /// </summary>
        public static Guid BuildGuid(string input)
        {
            ulong a = (ulong)Math.Abs(input.GetHashCode());
            ulong b = (ulong)Math.Abs(input.GetMD5Hash().GetHashCode());
            return BuildGuid(a, b);
        }

        /// <summary>
        ///     基于Guid生成一个 16 个字符长度的随机字符串，碰撞概率非常低。
        /// </summary>
        /// <example>3C4EBC5F5F2C4EDC</example>
        /// <remarks>Author Mads Kristensen http://madskristensen.net/post/Generate-unique-strings-and-numbers-in-C.aspx</remarks>
        /// <returns>类似 "3C4EBC5F5F2C4EDC" 的随机字符串。</returns>
        public static string GuidShortCode()
        {
            static string BuildRandomString()
            {
                long i = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current * (b + 1));
                return $"{i - DateTime.Now.Ticks:x}".ToUpperInvariant();
            }

            string s = BuildRandomString();

            while (s.Length < 16)
            {
                s += BuildRandomString();
            }

            return s.GetFirst(16);
        }

        /// <summary>
        ///     根据 SQL Server 的排序规则生成的有时序的 Guid，先生成的 Guid 的排序一定靠前。
        /// </summary>
        public static Guid NewSequentialGuid()
        {
            // This code was not reviewed to guarantee uniqueness under most conditions, nor
            // completely optimize for avoiding page splits in SQL Server when doing inserts from
            // multiple hosts, so do not re-use in production systems.
            byte[] guidBytes = Guid.NewGuid().ToByteArray();

            // get the milliseconds since Jan 1 1970
            byte[] sequential = BitConverter.GetBytes((DateTime.Now.Ticks / 10000L) - Constants.EpochMilliseconds);

            // discard the 2 most significant bytes, as we only care about the milliseconds
            // increasing, but the highest ones should be 0 for several thousand years to come (non-issue).
            if (BitConverter.IsLittleEndian)
            {
                guidBytes[10] = sequential[5];
                guidBytes[11] = sequential[4];
                guidBytes[12] = sequential[3];
                guidBytes[13] = sequential[2];
                guidBytes[14] = sequential[1];
                guidBytes[15] = sequential[0];
            }
            else
            {
                Buffer.BlockCopy(sequential, 2, guidBytes, 10, 6);
            }

            return new Guid(guidBytes);
        }

        /// <summary>
        ///     根据当前的UTC时间生成ID。
        /// </summary>
        /// <param name="format">
        ///     生成ID时根据的时间精度。可以为 "s", "ms" "t" 中的任意一个，如果不是这些值，会默认使用 "t" 作为精度。
        ///     "d" 表示生成ID时时间的精度只到天；
        ///     "h" 表示生成ID时时间的精度只到小时；
        ///     "m" 表示生成ID时时间的精度只到分钟；
        ///     "s" 表示生成ID时时间的精度只到秒；
        ///     "ms" 表示生成ID时时间的精度到豪秒；
        ///     "t" 表示生成ID时时间的精度到 Tick。
        /// </param>
        /// <returns>随机字符串。</returns>
        public static string NewSequentialId(string format = "t")
        {
            DateTime t = DateTime.UtcNow;

            return format switch
            {
                "d" => t.ToString("yyyyMMdd"),
                "h" => t.ToString("yyyyMMddHH"),
                "m" => t.ToString("yyyyMMddHHmm"),
                "s" => t.ToString("yyyyMMddHHmmss"),
                "ms" => t.ToString("yyyyMMddHHmmssfff"),
                _ => t.ToString("yyyyMMddHHmmssfffffff"),
            };
        }
    }
}

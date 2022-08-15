// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure
// File             : IIDGeneratorService.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Houpe.Foundation;

namespace Houpe.Infrastructure
{
    /// <summary>
    ///     IIDGeneratorService
    /// </summary>
    public interface IIDGeneratorService
    {
        /// <summary>
        ///     使用两个 <see cref="ulong" /> 生成 <see cref="System.Guid" />。
        /// </summary>
        public Guid BuildGuid(ulong a, ulong b) => IDGenerator.BuildGuid(a, b);

        /// <summary>
        ///     使用 <see cref="string" /> 生成 <see cref="System.Guid" />。
        /// </summary>
        public Guid BuildGuid(string input) => IDGenerator.BuildGuid(input);

        /// <summary>
        ///     基于Guid生成一个 16 个字符长度的随机字符串，碰撞概率非常低。
        /// </summary>
        /// <example>3C4EBC5F5F2C4EDC</example>
        /// <remarks>Author Mads Kristensen http://madskristensen.net/post/Generate-unique-strings-and-numbers-in-C.aspx</remarks>
        /// <returns>类似 "3C4EBC5F5F2C4EDC" 的随机字符串。</returns>
        public string GuidShortCode() => IDGenerator.GuidShortCode();

        /// <summary>
        ///     根据 SQL Server 的排序规则生成的有时序的 Guid，先生成的 Guid 的排序一定靠前。
        /// </summary>
        public Guid NewSequentialGuid() => IDGenerator.NewSequentialGuid();

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
        public string NewSequentialId(string format = "t") => IDGenerator.NewSequentialId(format);
    }
}

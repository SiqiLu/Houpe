// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : DateTimeUtility.cs
// CreatedAt        : 2021-07-13
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;

namespace Houpe.Foundation
{
    /// <summary>
    ///     DateTimeUtility
    /// </summary>
    public static class DateTimeUtility
    {
        /// <summary>
        ///     当前的 CurrentMonth 时间（基于 UTC 标准时）
        /// </summary>
        public static DateTimeOffset CurrentMonth => new DateTimeOffset(UtcNow.Year, UtcNow.Month, 1, 0, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        ///     当前的 CurrentMonth 时间（基于 东八区时区）
        /// </summary>
        public static DateTimeOffset CurrentMonthOfHK => new DateTimeOffset(UtcNow.Year, UtcNow.Month, 1, 0, 0, 0, 0, 8.Hours());

        /// <summary>
        ///     当前的 CurrentMonth 时间（基于 东九区时区）
        /// </summary>
        public static DateTimeOffset CurrentMonthOfJP => new DateTimeOffset(UtcNow.Year, UtcNow.Month, 1, 0, 0, 0, 0, 9.Hours());

        /// <summary>
        ///     当前的 CurrentYear 时间（基于 UTC 标准时）
        /// </summary>
        public static DateTimeOffset CurrentYear => new DateTimeOffset(UtcNow.Year, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        ///     当前的 CurrentYear 时间（基于 东八区时区）
        /// </summary>
        public static DateTimeOffset CurrentYearOfHK => new DateTimeOffset(UtcNow.Year, 1, 1, 0, 0, 0, 0, 8.Hours());

        /// <summary>
        ///     当前的 CurrentYear 时间（基于 东九区时区）
        /// </summary>
        public static DateTimeOffset CurrentYearOfJP => new DateTimeOffset(UtcNow.Year, 1, 1, 0, 0, 0, 0, 9.Hours());

        /// <summary>
        ///     当前的东八区时间
        /// </summary>
        public static DateTimeOffset NowOfHK => DateTimeOffset.UtcNow.ToHKTime();

        /// <summary>
        ///     当前的东九区时间
        /// </summary>
        public static DateTimeOffset NowOfJP => DateTimeOffset.UtcNow.ToJPTime();

        /// <summary>
        ///     当前的 Today 时间（基于 UTC 标准时）
        /// </summary>
        public static DateTimeOffset Today => new DateTimeOffset(UtcNow.Year, UtcNow.Month, UtcNow.Day, 0, 0, 0, 0, TimeSpan.Zero);

        /// <summary>
        ///     当前的 Today 时间（基于 东八区时区）
        /// </summary>
        public static DateTimeOffset TodayOfHK => new DateTimeOffset(UtcNow.Year, UtcNow.Month, UtcNow.Day, 0, 0, 0, 0, 8.Hours());

        /// <summary>
        ///     当前的 Today 时间（基于 东九区时区）
        /// </summary>
        public static DateTimeOffset TodayOfJP => new DateTimeOffset(UtcNow.Year, UtcNow.Month, UtcNow.Day, 0, 0, 0, 0, 9.Hours());

        /// <summary>
        ///     当前的 UTC 时间
        /// </summary>
        public static DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}

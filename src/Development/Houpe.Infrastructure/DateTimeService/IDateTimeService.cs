// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure
// File             : IDateTimeService.cs
// CreatedAt        : 2021-07-14
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Houpe.Foundation;

namespace Houpe.Infrastructure
{
    /// <summary>
    ///     IDateTimeService
    /// </summary>
    public interface IDateTimeService
    {
        /// <summary>
        ///     当前的 CurrentMonth 时间（基于 UTC 标准时）
        /// </summary>
        public DateTimeOffset CurrentMonth => DateTimeUtility.CurrentMonth;

        /// <summary>
        ///     当前的 CurrentMonth 时间（基于 东八区时区）
        /// </summary>
        public DateTimeOffset CurrentMonthOfHK => DateTimeUtility.CurrentMonthOfHK;

        /// <summary>
        ///     当前的 CurrentMonth 时间（基于 东九区时区）
        /// </summary>
        public DateTimeOffset CurrentMonthOfJP => DateTimeUtility.CurrentMonthOfJP;

        /// <summary>
        ///     当前的 CurrentYear 时间（基于 UTC 标准时）
        /// </summary>
        public DateTimeOffset CurrentYear => DateTimeUtility.CurrentYear;

        /// <summary>
        ///     当前的 CurrentYear 时间（基于 东八区时区）
        /// </summary>
        public DateTimeOffset CurrentYearOfHK => DateTimeUtility.CurrentYearOfHK;

        /// <summary>
        ///     当前的 CurrentYear 时间（基于 东九区时区）
        /// </summary>
        public DateTimeOffset CurrentYearOfJP => DateTimeUtility.CurrentYearOfJP;

        /// <summary>
        ///     当前的东八区时间
        /// </summary>
        public DateTimeOffset NowOfHK => DateTimeUtility.NowOfHK;

        /// <summary>
        ///     当前的东九区时间
        /// </summary>
        public DateTimeOffset NowOfJP => DateTimeUtility.NowOfJP;

        /// <summary>
        ///     当前的 Today 时间（基于 UTC 标准时）
        /// </summary>
        public DateTimeOffset Today => DateTimeUtility.Today;

        /// <summary>
        ///     当前的 Today 时间（基于 东八区时区）
        /// </summary>
        public DateTimeOffset TodayOfHK => DateTimeUtility.TodayOfHK;

        /// <summary>
        ///     当前的 Today 时间（基于 东九区时区）
        /// </summary>
        public DateTimeOffset TodayOfJP => DateTimeUtility.TodayOfJP;

        /// <summary>
        ///     当前的 UTC 时间
        /// </summary>
        public DateTimeOffset UtcNow => DateTimeUtility.UtcNow;
    }
}

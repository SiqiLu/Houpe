// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : IDateTimeService.cs
// CreatedAt        : 2023-01-14
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation;

namespace Houpe.Infrastructure;

/// <summary>
///     IDateTimeService
/// </summary>
public interface IDateTimeService
{
    /// <summary>
    ///     当前的 CurrentMonth 时间（基于 UTC 标准时）
    /// </summary>
    public DateTimeOffset CurrentMonth => Time.CurrentMonth;

    /// <summary>
    ///     当前的 CurrentMonth 时间（基于 东八区时区）
    /// </summary>
    public DateTimeOffset CurrentMonthOfHK => Time.CurrentMonthOfHK;

    /// <summary>
    ///     当前的 CurrentMonth 时间（基于 东九区时区）
    /// </summary>
    public DateTimeOffset CurrentMonthOfJP => Time.CurrentMonthOfJP;

    /// <summary>
    ///     当前的 CurrentYear 时间（基于 UTC 标准时）
    /// </summary>
    public DateTimeOffset CurrentYear => Time.CurrentYear;

    /// <summary>
    ///     当前的 CurrentYear 时间（基于 东八区时区）
    /// </summary>
    public DateTimeOffset CurrentYearOfHK => Time.CurrentYearOfHK;

    /// <summary>
    ///     当前的 CurrentYear 时间（基于 东九区时区）
    /// </summary>
    public DateTimeOffset CurrentYearOfJP => Time.CurrentYearOfJP;

    /// <summary>
    ///     当前的 UTC 时间
    /// </summary>
    public static DateTimeOffset Now => Time.Now;

    /// <summary>
    ///     当前的东八区时间
    /// </summary>
    public DateTimeOffset NowOfHK => Time.NowOfHK;

    /// <summary>
    ///     当前的东九区时间
    /// </summary>
    public DateTimeOffset NowOfJP => Time.NowOfJP;

    /// <summary>
    ///     当前的 Today 时间（基于 UTC 标准时）
    /// </summary>
    public DateTimeOffset Today => Time.Today;

    /// <summary>
    ///     当前的 Today 时间（基于 东八区时区）
    /// </summary>
    public DateTimeOffset TodayOfHK => Time.TodayOfHK;

    /// <summary>
    ///     当前的 Today 时间（基于 东九区时区）
    /// </summary>
    public DateTimeOffset TodayOfJP => Time.TodayOfJP;

    /// <summary>
    ///     当前的 UTC 时间
    /// </summary>
    public DateTimeOffset UtcNow => Time.UtcNow;
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : DateTimeExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

namespace Houpe.Foundation;

/// <summary>
///     <see cref="System.DateTime" /> 的扩展类。
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    ///     计算指定的 <see cref="System.DateTime" /> 对象的值距离 <see cref="System.DateTime.Now" /> 的差值。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>计算出的差值。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static TimeSpan DurationToNow(this DateTime dateTime) => DateTime.Now - dateTime;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否晚于指定的 <see cref="System.DateTime" /> 对象的值。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <returns>如果原 <see cref="System.DateTime" /> 对象的值晚于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsAfter(this DateTime source, DateTime destination) => source > destination;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否晚于指定的 <see cref="System.DateTime" /> 对象的值，并且需要指定冗余量。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <param name="redundancy">冗余量。</param>
    /// <returns>如果原 <see cref="System.DateTime" /> 对象的值晚于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 或者 <paramref name="redundancy" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsAfter(this DateTime source, DateTime destination, TimeSpan redundancy) => source - destination > redundancy;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否晚于或者等于指定的 <see cref="System.DateTime" /> 对象的值。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <returns>指示原 <see cref="System.DateTime" /> 对象的值晚于或者等于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsAfterOrEqual(this DateTime source, DateTime destination) => source >= destination;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否晚于或者等于指定的 <see cref="System.DateTime" /> 对象的值，并且需要指定冗余量。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <param name="redundancy">冗余量。</param>
    /// <returns>指示原 <see cref="System.DateTime" /> 对象的值晚于或者等于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 或者 <paramref name="redundancy" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsAfterOrEqual(this DateTime source, DateTime destination, TimeSpan redundancy) => source - destination >= redundancy;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否早于指定的 <see cref="System.DateTime" /> 对象的值。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <returns>指示原 <see cref="System.DateTime" /> 对象的值早于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsBefore(this DateTime source, DateTime destination) => destination > source;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否早于指定的 <see cref="System.DateTime" /> 对象的值。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <param name="redundancy">冗余量。</param>
    /// <returns>指示原 <see cref="System.DateTime" /> 对象的值早于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 或者 <paramref name="redundancy" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsBefore(this DateTime source, DateTime destination, TimeSpan redundancy) => destination - source > redundancy;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否早于指定的 <see cref="System.DateTime" /> 对象的值。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <returns>指示原 <see cref="System.DateTime" /> 对象的值早于或者等于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsBeforeOrEqual(this DateTime source, DateTime destination) => destination >= source;

    /// <summary>
    ///     指示原 <see cref="System.DateTime" /> 对象的值是否早于指定的 <see cref="System.DateTime" /> 对象的值。
    /// </summary>
    /// <param name="source">原 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="destination">指定的 <see cref="System.DateTime" /> 对象的。</param>
    /// <param name="redundancy">冗余量。</param>
    /// <returns>指示原 <see cref="System.DateTime" /> 对象的值早于或者等于指定的 <see cref="System.DateTime" /> 对象的值，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="source" /> 或者 <paramref name="destination" /> 或者 <paramref name="redundancy" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsBeforeOrEqual(this DateTime source, DateTime destination, TimeSpan redundancy) => destination - source >= redundancy;

    /// <summary>
    ///     指示指定的 <see cref="System.DateTime" /> 对象的 <see cref="System.DateTime.Date" /> 是否是当月的第一天。
    /// </summary>
    /// <param name="date">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>如果是，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="date" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsFirstDayOfThisMonth(this DateTime date) => date.Month != date.AddDays(-1).Month;

    /// <summary>
    ///     指示指定的 <see cref="System.DateTime" /> 对象的 <see cref="System.DateTime.Date" /> 是否是当年的第一天。
    /// </summary>
    /// <param name="date">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>如果是，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="date" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsFirstDayOfThisYear(this DateTime date) => date.Year != date.AddDays(-1).Year;

    /// <summary>
    ///     指示指定的 <see cref="System.DateTime" /> 对象的值是否是指定日期内的时间。
    /// </summary>
    /// <param name="time">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <param name="date">指定日期。</param>
    /// <returns>如果是，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="time" /> 或者 <paramref name="date" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsInTheDay(this DateTime time, DateTime date) => time >= date.Date && time < date.Date.AddDays(1);

    /// <summary>
    ///     指示指定的 <see cref="System.DateTime" /> 对象的 <see cref="System.DateTime.Date" /> 是否是当月的最后一天。
    /// </summary>
    /// <param name="date">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>如果是，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="date" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsLastDayOfThisMonth(this DateTime date) => date.Month != date.AddDays(1).Month;

    /// <summary>
    ///     指示指定的 <see cref="System.DateTime" /> 对象的 <see cref="System.DateTime.Date" /> 是否是当年的最后一天。
    /// </summary>
    /// <param name="date">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>如果是，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="date" /> 为 <c>null</c>。
    /// </exception>
    public static bool IsLastDayOfThisYear(this DateTime date) => date.Year != date.AddDays(1).Year;

    /// <summary>
    ///     将指定的 <see cref="System.DateTime" /> 对象转换为中国标准时区的 <see cref="System.DateTime" />。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>转换后的中国标准时区的 <see cref="System.DateTime" />，并且对象的 <see cref="System.DateTime.Kind" /> 为 <see cref="System.DateTimeKind.Local" />。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static DateTime ToChinaStandardTime(this DateTime dateTime)
    {
        dateTime = dateTime.ToUniversalTime().AddHours(8);
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, DateTimeKind.Local);
    }

    /// <summary>
    ///     将指定的 <see cref="System.DateTime" /> 对象转换为JavaScript的整型时间。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>转换后的JavaScript的整型时间。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static long ToJSDate(this DateTime dateTime)
    {
        DateTime utc = dateTime.ToUniversalTime();
        return (utc.Ticks - Constants.EpochTicks) / 10000;
    }

    /// <summary>
    ///     将指定的 <see cref="System.DateTime" /> 对象转换为日志中使用的 <see cref="string" />。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <example>转换后的字符串会类似 “2016-08-31T23:31:40.5610456+08:00” 。</example>
    /// <returns>转换后的时间字符串。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static string ToLogFormatString(this DateTime dateTime) => dateTime.ToString("O");

    /// <summary>
    ///     将指定的 <see cref="System.DateTime" /> 对象转换为易于阅读的格式的 <see cref="string" />。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" />。</param>
    /// <example>转换后的字符串会类似 “2016-06-06 15:01:03” 。</example>
    /// <returns>转换后的时间字符串。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static string ToReadableString(this DateTime dateTime) => dateTime.ToString("s").Replace('T', ' ');

    /// <summary>
    ///     将指定的 <see cref="System.DateTime" /> 对象转换为UNIX的时间戳。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" /> 对象。</param>
    /// <returns>转换后的时间戳。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static long ToUnixTimestamp(this DateTime dateTime)
    {
        DateTime utc = dateTime.ToUniversalTime();
        return (utc.Ticks - Constants.EpochTicks) / 10000000;
    }

    /// <summary>
    ///     将指定的 <see cref="System.DateTime" /> 对象的值转换为协调世界时 (UTC)。
    /// </summary>
    /// <param name="dateTime">指定的 <see cref="System.DateTime" />。</param>
    /// <returns>一个对象，其 <see cref="P:System.DateTime.Kind" /> 属性为 <see cref="System.DateTimeKind.Utc" />，并且其值为等效于指定的 <see cref="System.DateTime" /> 对象的值的 UTC时间；如果经转换的值过大以至于不能由 MaxValue 对象表示，则为 <see cref="System.DateTime.MaxValue" /> 对象，或者，如果经转换的值过小以至于不能表示为 MinValue 对象，则为 <see cref="System.DateTime.MinValue" /> 对象。</returns>
    /// <exception cref="System.ArgumentNullException">
    ///     <paramref name="dateTime" /> 为 <c>null</c>。
    /// </exception>
    public static DateTime ToUTC(this DateTime dateTime) => dateTime.ToUniversalTime();
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Int64Extensions.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;

namespace Houpe.Foundation
{
    /// <summary>
    ///     <see cref="long" /> 的扩展类。
    /// </summary>
    public static class Int64Extensions
    {
        /// <summary>
        ///     将指定的 <see cref="long" /> 对象作为FileTime转换为 <see cref="System.DateTime" />对象，并且指定 <see cref="System.DateTime" />对象的 <see cref="System.DateTimeKind" />。
        /// </summary>
        /// <param name="fileTime">指定的 <see cref="long" /> 对象。</param>
        /// <returns>转换后的 <see cref="System.DateTime" />，转换后的 <see cref="System.DateTime" /> 的 <see cref="System.DateTime.Kind" /> 为 <see cref="System.DateTimeKind.Utc" />。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="fileTime" /> 的值超过合理范围。
        /// </exception>
        public static DateTime ToDateTimeFromFileTime(this long fileTime)
        {
            long ticks = fileTime + Constants.FileTimeOffset;

            if (ticks > DateTime.MaxValue.Ticks || ticks < DateTime.MinValue.Ticks)
            {
                throw new ArgumentOutOfRangeException(nameof(fileTime), fileTime, Resource.ArgumentOutOfRange_DateTimeBadTicks);
            }

            return new DateTime(ticks, DateTimeKind.Utc);
        }

        /// <summary>
        ///     将指定的 <see cref="long" /> 对象的值作为 Ticks 值转换为 <see cref="System.DateTime" />对象，并且指定 <see cref="System.DateTime" />对象的 <see cref="System.DateTimeKind" />。
        /// </summary>
        /// <param name="ticks">指定的 <see cref="long" /> 对象。</param>
        /// <param name="dateTimeKind">指定的 <see cref="System.DateTime.Kind" />。</param>
        /// <returns>转换后的 <see cref="System.DateTime" />，并且对象的 <see cref="System.DateTime.Kind" /> 为参数指定值。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="ticks" /> 的值超过合理范围。
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="dateTimeKind" /> 不是合法的 <see cref="System.DateTimeKind" />。
        /// </exception>
        public static DateTime ToDateTimeFromTicks(this long ticks, DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            if (ticks > DateTime.MaxValue.Ticks || ticks < DateTime.MinValue.Ticks)
            {
                throw new ArgumentOutOfRangeException(nameof(ticks), ticks, Resource.ArgumentOutOfRange_DateTimeBadTicks);
            }

            if (!Enum.IsDefined(typeof(DateTimeKind), dateTimeKind))
            {
                throw new ArgumentException(Resource.Argument_EnumIllegalVal.FormatWith(nameof(dateTimeKind)), nameof(dateTimeKind));
            }

            return new DateTime(ticks, dateTimeKind);
        }

        /// <summary>
        ///     将指定的 <see cref="long" /> 对象的值作为 UnixTimestamp 值转换为 <see cref="System.DateTime" />对象，并且指定 <see cref="System.DateTime" />对象的 <see cref="System.DateTimeKind" />。
        /// </summary>
        /// <param name="timeStamp">指定的 <see cref="long" /> 对象。</param>
        /// <returns>转换后的 <see cref="System.DateTime" />，转换后的 <see cref="System.DateTime" /> 的 <see cref="System.DateTime.Kind" /> 为 <see cref="System.DateTimeKind.Utc" />。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="timeStamp" /> 的值超过合理范围。
        /// </exception>
        public static DateTime ToDateTimeFromUnixTimestamp(this long timeStamp)
        {
            long seconds = timeStamp + Constants.EpochSeconds;
            long ticks = seconds * 1000 * Constants.MillisecondTicks;

            if (ticks > DateTime.MaxValue.Ticks || ticks < DateTime.MinValue.Ticks)
            {
                throw new ArgumentOutOfRangeException(nameof(timeStamp), timeStamp, Resource.ArgumentOutOfRange_DateTimeBadTicks);
            }

            return new DateTime(ticks, DateTimeKind.Utc);
        }

        /// <summary>
        ///     如果值小于0，则返回0，否则返回原值。
        /// </summary>
        /// <param name="value">原值。</param>
        /// <returns>如果值小于0，则返回0，否则返回原值。</returns>
        public static long ToZeroIfNegNum(this long value) => value < 0 ? 0 : value;
    }
}

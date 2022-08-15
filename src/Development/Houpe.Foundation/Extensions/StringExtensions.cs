// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : StringExtensions.cs
// CreatedAt        : 2022-08-16
// LastModifiedAt   : 2022-08-16
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Houpe.Foundation.Internal;

namespace Houpe.Foundation
{
    /// <summary>
    ///     <see cref="System.String" /> 的扩展类。
    /// </summary>
    [SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
    public static class StringExtensions
    {
        /// <summary>
        ///     将 <see cref="System.String" /> 转换为指定的类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <typeparam name="TValue">指定的转换类型。</typeparam>
        /// <returns>转换后指定类型的值。</returns>
        public static TValue As<TValue>(this string s, TValue defaultValue = default)
        {
            try
            {
                TypeConverter converter1 = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter1.CanConvertFrom(typeof(string)))
                {
                    return (TValue)converter1.ConvertFrom(s);
                }
            }
            catch
            {
                // ignored
            }

            return defaultValue;
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Boolean" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static bool AsBoolean(this string s, bool defaultValue = default) => !bool.TryParse(s, out bool result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.DateTime" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static DateTime AsDateTime(this string s, DateTime defaultValue = default) => !DateTime.TryParse(s, out DateTime result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.DateTimeOffset" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static DateTimeOffset AsDateTimeOffset(this string s, DateTimeOffset defaultValue = default) =>
            !DateTimeOffset.TryParse(s, out DateTimeOffset result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Decimal" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static decimal AsDecimal(this string s, decimal defaultValue = 0m) => !decimal.TryParse(s, out decimal result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Double" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static double AsDouble(this string s, double defaultValue = 0d) => !double.TryParse(s, out double result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Single" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static float AsFloat(this string s, float defaultValue = 0.0f) => !float.TryParse(s, out float result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Guid" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="format">下列说明符之一，指示当转换 input 时要使用的确切格式：“N”、“D”、“B”、“P”或“X”。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static Guid AsGuid(this string s, string format = "N", Guid? defaultValue = null) =>
            !Guid.TryParseExact(s, format, out Guid result) ? defaultValue.GetValueOrDefault(Guid.Empty) : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int32" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static int AsInt(this string s, int defaultValue = 0) => !int.TryParse(s, out int result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int16" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static short AsInt16(this string s, short defaultValue = 0) => !short.TryParse(s, out short result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int32" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static int AsInt32(this string s, int defaultValue = 0) => !int.TryParse(s, out int result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int64" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static long AsInt64(this string s, long defaultValue = 0) => !long.TryParse(s, out long result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int64" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static long AsLong(this string s, long defaultValue = 0L) => !long.TryParse(s, out long result) ? defaultValue : result;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Single" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则返回指定的默认值。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="defaultValue">如果 <paramref name="s" /> 为 <c>null</c> 或者转换失败，返回的默认值。</param>
        /// <returns>转换后的值。</returns>
        public static float AsSingle(this string s, float defaultValue = 0.0f) => !float.TryParse(s, out float result) ? defaultValue : result;

        /// <summary>
        ///     连接 <see cref="System.String" /> 的两个指定实例。
        /// </summary>
        /// <param name="source">要连接的第一个字符串。</param>
        /// <param name="target">要连接的第一个字符串。</param>
        /// <returns>连接后的字符串</returns>
        public static string Concat(this string source, string target) => string.Concat(source, target);

        /// <summary>
        ///     用于调用 <see cref="System.String.Format(string, object[])" /> 的扩展方法。将指定字符串中的一个或多个格式项替换为对应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">需要格式化的字符串。</param>
        /// <param name="args">要设置格式的对象。</param>
        /// <returns><paramref name="format" /> 的副本，其中的一个或多个格式项已替换为 <paramref name="args" /> 的字符串表示形式。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="format" /> 或 <paramref name="args" /> 为 <c>null</c>。
        /// </exception>
        /// <exception cref="System.FormatException"><paramref name="format" /> 无效。</exception>
        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            return string.Format(format, args);
        }

        /// <summary>
        ///     用于调用 <see cref="System.String.Format(IFormatProvider, string, object[])" /> 的扩展方法。将指定字符串中的一个或多个格式项替换为对应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">需要格式化的字符串。</param>
        /// <param name="provider">一个提供区域性特定的格式设置信息的对象。</param>
        /// <param name="args">要设置格式的对象。</param>
        /// <returns><paramref name="format" /> 的副本，其中的一个或多个格式项已替换为 <paramref name="args" /> 的字符串表示形式。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="format" /> 或 <paramref name="args" /> 为 null。
        /// </exception>
        /// <exception cref="System.FormatException"><paramref name="format" /> 无效。</exception>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            return string.Format(provider, format, args);
        }

        /// <summary>
        ///     用于调用 <see cref="System.String.Format(string, object[])" /> 的扩展方法。
        ///     可以使用{NamedformatItem}的格式，但是不能控制格式的顺序。
        ///     将指定字符串中的一个或多个格式项按顺序替换为对应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">需要格式化的字符串。</param>
        /// <param name="args">要设置格式的对象。</param>
        /// <returns><paramref name="format" /> 的副本，其中的一个或多个格式项已替换为 <paramref name="args" /> 的字符串表示形式。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="format" /> 或 <paramref name="args" /> 为 <c>null</c>。
        /// </exception>
        /// <exception cref="System.FormatException"><paramref name="format" /> 无效。</exception>
        public static string FormatWithValues(this string format, params object[] args)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            return new FormattedStringValues(format, args).ToString();
        }

        /// <summary>
        ///     将指定的JSON字符串反序列化为 <typeparamref name="T" /> 的实例。 如果 <paramref name="s" /> 是 <c>null</c>
        ///     或者空字符串, 将返回 <typeparamref name="T" /> 的默认值 。
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型。</typeparam>
        /// <param name="s">指定的JSON字符串。</param>
        /// <returns>
        ///     <typeparamref name="T" /> 的实例。 如果 <paramref name="s" /> 是 <c>null</c> 或者空字符串, 则返回
        ///     <typeparamref name="T" /> 的默认值 。
        /// </returns>
        public static T FromJson<T>(this string s) => s.IsNullOrEmpty() ? default : JsonSerializer.Deserialize<T>(s);

        /// <summary>
        ///     将指定的JSON字符串反序列化为 <typeparamref name="T" /> 的实例。 如果 <paramref name="s" /> 是 <c>null</c>
        ///     或者空字符串, 将返回 <typeparamref name="T" /> 的默认值 。
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型。</typeparam>
        /// <param name="s">指定的JSON字符串。</param>
        /// <param name="options">反序列化的配置类。</param>
        /// <returns>
        ///     <typeparamref name="T" /> 的实例。 如果 <paramref name="s" /> 是 <c>null</c> 或者空字符串, 则返回
        ///     <typeparamref name="T" /> 的默认值 。
        /// </returns>
        public static T FromJson<T>(this string s, JsonSerializerOptions options) => s.IsNullOrEmpty() ? default : JsonSerializer.Deserialize<T>(s, options);

        /// <summary>
        ///     从 <paramref name="s" /> 的第一个字符开始向后截取指定数量字符的子字符串。如果需要的数量大于 <paramref name="s" /> 的长度，则直接返回
        ///     <paramref name="s" /> 。
        /// </summary>
        /// <param name="s">被截取的原字符串。</param>
        /// <param name="count">截取的字符数量。</param>
        /// <returns>截取后的子字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static string GetFirst(this string s, int count = 1)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resource.ArgumentOutOfRange_MustBeNonNegNum);
            }

            if (count == 0)
            {
                return string.Empty;
            }

            return SubString(s, 0, count);
        }

        /// <summary>
        ///     从 <paramref name="s" /> 的末尾向前截取指定数量字符的子字符串。如果需要的数量大于 <paramref name="s" /> 的长度，则直接返回
        ///     <paramref name="s" /> 。
        /// </summary>
        /// <param name="s">被截取的原字符串。</param>
        /// <param name="count">截取的字符数量。</param>
        /// <returns>截取后的子字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static string GetLast(this string s, int count = 1)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), Resource.ArgumentOutOfRange_MustBeNonNegNum);
            }

            if (count == 0)
            {
                return string.Empty;
            }

            int start = s.Length - count;
            if (start < 0)
            {
                start = 0;
            }

            return SubString(s, start, count);
        }

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为指定的类型。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <typeparam name="TValue">转换的目标类型。</typeparam>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool Is<TValue>(this string s)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
            try
            {
                if (s != null)
                {
                    if (!converter.CanConvertFrom(null, s.GetType()))
                    {
                        return false;
                    }
                }

                // ReSharper disable once AssignNullToNotNullAttribute
                // ReSharper disable once AssignmentIsFullyDiscarded
                _ = converter.ConvertFrom(null, CultureInfo.CurrentCulture, s);
                return true;
            }
            catch
            {
                // ignored
            }

            return false;
        }

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Boolean" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsBoolean(this string s) => bool.TryParse(s, out _);

        /// <summary>
        ///     指示 <paramref name="s" /> 是否是合法的中国大陆手机号，10号段作为开发号段，是会判定为合法的手机号。
        /// </summary>
        /// <remarks>
        /// 使用 ^(?:\+?86)?(13|14|15|16|17|18|19|10)\d{9}$ 检测
        /// 所以:
        /// 1. 无论是否包含国家区号都能通过检测
        /// 2. 只判断号段的前两位
        /// 3. 10 号段作为开发号段，是可以正常通过检测的
        /// </remarks>
        /// <param name="s">指定的字符串。</param>
        /// <returns>如果是合法的手机号，则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static bool IsCMCellphone(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return Match(s, RegexConstants.CMCellphoneRegex);
        }

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.DateTime" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsDateTime(this string s) => DateTime.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.DateTimeOffset" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsDateTimeOffset(this string s) => DateTimeOffset.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Decimal" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsDecimal(this string s) => decimal.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Double" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsDouble(this string s) => double.TryParse(s, out _);

        /// <summary>
        ///     指示 <paramref name="s" /> 是否是合法的电子邮箱。
        /// </summary>
        /// <param name="s">指定的字符串。</param>
        /// <returns>如果是合法的电子邮箱，则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static bool IsEmail(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return Match(s, RegexConstants.EmailRegex);
        }

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Single" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsFloat(this string s) => float.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Guid" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <param name="format">下列说明符之一，指示当转换 input 时要使用的确切格式：“N”、“D”、“B”、“P”或“X”。</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsGuid(this string s, string format = "N") => Guid.TryParseExact(s, format, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Int32" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsInt(this string s) => int.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Int16" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsInt16(this string s) => short.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Int32" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsInt32(this string s) => int.TryParse(s, out _);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Int64" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsInt64(this string s) => long.TryParse(s, out _);

        /// <summary>
        ///     指示 <paramref name="s" /> 是否是合法的IP地址。
        /// </summary>
        /// <param name="s">指定的字符串。</param>
        /// <returns>如果是合法的IP地址，则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static bool IsIPAddress(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return Match(s, RegexConstants.IPAddressRegex);
        }

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="long" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsLong(this string s) => long.TryParse(s, out _);

        /// <summary>
        ///     判断指定的字符串是否是 <c>null</c> 或者 <see cref="System.String.Empty" />。
        /// </summary>
        /// <param name="s">要测试的字符串。</param>
        /// <returns>如果 <paramref name="s" /> 字符串不是 <c>null</c> 并且不是空字符串，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsNotNullOrEmpty(this string s) => !string.IsNullOrEmpty(s);

        /// <summary>
        ///     判断指定的字符串是否是 <c>null</c>、 <see cref="System.String.Empty" /> 或者仅由空白字符组成。
        /// </summary>
        /// <param name="s">要测试的字符串。</param>
        /// <returns>
        ///     如果 <paramref name="s" /> 字符串为不是 <c>null</c>、也不是空字符串并且不是仅由空白字符组成，则为 <c>true</c>；否则为 <c>false</c>。
        /// </returns>
        public static bool IsNotNullOrWhiteSpace(this string s) => !string.IsNullOrWhiteSpace(s);

        /// <summary>
        ///     判断指定的字符串是否是 <c>null</c> 或者 <see cref="System.String.Empty" />。
        /// </summary>
        /// <param name="s">要测试的字符串。</param>
        /// <returns>如果 <paramref name="s" /> 字符串为 <c>null</c> 或者空字符串，则为 <c>true</c>；否则为 <c>false</c>。</returns>
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);

        /// <summary>
        ///     判断指定的字符串是否是 <c>null</c>、 <see cref="System.String.Empty" /> 或者仅由空白字符组成。
        /// </summary>
        /// <param name="s">要测试的字符串。</param>
        /// <returns>
        ///     如果 <paramref name="s" /> 字符串为 <c>null</c>、空字符串或者仅由空白字符组成，则为 <c>true</c>；否则为 <c>false</c>。
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string s) => string.IsNullOrWhiteSpace(s);

        /// <summary>
        ///     指示 <see cref="System.String" /> 是否可以转换为 <see cref="System.Single" />。
        /// </summary>
        /// <param name="s">需要检查的字符串</param>
        /// <returns>如果可以转换为指定的类型，返回 <c>true</c>；否则返回 <c>false</c> 。</returns>
        public static bool IsSingle(this string s) => float.TryParse(s, out _);

        /// <summary>
        ///     从字符串中移除指定的字符子串。
        /// </summary>
        /// <param name="s">原字符串。</param>
        /// <param name="target">需要移除的字符子串。</param>
        /// <returns>移除了指定的字符子串后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="target" /> 为 <c>null</c>。</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="target" /> 为 <c>null</c>。</exception>
        public static string Remove(this string s, string target)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            if (target.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString, nameof(target));
            }

            return s.Replace(target, "");
        }

        /// <summary>
        ///     将 PascalCase 风格的字符串为以单词为单位使用空格分隔开。
        /// </summary>
        /// <example>
        ///     "ThisIsPascalCase".SeparatePascalCase(); // returns "This Is Pascal Case"
        /// </example>
        /// <param name="s">PascalCase 风格的字符串。</param>
        /// <returns>分隔后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static string SeparatePascalCase(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return Regex.Replace(s, "([A-Z])", " $1").Trim();
        }

        /// <summary>
        ///     更安全截取子字符串的方法。与 <see cref="F:System.String.Substring()" /> 不同，字符串指定部分的长度不足需要获取的子字符串的长度时，该方法不会报错，而是返回尽量截取出的长度的部分。
        /// </summary>
        /// <param name="s">原字符串。</param>
        /// <param name="start">此实例中子字符串的起始字符位置（从零开始）。</param>
        /// <param name="count">子字符串中的字符数。</param>
        /// <returns>与此实例中在 length 处开头、长度为 startIndex 的子字符串等效的一个字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        public static string SubString(this string s, int start, int count = 1)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), start, Resource.ArgumentOutOfRange_IndexString);
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, Resource.ArgumentOutOfRange_MustBeNonNegNum);
            }

            if (start >= s.Length)
            {
                return string.Empty;
            }

            if (count == 0)
            {
                return string.Empty;
            }

            return s.Length - count - start < 0 ? s.Substring(start) : s.Substring(start, count);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Boolean" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="s" /> 为 <c>null</c>。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static bool ToBoolean(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            return bool.Parse(s);
        }

        /// <summary>
        ///     将指定的字符串转换为 camelCase 风格
        /// </summary>
        /// <param name="s">指定的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        public static string ToCamelCase(this string s)
        {
            if (s.IsNullOrWhiteSpace())
            {
                return s;
            }

            int len = s.Length;
            char[] newValue = new char[len];
            bool firstPart = true;

            for (int i = 0; i < len; ++i)
            {
                char c0 = s[i];
                char c1 = i < len - 1 ? s[i + 1] : 'A';
                bool c0IsUpper = c0 is >= 'A' and <= 'Z';
                bool c1IsUpper = c1 is >= 'A' and <= 'Z';

                if (firstPart && c0IsUpper && (c1IsUpper || i == 0))
                {
                    // IPadIsUnsupported
                    // PadIsUnsupported
                    c0 = (char)(c0 + Constants.LowerCaseOffset);
                }
                else
                {
                    firstPart = false;
                }

                newValue[i] = c0;
            }

            return new string(newValue);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.DateTime" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException">
        ///     <paramref name="s" /> 为 <c>null</c> 或者空字符串。
        /// </exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static DateTime ToDateTime(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return DateTime.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.DateTimeOffset" /> 类型，如果字符串为 <c>null</c>、空字符串或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static DateTimeOffset ToDateTimeOffset(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return DateTimeOffset.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Decimal" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static decimal ToDecimal(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return decimal.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Double" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static double ToDouble(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return double.Parse(s);
        }

        /// <summary>
        ///     如果指定的字符串是 <c>null</c> 或者空字符串，则返回 <see cref="System.String.Empty" />。
        /// </summary>
        /// <param name="s">指定的字符串。</param>
        /// <returns>
        ///     如果指定的字符串是 <c>null</c> 或者空字符串，则返回 <see cref="System.String.Empty" />；否则返回原字符串 <paramref name="s" />。
        /// </returns>
        public static string ToEmptyIfNull(this string s) => s.IsNullOrEmpty() ? string.Empty : s;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Single" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static float ToFloat(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return float.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Guid" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <param name="format">下列说明符之一，指示当转换 input 时要使用的确切格式：“N”、“D”、“B”、“P”或“X”。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static Guid ToGuid(this string s, string format = "N")
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return Guid.ParseExact(s, format);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int32" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static int ToInt(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return int.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int16" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static short ToInt16(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return short.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int32" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static int ToInt32(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return int.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int64" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static long ToInt64(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return long.Parse(s);
        }

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Int64" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static long ToLong(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return long.Parse(s);
        }

        /// <summary>
        ///     使用“*”替换指定字符串中的部分字符，以达到给字符串加马赛克的效果。
        /// </summary>
        /// <param name="s">指定字符串。</param>
        /// <returns>处理后的字符串。</returns>
        public static string ToMosaicString(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            if (s.Length >= 12)
            {
                _ = sb.Append(GetFirst(s, 4));
                (s.Length - 8).ToZeroIfNegNum().Times().Do(() => sb.Append("*"));
                _ = sb.Append(GetLast(s, 4));
            }
            else
            {
                (s.Length - 4).ToZeroIfNegNum().Times().Do(() => sb.Append("*"));
                _ = sb.Append(GetLast(s, 4));
            }

            return sb.ToString();
        }

        /// <summary>
        ///     如果指定的字符串是 <c>null</c> 或者空字符串，则返回 <c>null</c>。
        /// </summary>
        /// <param name="s">指定的字符串。</param>
        /// <returns>如果指定的字符串是 <c>null</c> 或者空字符串，则返回 <c>null</c>；否则返回原字符串 <paramref name="s" />。</returns>
        public static string ToNullIfEmpty(this string s) => s.IsNullOrEmpty() ? null : s;

        /// <summary>
        ///     将 <see cref="System.String" /> 转换为 <see cref="System.Single" /> 类型，如果字符串为 <c>null</c> 或者转换失败，则抛出异常。
        /// </summary>
        /// <param name="s">包含要转换的值的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        /// <exception cref="System.ArgumentException"><paramref name="s" /> 为 <c>null</c> 或者空字符串。</exception>
        /// <exception cref="System.FormatException"><paramref name="s" /> 不是可以转换的合法格式。</exception>
        public static float ToSingle(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                throw new ArgumentException(Resource.Argument_EmptyOrNullString.FormatWith(nameof(s)), nameof(s));
            }

            return float.Parse(s);
        }

        /// <summary>
        ///     将指定的字符串转换为 UnderScope 风格。
        /// </summary>
        /// <param name="s">待转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        public static string ToUnderScope(this string s)
        {
            if (s.IsNullOrWhiteSpace())
            {
                return s;
            }

            int len = s.Length;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                char currentChar = s[i];
                char? lastChar = i > 0 ? s[i - 1] : null;
                char? nextChar = i < len - 1 ? s[i + 1] : null;

                bool currentCharIsUpper = currentChar is >= 'A' and <= 'Z';

                // bool lastCharIsUpper = lastChar != null && lastChar >= 'A' && lastChar <= 'Z';
                bool nextCharIsUpper = nextChar is >= 'A' and <= 'Z';

                if (currentCharIsUpper && lastChar != null && !nextCharIsUpper)
                {
                    _ = sb.Append('_');
                }

                _ = sb.Append(currentChar);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     指示 <paramref name="s" /> 在指定的字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="s">指定的字符串。</param>
        /// <param name="regex">进行匹配的正则表达式。</param>
        /// <returns>如果正则表达式找到匹配项 ，则返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="s" /> 或者 <paramref name="regex" /> 为 <c>null</c>。
        /// </exception>
        [ExcludeFromCodeCoverage]
        private static bool Match(this string s, Regex regex)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (regex == null)
            {
                throw new ArgumentNullException(nameof(regex));
            }

            return s.IsNotNullOrEmpty() && regex.IsMatch(s);
        }
    }
}

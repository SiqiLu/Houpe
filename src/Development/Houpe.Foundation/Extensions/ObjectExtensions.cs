// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ObjectExtensions.cs
// CreatedAt        : 2021-06-26
// LastModifiedAt   : 2022-08-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;

namespace Houpe.Foundation
{
    /// <summary>
    ///     <see cref="System.Object" /> 的扩展类。
    /// </summary>
    [SuppressMessage("Style", "IDE0049:Simplify Names", Justification = "<Pending>")]
    public static class ObjectExtensions
    {
        private const int MaximumNumberOfRecursiveCalls = 10;

        /// <summary>
        ///     当指定的 <paramref name="obj" /> 实例不是 <c>null</c> 时，执行指定的操作，并且返回操作的返回值。
        ///     当指定的 <paramref name="obj" /> 实例是 <c>null</c> 时，直接返回 <paramref name="defaultValue" />。
        /// </summary>
        /// <typeparam name="TObject"><paramref name="obj" /> 的类型。</typeparam>
        /// <typeparam name="TResult">执行操作后的返回值或者默认返回值的类型。</typeparam>
        /// <param name="obj">指定的对象实例。</param>
        /// <param name="action">指定的可执行操作。</param>
        /// <param name="defaultValue">当指定的 <paramref name="obj" /> 实例是 <c>null</c> 时，直接返回的值。</param>
        /// <returns>最终返回值。</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="action" /> 是 <c>null</c>。
        /// </exception>
        public static TResult IfNotNull<TObject, TResult>(this TObject obj, Func<TObject, TResult> action, TResult defaultValue = default) where TObject : class
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return obj != null ? action(obj) : defaultValue;
        }

        /// <summary>
        ///     当指定的 <paramref name="obj" /> 实例不是 <c>null</c> 时，执行指定的操作。
        /// </summary>
        /// <typeparam name="TObject"><paramref name="obj" /> 的类型。</typeparam>
        /// <param name="obj">指定的对象实例。</param>
        /// <param name="action">指定的可执行操作。</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="action" /> 是 <c>null</c>。
        /// </exception>
        public static void IfNotNull<TObject>(this TObject obj, Action<TObject> action) where TObject : class
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (obj == null)
            {
                return;
            }

            action(obj);
        }

        /// <summary>
        ///     Transforms an object into a string representation that can be used to represent it's value in an
        ///     exception message. When the value is a null reference, the string "null" will be returned, when
        ///     the specified value is a string or a char, it will be surrounded with single quotes.
        /// </summary>
        /// <param name="value">The value to be transformed.</param>
        /// <returns>A string representation of the supplied <paramref name="value" />.</returns>
        public static string Stringified(this object value)
        {
            try
            {
                return StringifyInternal(value, MaximumNumberOfRecursiveCalls);
            }
            catch (InvalidOperationException)
            {
                // Stack overflow prevented. We can not build a string representation of the supplied object.
                // We return the default representation of the object.
                return value.ToString();
            }
        }

        /// <summary>
        ///     将一个 <see cref="System.Object" /> 的实例序列化为 JSON。 如果实例的值为 <c>null</c>，会返回 <c>null</c>。
        /// </summary>
        /// <param name="value">需要序列化的对象。</param>
        /// <param name="options">JSON 序列化的配置类。</param>
        /// <returns><paramref name="value" /> 序列化后的 JSON 字符串。</returns>
        public static string ToJson(this object value, JsonSerializerOptions options = null) => value.ToJson(null, options);

        /// <summary>
        ///     将一个 <see cref="System.Object" /> 的实例序列化为 JSON。 如果实例的值为 <c>null</c>，会返回 <paramref name="nullValue" />。
        /// </summary>
        /// <param name="value">需要序列化的对象。</param>
        /// <param name="nullValue">如果实例的值为 <c>null</c>，会返回的字符串，可以为 <c>null</c>。</param>
        /// <param name="options">JSON 序列化的配置类。</param>
        /// <returns><paramref name="value" /> 序列化后的 JSON 字符串。</returns>
        public static string ToJson(this object value, string nullValue, JsonSerializerOptions options = null)
        {
            if (value == null)
            {
                return nullValue;
            }

            try
            {
                return JsonSerializer.Serialize(value, options);
            }
            catch
            {
                return value.Stringified();
            }
        }

        private static string StringifyCollection(IEnumerable collection, int maximumNumberOfRecursiveCalls) =>
            "[" + string.Join(",", (from object o in collection select StringifyInternal(o, maximumNumberOfRecursiveCalls - 1)).ToArray()) + "]";

        [ExcludeFromCodeCoverage]
        private static string StringifyInternal(object value, int maximumNumberOfRecursiveCalls)
        {
            if (value == null)
            {
                return "null";
            }

            if (maximumNumberOfRecursiveCalls < 0)
            {
                // Prevent stack overflow exceptions.
                throw new InvalidOperationException();
            }

            if (value is string)
            {
                return "\"" + value + "\"";
            }

            if (value is char)
            {
                return "'" + value + "'";
            }

            return value is IEnumerable collection ? StringifyCollection(collection, maximumNumberOfRecursiveCalls) : value.ToString();
        }
    }
}

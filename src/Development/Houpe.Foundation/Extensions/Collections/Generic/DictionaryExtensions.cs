// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : DictionaryExtensions.cs
// CreatedAt        : 2021-07-01
// LastModifiedAt   : 2021-07-01
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Houpe.Foundation.Collections.Generic
{
    /// <summary>
    ///     <see cref="System.Collections.Generic.IDictionary{TKey, TValue}" /> 的扩展类。
    /// </summary>
    [SuppressMessage("ReSharper", "CompareNonConstrainedGenericWithNull")]
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     如果 <paramref name="dictionary" /> 不包含指定的键，将指定的键和值添加到字典中。
        /// </summary>
        /// <typeparam name="TKey">要添加元素的键的类型。</typeparam>
        /// <typeparam name="TValue">要添加元素的值的类型。</typeparam>
        /// <param name="dictionary">字典。</param>
        /// <param name="key">要添加元素的键。</param>
        /// <param name="value">要添加元素的值。对于引用类型，该值可以为 <c>null</c>。</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="dictionary" /> 为 null。
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="key" /> 为 null。
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        ///     <paramref name="dictionary" /> 是只读的。
        /// </exception>
        public static void AddIfNotExist<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary), Resource.ArgumentNull_Dictionary);
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), Resource.ArgumentNull_Generic);
            }

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }

        /// <summary>
        ///     获取与指定键关联的值，如果获取失败则返回指定的默认值 <paramref name="defaultValue" />。
        /// </summary>
        /// <typeparam name="TKey">要获取元素的键的类型。</typeparam>
        /// <typeparam name="TValue">要获取元素的值的类型。</typeparam>
        /// <param name="dictionary">字典。</param>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="defaultValue">当此方法返回时，如果没有找到指定键，则返回该默认值。</param>
        /// <returns>如果找到指定键，则包含与该键相关的值；否则返回指定的默认值<paramref name="defaultValue" />。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="dictionary" /> 为 null。
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="key" /> 为 null。
        /// </exception>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary), Resource.ArgumentNull_Dictionary);
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), Resource.ArgumentNull_Generic);
            }

            return dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }
    }
}

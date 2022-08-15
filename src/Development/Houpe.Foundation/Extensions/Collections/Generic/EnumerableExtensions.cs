// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : EnumerableExtensions.cs
// CreatedAt        : 2020-05-10
// LastModifiedAt   : 2022-07-26
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Houpe.Foundation.Collections.Generic
{
    /// <summary>
    ///     <see cref="System.Collections.Generic.IEnumerable{T}" /> 的扩展类。
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     对 <paramref name="sequence" /> 的每一个元素执行指定操作。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">要对其元素执行操作。</param>
        /// <param name="action">要执行的指定操作。</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="sequence" /> 或者 <paramref name="action" /> 为 <c>null</c>。
        /// </exception>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), Resource.ArgumentNull_Generic);
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), Resource.ArgumentNull_Generic);
            }

            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            foreach (T value in values)
            {
                action(value);
            }
        }

        /// <summary>
        ///     对 <paramref name="sequence" /> 的每一个元素执行指定操作。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <typeparam name="TResult">指定操作的返回值类型。</typeparam>
        /// <returns>对 <paramref name="sequence" /> 的每一个元素执行指定操作后的返回值按原顺序组成的序列。</returns>
        /// <param name="sequence">要对其元素执行操作。</param>
        /// <param name="action">要执行的指定操作。</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="sequence" /> 或者 <paramref name="action" /> 为 <c>null</c>。
        /// </exception>
        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), Resource.ArgumentNull_Generic);
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), Resource.ArgumentNull_Generic);
            }

            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            return values.Select(value => action(value)).ToList();
        }

        /// <summary>
        ///     对 <paramref name="sequence" /> 的每一个元素执行指定操作。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">要对其元素执行操作。</param>
        /// <param name="action">要执行的指定操作。</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="sequence" /> 或者 <paramref name="action" /> 为 <c>null</c>。
        /// </exception>
        public static Task ForEach<T>(this IEnumerable<T> sequence, Func<T, Task> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), Resource.ArgumentNull_Generic);
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), Resource.ArgumentNull_Generic);
            }

            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            IEnumerable<Task> tasks = values.Select(value => action(value));
            return Task.WhenAll(tasks);
        }

        /// <summary>
        ///     对 <paramref name="sequence" /> 的每一个元素执行指定操作。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <typeparam name="TResult">指定操作的返回值类型。</typeparam>
        /// <returns>对 <paramref name="sequence" /> 的每一个元素执行指定操作后的返回值按原顺序组成的序列。</returns>
        /// <param name="sequence">要对其元素执行操作。</param>
        /// <param name="action">要执行的指定操作。</param>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="sequence" /> 或者 <paramref name="action" /> 为 <c>null</c>。
        /// </exception>
        public static async Task<IEnumerable<TResult>> ForEach<T, TResult>(this IEnumerable<T> sequence, Func<T, Task<TResult>> action)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), Resource.ArgumentNull_Generic);
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), Resource.ArgumentNull_Generic);
            }

            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            IList<TResult> results = new List<TResult>();
            foreach (T value in values)
            {
                results.Add(await action(value));
            }

            return results;
        }

        /// <summary>
        ///     对 <paramref name="sequence" /> 按照指定的单页元素数量进行分页，并且取指定的页码索引中的元素序列。第一页的页码索引为0。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">元素序列。</param>
        /// <param name="pageIndex">指定的页码索引。第一页的页码索引为0。</param>
        /// <param name="pageSize">指定的单页元素数量。</param>
        /// <returns>指定页码索引的元素序列。</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="sequence" /> 为 <c>null</c>。
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="pageIndex" /> 不能为负值。
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     <paramref name="pageSize" /> 不能为负值。
        /// </exception>
        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> sequence, int pageIndex, int pageSize)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), Resource.ArgumentNull_Generic);
            }

            if (pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, Resource.ArgumentOutOfRange_MustBeNonNegNum);
            }

            if (pageSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, Resource.ArgumentOutOfRange_MustBeNonNegNum);
            }

            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            return values.Skip(pageIndex * pageSize).Take(pageSize);
        }

        /// <summary>
        ///     指示 <paramref name="sequence" /> 是否不是 <c>null</c> 并且元素数量不为0。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">元素序列。</param>
        /// <returns> 如果 <paramref name="sequence" />不是 <c>null</c> 并且元素数量不为0，则返回 <c>true</c>；否则，返回<c>false</c>。</returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> sequence) => sequence?.Any() == true;

        /// <summary>
        ///     指示 <paramref name="sequence" /> 是否是 <c>null</c> 或者元素数量为0。
        /// </summary>
        /// <param name="sequence">元素序列。</param>
        /// <returns> 如果 <paramref name="sequence" />不是 <c>null</c> 并且元素数量不为0，则返回 <c>true</c>；否则，返回<c>false</c>。</returns>
        public static bool IsNotNullOrEmpty(this IEnumerable sequence) => sequence?.IsSequenceNullOrEmpty() == false;

        /// <summary>
        ///     指示 <paramref name="sequence" /> 是否是 <c>null</c> 或者元素数量为0。
        /// </summary>
        /// <param name="sequence">元素序列。</param>
        /// <returns> 如果 <paramref name="sequence" />是 <c>null</c> 或者元素数量为0，则返回 <c>true</c>；否则，返回<c>false</c>。</returns>
        public static bool IsNullOrEmpty(this IEnumerable sequence) => sequence?.IsSequenceNullOrEmpty() != false;

        /// <summary>
        ///     指示 <paramref name="sequence" /> 是否是 <c>null</c> 或者元素数量为0。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">元素序列。</param>
        /// <returns> 如果 <paramref name="sequence" />是 <c>null</c> 或者元素数量为0，则返回 <c>true</c>；否则，返回<c>false</c>。</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            if (sequence is ICollection<T> collection)
            {
                // We expect this to be the normal flow.
                return collection.Count == 0;
            }

            // We expect this to be the exceptional flow, because most collections implement
            // ICollection<T>.
            return sequence.IsSequenceNullOrEmpty();
        }

        /// <summary>
        ///     将 <paramref name="sequence" /> 拼接为一个字符串，并且使用 <paramref name="separator" /> 作为分隔符。如果 <paramref name="sequence" /> 为 <c>null</c>，则返回 <paramref name="nullValue" />。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">原元素序列。</param>
        /// <param name="separator">分隔符，默认为","。</param>
        /// <param name="nullValue">如果 <paramref name="sequence" /> 为 <c>null</c>，需要返回的值。</param>
        /// <returns> 拼接后的字符串。</returns>
        public static string Join<T>(this IEnumerable<T> sequence, string separator = ",", string nullValue = null)
        {
            separator ??= ",";
            return sequence == null ? nullValue : string.Join(separator, sequence);
        }

        /// <summary>
        ///     将 <paramref name="sequence" /> 转换为只读集合。
        /// </summary>
        /// <typeparam name="T"><paramref name="sequence" /> 中的元素类型。</typeparam>
        /// <param name="sequence">原元素序列。</param>
        /// <returns> 只读的集合。</returns>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), Resource.ArgumentNull_Generic);
            }

            return new ReadOnlyCollection<T>(sequence.ToList());
        }

        /// <summary>
        ///     返回一个可以表示集合内容的，并且可阅读性更强的字符串。如果集合为 <c>null</c>，则返回 "null" 或者 "[]"。
        /// </summary>
        /// <typeparam name="T"><paramref name="collection" /> 集合中元素的类型。</typeparam>
        /// <param name="collection">要描述的集合。</param>
        /// <param name="toString">可以指定的针对每个元素转换为字符串的方法。</param>
        /// <param name="separator">每个元素之间的分隔符，默认为", "。</param>
        /// <param name="putInBrackets">元素是否使用"[]"包裹。</param>
        /// <returns>可以表示集合的可阅读字符串。</returns>
        public static string ToString<T>(this IEnumerable<T> collection, Func<T, string> toString = null,
            string separator = ", ", bool putInBrackets = true)
        {
            if (collection == null)
            {
                return putInBrackets ? "[]" : "null";
            }

            StringBuilder sb = new StringBuilder();
            if (putInBrackets)
            {
                _ = sb.Append('[');
            }

            IEnumerator<T> enumerator = collection.GetEnumerator();
            bool firstDone = false;
            while (enumerator.MoveNext())
            {
                T value = enumerator.Current;
                string val;
                if (toString != null)
                {
                    val = toString(value);
                }
                else
                {
#pragma warning disable IDE0041 // Use 'is null' check

                    // ReSharper disable once PossibleNullReferenceException
                    val = ReferenceEquals(value, null) ? "null" : value.ToString();
#pragma warning restore IDE0041 // Use 'is null' check
                }

                if (firstDone)
                {
                    _ = sb.Append(separator);
                    _ = sb.Append(val);
                }
                else
                {
                    _ = sb.Append(val);
                    firstDone = true;
                }
            }

            if (putInBrackets)
            {
                _ = sb.Append("]");
            }

            return sb.ToString();
        }

        [ExcludeFromCodeCoverage]
        private static bool IsEnumerableEmpty(IEnumerable sequence)
        {
            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                return !enumerator.MoveNext();
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                disposable?.Dispose();
            }
        }

        [ExcludeFromCodeCoverage]
        private static bool IsSequenceNullOrEmpty(this IEnumerable sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            if (sequence is ICollection collection)
            {
                // We expect this to be the normal flow.
                return collection.Count == 0;
            }

            // We expect this to be the exceptional flow, because most collections implement ICollection.
            return IsEnumerableEmpty(sequence);
        }
    }
}

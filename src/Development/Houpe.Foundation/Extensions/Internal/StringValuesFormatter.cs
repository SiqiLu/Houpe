// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : StringValuesFormatter.cs
// CreatedAt        : 2020-05-10
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Houpe.Foundation.Internal
{
    /// <summary>
    ///     Formatter to convert the named format items like {NamedformatItem} to <see cref="M:string.Format" /> format.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class StringValuesFormatter
    {
        private readonly string _format;

        internal StringValuesFormatter(string format)
        {
            OriginalFormat = format;

            StringBuilder sb = new StringBuilder();
            int scanIndex = 0;
            int endIndex = format.Length; // 本文件中的代码，需要注意 endIndex 是 字符串的长度，比字符串最后一共 char 的 index 大 1

            while (scanIndex < endIndex)
            {
                int openBraceIndex = FindBraceIndex(format, '{', scanIndex, endIndex);
                int closeBraceIndex = FindBraceIndex(format, '}', openBraceIndex, endIndex);

                // Format item syntax : { index[,alignment][ :formatString] }.
                int formatDelimiterIndex = FindIndexOf(format, ',', openBraceIndex, closeBraceIndex);
                if (formatDelimiterIndex == closeBraceIndex)
                {
                    formatDelimiterIndex = FindIndexOf(format, ':', openBraceIndex, closeBraceIndex);
                }

                if (closeBraceIndex == endIndex)
                {
                    _ = sb.Append(format, scanIndex, endIndex - scanIndex);
                    scanIndex = endIndex;
                }
                else
                {
                    _ = sb.Append(format, scanIndex, openBraceIndex - scanIndex + 1);
                    _ = sb.Append(ValueNames.Count.ToString(CultureInfo.InvariantCulture));
                    ValueNames.Add(format.Substring(openBraceIndex + 1, formatDelimiterIndex - openBraceIndex - 1));
                    _ = sb.Append(format, formatDelimiterIndex, closeBraceIndex - formatDelimiterIndex + 1);

                    scanIndex = closeBraceIndex + 1;
                }
            }

            _format = sb.ToString();
        }

        private string OriginalFormat { get; }
        internal List<string> ValueNames { get; } = new List<string>();

        internal string Format(object[] values)
        {
            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    object value = values[i];

                    switch (value)
                    {
                        case null:
                            continue;
                        case string:
                            // since 'string' implements IEnumerable, special case it
                            continue;
                        case IEnumerable enumerable:
                            // if the value implements IEnumerable, build a comma separated string.
                            values[i] = string.Join(", ", enumerable.Cast<object>().Where(obj => obj != null));
                            break;
                    }
                }
            }
            else
            {
                values = new object[] { };
            }

            return string.Format(CultureInfo.InvariantCulture, _format, values);
        }

        internal KeyValuePair<string, object> GetValue(object[] values, int index)
        {
            if (index < 0 || index > ValueNames.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return ValueNames.Count > index
                ? new KeyValuePair<string, object>(ValueNames[index], values[index])
                : new KeyValuePair<string, object>("{OriginalFormat}", OriginalFormat);
        }

        internal IEnumerable<KeyValuePair<string, object>> GetValues(object[] values)
        {
            KeyValuePair<string, object>[] valueArray = new KeyValuePair<string, object>[values.Length + 1];
            for (int index = 0; index != ValueNames.Count; ++index)
            {
                valueArray[index] = new KeyValuePair<string, object>(ValueNames[index], values[index]);
            }

            valueArray[^1] = new KeyValuePair<string, object>("{OriginalFormat}", OriginalFormat);
            return valueArray;
        }

        private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex)
        {
            // 连续两个 '{' 或者 '}' 表示转义
            // Example: {{prefix{{{Argument}}}suffix}}.
            int braceIndex = endIndex;
            int scanIndex = startIndex;
            int braceOccurrenceCount = 0;

            while (scanIndex < endIndex)
            {
                // 处理转义
                if (braceOccurrenceCount > 0 && format[scanIndex] != brace)
                {
                    if (braceOccurrenceCount % 2 == 0)
                    {
                        // Even number of '{' or '}' found. Proceed search with next occurrence of '{' or '}'.
                        braceOccurrenceCount = 0;
                        braceIndex = endIndex;
                    }
                    else
                    {
                        // An unescaped '{' or '}' found. // 找到的是非转义的 '{' 或者 '}'
                        break;
                    }
                }
                else if (format[scanIndex] == brace) // An '{' or '}' found.
                {
                    if (brace == '}') // '}' found.
                    {
                        if (braceOccurrenceCount == 0)
                        {
                            // For '}' pick the first occurrence.
                            braceIndex = scanIndex;
                        }
                    }
                    else
                    {
                        // For '{' pick the last occurrence.
                        braceIndex = scanIndex;
                    }

                    braceOccurrenceCount++;
                }

                scanIndex++;
            }

            return braceIndex;
        }

        private static int FindIndexOf(string format, char ch, int startIndex, int endIndex)
        {
            int findIndex = format.IndexOf(ch, startIndex, endIndex - startIndex);
            return findIndex == -1 ? endIndex : findIndex;
        }
    }
}

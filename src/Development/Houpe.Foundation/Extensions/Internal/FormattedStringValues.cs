// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : FormattedStringValues.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Houpe.Foundation.Internal;

[ExcludeFromCodeCoverage]
internal class FormattedStringValues : IReadOnlyList<KeyValuePair<string, object?>>
{
    private static readonly ConcurrentDictionary<string, StringValuesFormatter> s_formatters = new ConcurrentDictionary<string, StringValuesFormatter>();
    private readonly StringValuesFormatter? _formatter;
    private readonly string _originalMessage;
    private readonly object?[] _values;

    internal FormattedStringValues(string format, params object?[] values)
    {
        ArgumentNullException.ThrowIfNull(format);

        if (values.Length != 0)
        {
            _formatter = s_formatters.GetOrAdd(format, f => new StringValuesFormatter(f));
        }

        _originalMessage = format;
        _values = values;
    }

    #region IReadOnlyList<KeyValuePair<string,object?>> Members

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        for (int i = 0; i < Count; ++i)
        {
            yield return this[i];
        }
    }

    public int Count
    {
        get
        {
            if (_formatter == null)
            {
                return 1;
            }

            return _formatter.ValueNames.Count + 1;
        }
    }

    public KeyValuePair<string, object?> this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return index == Count - 1 || _formatter is null
                ? new KeyValuePair<string, object?>("{OriginalFormat}", _originalMessage)
                : _formatter.GetValue(_values, index);
        }
    }

    #endregion

    public override string ToString() => _formatter is null ? _originalMessage : _formatter.Format(_values);
}

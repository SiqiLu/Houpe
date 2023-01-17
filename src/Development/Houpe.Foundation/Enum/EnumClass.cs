// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : EnumClass.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Runtime.CompilerServices;

namespace Houpe.Foundation;

/// <summary>
///     枚举类型的基础类。本类型为抽象类型不能实例化。
/// </summary>
public abstract class EnumClass : IEquatable<EnumClass>, IComparable<EnumClass>
{
    /// <summary>
    ///     使用指定的枚举代码和指定的枚举值初始化 <see cref="EnumClass" /> 实例。
    ///     每次初始化 <see cref="EnumClass" /> 实例，该实例就会被认为是合法的枚举值。
    /// </summary>
    /// <param name="code">指定的枚举代码。</param>
    /// <param name="value">指定的枚举值。</param>
    protected EnumClass(int code, string value)
    {
        Code = code;
        Value = value;
    }

    /// <summary>
    ///     枚举代码。
    /// </summary>
    public int Code { get; }

    /// <summary>
    ///     枚举值。
    /// </summary>
    public string Value { get; }

    #region IComparable<EnumClass> Members

    /// <summary>将此实例与指定的 <see cref="EnumClass" /> 实例进行比较，并指示此实例在排序顺序中是位于指定的 <see cref="EnumClass" /> 实例之前、之后还是与其出现在同一位置。</summary>
    /// <returns>一个 32 位带符号整数，该整数指示此实例在排序顺序中是位于 <paramref name="other" /> 参数之前、之后还是与其出现在同一位置。</returns>
    /// <param name="other">要与此实例进行比较的 <see cref="EnumClass" /> 实例。</param>
    public int CompareTo(EnumClass? other) => other is null ? 1 : Code.CompareTo(other.Code);

    #endregion

    #region IEquatable<EnumClass> Members

    /// <summary>确定指定的 <see cref="EnumClass" /> 实例是否等于当前实例。</summary>
    /// <returns>如果指定的 <see cref="EnumClass" /> 实例等于当前实例，则为 true；否则为 false。</returns>
    /// <param name="other">要与当前实例进行比较的 <see cref="EnumClass" /> 实例。</param>
    public bool Equals(EnumClass? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Code == other.Code;
    }

    #endregion

    /// <summary>确定指定的 <see cref="object" /> 对象是否等于当前实例。</summary>
    /// <returns>如果指定的 <see cref="object" /> 对象等于当前实例，则为 true；否则为 false。</returns>
    /// <param name="obj">要与当前实例进行比较的 <see cref="object" /> 对象。</param>
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        EnumClass? e = obj as EnumClass;
        return e is not null && Equals(e);
    }

    /// <summary>用作默认哈希函数。</summary>
    /// <returns>当前对象的哈希代码。此处返回的是当前实例的 <see cref="EnumClass.Code" /> 值。</returns>
    public override int GetHashCode() => Code;

    /// <summary>返回表示当前对象的字符串。</summary>
    /// <returns>表示当前对象的字符串。此处返回的是当前实例的 <see cref="EnumClass.Value" /> 值。</returns>
    public override string ToString() => Value;

    /// <summary>
    ///     如果操作数相等， == 运算符返回 true，否则返回 false。
    /// </summary>
    /// <param name="left">要进行比较的左边的 <see cref="EnumClass" /> 实例。</param>
    /// <param name="right">要进行比较的右边的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>如果左边的 <see cref="EnumClass" /> 实例等于左边的 <see cref="EnumClass" /> 实例，则为 true；否则为 false。</returns>
    public static bool operator ==(EnumClass? left, EnumClass? right)
    {
        if (ReferenceEquals(left, right))
        {
            // include left is null && right is null
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Code == right.Code;
    }

    /// <summary>
    ///     如果左侧操作数大于右侧操作数，> 运算符返回 true，否则返回 false。
    /// </summary>
    /// <param name="left">要进行比较的左边的 <see cref="EnumClass" /> 实例。</param>
    /// <param name="right">要进行比较的右边的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>如果左边的 <see cref="EnumClass" /> 实例大于左边的 <see cref="EnumClass" /> 实例，则为 true；否则为 false。</returns>
    public static bool operator >(EnumClass? left, EnumClass? right)
    {
        if (left is null && right is null)
        {
            return false;
        }

        if (left is null)
        {
            return false;
        }

        if (right is null)
        {
            return true;
        }

        return left.Code > right.Code;
    }

    /// <summary>
    ///     如果左侧操作数大于或等于右侧操作数，>= 运算符返回 true，否则返回 false。
    /// </summary>
    /// <param name="left">要进行比较的左边的 <see cref="EnumClass" /> 实例。</param>
    /// <param name="right">要进行比较的右边的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>如果左边的 <see cref="EnumClass" /> 实例大于或等于左边的 <see cref="EnumClass" /> 实例，则为 true；否则为 false。</returns>
    public static bool operator >=(EnumClass? left, EnumClass? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null)
        {
            return false;
        }

        if (right is null)
        {
            return true;
        }

        return left.Code >= right.Code;
    }

    /// <summary>
    ///     定义从 <see cref="EnumClass" /> 到 <see cref="string" /> 的隐式转换。
    /// </summary>
    /// <param name="e">转换的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>隐式转换后的 <see cref="string" /> 实例。</returns>
    public static implicit operator string(EnumClass e) => e.Value;

    /// <summary>
    ///     定义从 <see cref="EnumClass" /> 到 <see cref="int" /> 的隐式转换。
    /// </summary>
    /// <param name="e">转换的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>隐式转换后的 <see cref="int" /> 实例。</returns>
    public static implicit operator int(EnumClass e) => e.Code;

    /// <summary>
    ///     如果左侧操作数不等于右侧操作数，>= 运算符返回 true，否则返回 false。
    /// </summary>
    /// <param name="left">要进行比较的左边的 <see cref="EnumClass" /> 实例。</param>
    /// <param name="right">要进行比较的右边的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>如果左边的 <see cref="EnumClass" /> 实例不等于左边的 <see cref="EnumClass" /> 实例，则为 true；否则为 false。</returns>
    public static bool operator !=(EnumClass? left, EnumClass? right) => !(left == right);

    /// <summary>
    ///     如果左侧操作数小于右侧操作数，&lt; 运算符返回 true，否则返回 false。
    /// </summary>
    /// <param name="left">要进行比较的左边的 <see cref="EnumClass" /> 实例。</param>
    /// <param name="right">要进行比较的右边的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>如果左边的 <see cref="EnumClass" /> 实例小于左边的 <see cref="EnumClass" /> 实例，则为 true；否则为 false。</returns>
    public static bool operator <(EnumClass? left, EnumClass? right)
    {
        if (left is null && right is null)
        {
            return false;
        }

        if (left is null)
        {
            return true;
        }

        if (right is null)
        {
            return false;
        }

        return left.Code < right.Code;
    }

    /// <summary>
    ///     如果左侧操作数小于或等于右侧操作数，&lt; 运算符返回 true，否则返回 false。
    /// </summary>
    /// <param name="left">要进行比较的左边的 <see cref="EnumClass" /> 实例。</param>
    /// <param name="right">要进行比较的右边的 <see cref="EnumClass" /> 实例。</param>
    /// <returns>如果左边的 <see cref="EnumClass" /> 实例或等于左边的 <see cref="EnumClass" /> 实例，则为 true；否则为 false。</returns>
    public static bool operator <=(EnumClass? left, EnumClass? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null)
        {
            return true;
        }

        if (right is null)
        {
            return false;
        }

        return left.Code <= right.Code;
    }
}

/// <summary>
///     枚举类型的基础类。本类型为抽象类型不能实例化。
/// </summary>
/// <typeparam name="T">枚举的类型。</typeparam>
public class EnumClass<T> : EnumClass, IEquatable<EnumClass<T>>, IEquatable<T> where T : EnumClass
{
    private static readonly Dictionary<int, T> s_codes = new Dictionary<int, T>();
    private static readonly Dictionary<string, T> s_values = new Dictionary<string, T>();
    private static T? s_default;

    static EnumClass()
    {
        // 运营 T 的构造器，T 必须在构造器中初始化枚举的初始合法值。如果有需要还需要设置默认枚举值。
        Type type = typeof(T);
        RuntimeHelpers.RunClassConstructor(type.TypeHandle);
    }

    /// <inheritdoc />
    protected EnumClass(int code, string value) : base(code, value)
    {
    }

    /// <summary>
    ///     枚举的默认实例。
    /// </summary>
    public static T? Default
    {
        get
        {
            if (s_default != null)
            {
                return s_default;
            }

            if (s_codes.TryGetValue(0, out T? value))
            {
                return value;
            }

            return null;
        }
        private set => s_default = value;
    }

    #region IEquatable<EnumClass<T>> Members

    /// <summary>确定指定的 <see cref="EnumClass{T}" /> 实例是否等于当前实例。</summary>
    /// <returns>如果指定的 <see cref="EnumClass{T}" /> 实例等于当前实例，则为 true；否则为 false。</returns>
    /// <param name="other">要与当前实例进行比较的 <see cref="EnumClass{T}" /> 实例。</param>
    public bool Equals(EnumClass<T>? other) => Equals(other as T);

    #endregion

    #region IEquatable<T> Members

    /// <summary>确定指定的枚举实例是否等于当前实例。</summary>
    /// <returns>如果指定的枚举实例实例等于当前实例，则为 true；否则为 false。</returns>
    /// <param name="other">要与当前实例进行比较的枚举实例实例。</param>
    public bool Equals(T? other) => Equals(other as EnumClass);

    #endregion

    /// <summary>
    ///     确定当前实例的枚举值是否是默认的枚举实例。即当前实例的枚举代码是否为 0。
    /// </summary>
    /// <returns>如果是则为 true；否则为 false。</returns>
    public virtual bool IsDefault() => Equals(Default);

    /// <summary>
    ///     获得指定的枚举代码所代表的枚举实例。
    /// </summary>
    /// <param name="code">指定的枚举代码。</param>
    /// <returns></returns>
    /// <exception cref="InvalidEnumCodeException">
    ///     <paramref name="code" /> 不是合法的枚举代码。
    /// </exception>
    public static T Get(int code)
    {
        if (s_codes.TryGetValue(code, out T? t))
        {
            return t;
        }

        throw new InvalidEnumCodeException(code, typeof(T));
    }

    /// <summary>
    ///     获得指定的枚举值所代表的枚举实例。
    /// </summary>
    /// <param name="value">指定的枚举值。</param>
    /// <returns></returns>
    /// <exception cref="InvalidEnumValueException">
    ///     <paramref name="value" /> 不是合法的枚举值。
    /// </exception>
    public static T Get(string value)
    {
        if (s_values.TryGetValue(value, out T? t))
        {
            return t;
        }

        throw new InvalidEnumValueException(value, typeof(T));
    }

    /// <summary>
    ///     确定指定的枚举代码是否是合法的枚举代码。
    /// </summary>
    /// <param name="code">指定的枚举代码。</param>
    /// <returns>如果是则为 true；否则为 false。</returns>
    public static bool IsAvailableCode(int code) => s_codes.ContainsKey(code);

    /// <summary>
    ///     确定指定的枚举值是否是合法的枚举值。
    /// </summary>
    /// <param name="value">指定的枚举实例。</param>
    /// <returns>如果是则为 true；否则为 false。</returns>
    public static bool IsAvailableValue(string value) => s_values.ContainsKey(value);

    /// <summary>
    ///     使用加法将两个枚举实例进行组合，即将两个枚举实例的代码相加，得出新代码对应的新枚举实例。
    ///     只适用于经过特殊设计的枚举。如果组合后的不合法，会导致异常。
    /// </summary>
    /// <param name="left">组合中的左边的枚举实例。</param>
    /// <param name="right">组合中的右边的枚举实例。</param>
    /// <returns>组合后的新枚举实例。</returns>
    /// <exception cref="InvalidEnumCodeException" />
    public static T operator +(EnumClass<T> left, EnumClass<T> right) => Get(left.Code + right.Code);

    /// <summary>
    ///     使用减法将两个枚举实例进行组合，即将两个枚举实例的代码相减，得出新代码对应的新枚举实例。
    ///     只适用于经过特殊设计的枚举。如果组合后的不合法，会导致异常。
    /// </summary>
    /// <param name="left">组合中的左边的枚举实例。</param>
    /// <param name="right">组合中的右边的枚举实例。</param>
    /// <returns>组合后的新枚举实例。</returns>
    /// <exception cref="InvalidEnumCodeException" />
    public static T operator -(EnumClass<T> left, EnumClass<T> right) => Get(left.Code - right.Code);

    /// <summary>
    ///     尝试解析出指定的枚举代码所代表的枚举实例。
    /// </summary>
    /// <param name="code">指定的枚举代码。</param>
    /// <param name="enumValue">如果指定的枚举代码是合法的枚举代码，则获得相应的合法枚举实例，否则为 <c>null</c>。</param>
    /// <returns>如果解析出合法枚举实例则为 true；否则为 false。</returns>
    public static bool Parse(int code, out T? enumValue) => s_codes.TryGetValue(code, out enumValue);

    /// <summary>
    ///     尝试解析出指定的枚举值所代表的枚举实例。
    /// </summary>
    /// <param name="value">指定的枚举值。</param>
    /// <param name="enumValue">如果指定的枚举值是合法的枚举值，则获得相应的合法枚举实例，否则为 <c>null</c>。</param>
    /// <returns>如果解析出合法枚举实例则为 true；否则为 false。</returns>
    public static bool Parse(string? value, out T? enumValue)
    {
        if (value is null)
        {
            enumValue = null;
            return false;
        }

        return s_values.TryGetValue(value, out enumValue);
    }

    /// <summary>
    ///     初始化枚举实例，并且将之后出现的与该枚举实例相等的枚举实例均视为合法的枚举实例。
    ///     只能在枚举类的静态构造函数中使用。否则会因为枚举实例初始化时间早于使用时间而导致异常。
    /// </summary>
    /// <param name="enumValue">需要初始化和合法化的枚举实例。</param>
    protected static T Initialize(T enumValue)
    {
        s_codes[enumValue.Code] = enumValue;
        s_values[enumValue.Value] = enumValue;
        return enumValue;
    }

    /// <summary>
    ///     改变默认的枚举实例。
    /// </summary>
    /// <param name="defaultEnum"></param>
    protected static T SetDefaultEnum(T defaultEnum)
    {
        Default = Initialize(defaultEnum);
        return Default;
    }
}

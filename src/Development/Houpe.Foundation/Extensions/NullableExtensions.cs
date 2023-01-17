// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : NullableExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

namespace Houpe.Foundation;

/// <summary>
///     <see cref="System.Nullable" /> 的扩展类。
/// </summary>
public static class NullableExtensions
{
    /// <summary>
    ///     判断指定的 <see cref="Nullable" /> 是否是 <c>false</c>。
    /// </summary>
    /// <param name="b">要测试的 nullable 对象。</param>
    /// <returns>如果 <paramref name="b" /> 是 <c>false</c>，则为 <c>true</c>；否则为 <c>false</c>。</returns>
    public static bool IsFalse(this bool? b) => !b.GetValueOrDefault(true);

    /// <summary>
    ///     判断指定的 <see cref="Nullable" /> 是否是 <c>false</c> 或者 <c>null</c>。
    /// </summary>
    /// <param name="b">要测试的 nullable 对象。</param>
    /// <returns>如果 <paramref name="b" /> 是 <c>false</c> 或者 <c>null</c>，则为 <c>true</c>；否则为 <c>false</c>。</returns>
    public static bool IsFalseOrNull(this bool? b) => !b.GetValueOrDefault(false);

    /// <summary>
    ///     判断指定的 <see cref="Nullable" /> 是否是 <c>true</c>。
    /// </summary>
    /// <param name="b">要测试的 nullable 对象。</param>
    /// <returns>如果 <paramref name="b" /> <c>true</c>，则为 <c>true</c>；否则为 <c>false</c>。</returns>
    public static bool IsTrue(this bool? b) => b.GetValueOrDefault(false);

    /// <summary>
    ///     判断指定的 <see cref="Nullable" /> 是否是 <c>true</c> 或者 <c>null</c>。
    /// </summary>
    /// <param name="b">要测试的 nullable 对象。</param>
    /// <returns>如果 <paramref name="b" /> 是 <c>true</c> 或者 <c>null</c>，则为 <c>true</c>；否则为 <c>false</c>。</returns>
    public static bool IsTrueOrNull(this bool? b) => b.GetValueOrDefault(true);
}

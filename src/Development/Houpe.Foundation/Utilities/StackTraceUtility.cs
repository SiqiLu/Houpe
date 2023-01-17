// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : StackTraceUtility.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Houpe.Foundation;

/// <summary>
///     StackTraceUtility
/// </summary>
public static class StackTraceUtility
{
    /// <summary>
    ///     获取当前正在执行的方法所在类的名称。
    /// </summary>
    /// <returns>当前正在执行的方法所在类的名称。</returns>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetCurrentClassName(int frameIndex = 1)
    {
        StackTrace st = new StackTrace();
        StackFrame? sf = st.GetFrame(frameIndex);

        return sf?.GetMethod()?.ReflectedType?.FullName ??
               sf?.GetMethod()?.DeclaringType?.FullName ?? sf?.GetFileName() ?? "";
    }

    /// <summary>
    ///     获取当前正在执行的方法的名称。
    /// </summary>
    /// <returns>当前正在执行的方法的名称。</returns>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetCurrentMethodName(int frameIndex = 1)
    {
        StackTrace st = new StackTrace();
        StackFrame? sf = st.GetFrame(frameIndex);

        return sf?.GetMethod()?.Name ?? "";
    }
}

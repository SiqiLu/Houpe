// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : UriUtility.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Houpe.Foundation;

/// <summary>
///     UrlUtility
/// </summary>
public static class UriUtility
{
    /// <summary>
    ///     将两个Url字符串拼接起来，并且返回 <see cref="System.Uri" /> 实例。
    /// </summary>
    /// <param name="path1">第一个Url的字符串。</param>
    /// <param name="path2">第二个Url的字符串。</param>
    /// <returns>拼接后的<see cref="System.Uri" /> 实例。</returns>
    [SuppressMessage("Style", "IDE0018:Inline variable declaration", Justification = "<Pending>")]
    [SuppressMessage("ReSharper", "InlineOutVariableDeclaration")]
    [SuppressMessage("ReSharper", "MergeSequentialChecksWhenPossible")]
    public static Uri? CombineUrlPaths(string? path1, string? path2)
    {
        char[] uriTrimChars = { '/', '\\', '.', '~' };
        Uri? current;

        if (Uri.TryCreate(path1?.Trim().TrimEnd(uriTrimChars), UriKind.Absolute, out current))
        {
            if (path2 is not null && path2.IsNotNullOrWhiteSpace() && Uri.TryCreate(path2.Trim().TrimStart(uriTrimChars), UriKind.Relative, out Uri? relativeUri))
            {
                string combinedPath = current.ToString().TrimEnd(uriTrimChars) + "/" + relativeUri.ToString().TrimStart(uriTrimChars);
                if (Uri.TryCreate(combinedPath, UriKind.Absolute, out Uri? combinedResult))
                {
                    current = combinedResult;
                }
            }
        }
        else
        {
            bool _ = Uri.TryCreate(path2, UriKind.Absolute, out current);
        }

        return current;
    }

    /// <summary>
    ///     将若干个个Url字符串拼接起来，并且返回 <see cref="System.Uri" /> 实例。
    /// </summary>
    /// <param name="paths">需要拼接Url的所有字符串的数组。</param>
    /// <returns>拼接后的<see cref="System.Uri" /> 实例。</returns>
    public static Uri? CombineUrlPaths(params string?[] paths)
    {
        if (paths.IsNullOrEmpty())
        {
            return null;
        }

        Uri? result;

        if (paths.Length == 1)
        {
            result = CombineUrlPaths(paths[0], string.Empty);
        }
        else
        {
            result = CombineUrlPaths(paths[0], paths[1]);
            for (int i = 2; i < paths.Length; i++)
            {
                result = CombineUrlPaths(result?.ToString(), paths[i]);
            }
        }

        return result;
    }
}

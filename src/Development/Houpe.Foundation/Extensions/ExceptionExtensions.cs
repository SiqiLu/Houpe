// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ExceptionExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace Houpe.Foundation;

/// <summary>
///     <see cref="System.Exception" /> 的扩展类。
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    ///     将 <see cref="System.Reflection.ReflectionTypeLoadException" /> 转换为 <see cref="System.AggregateException" />
    /// </summary>
    public static void FlattenToAggregateException(this ReflectionTypeLoadException exception)
    {
        // if ReflectionTypeLoadException is thrown, we need to provide the
        // LoaderExceptions property in order to make it meaningful.
        List<Exception> all = new List<Exception> { exception };
        exception.LoaderExceptions.ForEach(e =>
        {
            if (e is not null)
            {
                all.Add(e);
            }
        });

        // ReSharper disable once BadParensLineBreaks
        throw new AggregateException(
            "A ReflectionTypeLoadException has been thrown. The original exception and the contents of the LoaderExceptions property have been aggregated for your convenience.",
            all);
    }

    /// <summary>
    ///     获取 <see cref="System.Exception" /> 的详细错误信息。
    /// </summary>
    public static string GetExceptionInformation(this Exception exception)
    {
        StringBuilder sb = new StringBuilder();
        CreateExceptionString(sb, exception);
        return sb.ToString();
    }

    [ExcludeFromCodeCoverage]
    private static void CreateExceptionString(StringBuilder? sb, Exception exception)
    {
        sb ??= new StringBuilder();

        while (true)
        {
            ArgumentNullException.ThrowIfNull(exception);

            if (sb.Length > 0)
            {
                _ = sb.AppendLine("Inner Exception(s) Found:");
            }

            _ = sb.AppendLine($"Type: {exception.GetType().FullName}");
            _ = sb.AppendLine($"Message: {exception.Message}");
            _ = sb.AppendLine($"DataJson: {exception.Data.ToJson("\\N", JsonOptions.LogJsonOptions)}");
            _ = sb.AppendLine("Stacktrace:");
            _ = sb.AppendLine($"{exception.StackTrace}");

            if (exception is ReflectionTypeLoadException loadException)
            {
                Exception?[] loaderExceptions = loadException.LoaderExceptions;
                if (loaderExceptions.Length == 0)
                {
                    _ = sb.AppendLine("No LoaderExceptions found.");
                }
                else
                {
                    foreach (Exception? e in loaderExceptions)
                    {
                        if (e is not null)
                        {
                            CreateExceptionString(sb, e);
                        }
                    }
                }
            }
            else if (exception is AggregateException aggregateException)
            {
                ReadOnlyCollection<Exception> innerExceptions = aggregateException.InnerExceptions;
                if (innerExceptions.Count == 0)
                {
                    _ = sb.AppendLine("No InnerExceptions found.");
                }
                else
                {
                    foreach (Exception e in innerExceptions)
                    {
                        CreateExceptionString(sb, e);
                    }
                }
            }
            else if (exception.InnerException != null)
            {
                _ = sb.AppendLine();
                exception = exception.InnerException;
                continue;
            }

            break;
        }
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : RegexConstants.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Text.RegularExpressions;

namespace Houpe.Foundation;

/// <summary>
///     RegexConstants
/// </summary>
public static class RegexConstants
{
    /// <summary>
    ///     BankCardRegex
    /// </summary>
    public static readonly Regex BankCardRegex = new Regex(Constants.BankCardRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     CellphoneRegex
    /// </summary>
    public static readonly Regex CMCellphoneRegex = new Regex(Constants.CMCellphoneRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     ComplexPasswordRegex
    /// </summary>
    public static readonly Regex ComplexPasswordRegex =
        new Regex(Constants.ComplexPasswordRegexString, RegexOptions.ExplicitCapture | RegexOptions.Compiled, TimeSpan.FromMinutes(2));

    /// <summary>
    ///     DateStringRegex
    /// </summary>
    public static readonly Regex DateStringRegex = new Regex(Constants.DateRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     DateTimeRegex
    /// </summary>
    public static readonly Regex DateTimeRegex = new Regex(Constants.DateTimeRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     EmailRegex
    /// </summary>
    public static readonly Regex EmailRegex = new Regex(Constants.EmailRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     IDCardRegex
    /// </summary>
    public static readonly Regex IDCardRegex = new Regex(Constants.IdCardRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     IPAddressRegex
    /// </summary>
    public static readonly Regex IPAddressRegex = new Regex(Constants.IpAddressRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     NumericPasswordRegex
    /// </summary>
    public static readonly Regex NumericPasswordRegex = new Regex(Constants.NumericPasswordRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     PositiveNumberRegex
    /// </summary>
    public static readonly Regex PositiveNumberRegex = new Regex(Constants.PositiveNumberRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     PositiveNumberWithZeroRegex
    /// </summary>
    public static readonly Regex PositiveNumberWithZeroRegex = new Regex(Constants.PositiveNumberWithZeroRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));

    /// <summary>
    ///     SimplePasswordRegex
    /// </summary>
    public static readonly Regex SimplePasswordRegex =
        new Regex(Constants.SimplePasswordRegexString, RegexOptions.ExplicitCapture | RegexOptions.Compiled, TimeSpan.FromMinutes(2));

    /// <summary>
    ///     UrlRegex
    /// </summary>
    public static readonly Regex UrlRegex = new Regex(Constants.UrlRegexString,
        RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled,
        TimeSpan.FromMinutes(2));
}

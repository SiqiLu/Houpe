// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : IProperty.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic;

/// <summary>
///     Simple abstraction to make field and property access consistent
/// </summary>
public interface IProperty
{
    string Name { get; }

    Type PropertyType { get; }

    object? GetValue(object obj, object?[]? index);

    void SetValue(object obj, object? val, object?[]? index);
}

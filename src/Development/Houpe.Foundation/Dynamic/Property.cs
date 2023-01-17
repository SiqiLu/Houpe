// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Property.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic;

public static class PropertyInfoExtensions
{
    public static IProperty ToIProperty(this PropertyInfo info) => new Property { PropertyInfo = info };
}

public class Property : IProperty
{
    public required PropertyInfo PropertyInfo { get; init; }

    #region IProperty Members

    public object? GetValue(object obj, object?[]? index) => PropertyInfo.GetValue(obj, index);

    public string Name => PropertyInfo.Name;

    public Type PropertyType => PropertyInfo.PropertyType;

    public void SetValue(object obj, object? val, object?[]? index) => PropertyInfo.SetValue(obj, val, index);

    #endregion
}

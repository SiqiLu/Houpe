// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Field.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic;

public static class FieldInfoExtensions
{
    public static IProperty ToIProperty(this FieldInfo info) => new Field { FieldInfo = info };
}

public class Field : IProperty
{
    public required FieldInfo FieldInfo { get; init; }

    #region IProperty Members

    public object? GetValue(object obj, object?[]? index) => FieldInfo.GetValue(obj);

    public string Name => FieldInfo.Name;

    public Type PropertyType => FieldInfo.FieldType;

    public void SetValue(object obj, object? val, object?[]? index) => FieldInfo.SetValue(obj, val);

    #endregion
}

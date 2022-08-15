// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : IProperty.cs
// CreatedAt        : 2020-11-28
// LastModifiedAt   : 2021-04-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic
{
    /// <summary>
    ///     Simple abstraction to make field and property access consistent
    /// </summary>
    public interface IProperty
    {
        string Name { get; }

        Type PropertyType { get; }

        object GetValue(object obj, object[] index);

        void SetValue(object obj, object val, object[] index);
    }
}

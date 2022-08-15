// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Property.cs
// CreatedAt        : 2020-11-28
// LastModifiedAt   : 2021-04-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic
{
    public static class PropertyInfoExtensions
    {
        public static IProperty ToIProperty(this PropertyInfo info) => new Property { PropertyInfo = info };
    }

    public class Property : IProperty
    {
        internal PropertyInfo PropertyInfo { get; set; }

        #region IProperty Members

        public string Name => PropertyInfo.Name;

        public Type PropertyType => PropertyInfo.PropertyType;

        public object GetValue(object obj, object[] index) => PropertyInfo.GetValue(obj, index);

        public void SetValue(object obj, object val, object[] index) => PropertyInfo.SetValue(obj, val, index);

        #endregion
    }
}

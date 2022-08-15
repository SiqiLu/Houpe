// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : Field.cs
// CreatedAt        : 2020-11-28
// LastModifiedAt   : 2021-04-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic
{
    public static class FieldInfoExtensions
    {
        public static IProperty ToIProperty(this FieldInfo info) => new Field { FieldInfo = info };
    }

    public class Field : IProperty
    {
        internal FieldInfo FieldInfo { get; set; }

        #region IProperty Members

        public string Name => FieldInfo.Name;

        public Type PropertyType => FieldInfo.FieldType;

        public object GetValue(object obj, object[] index) => FieldInfo.GetValue(obj);

        public void SetValue(object obj, object val, object[] index) => FieldInfo.SetValue(obj, val);

        #endregion
    }
}

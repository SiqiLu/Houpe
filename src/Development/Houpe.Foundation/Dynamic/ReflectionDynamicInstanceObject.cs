// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ReflectionDynamicInstanceObject.cs
// CreatedAt        : 2020-11-28
// LastModifiedAt   : 2021-04-05
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic
{
    public class ReflectionDynamicInstanceObject : ReflectionDynamicObjectBase
    {
        private static readonly IDictionary<Type, IDictionary<string, IProperty>> s_propertiesOnType = new ConcurrentDictionary<Type, IDictionary<string, IProperty>>();
        private readonly object _instance;

        public ReflectionDynamicInstanceObject(object instance) => _instance = instance;

        public override object RealObject => Instance;

        internal override IDictionary<Type, IDictionary<string, IProperty>> PropertiesOnType => s_propertiesOnType;

        protected override BindingFlags BindingFlags => BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        protected override object Instance => _instance;

        // For instance calls, we get the type from the instance
        protected override Type TargetType => _instance.GetType();
    }
}

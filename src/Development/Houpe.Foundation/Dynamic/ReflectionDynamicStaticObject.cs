// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ReflectionDynamicStaticObject.cs
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
    public class ReflectionDynamicStaticObject : ReflectionDynamicObjectBase
    {
        private static readonly IDictionary<Type, IDictionary<string, IProperty>> s_propertiesOnType = new ConcurrentDictionary<Type, IDictionary<string, IProperty>>();

        public ReflectionDynamicStaticObject(Type type) => TargetType = type;

        public override object RealObject => TargetType;

        internal override IDictionary<Type, IDictionary<string, IProperty>> PropertiesOnType => s_propertiesOnType;

        protected override BindingFlags BindingFlags => BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        protected override object Instance => null;

        // For static calls, we have the type and the instance is always null
        protected override Type TargetType { get; }

        public dynamic New(params object[] args) =>
            Activator.CreateInstance(TargetType, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, args, null).AsDynamic();
    }
}

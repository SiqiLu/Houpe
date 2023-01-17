// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ReflectionDynamicStaticObject.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Collections.Concurrent;
using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic;

public class ReflectionDynamicStaticObject : ReflectionDynamicObjectBase
{
    private static readonly IDictionary<Type, IDictionary<string, IProperty>> s_propertiesOnType = new ConcurrentDictionary<Type, IDictionary<string, IProperty>>();

    public ReflectionDynamicStaticObject(Type type)
    {
        Instance = new object();
        TargetType = type;
    }

    public ReflectionDynamicStaticObject(object instance, Type type)
    {
        Instance = instance;
        TargetType = type;
    }

    protected override BindingFlags BindingFlags => BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    protected override object Instance { get; }

    internal override IDictionary<Type, IDictionary<string, IProperty>> PropertiesOnType => s_propertiesOnType;

    public override object RealObject => TargetType;

    // For static calls, we have the type and the instance is always null
    protected override Type TargetType { get; }

    public dynamic? New(params object[] args) =>
        Activator.CreateInstance(TargetType, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, args, null).AsDynamic();
}

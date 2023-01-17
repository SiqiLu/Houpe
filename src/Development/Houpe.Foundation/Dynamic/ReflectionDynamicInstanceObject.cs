// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ReflectionDynamicInstanceObject.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using System.Collections.Concurrent;
using System.Reflection;

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic;

public class ReflectionDynamicInstanceObject : ReflectionDynamicObjectBase
{
    private static readonly IDictionary<Type, IDictionary<string, IProperty>> s_propertiesOnType = new ConcurrentDictionary<Type, IDictionary<string, IProperty>>();
    private readonly object _instance;

    public ReflectionDynamicInstanceObject(object instance) => _instance = instance;

    protected override BindingFlags BindingFlags => BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    protected override object Instance => _instance;

    internal override IDictionary<Type, IDictionary<string, IProperty>> PropertiesOnType => s_propertiesOnType;

    public override object RealObject => Instance;

    // For instance calls, we get the type from the instance
    protected override Type TargetType => _instance.GetType();
}

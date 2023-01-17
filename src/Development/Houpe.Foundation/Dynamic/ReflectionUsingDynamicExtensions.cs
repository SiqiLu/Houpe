// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ReflectionUsingDynamicExtensions.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-12
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

#pragma warning disable 1591

namespace Houpe.Foundation.Dynamic;

public static class ReflectionUsingDynamicExtensions
{
    public static dynamic? AsDynamic(this object? o)
    {
        // Don't wrap primitive types, which don't have many interesting internal APIs
        // The primitive types are Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64,
        // UInt64, IntPtr, UIntPtr, Char, Double, and Single.

        // ReSharper disable once MergeSequentialChecksWhenPossible
        if (o == null || o.GetType().IsPrimitive || o is string || o is ReflectionDynamicObjectBase)
        {
            return o;
        }

        return new ReflectionDynamicInstanceObject(o);
    }

    // Type => ReflectionDynamicStaticObject
    public static dynamic AsDynamicType(this Type type) => new ReflectionDynamicStaticObject(type);
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : ValueObject.cs
// CreatedAt        : 2021-07-14
// LastModifiedAt   : 2021-07-14
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;

namespace Houpe.Foundation.Domain
{
    /// <summary>
    ///     ValueObject
    /// </summary>
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public abstract class ValueObject<T> : IEquatable<T>
    {
        #region IEquatable<T> Members

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><c>true</c> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
        public abstract bool Equals(T other);

        #endregion

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public abstract override int GetHashCode();

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((T)obj);
        }

        /// <summary>
        ///     Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><c>true</c> if the objects are considered equal; otherwise, <c>false</c>. If both <paramref name="left"/> and <paramref name="right"/> are null, the method returns <c>true</c>.</returns>
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => Equals(left, right);

        /// <summary>
        ///     Determines whether the specified object instances are not considered equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><c>true</c> if the objects are not considered equal; otherwise, <c>false</c>. If both <paramref name="left"/> and <paramref name="right"/> are null, the method returns <c>false</c>.</returns>
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !Equals(left, right);
    }
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
}

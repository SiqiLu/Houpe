// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : AuditableEntity.cs
// CreatedAt        : 2021-07-14
// LastModifiedAt   : 2021-07-14
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;

namespace Houpe.Foundation.Domain
{
    /// <summary>
    ///     AuditableEntity
    /// </summary>
    public abstract class AuditableEntity
    {
        /// <summary>
        ///     CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        ///     CreatedAt
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        ///     LastModifiedBy
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        ///     LastModifiedAt
        /// </summary>
        public DateTimeOffset? LastModifiedAt { get; set; }
    }
}

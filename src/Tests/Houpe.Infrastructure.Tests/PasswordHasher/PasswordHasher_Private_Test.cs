// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : PasswordHasher_Private_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Infrastructure.Tests;

[TestClass]
public class PasswordHasher_Private_Test
{
    [TestMethod]
    public void PasswordHasher_ByteArraysEqual_Should()
    {
        IPasswordHasher hasher = new PasswordHasher();

        Assert.IsTrue(hasher.AsDynamic()?.ByteArraysEqual(new byte[] { 1, 2, 3 }, new byte[] { 1, 2, 3 }));

        Assert.IsTrue(hasher.AsDynamic()?.ByteArraysEqual(null, null));

        Assert.IsFalse(hasher.AsDynamic()?.ByteArraysEqual(new byte[] { 1, 2, 3 }, null));
        Assert.IsFalse(hasher.AsDynamic()?.ByteArraysEqual(null, new byte[] { 1, 2, 3 }));
        Assert.IsFalse(hasher.AsDynamic()?.ByteArraysEqual(new byte[] { 1, 2, 3 }, new byte[] { 1, 2, 4 }));
    }
}

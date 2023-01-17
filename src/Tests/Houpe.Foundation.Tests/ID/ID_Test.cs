// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : ID_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Houpe.Foundation.Tests;

[TestClass]
public class ID_Test
{
    [TestMethod]
    public void ID_BuildGuid_String_Should()
    {
        Randomizer r = new Randomizer();
        string s1 = r.Utf16String();
        string s2 = r.Utf16String();

        Guid id1 = ID.BuildGuid(s1);
        Guid id2 = ID.BuildGuid(s1);
        Guid id3 = ID.BuildGuid(s2);
        Assert.IsTrue(id1 == id2);
        Assert.IsTrue(id1 != id3);
    }

    [TestMethod]
    public void ID_BuildGuid_ULong_Should()
    {
        Randomizer r = new Randomizer();
        ulong a = r.ULong();
        ulong b = r.ULong();
        ulong c = r.ULong();

        Guid id1 = ID.BuildGuid(a, b);
        Guid id2 = ID.BuildGuid(a, b);
        Guid id3 = ID.BuildGuid(a, c);
        Assert.IsTrue(id1 == id2);
        Assert.IsTrue(id1 != id3);
    }

    [TestMethod]
    public void ID_GuidShortCode_Should() =>
        10000.Times().Do(() =>
        {
            Assert.IsTrue(ID.GuidShortCode().Length == 16);

            // ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(ID.GuidShortCode() != ID.GuidShortCode());
        });

    [TestMethod]
    public void ID_NewId_Should() =>
        10000.Times().Do(() =>
        {
            string id1 = ID.NewId();
            string id2 = ID.NewId();

            Assert.IsTrue(id1 != id2);
            Assert.AreEqual(32, id1.Length);
            Assert.AreEqual(32, id2.Length);

            Assert.AreEqual(id1.ToUpperInvariant(), id1);
            Assert.AreEqual(id2.ToUpperInvariant(), id2);
        });

    [TestMethod]
    public void ID_NewSequentialGuid_Should() =>
        10000.Times().Do(() =>
        {
            Guid id1 = ID.NewSequentialGuid();
            Guid id2 = ID.NewSequentialGuid();

            Assert.IsTrue(id1 != id2);
        });

    [TestMethod]
    [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
    public void ID_NewSequentialId_Should()
    {
        if (DateTime.UtcNow.Minute > 58)
        {
            return;
        }

        Assert.IsTrue(ID.NewSequentialId().StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(ID.NewSequentialId("h").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(ID.NewSequentialId("m").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(ID.NewSequentialId("s").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(ID.NewSequentialId("ms").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(ID.NewSequentialId("t").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(ID.NewSequentialId("any").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));

        Assert.IsTrue(ID.NewSequentialId("d").Length == 8);
        Assert.IsTrue(ID.NewSequentialId("h").Length == 10);
        Assert.IsTrue(ID.NewSequentialId("m").Length == 12);
        Assert.IsTrue(ID.NewSequentialId("s").Length == 14);
        Assert.IsTrue(ID.NewSequentialId("ms").Length == 17);
        Assert.IsTrue(ID.NewSequentialId("t").Length == 21);
        Assert.IsTrue(ID.NewSequentialId("any").Length == 21);
    }
}

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : IDGeneratorService_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Bogus;
using Houpe.Foundation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Houpe.Infrastructure.Tests;

[TestClass]
public class IDGeneratorService_Test
{
    [TestMethod]
    public void IDGeneratorService_BuildGuid_String_Should()
    {
        Randomizer r = new Randomizer();
        string s1 = r.Utf16String();
        string s2 = r.Utf16String();

        IIDGeneratorService idGeneratorService = new IDGeneratorService();

        Guid id1 = idGeneratorService.BuildGuid(s1);
        Guid id2 = idGeneratorService.BuildGuid(s1);
        Guid id3 = idGeneratorService.BuildGuid(s2);
        Assert.IsTrue(id1 == id2);
        Assert.IsTrue(id1 != id3);
    }

    [TestMethod]
    public void IDGeneratorService_BuildGuid_ULong_Should()
    {
        Randomizer r = new Randomizer();
        ulong a = r.ULong();
        ulong b = r.ULong();
        ulong c = r.ULong();

        IIDGeneratorService idGeneratorService = new IDGeneratorService();

        Guid id1 = idGeneratorService.BuildGuid(a, b);
        Guid id2 = idGeneratorService.BuildGuid(a, b);
        Guid id3 = idGeneratorService.BuildGuid(a, c);
        Assert.IsTrue(id1 == id2);
        Assert.IsTrue(id1 != id3);
    }

    [TestMethod]
    public void IDGeneratorService_GuidShortCode_Should()
    {
        IIDGeneratorService idGeneratorService = new IDGeneratorService();

        10000.Times().Do(() =>
        {
            Assert.IsTrue(idGeneratorService.GuidShortCode().Length == 16);

            // ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(idGeneratorService.GuidShortCode() != idGeneratorService.GuidShortCode());
        });
    }

    [TestMethod]
    public void IDGeneratorService_NewSequentialGuid_Should()
    {
        IIDGeneratorService idGeneratorService = new IDGeneratorService();

        10000.Times().Do(() =>
        {
            Guid id1 = idGeneratorService.NewSequentialGuid();
            Guid id2 = idGeneratorService.NewSequentialGuid();

            Assert.IsTrue(id1 != id2);
        });
    }

    [TestMethod]
    [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
    public void IDGeneratorService_NewSequentialId_Should()
    {
        if (DateTime.UtcNow.Minute > 58)
        {
            return;
        }

        IIDGeneratorService idGeneratorService = new IDGeneratorService();

        Assert.IsTrue(idGeneratorService.NewSequentialId().StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(idGeneratorService.NewSequentialId("h").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(idGeneratorService.NewSequentialId("m").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(idGeneratorService.NewSequentialId("s").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(idGeneratorService.NewSequentialId("ms").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(idGeneratorService.NewSequentialId("t").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
        Assert.IsTrue(idGeneratorService.NewSequentialId("any").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));

        Assert.IsTrue(idGeneratorService.NewSequentialId("d").Length == 8);
        Assert.IsTrue(idGeneratorService.NewSequentialId("h").Length == 10);
        Assert.IsTrue(idGeneratorService.NewSequentialId("m").Length == 12);
        Assert.IsTrue(idGeneratorService.NewSequentialId("s").Length == 14);
        Assert.IsTrue(idGeneratorService.NewSequentialId("ms").Length == 17);
        Assert.IsTrue(idGeneratorService.NewSequentialId("t").Length == 21);
        Assert.IsTrue(idGeneratorService.NewSequentialId("any").Length == 21);
    }
}

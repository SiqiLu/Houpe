// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : IDGenerator_Test.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class IDGenerator_Test
    {
        [TestMethod]
        public void IDGenerator_BuildGuid_String_Should()
        {
            Randomizer r = new Randomizer();
            string s1 = r.Utf16String();
            string s2 = r.Utf16String();

            Guid id1 = IDGenerator.BuildGuid(s1);
            Guid id2 = IDGenerator.BuildGuid(s1);
            Guid id3 = IDGenerator.BuildGuid(s2);
            Assert.IsTrue(id1 == id2);
            Assert.IsTrue(id1 != id3);
        }

        [TestMethod]
        public void IDGenerator_BuildGuid_ULong_Should()
        {
            Randomizer r = new Randomizer();
            ulong a = r.ULong();
            ulong b = r.ULong();
            ulong c = r.ULong();

            Guid id1 = IDGenerator.BuildGuid(a, b);
            Guid id2 = IDGenerator.BuildGuid(a, b);
            Guid id3 = IDGenerator.BuildGuid(a, c);
            Assert.IsTrue(id1 == id2);
            Assert.IsTrue(id1 != id3);
        }

        [TestMethod]
        public void IDGenerator_GuidShortCode_Should() =>
            10000.Times().Do(() =>
            {
                Assert.IsTrue(IDGenerator.GuidShortCode().Length == 16);

                // ReSharper disable once EqualExpressionComparison
                Assert.IsTrue(IDGenerator.GuidShortCode() != IDGenerator.GuidShortCode());
            });

        [TestMethod]
        public void IDGenerator_NewSequentialGuid_Should() =>
            10000.Times().Do(() =>
            {
                Guid id1 = IDGenerator.NewSequentialGuid();
                Guid id2 = IDGenerator.NewSequentialGuid();

                Assert.IsTrue(id1 != id2);
            });

        [TestMethod]
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public void IDGenerator_NewSequentialId_Should()
        {
            if (DateTime.UtcNow.Minute > 58)
            {
                return;
            }

            Assert.IsTrue(IDGenerator.NewSequentialId().StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
            Assert.IsTrue(IDGenerator.NewSequentialId("h").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
            Assert.IsTrue(IDGenerator.NewSequentialId("m").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
            Assert.IsTrue(IDGenerator.NewSequentialId("s").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
            Assert.IsTrue(IDGenerator.NewSequentialId("ms").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
            Assert.IsTrue(IDGenerator.NewSequentialId("t").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));
            Assert.IsTrue(IDGenerator.NewSequentialId("any").StartsWith(DateTime.UtcNow.ToString("yyyyMMddHH"), StringComparison.InvariantCulture));

            Assert.IsTrue(IDGenerator.NewSequentialId("d").Length == 8);
            Assert.IsTrue(IDGenerator.NewSequentialId("h").Length == 10);
            Assert.IsTrue(IDGenerator.NewSequentialId("m").Length == 12);
            Assert.IsTrue(IDGenerator.NewSequentialId("s").Length == 14);
            Assert.IsTrue(IDGenerator.NewSequentialId("ms").Length == 17);
            Assert.IsTrue(IDGenerator.NewSequentialId("t").Length == 21);
            Assert.IsTrue(IDGenerator.NewSequentialId("any").Length == 21);
        }
    }
}

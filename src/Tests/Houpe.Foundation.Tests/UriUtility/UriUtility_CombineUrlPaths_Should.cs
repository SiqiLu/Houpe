// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : UriUtility_CombineUrlPaths_Should.cs
// CreatedAt        : 2021-07-13
// LastModifiedAt   : 2022-08-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class UriUtility_CombineUrlPaths_Should
    {
        [TestMethod]
        public void CombineUrlPaths_Should()
        {
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("https://www.foo.com/", null));
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("https://www.foo.com/", ""));

            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths(null, "https://www.foo.com/"));
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("", "https://www.foo.com/"));

            Assert.AreEqual(new Uri("http://www.foo.com/"), UriUtility.CombineUrlPaths("foo", "http://www.foo.com/"));
            Assert.AreEqual(new Uri("http://www.foo.com/"), UriUtility.CombineUrlPaths("bar", "http://www.foo.com/"));

            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("foo", "https://www.foo.com/"));
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("bar", "https://www.foo.com/"));

            Assert.AreEqual(new Uri("https://foo.com/bar"), UriUtility.CombineUrlPaths("https://foo.com", "bar"));
            Assert.AreEqual(new Uri("https://foo.com/bar/"), UriUtility.CombineUrlPaths("https://foo.com", "bar/"));
            Assert.AreEqual(new Uri("https://foo.com/bar/"), UriUtility.CombineUrlPaths("https://foo.com/", "bar/"));
            Assert.AreEqual(new Uri("https://foo.com/bar"), UriUtility.CombineUrlPaths("https://foo.com/", "/bar"));
            Assert.AreEqual(new Uri("https://foo.com/bar"), UriUtility.CombineUrlPaths("https://foo.com//", "/bar"));

            Assert.AreEqual(null, UriUtility.CombineUrlPaths(null, null));
            Assert.AreEqual(null, UriUtility.CombineUrlPaths("foo", "bar"));

            Assert.AreEqual(new Uri("https://foo.com"), UriUtility.CombineUrlPaths("https://foo.com"));
            Assert.AreEqual(new Uri("https://foo.com/"), UriUtility.CombineUrlPaths("https://foo.com/"));

            Assert.AreEqual(new Uri("C:\\foo.com\\bar"), UriUtility.CombineUrlPaths("C:\\foo.com", "bar"));
            Assert.AreEqual(new Uri("C:\\foo.com\\bar"), UriUtility.CombineUrlPaths("C:\\foo.com", "/bar"));
            Assert.AreEqual(new Uri("C:\\foo.com\\bar"), UriUtility.CombineUrlPaths("C:\\foo.com", "\\bar"));

            Assert.AreEqual(new Uri("file://foo.com/bar"), UriUtility.CombineUrlPaths("file://foo.com", "bar"));
            Assert.AreEqual(new Uri("file://foo.com/bar"), UriUtility.CombineUrlPaths("file://foo.com", "/bar"));
            Assert.AreEqual(new Uri("file://foo.com/bar"), UriUtility.CombineUrlPaths("file://foo.com", "\\bar"));

            // ReSharper disable once RedundantCast
            Assert.AreEqual(null, UriUtility.CombineUrlPaths((string[])null));
            Assert.AreEqual(null, UriUtility.CombineUrlPaths(Array.Empty<string>()));

            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("https://www.foo.com/", null, null));
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("https://www.foo.com/", "", ""));

            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths(null, "", "https://www.foo.com/"));
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("", null, "https://www.foo.com/"));

            Assert.AreEqual(new Uri("http://www.foo.com/"), UriUtility.CombineUrlPaths("foo", "bar", "http://www.foo.com/"));
            Assert.AreEqual(new Uri("http://www.foo.com/"), UriUtility.CombineUrlPaths("bar", "foo", "http://www.foo.com/"));

            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("foo", "bar", "https://www.foo.com/"));
            Assert.AreEqual(new Uri("https://www.foo.com/"), UriUtility.CombineUrlPaths("bar", "foo", "https://www.foo.com/"));

            Assert.AreEqual(new Uri("https://foo.com/bar/foo"), UriUtility.CombineUrlPaths("https://foo.com", "bar", "foo"));
            Assert.AreEqual(new Uri("https://foo.com/bar/foo/"), UriUtility.CombineUrlPaths("https://foo.com", "bar/", "foo/"));
            Assert.AreEqual(new Uri("https://foo.com/bar/foo/"), UriUtility.CombineUrlPaths("https://foo.com/", "bar/", "foo/"));
            Assert.AreEqual(new Uri("https://foo.com/bar/foo"), UriUtility.CombineUrlPaths("https://foo.com/", "/bar/", "/foo"));
            Assert.AreEqual(new Uri("https://foo.com/bar/foo"), UriUtility.CombineUrlPaths("https://foo.com//", "/bar", "/foo"));
            Assert.AreEqual(new Uri("https://foo.com/bar/foo"), UriUtility.CombineUrlPaths("https://foo.com//", "//bar", "//foo"));
        }
    }
}

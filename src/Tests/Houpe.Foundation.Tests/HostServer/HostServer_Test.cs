// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : HostServer_Test.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    public class HostServer_Test
    {
        [TestMethod]
        public void HostServer_Test_Should()
        {
            Assert.AreEqual(Environment.CurrentManagedThreadId, HostServer.CurrentManagedThreadId);
            Assert.AreEqual(Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString(), HostServer.IP);
            Assert.AreEqual(Environment.Is64BitOperatingSystem, HostServer.Is64BitOperatingSystem);
            Assert.AreEqual(Environment.Is64BitProcess, HostServer.Is64BitProcess);
            Assert.AreEqual(Environment.MachineName, HostServer.MachineName);
            Assert.AreEqual(Environment.OSVersion.VersionString, HostServer.OSVersion);
            Assert.AreEqual(Environment.ProcessorCount, HostServer.ProcessorCount);
            Assert.AreEqual(Environment.ProcessId, HostServer.ProcessId);
            Assert.AreEqual(Environment.Version.ToString(), HostServer.RuntimeVersion);
        }
    }
}

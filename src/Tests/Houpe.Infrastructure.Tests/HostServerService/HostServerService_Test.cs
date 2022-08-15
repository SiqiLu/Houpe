// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : HostServerService_Test.cs
// CreatedAt        : 2022-08-07
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Infrastructure.Tests
{
    [TestClass]
    public class HostServerService_Test
    {
        [TestMethod]
        public void HostServerService_Test_Should()
        {
            IHostServerService hostServerService = new HostServerService();

            Assert.AreEqual(Environment.CurrentManagedThreadId, hostServerService.CurrentManagedThreadId);
            Assert.AreEqual(Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString(), hostServerService.IP);
            Assert.AreEqual(Environment.Is64BitOperatingSystem, hostServerService.Is64BitOperatingSystem);
            Assert.AreEqual(Environment.Is64BitProcess, hostServerService.Is64BitProcess);
            Assert.AreEqual(Environment.MachineName, hostServerService.MachineName);
            Assert.AreEqual(Environment.OSVersion.VersionString, hostServerService.OSVersion);
            Assert.AreEqual(Environment.ProcessorCount, hostServerService.ProcessorCount);
            Assert.AreEqual(Environment.ProcessId, hostServerService.ProcessId);
            Assert.AreEqual(Environment.Version.ToString(), hostServerService.RuntimeVersion);
        }
    }
}

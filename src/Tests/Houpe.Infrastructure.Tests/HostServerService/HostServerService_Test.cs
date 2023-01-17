// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Infrastructure.Tests
// File             : HostServerService_Test.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-17
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;

namespace Houpe.Infrastructure.Tests;

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

// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : HostServer.cs
// CreatedAt        : 2021-07-13
// LastModifiedAt   : 2022-08-07
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Houpe.Foundation
{
    /// <summary>
    ///     用户获取当前应用宿主机的环境值。
    /// </summary>
    public static class HostServer
    {
        /// <summary>
        ///     获取当前托管线程的唯一标识符。
        /// </summary>
        /// <example>6</example>
        public static int CurrentManagedThreadId => Environment.CurrentManagedThreadId;

        /// <summary>
        ///     获取当前宿主机的IP v4 地址。
        /// </summary>
        /// <example>192.168.1.36</example>
        public static string IP => Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();

        /// <summary>
        ///     确定当前操作系统是否为 64 位操作系统。
        /// </summary>
        public static bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;

        /// <summary>
        ///     确定当前进程是否为 64 位进程。
        /// </summary>
        public static bool Is64BitProcess => Environment.Is64BitProcess;

        /// <summary>
        ///     获取此本地计算机的 NetBIOS 名称。
        /// </summary>
        /// <example>SIQILU-SURFACE</example>
        public static string MachineName => Environment.MachineName;

        /// <summary>
        ///     获取包含当前平台标识符和版本号的字符串。
        /// </summary>
        /// <example>Microsoft Windows NT 6.2.9200.0</example>
        public static string OSVersion => Environment.OSVersion.VersionString;

        /// <summary>
        ///     获取当前应用执行的进程Id。
        /// </summary>
        /// <example>23888</example>
        public static int ProcessId => Process.GetCurrentProcess().Id;

        /// <summary>
        ///     获取当前计算机上的处理器数。
        /// </summary>
        public static int ProcessorCount => Environment.ProcessorCount;

        /// <summary>
        ///     获取描述公共语言运行时的主版本、次版本、内部版本和修订号的字符串。
        /// </summary>
        /// <value>4.0.30319.42000</value>
        public static string RuntimeVersion => Environment.Version.ToString();
    }
}

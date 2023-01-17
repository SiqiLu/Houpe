// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation
// File             : IHostServerService.cs
// CreatedAt        : 2023-01-14
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation;

namespace Houpe.Infrastructure;

/// <summary>
///     IHostServerService
/// </summary>
public interface IHostServerService
{
    /// <summary>
    ///     获取当前托管线程的唯一标识符。
    /// </summary>
    /// <example>6</example>
    public int CurrentManagedThreadId => HostServer.CurrentManagedThreadId;

    /// <summary>
    ///     获取当前宿主机的IP v4 地址。
    /// </summary>
    /// <example>192.168.1.36</example>
    public string IP => HostServer.IP;

    /// <summary>
    ///     确定当前操作系统是否为 64 位操作系统。
    /// </summary>
    public bool Is64BitOperatingSystem => HostServer.Is64BitOperatingSystem;

    /// <summary>
    ///     确定当前进程是否为 64 位进程。
    /// </summary>
    public bool Is64BitProcess => HostServer.Is64BitProcess;

    /// <summary>
    ///     获取此本地计算机的 NetBIOS 名称。
    /// </summary>
    /// <example>SIQILU-SURFACE</example>
    public string MachineName => HostServer.MachineName;

    /// <summary>
    ///     获取包含当前平台标识符和版本号的字符串。
    /// </summary>
    /// <example>Microsoft Windows NT 6.2.9200.0</example>
    public string OSVersion => HostServer.OSVersion;

    /// <summary>
    ///     获取当前应用执行的进程Id。
    /// </summary>
    /// <example>23888</example>
    public int ProcessId => HostServer.ProcessId;

    /// <summary>
    ///     获取当前计算机上的处理器数。
    /// </summary>
    public int ProcessorCount => HostServer.ProcessorCount;

    /// <summary>
    ///     获取描述公共语言运行时的主版本、次版本、内部版本和修订号的字符串。
    /// </summary>
    /// <value>4.0.30319.42000</value>
    public string RuntimeVersion => HostServer.RuntimeVersion;
}

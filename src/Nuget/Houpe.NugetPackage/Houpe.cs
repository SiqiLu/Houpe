// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.NugetPackage
// File             : Houpe.cs
// CreatedAt        : 2022-08-14
// LastModifiedAt   : 2022-08-14
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Diagnostics;
using System.Reflection;

// ReSharper disable CheckNamespace

namespace Houpe
{
    /// <summary>
    ///     Houpe Nuget Package
    /// </summary>
    public static class Houpe
    {
        /// <summary>
        ///     Houpe.FileVersion
        /// </summary>
        public static string FileVersion
        {
            get
            {
                Assembly assembly = Assembly.GetAssembly(typeof(Houpe));
                if (assembly != null)
                {
                    return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion ?? "";
                }

                return "";
            }
        }

        /// <summary>
        ///     Houpe.InformationalVersion
        /// </summary>
        public static string InformationalVersion
        {
            get
            {
                Assembly assembly = Assembly.GetAssembly(typeof(Houpe));
                if (assembly != null)
                {
                    return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "";
                }

                return "";
            }
        }

        /// <summary>
        ///     Houpe.Version
        /// </summary>
        public static string Version => Assembly.GetAssembly(typeof(Houpe))?.GetName().Version?.ToString() ?? "";
    }
}

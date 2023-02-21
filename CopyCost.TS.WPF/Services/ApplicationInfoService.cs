using System.Diagnostics;
using System.Reflection;
using CopyCost.TS.WPF.Contracts.Services;

namespace CopyCost.TS.WPF.Services;

public class ApplicationInfoService : IApplicationInfoService
{
    public Version GetVersion()
    {
        // Set the app version in CopyCost.TS.WPF > Properties > Package > PackageVersion
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var version = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
        return new Version(version);
    }
}
#tool "nuget:?package=GitVersion.CommandLine"

var fallbackVersion = Argument<string>("force-version", EnvironmentVariable("FALLBACK_VERSION") ?? "0.1.0");
 
string BuildVersion(string fallbackVersion) {
    var PackageVersion = string.Empty;
    try {
        Information("Attempting GitVersion...");
        var versionInfo = GitVersion();
        PackageVersion = versionInfo.NuGetVersionV2;
    } catch {
        Information($"Falling back to version: {fallbackVersion}");
        PackageVersion = fallbackVersion;
    } finally {
        Information($"Building for version '{PackageVersion}'");
    }
    return PackageVersion;
}
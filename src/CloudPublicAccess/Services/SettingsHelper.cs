
namespace CloudPublicAccess.Services;

internal static class SettingsHelper
{
    private const string PortalBaseUrl = "https://s1.umbraco.io";
    private const string DevPortalBaseUrl = "https://dev-cloud.umbraco.com";
    
    internal static string ResolvePortalUrl(string? identityTenant, string? projectAlias)
    {
        var baseUrl = PortalBaseUrl;
        
        if (identityTenant is not null && identityTenant.Contains("umbracoiddev"))
        {
            baseUrl = DevPortalBaseUrl;
        }

        if (projectAlias is not null)
        {
            return $"{baseUrl}/project/{projectAlias}";
        }
        
        return $"{baseUrl}/projects";
    }
    
    internal static string ResolveEnvironmentName(string? environmentNameFromConfig)
    {
        var environmentName = "local";
        
        if (environmentNameFromConfig is not null)
            environmentName = environmentNameFromConfig!;

        return environmentName;
    }
}
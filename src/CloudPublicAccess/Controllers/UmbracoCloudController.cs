using CloudPublicAccess.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Extensions;

namespace CloudPublicAccess.Controllers;

public class UmbracoCloudController : UmbracoAuthorizedJsonController
{
    private readonly UmbracoCloudHelperSettings _umbracoCloudHelperSettings;
    private readonly IConfiguration _config;

    public UmbracoCloudController(UmbracoCloudHelperSettings umbracoCloudHelperSettings, IConfiguration config)
    {
        _umbracoCloudHelperSettings = umbracoCloudHelperSettings;
        _config = config;
    }
    
    [HttpGet]
    public CloudPortalProjectLinkResponse GetCloudEnvironmentSettings()
    {
        var resolvedPortal = ResolvePortalUrl(_umbracoCloudHelperSettings.IdentityTenant, _umbracoCloudHelperSettings.ProjectAlias);
        var environmentName = ResolveEnvironmentName();
        return new CloudPortalProjectLinkResponse{ ProjectPortalLink = resolvedPortal, EnvironmentName = environmentName};
    }

    private string ResolvePortalUrl(string? identityTenant, string? projectAlias)
    {
        var baseUrl = "https://s1.umbraco.io";
        
        if (identityTenant.HasValue() && identityTenant.Contains("umbracoiddev"))
        {
            baseUrl = "https://dev-cloud.umbraco.com";
        }

        if (projectAlias.HasValue())
        {
            return $"{baseUrl}/project/{projectAlias}";
        }
        
        return $"{baseUrl}/projects";
    }

    private string ResolveEnvironmentName()
    {
        var environmentName = "local";
        
        if (_umbracoCloudHelperSettings.EnvironmentName.HasValue())
            environmentName = _umbracoCloudHelperSettings.EnvironmentName!;

        return environmentName;
    }
}

public class CloudPortalProjectLinkResponse
{
    public string ProjectPortalLink { get; set; }
    public string EnvironmentName { get; set; }
}
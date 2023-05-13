using CloudPublicAccess.Extensions;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace CloudPublicAccess.Controllers;

public class UmbracoCloudController : UmbracoAuthorizedJsonController
{
    private readonly UmbracoCloudHelperSettings _umbracoCloudHelperSettings;

    public UmbracoCloudController(UmbracoCloudHelperSettings umbracoCloudHelperSettings)
    {
        _umbracoCloudHelperSettings = umbracoCloudHelperSettings;
    }
    
    [HttpGet]
    public CloudPortalProjectLinkResponse GetCloudEnvironmentSettings()
    {
        var resolvedPortal = ResolvePortalUrl(_umbracoCloudHelperSettings.IdentityTenant, _umbracoCloudHelperSettings.ProjectAlias);
        
        return new CloudPortalProjectLinkResponse{ ProjectPortalLink = resolvedPortal, EnvironmentName = _umbracoCloudHelperSettings.EnvironmentName};
    }

    private string? ResolvePortalUrl(string? identityTenant, string? projectAlias)
    {
        if (!identityTenant.HasValue() || !projectAlias.HasValue())
            return null;

        if (identityTenant.Contains("umbracoiddev"))
        {
            return $"https://dev-cloud.umbraco.io/project/{projectAlias}";
        }
        
        return $"https://cloud.umbraco.io/project/{projectAlias}";
        
    }
}

public class CloudPortalProjectLinkResponse
{
    public string ProjectPortalLink { get; set; }
    public string EnvironmentName { get; set; }
}
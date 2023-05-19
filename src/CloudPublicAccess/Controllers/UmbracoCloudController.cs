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

    public UmbracoCloudController(UmbracoCloudHelperSettings umbracoCloudHelperSettings)
    {
        _umbracoCloudHelperSettings = umbracoCloudHelperSettings;
    }
    
    [HttpGet]
    public CloudPortalProjectLinkResponse GetCloudEnvironmentSettings()
    {
        return new CloudPortalProjectLinkResponse{ ProjectPortalLink = _umbracoCloudHelperSettings.PortalUrl, EnvironmentName = _umbracoCloudHelperSettings.EnvironmentName };
    }
}

public class CloudPortalProjectLinkResponse
{
    public string ProjectPortalLink { get; set; }
    public string EnvironmentName { get; set; }
}
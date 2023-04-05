using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace CloudPublicAccess.Controllers;

public class CloudPublicAccessController : UmbracoAuthorizedJsonController
{
    private readonly BasicAuthSettings _basicAuthSettings;

    public CloudPublicAccessController(IOptionsMonitor<BasicAuthSettings> basicAuthSettings)
    {
        _basicAuthSettings = basicAuthSettings.CurrentValue;
    }

    [HttpGet]
    public CloudPublicAccessSettings GetSettings()
    {
        var portalLink = Environment.GetEnvironmentVariable("UMBRACO:CLOUD:IDENTITY:CLOUDRELAYENDPOINTBASEURL");
        portalLink = portalLink.Replace("api.", "");
        return CreateResponse(_basicAuthSettings, portalLink);
    }

    private CloudPublicAccessSettings CreateResponse(BasicAuthSettings basicAuthSettings, string portalLink)
    {
        return new CloudPublicAccessSettings
        {
            Enabled = basicAuthSettings.Enabled,
            AllowedIPs = basicAuthSettings.AllowedIPs,
            RedirectToLoginPage = basicAuthSettings.RedirectToLoginPage,
            PortalLink = portalLink
        };
    }
}

public class CloudPublicAccessSettings
{
    public bool Enabled { get; init; }

    public string[] AllowedIPs { get; init; } = Array.Empty<string>();

    public bool RedirectToLoginPage { get; init; }
    public string PortalLink { get; init; }
}
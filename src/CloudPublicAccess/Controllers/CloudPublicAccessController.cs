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
        return CreateResponse(_basicAuthSettings);
    }

    private CloudPublicAccessSettings CreateResponse(BasicAuthSettings basicAuthSettings)
    {
        return new CloudPublicAccessSettings
        {
            Enabled = basicAuthSettings.Enabled,
            AllowedIPs = basicAuthSettings.AllowedIPs,
            RedirectToLoginPage = basicAuthSettings.RedirectToLoginPage
        };
    }
}

public class CloudPublicAccessSettings
{
    public bool Enabled { get; init; }

    public string[] AllowedIPs { get; init; } = Array.Empty<string>();

    public bool RedirectToLoginPage { get; init; }
}
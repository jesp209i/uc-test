using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Core.PropertyEditors;

namespace CloudPublicAccess;

public class CloudPackageManifestFilter : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = "CloudPublicAccess",
            Version = "0.0.1",
            AllowPackageTelemetry = true,
            Scripts = new []
            {
                "/App_Plugins/CloudPublicAccess/backoffice/cloudPublicAccess/overview.controller.js"
            }
        });
    }
}
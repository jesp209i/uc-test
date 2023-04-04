using Umbraco.Cms.Core.Manifest;

namespace BackofficePlay.Code.Manifest;

public class CloudPublicAccessManifestFilter : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        var cloudPublicAccessManifest = new PackageManifest
        {
            Scripts = new []{ "/App_Plugins/PublicAccess/backoffice/cloudPublicAccess/overview.controller.js" }
        };
        manifests.Add(cloudPublicAccessManifest);
    }
}
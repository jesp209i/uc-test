using CloudPublicAccess.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace CloudPublicAccess.Composers;

public class CloudComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddCloudSettings();
        builder.AddCloudManifestFilters();
        builder.AddUmbracoCloudSection();
    }
}
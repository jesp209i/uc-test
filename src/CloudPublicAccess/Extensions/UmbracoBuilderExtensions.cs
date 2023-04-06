using CloudPublicAccess.Section;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Sections;

namespace CloudPublicAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IUmbracoBuilder AddUmbracoCloudSection(this IUmbracoBuilder self)
    {
        self.ManifestFilters().Append<CloudPackageManifestFilter>();
        self.Sections().InsertAfter<TranslationSection, UmbracoCloudSection>();
        return self;
    }
}
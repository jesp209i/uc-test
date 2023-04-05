using CloudPublicAccess.Section;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Sections;

namespace CloudPublicAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IUmbracoBuilder AddUmbracoCloudSection(this IUmbracoBuilder self)
    {
        self.Sections().InsertAfter<TranslationSection, UmbracoCloudSection>();
        return self;
    }
}
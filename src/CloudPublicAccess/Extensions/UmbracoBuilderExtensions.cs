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

    public static IUmbracoBuilder AddCloudManifestFilters(this IUmbracoBuilder self)
    {
        self.ManifestFilters().Append<CloudPackageManifestFilter>();
        return self;
    }

    public static IUmbracoBuilder AddCloudSettings(this IUmbracoBuilder self)
    {
        var projectAlias = self.Config["Umbraco:Cloud:Deploy:Project:Alias"];
        var projectIdentity = self.Config["Umbraco:Cloud:Identity:Tenant"];
        var environmentName = self.Config["Umbraco:Cloud:Deploy:EnvironmentName"];

        var settings = new UmbracoCloudHelperSettings(projectAlias, projectIdentity, environmentName);

        self.Services.AddSingleton(settings);
        
        return self;
    }
}

public class UmbracoCloudHelperSettings
{
    public UmbracoCloudHelperSettings(string? projectAlias, string? identityTenant, string? environmentName)
    {
        ProjectAlias = projectAlias;
        IdentityTenant = identityTenant;
        EnvironmentName = environmentName;
    }
    public string? ProjectAlias { get; }
    public string? IdentityTenant { get; }
    public string? EnvironmentName { get; }
}
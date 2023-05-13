using CloudPublicAccess.Section;
using Microsoft.Extensions.Configuration;
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
        var configuration = new ConfigurationBuilder()
            .SetBasePath(self.BuilderHostingEnvironment!.ApplicationPhysicalPath)
            .AddJsonFile("umbraco-cloud.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables("Umbraco:Cloud:")
            .AddEnvironmentVariables("Umbraco__Cloud__")
            .Build();

        var projectAlias = configuration["Deploy:Project:Alias"];
            
        var projectIdentity = configuration["Identity:Tenant"];
        
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
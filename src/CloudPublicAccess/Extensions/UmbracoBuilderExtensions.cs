using CloudPublicAccess.Handlers;
using CloudPublicAccess.Section;
using CloudPublicAccess.Services;
using CSharpTest.Net.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Sections;
using Umbraco.Cms.Web.BackOffice.Authorization;

namespace CloudPublicAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IUmbracoBuilder AddUmbracoCloudSection(this IUmbracoBuilder self)
    {
        if (!self.Sections().Has<UmbracoCloudSection>())
            self.Sections().InsertAfter<TranslationSection, UmbracoCloudSection>();
        
        self.AddNotificationHandler<UmbracoApplicationStartedNotification, ApplicationStartedHandler>();
        return self;
    }
    
    public static IUmbracoBuilder AddCloudManifestFilters(this IUmbracoBuilder self)
    {
        if (!self.ManifestFilters().Has<CloudPackageManifestFilter>())
        {
            self.ManifestFilters().Append<CloudPackageManifestFilter>();
        }
            
        return self;
    }

    public static IUmbracoBuilder AddCloudSettings(this IUmbracoBuilder self)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(self.BuilderHostingEnvironment!.ApplicationPhysicalPath)
            .AddJsonFile("umbraco-cloud.json", optional: true, reloadOnChange: true)
            .Build();

        var projectAlias = configuration["Deploy:Project:Alias"];
            
        var projectIdentity = configuration["Identity:Tenant"];
        
        var environmentNameFromConfig = self.Config["Umbraco:Cloud:Deploy:EnvironmentName"];

        var environmentName = SettingsHelper.ResolveEnvironmentName(environmentNameFromConfig);

        var portalUrl = SettingsHelper.ResolvePortalUrl(projectIdentity, projectAlias);

        var settings = new UmbracoCloudHelperSettings(portalUrl, environmentName);

        self.Services.AddSingleton(settings);
        
        return self;
    }
}

public class UmbracoCloudHelperSettings
{
    public UmbracoCloudHelperSettings(string? portalUrl, string? environmentName)
    {
        PortalUrl = portalUrl;
        EnvironmentName = environmentName;
    }
    public string? PortalUrl { get; }
    public string? EnvironmentName { get; }
}
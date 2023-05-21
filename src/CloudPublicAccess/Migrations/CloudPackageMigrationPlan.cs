using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Scoping;

namespace CloudPublicAccess.Migrations;

public class CloudPackageMigrationPlan : MigrationPlan
{
    private readonly IScopeProvider _scopeProvider;

    public CloudPackageMigrationPlan(IScopeProvider scopeProvider) : base("cloud_package")
    {
        _scopeProvider = scopeProvider;
        DefinePlan();
    }

    private void DefinePlan()
    {
        using IScope scope = _scopeProvider.CreateScope();
        From("CloudPublicAccess_Zero")
            .To<CloudPublicAccess_Initial>(nameof(CloudPublicAccess_Initial));
    }
}
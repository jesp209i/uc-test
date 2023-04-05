using Umbraco.Cms.Infrastructure.Migrations;

namespace CloudPublicAccess.Migrations;

public class CloudPackageMigrationPlan : MigrationPlan
{
    public CloudPackageMigrationPlan() : base(Constants.PackageName)
    {
        DefinePlan();
    }
    
    private void DefinePlan()
    {
        MigrationPlan plan = From(InitialState);

        _ = plan
            .To<CloudPublicAccess_Initial>(CloudPublicAccess_Initial.MigrationName);
    }
}
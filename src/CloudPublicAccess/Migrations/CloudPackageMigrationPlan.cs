using Umbraco.Cms.Infrastructure.Migrations;

namespace CloudPublicAccess.Migrations;

public class CloudPackageMigrationPlan : MigrationPlan
{
    public CloudPackageMigrationPlan() : base(Constants.PackageName)
    {
        DefinePlan();
    }

    private new const string InitialState = "";

    private void DefinePlan()
    {
        MigrationPlan plan = From(InitialState);

        _ = plan
            .To<CloudPublicAccess_Initial>(CloudPublicAccess_Initial.MigrationName);
    }
}
using Umbraco.Cms.Infrastructure.Migrations;

namespace CloudPublicAccess.Migrations;

public class CloudPackageMigrationPlan : MigrationPlan
{
    public CloudPackageMigrationPlan() : base("cloud_package")
    {
        From(string.Empty)
            .To<CloudPublicAccess_Initial>(CloudPublicAccess_Initial.MigrationName);
    }

}
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Core.Services;

namespace CloudPublicAccess.Migrations;

public class CloudPublicAccess_Initial : MigrationBase
{
    public static string MigrationName = "CloudPackage_OneZeroZero";
    
    private readonly IUserService _userService;

    public CloudPublicAccess_Initial(
        IMigrationContext context,
        IUserService userService)
        : base(context)
    {
        _userService = userService;
    }

    protected override void Migrate()
    {
        // give all usergroups access to Umbraco Cloud section
        var userGroups = _userService.GetAllUserGroups();
        
        foreach (var userGroup in userGroups)
        {
            userGroup.AddAllowedSection("umbracoCloud");
            _userService.Save(userGroup);
        }
    }
}
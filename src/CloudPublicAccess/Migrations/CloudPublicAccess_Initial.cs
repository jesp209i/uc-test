using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Scoping;

namespace CloudPublicAccess.Migrations;

public class CloudPublicAccess_Initial : MigrationBase
{
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
            userGroup.AddAllowedSection(Constants.Sections.CloudSection);
            _userService.Save(userGroup);
        }
    }
}
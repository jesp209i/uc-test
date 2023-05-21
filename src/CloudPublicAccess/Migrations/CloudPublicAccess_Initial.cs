using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Scoping;

namespace CloudPublicAccess.Migrations;

public class CloudPublicAccess_Initial : MigrationBase
{
    public static string MigrationName = "CloudPackage_OneZeroZero";
    
    private readonly IUserService _userService;
    private readonly IScopeProvider _scopeProvider;

    public CloudPublicAccess_Initial(
        IMigrationContext context,
        IUserService userService,
        IScopeProvider scopeProvider)
        : base(context)
    {
        _userService = userService;
        _scopeProvider = scopeProvider;
    }

    protected override void Migrate()
    {
        using (IScope scope = _scopeProvider.CreateScope())
        {
            // give all usergroups access to Umbraco Cloud section
            var userGroups = _userService.GetAllUserGroups();
        
            foreach (var userGroup in userGroups)
            {
                userGroup.AddAllowedSection("umbracoCloud");
                _userService.Save(userGroup);
            }

            scope.Complete();
        }
        
    }
}
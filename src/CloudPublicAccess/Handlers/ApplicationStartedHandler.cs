using CloudPublicAccess.Migrations;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Umbraco.Cms.Infrastructure.Scoping;

namespace CloudPublicAccess.Handlers;

public class ApplicationStartedHandler : INotificationHandler<UmbracoApplicationStartedNotification>
{
    private readonly IScopeProvider _scopeProvider;
    private readonly IKeyValueService _keyValueService;
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;
    private readonly IRuntimeState _runtimeState;

    public ApplicationStartedHandler(
        IScopeProvider scopeProvider,
        IKeyValueService keyValueService,
        IMigrationPlanExecutor migrationPlanExecutor,
        IRuntimeState runtimeState)
    {
        _scopeProvider = scopeProvider;
        _keyValueService = keyValueService;
        _migrationPlanExecutor = migrationPlanExecutor;
        _runtimeState = runtimeState;
    }

    public void Handle(UmbracoApplicationStartedNotification notification)
    {
        if (_runtimeState.Level != RuntimeLevel.Run)
        {
            return;
        }

        Upgrader? upgrader = new(new CloudPackageMigrationPlan(_scopeProvider));
        upgrader.Execute(_migrationPlanExecutor, _scopeProvider, _keyValueService);

        throw new System.NotImplementedException();
    }
}
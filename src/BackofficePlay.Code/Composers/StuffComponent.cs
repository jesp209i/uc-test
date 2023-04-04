using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Configuration.Models;

namespace BackofficePlay.Code.Composers;

public class StuffComponent : IComponent
{
    private readonly BasicAuthSettings _basicAuthSettings;

    public StuffComponent(IOptionsMonitor<BasicAuthSettings> basicAuthSettings)
    {
        _basicAuthSettings = basicAuthSettings.CurrentValue;
    }
    public void Initialize()
    {
        
    }

    public void Terminate()
    {
        throw new NotImplementedException();
    }
}
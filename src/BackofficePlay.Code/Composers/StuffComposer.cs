using Umbraco.Cms.Core.Composing;

namespace BackofficePlay.Code.Composers;

public class StuffComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddComponent<StuffComponent>();
    }
}
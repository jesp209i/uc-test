using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace BackofficePlay.Code;
[Tree(Constants.Sections.Settings, "cloudPublicAccess", TreeTitle = "Cloud Public Access", TreeGroup = "cloudPublicAccessGroup")]
[PluginController("PublicAccess")]
public class PublicAccessTreeController : TreeController
{
    private readonly IMenuItemCollectionFactory _menuItemCollectionFactory;
    
    public PublicAccessTreeController(
        ILocalizedTextService localizedTextService, 
        UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection, 
        IEventAggregator eventAggregator,
        IMenuItemCollectionFactory menuItemCollectionFactory) 
        : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
    {
        _menuItemCollectionFactory = menuItemCollectionFactory;
    }

    protected override ActionResult<TreeNodeCollection> GetTreeNodes(string id, FormCollection queryStrings)
    {
        var nodes = new TreeNodeCollection();

        var node = CreateTreeNode("1", "-1", queryStrings, "hest", "icon-presentation", false);
        
        nodes.Add(node);

        return nodes;
    }

    protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, FormCollection queryStrings)
    {
        return _menuItemCollectionFactory.Create();
    }
}
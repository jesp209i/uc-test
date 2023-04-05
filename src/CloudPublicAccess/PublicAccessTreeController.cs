using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace CloudPublicAccess;
[Tree(Constants.Sections.Settings, Constants.Trees.CloudPublicAccess, TreeTitle = "Cloud Public Access", TreeGroup = "cloudPublicAccess", SortOrder = 9)]
[PluginController("CloudPublicAccess")]
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
        return new TreeNodeCollection();
        
    }

    protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, FormCollection queryStrings)
    {
        return _menuItemCollectionFactory.Create();
    }
    protected override ActionResult<TreeNode?> CreateRootNode(FormCollection queryStrings)
    {
        ActionResult<TreeNode?> rootResult = base.CreateRootNode(queryStrings);
        if (!(rootResult.Result is null))
        {
            return rootResult;
        }

        TreeNode? root = rootResult.Value;

        if (root is not null)
        {
            // This will load in a custom UI instead of the dashboard for the root node
            root.RoutePath = $"{Constants.Sections.Settings}/{Constants.Trees.CloudPublicAccess}/overview";
            root.Icon = "icon-unlocked";
            root.HasChildren = false;
            root.MenuUrl = null;
        }

        return root;
    }
}
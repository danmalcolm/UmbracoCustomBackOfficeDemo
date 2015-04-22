using System;
using System.Collections.Generic;
using System.Text;
using umbraco.businesslogic;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace UmbracoCustomBackOfficeDemo.PropertyManagement
{
    [Tree("propertyManagement", "propertyManagement", "Property Management")]
    public class PropertyManagementTree : BaseTree
    {
        public PropertyManagementTree(string application) : base(application) { }
        
        public override void RenderJS(ref StringBuilder javascript)
        {
            javascript.Append(
                @"
function openSection(section) {
    var path = 'property-management/' + section + '/index';
    UmbClientMgr.contentFrame(path);
}
");
        }

        protected override void CreateAllowedActions(ref List<IAction> actions)
        {
            actions.Clear();
            actions.Add(ActionNew.Instance);
        }

        public override void Render(ref XmlTree tree)
        {
            CreateNode(tree, "Agents", "icon-user");
            CreateNode(tree, "Sales", "icon-home");
            CreateNode(tree, "Lettings", "icon-home");
        }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            
        }

        private void CreateNode(XmlTree tree, string section, string icon)
        {
            var node = XmlTreeNode.Create(this);
            node.NodeID = section;
            node.Text = section;
            node.Action = "javascript:openSection('" + section.ToLowerInvariant() + "');";
            node.Icon = icon;
            node.OpenIcon = icon;

            OnBeforeNodeRender(ref tree, ref node, EventArgs.Empty);
            if (node != null)
            {
                tree.Add(node);
                OnAfterNodeRender(ref tree, ref node, EventArgs.Empty);
            }
        }
    }
}
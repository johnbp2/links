using AngleSharp.Dom;
using AngleSharp.Dom;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Links.Winforms.App
{
    internal class ViewNodesPresenter
    {
        private Form _viewNodes;
        internal Form viewNodes
        {
            get => _viewNodes;

            private set => _viewNodes = value;

        }


        private TreeNode _selectedNode;
        
        internal TreeNode SelectedNode
        {
            get => _selectedNode;
            private set => _selectedNode = value;
        }

        internal ViewNodesPresenter(Form ViewNodes)
        {
            this._viewNodes = ViewNodes;
        }


        internal void AddNodeToTreeView(TreeNode treeNode, TreeView treeView1)
        {


            treeView1.Nodes.AddRange(new TreeNode[] { treeNode });
        }

        private void SetTreeNodeValues(TreeNode treeNode, IElement? element)
        {


            if (element != null)
            {
                treeNode.Text = element.TagName;
                treeNode.Name = element.TagName;
                //currentChildTreeNode.Name = html.TagName;
                //currentChildTreeNode.Text = html.InnerHtml;
            }

        }

       internal void GetNodesRecursive(IElement? html, TreeNode currentChildTreeNode, TreeNode? currentParent)
        {
            bool currentParentWasNull = false;
            if (currentParent == null)
            {
                /// only want to do these things one time, at the first entry of the recursion

                currentParentWasNull = true;
                //treeView1.Nodes.Add(currentChildTreeNode);
                // SetTreeNodeValues(currentChildTreeNode, html);
            }





            if (html.HasChildNodes)
            {

                foreach (var element in html.Children)
                {
                    var treeNode = new TreeNode();
                    if (currentParentWasNull)
                    {
                        currentChildTreeNode.Nodes.Add(treeNode);

                    }
                    else
                    {
                        currentParent.Nodes.Add(treeNode);
                    }
                    SetTreeNodeValues(treeNode, element);
                    // currentChildTreeNode.Nodes.Add(treeNode);
                    if (element.HasChildNodes)
                    {

                        //Debug.Print(element.OuterHtml);
                        GetNodesRecursive(element, treeNode, currentChildTreeNode);
                    }
                }
            }
        }
    }
}

using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using HtmlAgilityPack;
using Links.App;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Links.Winforms.App
{
    public partial class ViewNodes : Form
    {

        private ViewNodesPresenter presenter;
        public ViewNodes()
        {

            InitializeComponent();
            presenter = new ViewNodesPresenter(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var htmlNodes = DocumentParserFacade.GetNodes(@"C:\temp\bookmarks6.html");
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            // Suppress repainting the TreeView until all the objects have been created.
            treeView1.BeginUpdate();

            // Clear the TreeView each time the method is called.
            treeView1.Nodes.Clear();


            var treeNode = new TreeNode(htmlNodes[0].TagName);//treeView1.Nodes.Add(htmlNodes[0].TagName, htmlNodes[0].TagName);
            presenter.AddNodeToTreeView(treeNode, treeView1);

            if (htmlNodes != null && htmlNodes.ElementAtOrDefault(1) != null)
            {


                presenter.GetNodesRecursive(htmlNodes.ElementAtOrDefault(0), treeNode, null);
                Debugger.Break();
            }
            // Reset the cursor to the default for all controls.
            Cursor.Current = Cursors.Default;

            // Begin repainting the TreeView.
            treeView1.EndUpdate();
            //his.treeView1.d

        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
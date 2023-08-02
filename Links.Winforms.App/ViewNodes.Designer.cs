namespace Links.Winforms.App
{
    partial class ViewNodes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TreeNode treeNode1 = new TreeNode("Node0");
            treeView1 = new TreeView();
            splitter1 = new Splitter();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1 });
            treeView1.Size = new Size(618, 450);
            treeView1.TabIndex = 0;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Right;
            splitter1.Location = new Point(707, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(132, 842);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // ViewNodes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 842);
            Controls.Add(splitter1);
            Controls.Add(treeView1);
            Name = "ViewNodes";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsRefresh;
        private Splitter splitter1;
    }
}
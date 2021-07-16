
namespace Sts.Lib.Win.Windows.Forms.Dialogs
{
    partial class OpenFolderDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFolderDialog));
            this.statusStrip1 = new Sts.Lib.Win.Windows.Forms.StatusStrip();
            this.panel1 = new Sts.Lib.Win.Windows.Forms.Panel();
            this.panel2 = new Sts.Lib.Win.Windows.Forms.SplitContainer();
            this.toolStrip1 = new Sts.Lib.Win.Windows.Forms.ToolStrip();
            this.tsbUp = new Sts.Lib.Win.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new Sts.Lib.Win.Windows.Forms.ToolStripSeparator();
            this.tstbCurrentPath = new Sts.Lib.Win.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new Sts.Lib.Win.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new Sts.Lib.Win.Windows.Forms.ToolStrip();
            this.toolStripTextBox2 = new Sts.Lib.Win.Windows.Forms.ToolStripTextBox();
            this.tsddbView = new Sts.Lib.Win.Windows.Forms.ToolStripDropDownButton();
            this.splitContainer1 = new Sts.Lib.Win.Windows.Forms.SplitContainer();
            this.twFolders = new Sts.Lib.Win.Windows.Forms.TreeView();
            this.ilIcons32 = new System.Windows.Forms.ImageList(this.components);
            this.lvFolders = new Sts.Lib.Win.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ilIcons64 = new System.Windows.Forms.ImageList(this.components);
            this.ilIcons16 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.Panel1.SuspendLayout();
            this.panel2.Panel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 112);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            // 
            // panel2.Panel1
            // 
            this.panel2.Panel1.Controls.Add(this.toolStrip1);
            // 
            // panel2.Panel2
            // 
            this.panel2.Panel2.Controls.Add(this.toolStrip2);
            this.panel2.Size = new System.Drawing.Size(800, 28);
            this.panel2.SplitterDistance = 609;
            this.panel2.SplitterWidth = 10;
            this.panel2.TabIndex = 2;
            this.panel2.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUp,
            this.toolStripSeparator1,
            this.tstbCurrentPath,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(609, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbUp.Image")));
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(23, 22);
            this.tsbUp.Text = "toolStripButton1";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstbCurrentPath
            // 
            this.tstbCurrentPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbCurrentPath.Name = "tstbCurrentPath";
            this.tstbCurrentPath.Size = new System.Drawing.Size(523, 25);
            this.tstbCurrentPath.Spring = true;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2,
            this.tsddbView});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(181, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(118, 25);
            this.toolStripTextBox2.Spring = true;
            // 
            // tsddbView
            // 
            this.tsddbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddbView.Image = ((System.Drawing.Image)(resources.GetObject("tsddbView.Image")));
            this.tsddbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbView.Name = "tsddbView";
            this.tsddbView.Size = new System.Drawing.Size(29, 22);
            this.tsddbView.Text = "tsddbView";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.twFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvFolders);
            this.splitContainer1.Size = new System.Drawing.Size(800, 288);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // twFolders
            // 
            this.twFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twFolders.ImageIndex = 0;
            this.twFolders.ImageList = this.ilIcons32;
            this.twFolders.Location = new System.Drawing.Point(0, 0);
            this.twFolders.Name = "twFolders";
            this.twFolders.SelectedImageIndex = 0;
            this.twFolders.Size = new System.Drawing.Size(266, 288);
            this.twFolders.TabIndex = 0;
            this.twFolders.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.twFolders_AfterCollapse);
            this.twFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.twFolders_BeforeExpand);
            this.twFolders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.twFolders_AfterExpand);
            this.twFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.twFolders_NodeMouseClick);
            this.twFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.twFolders_KeyDown);
            // 
            // ilIcons32
            // 
            this.ilIcons32.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcons32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons32.ImageStream")));
            this.ilIcons32.TransparentColor = System.Drawing.Color.Black;
            this.ilIcons32.Images.SetKeyName(0, "desktop");
            this.ilIcons32.Images.SetKeyName(1, "documents");
            this.ilIcons32.Images.SetKeyName(2, "folder");
            this.ilIcons32.Images.SetKeyName(3, "hdd");
            this.ilIcons32.Images.SetKeyName(4, "monitor");
            this.ilIcons32.Images.SetKeyName(5, "user-folder");
            this.ilIcons32.Images.SetKeyName(6, "open-folder");
            // 
            // lvFolders
            // 
            this.lvFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFolders.HideSelection = false;
            this.lvFolders.LargeImageList = this.ilIcons64;
            this.lvFolders.Location = new System.Drawing.Point(0, 0);
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.Size = new System.Drawing.Size(524, 288);
            this.lvFolders.SmallImageList = this.ilIcons32;
            this.lvFolders.StateImageList = this.ilIcons32;
            this.lvFolders.TabIndex = 0;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFolders_KeyDown);
            this.lvFolders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFolders_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date Created";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date Modified";
            // 
            // ilIcons64
            // 
            this.ilIcons64.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcons64.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons64.ImageStream")));
            this.ilIcons64.TransparentColor = System.Drawing.Color.Black;
            this.ilIcons64.Images.SetKeyName(0, "desktop");
            this.ilIcons64.Images.SetKeyName(1, "documents");
            this.ilIcons64.Images.SetKeyName(2, "folder");
            this.ilIcons64.Images.SetKeyName(3, "hdd");
            this.ilIcons64.Images.SetKeyName(4, "monitor");
            this.ilIcons64.Images.SetKeyName(5, "user-folder");
            this.ilIcons64.Images.SetKeyName(6, "open-folder");
            // 
            // ilIcons16
            // 
            this.ilIcons16.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcons16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons16.ImageStream")));
            this.ilIcons16.TransparentColor = System.Drawing.Color.Black;
            this.ilIcons16.Images.SetKeyName(0, "desktop");
            this.ilIcons16.Images.SetKeyName(1, "documents");
            this.ilIcons16.Images.SetKeyName(2, "folder");
            this.ilIcons16.Images.SetKeyName(3, "hdd");
            this.ilIcons16.Images.SetKeyName(4, "monitor");
            this.ilIcons16.Images.SetKeyName(5, "user-folder");
            this.ilIcons16.Images.SetKeyName(6, "open-folder");
            // 
            // OpenFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "OpenFolderDialog";
            this.ShowInTaskbar = false;
            this.Text = "OpenFolderDialog";
            this.panel2.Panel1.ResumeLayout(false);
            this.panel2.Panel1.PerformLayout();
            this.panel2.Panel2.ResumeLayout(false);
            this.panel2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private Panel panel1;
        private SplitContainer panel2;
        private SplitContainer splitContainer1;
        private TreeView twFolders;
        private ListView lvFolders;
        private System.Windows.Forms.ImageList ilIcons32;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbUp;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripTextBox tstbCurrentPath;
        private ToolStrip toolStrip2;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripDropDownButton tsddbView;
        private System.Windows.Forms.ImageList ilIcons64;
        private System.Windows.Forms.ImageList ilIcons16;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
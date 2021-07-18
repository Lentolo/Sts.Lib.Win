
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
            this.ssStatus = new Sts.Lib.Win.Windows.Forms.StatusStrip();
            this.spltToolbar = new Sts.Lib.Win.Windows.Forms.SplitContainer();
            this.tsLeft = new Sts.Lib.Win.Windows.Forms.ToolStrip();
            this.tsbUp = new Sts.Lib.Win.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new Sts.Lib.Win.Windows.Forms.ToolStripSeparator();
            this.tstbCurrentPath = new Sts.Lib.Win.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new Sts.Lib.Win.Windows.Forms.ToolStripButton();
            this.tsRight = new Sts.Lib.Win.Windows.Forms.ToolStrip();
            this.toolStripTextBox2 = new Sts.Lib.Win.Windows.Forms.ToolStripTextBox();
            this.tsddbView = new Sts.Lib.Win.Windows.Forms.ToolStripDropDownButton();
            this.ilIcons32 = new System.Windows.Forms.ImageList(this.components);
            this.ilIcons64 = new System.Windows.Forms.ImageList(this.components);
            this.ilIcons16 = new System.Windows.Forms.ImageList(this.components);
            this.spltHorizontal = new Sts.Lib.Win.Windows.Forms.SplitContainer();
            this.spltVertical = new Sts.Lib.Win.Windows.Forms.SplitContainer();
            this.twFolders = new Sts.Lib.Win.Windows.Forms.TreeView();
            this.lvFolders = new Sts.Lib.Win.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.pnlBottom = new Sts.Lib.Win.Windows.Forms.Panel();
            this.groupBox1 = new Sts.Lib.Win.Windows.Forms.GroupBox();
            this.pnlSelectedFolders = new Sts.Lib.Win.Windows.Forms.Panel();
            this.panel1 = new Sts.Lib.Win.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spltToolbar)).BeginInit();
            this.spltToolbar.Panel1.SuspendLayout();
            this.spltToolbar.Panel2.SuspendLayout();
            this.spltToolbar.SuspendLayout();
            this.tsLeft.SuspendLayout();
            this.tsRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltHorizontal)).BeginInit();
            this.spltHorizontal.Panel1.SuspendLayout();
            this.spltHorizontal.Panel2.SuspendLayout();
            this.spltHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltVertical)).BeginInit();
            this.spltVertical.Panel1.SuspendLayout();
            this.spltVertical.Panel2.SuspendLayout();
            this.spltVertical.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssStatus
            // 
            this.ssStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ssStatus.Location = new System.Drawing.Point(0, 644);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(977, 22);
            this.ssStatus.TabIndex = 0;
            this.ssStatus.Text = "ssStatus";
            // 
            // spltToolbar
            // 
            this.spltToolbar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spltToolbar.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.spltToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.spltToolbar.Location = new System.Drawing.Point(0, 0);
            this.spltToolbar.Name = "spltToolbar";
            // 
            // spltToolbar.Panel1
            // 
            this.spltToolbar.Panel1.Controls.Add(this.tsLeft);
            // 
            // spltToolbar.Panel2
            // 
            this.spltToolbar.Panel2.Controls.Add(this.tsRight);
            this.spltToolbar.Size = new System.Drawing.Size(977, 28);
            this.spltToolbar.SplitterDistance = 743;
            this.spltToolbar.SplitterWidth = 10;
            this.spltToolbar.TabIndex = 2;
            this.spltToolbar.TabStop = false;
            // 
            // tsLeft
            // 
            this.tsLeft.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUp,
            this.toolStripSeparator1,
            this.tstbCurrentPath,
            this.toolStripButton2});
            this.tsLeft.Location = new System.Drawing.Point(0, 0);
            this.tsLeft.Name = "tsLeft";
            this.tsLeft.Size = new System.Drawing.Size(743, 25);
            this.tsLeft.TabIndex = 0;
            this.tsLeft.Text = "tsLeft";
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
            this.tstbCurrentPath.Size = new System.Drawing.Size(657, 25);
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
            // tsRight
            // 
            this.tsRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox2,
            this.tsddbView});
            this.tsRight.Location = new System.Drawing.Point(0, 0);
            this.tsRight.Name = "tsRight";
            this.tsRight.Size = new System.Drawing.Size(224, 25);
            this.tsRight.TabIndex = 1;
            this.tsRight.Text = "tsRight";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(161, 25);
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
            // spltHorizontal
            // 
            this.spltHorizontal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spltHorizontal.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.spltHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltHorizontal.Location = new System.Drawing.Point(0, 28);
            this.spltHorizontal.Name = "spltHorizontal";
            this.spltHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltHorizontal.Panel1
            // 
            this.spltHorizontal.Panel1.Controls.Add(this.spltVertical);
            // 
            // spltHorizontal.Panel2
            // 
            this.spltHorizontal.Panel2.Controls.Add(this.pnlBottom);
            this.spltHorizontal.Size = new System.Drawing.Size(977, 616);
            this.spltHorizontal.SplitterDistance = 300;
            this.spltHorizontal.SplitterWidth = 10;
            this.spltHorizontal.TabIndex = 3;
            // 
            // spltVertical
            // 
            this.spltVertical.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spltVertical.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.spltVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltVertical.Location = new System.Drawing.Point(0, 0);
            this.spltVertical.Name = "spltVertical";
            // 
            // spltVertical.Panel1
            // 
            this.spltVertical.Panel1.Controls.Add(this.twFolders);
            // 
            // spltVertical.Panel2
            // 
            this.spltVertical.Panel2.Controls.Add(this.lvFolders);
            this.spltVertical.Size = new System.Drawing.Size(977, 300);
            this.spltVertical.SplitterDistance = 318;
            this.spltVertical.SplitterWidth = 10;
            this.spltVertical.TabIndex = 3;
            this.spltVertical.TabStop = false;
            // 
            // twFolders
            // 
            this.twFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twFolders.ImageIndex = 0;
            this.twFolders.ImageList = this.ilIcons32;
            this.twFolders.Location = new System.Drawing.Point(0, 0);
            this.twFolders.Name = "twFolders";
            this.twFolders.SelectedImageIndex = 0;
            this.twFolders.Size = new System.Drawing.Size(318, 300);
            this.twFolders.TabIndex = 0;
            this.twFolders.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.twFolders_AfterCollapse);
            this.twFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.twFolders_BeforeExpand);
            this.twFolders.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.twFolders_AfterExpand);
            this.twFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.twFolders_NodeMouseClick);
            this.twFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.twFolders_KeyDown);
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
            this.lvFolders.OwnerDraw = true;
            this.lvFolders.ShowGroups = false;
            this.lvFolders.Size = new System.Drawing.Size(649, 300);
            this.lvFolders.SmallImageList = this.ilIcons32;
            this.lvFolders.TabIndex = 0;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvFolders_ItemChecked);
            this.lvFolders.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvFolders_ItemSelectionChanged);
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
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlBottom.Controls.Add(this.groupBox1);
            this.pnlBottom.Controls.Add(this.panel1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(977, 306);
            this.pnlBottom.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlSelectedFolders);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 271);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected folders";
            // 
            // pnlSelectedFolders
            // 
            this.pnlSelectedFolders.AutoScroll = true;
            this.pnlSelectedFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectedFolders.Location = new System.Drawing.Point(3, 19);
            this.pnlSelectedFolders.Name = "pnlSelectedFolders";
            this.pnlSelectedFolders.Size = new System.Drawing.Size(971, 249);
            this.pnlSelectedFolders.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(890, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(809, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // OpenFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 666);
            this.Controls.Add(this.spltHorizontal);
            this.Controls.Add(this.spltToolbar);
            this.Controls.Add(this.ssStatus);
            this.Name = "OpenFolderDialog";
            this.ShowInTaskbar = false;
            this.Text = "OpenFolderDialog";
            this.spltToolbar.Panel1.ResumeLayout(false);
            this.spltToolbar.Panel1.PerformLayout();
            this.spltToolbar.Panel2.ResumeLayout(false);
            this.spltToolbar.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltToolbar)).EndInit();
            this.spltToolbar.ResumeLayout(false);
            this.tsLeft.ResumeLayout(false);
            this.tsLeft.PerformLayout();
            this.tsRight.ResumeLayout(false);
            this.tsRight.PerformLayout();
            this.spltHorizontal.Panel1.ResumeLayout(false);
            this.spltHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltHorizontal)).EndInit();
            this.spltHorizontal.ResumeLayout(false);
            this.spltVertical.Panel1.ResumeLayout(false);
            this.spltVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltVertical)).EndInit();
            this.spltVertical.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip ssStatus;
        private SplitContainer spltToolbar;
        private System.Windows.Forms.ImageList ilIcons32;
        private ToolStrip tsLeft;
        private ToolStripButton tsbUp;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripTextBox tstbCurrentPath;
        private ToolStrip tsRight;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripDropDownButton tsddbView;
        private System.Windows.Forms.ImageList ilIcons64;
        private System.Windows.Forms.ImageList ilIcons16;
        private SplitContainer spltHorizontal;
        private SplitContainer spltVertical;
        private TreeView twFolders;
        private ListView lvFolders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Panel pnlBottom;
        private GroupBox groupBox1;
        private Panel pnlSelectedFolders;
        private Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}
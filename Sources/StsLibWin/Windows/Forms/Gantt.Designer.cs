﻿using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public partial class Gantt
  {
    private System.Windows.Forms.SplitContainer splitContainer1;
    private Panel pnlBottomLeft;
    private Panel pnlTopLeft;
    private Panel pnlBottomRight;
    private Panel pnlDrawBottomLeft;
    private Panel pnlDrawBottomRight;
    private Panel pnlTopRight;
    private Panel pnlDrawTopLeft;
    private Panel pnlDrawTopRight;
    private void InitializeComponent()
    {
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.pnlBottomLeft = new System.Windows.Forms.Panel();
      this.pnlDrawBottomLeft = new System.Windows.Forms.Panel();
      this.pnlTopLeft = new System.Windows.Forms.Panel();
      this.pnlBottomRight = new System.Windows.Forms.Panel();
      this.pnlDrawBottomRight = new System.Windows.Forms.Panel();
      this.pnlTopRight = new System.Windows.Forms.Panel();
      this.pnlDrawTopLeft = new System.Windows.Forms.Panel();
      this.pnlDrawTopRight = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.pnlBottomLeft.SuspendLayout();
      this.pnlTopLeft.SuspendLayout();
      this.pnlBottomRight.SuspendLayout();
      this.pnlTopRight.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.pnlBottomLeft);
      this.splitContainer1.Panel1.Controls.Add(this.pnlTopLeft);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.pnlBottomRight);
      this.splitContainer1.Panel2.Controls.Add(this.pnlTopRight);
      this.splitContainer1.Size = new System.Drawing.Size(500, 432);
      this.splitContainer1.SplitterDistance = 166;
      this.splitContainer1.TabIndex = 0;
      // 
      // pnlBottomLeft
      // 
      this.pnlBottomLeft.Controls.Add(this.pnlDrawBottomLeft);
      this.pnlBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlBottomLeft.Location = new System.Drawing.Point(0, 100);
      this.pnlBottomLeft.Name = "pnlBottomLeft";
      this.pnlBottomLeft.Size = new System.Drawing.Size(166, 332);
      this.pnlBottomLeft.TabIndex = 1;
      // 
      // pnlDrawBottomLeft
      // 
      this.pnlDrawBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDrawBottomLeft.Location = new System.Drawing.Point(3, 6);
      this.pnlDrawBottomLeft.Name = "pnlDrawBottomLeft";
      this.pnlDrawBottomLeft.Size = new System.Drawing.Size(104, 100);
      this.pnlDrawBottomLeft.TabIndex = 1;
      this.pnlDrawBottomLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDrawLeft_Paint);
      // 
      // pnlTopLeft
      // 
      this.pnlTopLeft.Controls.Add(this.pnlDrawTopLeft);
      this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
      this.pnlTopLeft.Name = "pnlTopLeft";
      this.pnlTopLeft.Size = new System.Drawing.Size(166, 100);
      this.pnlTopLeft.TabIndex = 0;
      // 
      // pnlBottomRight
      // 
      this.pnlBottomRight.Controls.Add(this.pnlDrawBottomRight);
      this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlBottomRight.Location = new System.Drawing.Point(0, 100);
      this.pnlBottomRight.Name = "pnlBottomRight";
      this.pnlBottomRight.Size = new System.Drawing.Size(330, 332);
      this.pnlBottomRight.TabIndex = 2;
      // 
      // pnlDrawBottomRight
      // 
      this.pnlDrawBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDrawBottomRight.Location = new System.Drawing.Point(3, 6);
      this.pnlDrawBottomRight.Name = "pnlDrawBottomRight";
      this.pnlDrawBottomRight.Size = new System.Drawing.Size(200, 140);
      this.pnlDrawBottomRight.TabIndex = 0;
      this.pnlDrawBottomRight.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDrawRight_Paint);
      // 
      // pnlTopRight
      // 
      this.pnlTopRight.Controls.Add(this.pnlDrawTopRight);
      this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTopRight.Location = new System.Drawing.Point(0, 0);
      this.pnlTopRight.Name = "pnlTopRight";
      this.pnlTopRight.Size = new System.Drawing.Size(330, 100);
      this.pnlTopRight.TabIndex = 1;
      // 
      // pnlDrawTopLeft
      // 
      this.pnlDrawTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDrawTopLeft.Location = new System.Drawing.Point(31, 0);
      this.pnlDrawTopLeft.Name = "pnlDrawTopLeft";
      this.pnlDrawTopLeft.Size = new System.Drawing.Size(104, 100);
      this.pnlDrawTopLeft.TabIndex = 2;
      // 
      // pnlDrawTopRight
      // 
      this.pnlDrawTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDrawTopRight.Location = new System.Drawing.Point(65, -20);
      this.pnlDrawTopRight.Name = "pnlDrawTopRight";
      this.pnlDrawTopRight.Size = new System.Drawing.Size(200, 140);
      this.pnlDrawTopRight.TabIndex = 1;
      // 
      // Gantt
      // 
      this.Controls.Add(this.splitContainer1);
      this.Name = "Gantt";
      this.Size = new System.Drawing.Size(500, 432);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.pnlBottomLeft.ResumeLayout(false);
      this.pnlTopLeft.ResumeLayout(false);
      this.pnlBottomRight.ResumeLayout(false);
      this.pnlTopRight.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
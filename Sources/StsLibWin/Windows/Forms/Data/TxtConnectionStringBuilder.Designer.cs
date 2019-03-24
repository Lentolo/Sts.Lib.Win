namespace StsLibWin.Windows.Forms.Data
{
    partial class TxtConnectionStringBuilder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnDlg = new System.Windows.Forms.Button();
            this.TxtCn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnDlg
            // 
            this.BtnDlg.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnDlg.Location = new System.Drawing.Point(857, 0);
            this.BtnDlg.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDlg.Name = "BtnDlg";
            this.BtnDlg.Size = new System.Drawing.Size(41, 22);
            this.BtnDlg.TabIndex = 1;
            this.BtnDlg.Text = "...";
            this.BtnDlg.UseVisualStyleBackColor = true;
            // 
            // TxtCn
            // 
            this.TxtCn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtCn.Location = new System.Drawing.Point(0, 0);
            this.TxtCn.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCn.Name = "TxtCn";
            this.TxtCn.Size = new System.Drawing.Size(857, 22);
            this.TxtCn.TabIndex = 0;
            this.TxtCn.Leave += new System.EventHandler(this.TxtCn_Leave);
            // 
            // TxtConnectionStringBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtCn);
            this.Controls.Add(this.BtnDlg);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TxtConnectionStringBuilder";
            this.Size = new System.Drawing.Size(898, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnDlg;
        private System.Windows.Forms.TextBox TxtCn;
    }
}

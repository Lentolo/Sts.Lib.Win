using System;
using System.Data.OleDb;
using System.Windows.Forms;
using Sts.Lib.Data;
using Sts.Lib.Data.Connections.OleDb;
using Sts.Lib.Data.Generic;
using Sts.Lib.Win.Windows.Forms.Data;
using Button = Sts.Lib.Win.Windows.Forms.Button;
using Label = Sts.Lib.Win.Windows.Forms.Label;
using TextBox = Sts.Lib.Win.Windows.Forms.TextBox;

namespace Sts.Lib.Win.Data.Connections.OleDB
{
    public class DatabaseConnectionBuilder : DatabaseConnectionBuilderBase
    {
        public DatabaseConnectionBuilder()
        {
            InitializeComponent();
        }
        private Label label1;
        private TextBox txtSrv;
        private TextBox txtPwd;
        private Button btnBrowse;
        private OpenFileDialog ofdBrowseDB;
        private Label label3;

        private void InitializeComponent()
        {
            this.label1 = new Sts.Lib.Win.Windows.Forms.Label();
            this.txtSrv = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.txtPwd = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.label3 = new Sts.Lib.Win.Windows.Forms.Label();
            this.btnBrowse = new Sts.Lib.Win.Windows.Forms.Button();
            this.ofdBrowseDB = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database File";
            // 
            // txtSrv
            // 
            this.txtSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrv.SaveControlState = false;
            this.txtSrv.Location = new System.Drawing.Point(104, 15);
            this.txtSrv.Name = "txtSrv";
            this.txtSrv.Size = new System.Drawing.Size(308, 22);
            this.txtSrv.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.SaveControlState = false;
            this.txtPwd.Location = new System.Drawing.Point(104, 43);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(308, 22);
            this.txtPwd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(418, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ofdBrowseDB
            // 
            this.ofdBrowseDB.FileName = "openFileDialog1";
            // 
            // DatabaseConnectionBuilder
            // 
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSrv);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseConnectionBuilder";
            this.Size = new System.Drawing.Size(451, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public override GenericConnectionString ConnectionString
        {
            get
            {
                var builder = new OleDbConnectionStringBuilder
                {
                    DataSource = txtSrv.Text
                };

                if (!string.IsNullOrEmpty(txtPwd.Text))
                {
                    builder.Add("Database Password", txtPwd.Text);
                }

                return new GenericConnectionString(typeof(Sts.Lib.Data.Connections.OleDb.OleDbEnhancedConnection),
                                                   builder.ConnectionString);
            }
        }
        public override string DatabaseTypeName
        {
            get
            {
                return "OleDB";
            }
        }
        public override bool Test()
        {
            try
            {
                using var db = ConnectionString.CreateAndOpenConnection();
                return true;
            }
            catch
            { }
            return false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofdBrowseDB.ShowDialog(this) == DialogResult.OK)
            {
                txtSrv.Text = ofdBrowseDB.FileName;
            }
        }
    }
}

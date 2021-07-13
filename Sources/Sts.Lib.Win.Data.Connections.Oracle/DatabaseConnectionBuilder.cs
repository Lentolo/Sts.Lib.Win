using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Sts.Lib.Data;
using Sts.Lib.Data.Generic;
using Sts.Lib.Win.Windows.Forms.Data;
using Label = Sts.Lib.Win.Windows.Forms.Label;
using TextBox = Sts.Lib.Win.Windows.Forms.TextBox;

namespace Sts.Lib.Win.Data.Connections.Oracle
{
    public class DatabaseConnectionBuilder : DatabaseConnectionBuilderBase
    {
        public DatabaseConnectionBuilder()
        {
            InitializeComponent();
        }
        private Label label1;
        private TextBox txtSrv;
        private TextBox txtPort;
        private Label label2;
        private TextBox txtPwd;
        private Label label3;
        private TextBox txtUid;
        private Label label5;
        private TextBox txtSid;
        private Label label4;

        private void InitializeComponent()
        {
            this.label1 = new Sts.Lib.Win.Windows.Forms.Label();
            this.txtSrv = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.txtPort = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.label2 = new Sts.Lib.Win.Windows.Forms.Label();
            this.txtPwd = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.label3 = new Sts.Lib.Win.Windows.Forms.Label();
            this.txtUid = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.label4 = new Sts.Lib.Win.Windows.Forms.Label();
            this.label5 = new Sts.Lib.Win.Windows.Forms.Label();
            this.txtSid = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // txtSrv
            // 
            this.txtSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrv.SaveControlState = false;
            this.txtSrv.Location = new System.Drawing.Point(62, 15);
            this.txtSrv.Name = "txtSrv";
            this.txtSrv.Size = new System.Drawing.Size(386, 20);
            this.txtSrv.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.SaveControlState = false;
            this.txtPort.Location = new System.Drawing.Point(364, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(84, 20);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "1521";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sid";
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.SaveControlState = false;
            this.txtPwd.Location = new System.Drawing.Point(62, 93);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(386, 20);
            this.txtPwd.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtUid
            // 
            this.txtUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUid.SaveControlState = false;
            this.txtUid.Location = new System.Drawing.Point(62, 67);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(386, 20);
            this.txtUid.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "User";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // txtSid
            // 
            this.txtSid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSid.SaveControlState = false;
            this.txtSid.Location = new System.Drawing.Point(62, 41);
            this.txtSid.Name = "txtSid";
            this.txtSid.Size = new System.Drawing.Size(264, 20);
            this.txtSid.TabIndex = 1;
            this.txtSid.Text = "orcl";
            // 
            // DatabaseConnectionBuilder
            // 
            this.Controls.Add(this.txtSid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSrv);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseConnectionBuilder";
            this.Size = new System.Drawing.Size(451, 124);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public override GenericConnectionString ConnectionString
        {
            get
            {
                return new GenericConnectionString(typeof(OracleEnhancedConnection), $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={txtSrv.Text})(PORT={txtPort.Text}))(CONNECT_DATA=(SERVICE_NAME={txtSid.Text})));User Id={txtUid.Text};Password={txtPwd.Text};");
            }
        }
        public override string DatabaseTypeName
        {
            get
            {
                return "Oracle";
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

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

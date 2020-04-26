using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StsLib.Data.Connections.SqLite;
using StsLibWin.Windows.Forms.Data;
using ComboBox = StsLibWin.Windows.Forms.ComboBox;
using Label = StsLibWin.Windows.Forms.Label;
using TextBox = StsLibWin.Windows.Forms.TextBox;

namespace StsLibWin.Data.Connections.SqlServer
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
            this.label1 = new StsLibWin.Windows.Forms.Label();
            this.txtSrv = new StsLibWin.Windows.Forms.TextBox();
            this.txtPwd = new StsLibWin.Windows.Forms.TextBox();
            this.label3 = new StsLibWin.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
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
            this.txtSrv.CanSaveControlState = false;
            this.txtSrv.Location = new System.Drawing.Point(104, 15);
            this.txtSrv.Name = "txtSrv";
            this.txtSrv.Size = new System.Drawing.Size(308, 22);
            this.txtSrv.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.CanSaveControlState = false;
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
        public override string ConnectionString
        {
            get
            {
                return "Sts Provider=" + typeof(DatabaseConnection).FullName + ";" + ConnectionStringNoProvider;
            }
        }
        public override string ConnectionStringNoProvider
        {
            get
            {
                var connectionStringNoProvider = $"Data Source={txtSrv.Text};";
                if (!string.IsNullOrEmpty(txtPwd.Text))
                {
                    connectionStringNoProvider += $"Password={txtPwd.Text};";
                }

                return connectionStringNoProvider;
            }
        }
        public override string DatabaseTypeName
        {
            get
            {
                return "SqLite";
            }
        }
        public override Type DatabaseConnectionType
        {
            get
            {
                return typeof(DatabaseConnection);
            }
        }
        public override bool Test()
        {
            try
            {
                using (var db = new DatabaseConnection
                {
                    ConnectionString = ConnectionStringNoProvider
                })
                {
                    db.Open();
                    return true;
                }
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

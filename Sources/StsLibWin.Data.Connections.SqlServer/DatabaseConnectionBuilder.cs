using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StsLib.Data.Connections.SqlServer;
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
        private TextBox txtPort;
        private Label label2;
        private TextBox txtPwd;
        private Label label3;
        private TextBox txtUid;
        private ComboBox cmbDB;
        private Label label5;
        private Label label4;

        private void InitializeComponent()
        {
            this.label1 = new StsLibWin.Windows.Forms.Label();
            this.txtSrv = new StsLibWin.Windows.Forms.TextBox();
            this.txtPort = new StsLibWin.Windows.Forms.TextBox();
            this.label2 = new StsLibWin.Windows.Forms.Label();
            this.txtPwd = new StsLibWin.Windows.Forms.TextBox();
            this.label3 = new StsLibWin.Windows.Forms.Label();
            this.txtUid = new StsLibWin.Windows.Forms.TextBox();
            this.label4 = new StsLibWin.Windows.Forms.Label();
            this.cmbDB = new StsLibWin.Windows.Forms.ComboBox();
            this.label5 = new StsLibWin.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // txtSrv
            // 
            this.txtSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSrv.CanSaveControlState = false;
            this.txtSrv.Location = new System.Drawing.Point(78, 15);
            this.txtSrv.Name = "txtSrv";
            this.txtSrv.Size = new System.Drawing.Size(370, 22);
            this.txtSrv.TabIndex = 1;
            this.txtSrv.Leave += new System.EventHandler(this.field_Leave);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.CanSaveControlState = false;
            this.txtPort.Location = new System.Drawing.Point(364, 99);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(84, 22);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "1433";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            this.txtPort.Leave += new System.EventHandler(this.field_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Database";
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.CanSaveControlState = false;
            this.txtPwd.Location = new System.Drawing.Point(78, 71);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(370, 22);
            this.txtPwd.TabIndex = 5;
            this.txtPwd.Leave += new System.EventHandler(this.field_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtUid
            // 
            this.txtUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUid.CanSaveControlState = false;
            this.txtUid.Location = new System.Drawing.Point(78, 43);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(370, 22);
            this.txtUid.TabIndex = 3;
            this.txtUid.Leave += new System.EventHandler(this.field_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "User";
            // 
            // cmbDB
            // 
            this.cmbDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(78, 99);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(240, 24);
            this.cmbDB.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // DatabaseConnectionBuilder
            // 
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSrv);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseConnectionBuilder";
            this.Size = new System.Drawing.Size(451, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public override string ConnectionString
        {
            get
            {
                return "Provider=" + typeof(DatabaseConnection).FullName + ";" + ConnectionStringNoProvider;
            }
        }
        public override string ConnectionStringNoProvider
        {
            get
            {
                var connectionStringNoProvider = $"MultipleActiveResultSets=True;User ID={txtUid.Text};Server={txtSrv.Text};";
                if (!string.IsNullOrEmpty(txtPort.Text) && txtPort.Text != "1433")
                {
                    connectionStringNoProvider = $"User ID={txtUid.Text};Server={txtSrv.Text},{txtPort.Text};";
                }
                if (!string.IsNullOrEmpty(txtPwd.Text))
                {
                    connectionStringNoProvider += $"Password={txtPwd.Text};";
                }
                if (!string.IsNullOrEmpty(cmbDB.SelectedItem as string))
                {
                    connectionStringNoProvider += $"Database={cmbDB.SelectedItem as string};";
                }

                return connectionStringNoProvider;
            }
        }
        public override string DatabaseTypeName
        {
            get
            {
                return "Sql Server";
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

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void field_Leave(object sender, EventArgs e)
        {
            FillCombo();
        }

        void FillCombo()
        {
            if (cmbDB.Items.Count == 0 && !string.IsNullOrEmpty(txtSrv.Text) && !string.IsNullOrEmpty(txtUid.Text))
            {
                try
                {
                    using (var db = new DatabaseConnection
                    {
                        ConnectionString = ConnectionStringNoProvider
                    })
                    {
                        db.Open();
                        cmbDB.Items.AddRange(db.ServerSchema.Databases.Select(d => d.Name).ToArray());
                    }
                }
                catch
                { }
            }
        }
    }
}

using System;
using System.Linq;

namespace Sts.Lib.Win.Data.Connections.Postgres
{
    public class DatabaseConnectionBuilder : Sts.Lib.Win.Windows.Forms.Data.DatabaseConnectionBuilderBase
    {
        public DatabaseConnectionBuilder()
        {
            InitializeComponent();
        }
        private Sts.Lib.Win.Windows.Forms.Label label1;
        private Sts.Lib.Win.Windows.Forms.TextBox txtSrv;
        private Sts.Lib.Win.Windows.Forms.TextBox txtPort;
        private Sts.Lib.Win.Windows.Forms.Label label2;
        private Sts.Lib.Win.Windows.Forms.TextBox txtPwd;
        private Sts.Lib.Win.Windows.Forms.Label label3;
        private Sts.Lib.Win.Windows.Forms.TextBox txtUid;
        private Sts.Lib.Win.Windows.Forms.ComboBox cmbDB;
        private Sts.Lib.Win.Windows.Forms.Label label5;
        private Sts.Lib.Win.Windows.Forms.Label label4;

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
            this.cmbDB = new Sts.Lib.Win.Windows.Forms.ComboBox();
            this.label5 = new Sts.Lib.Win.Windows.Forms.Label();
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
            this.txtSrv.CanSaveControlState = false;
            this.txtSrv.Location = new System.Drawing.Point(78, 15);
            this.txtSrv.Name = "txtSrv";
            this.txtSrv.Size = new System.Drawing.Size(370, 20);
            this.txtSrv.TabIndex = 1;
            this.txtSrv.Leave += new System.EventHandler(this.txtSrv_Leave);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.CanSaveControlState = false;
            this.txtPort.Location = new System.Drawing.Point(364, 99);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(84, 20);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "5432";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            this.txtPort.Leave += new System.EventHandler(this.txtPort_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
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
            this.txtPwd.Size = new System.Drawing.Size(370, 20);
            this.txtPwd.TabIndex = 5;
            this.txtPwd.Leave += new System.EventHandler(this.txtPwd_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
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
            this.txtUid.Size = new System.Drawing.Size(370, 20);
            this.txtUid.TabIndex = 3;
            this.txtUid.Leave += new System.EventHandler(this.txtUid_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
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
            this.cmbDB.Size = new System.Drawing.Size(240, 21);
            this.cmbDB.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
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
                return "Sts Provider=" + typeof(Sts.Lib.Data.Connections.Postgres.DatabaseConnection).FullName + ";" + ConnectionStringNoProvider;
            }
        }
        public override string ConnectionStringNoProvider
        {
            get
            {
                var connectionStringNoProvider = $"User ID={txtUid.Text};Host={txtSrv.Text};";
                if (!string.IsNullOrEmpty(txtPwd.Text))
                {
                    connectionStringNoProvider += $"Password={txtPwd.Text};";
                }
                if (!string.IsNullOrEmpty(txtPort.Text) && txtPort.Text != "5432")
                {
                    connectionStringNoProvider += $"Port={txtPort.Text};";
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
                return "Postgres";
            }
        }
        public override Type DatabaseConnectionType
        {
            get
            {
                return typeof(Sts.Lib.Data.Connections.Postgres.DatabaseConnection);
            }
        }
        public override bool Test()
        {
            try
            {
                using (var db = new Sts.Lib.Data.Connections.Postgres.DatabaseConnection()
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

        private void txtPort_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSrv_Leave(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void txtUid_Leave(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            FillCombo();
        }

        void FillCombo()
        {
            if (cmbDB.Items.Count == 0 && !string.IsNullOrEmpty(txtSrv.Text) && !string.IsNullOrEmpty(txtUid.Text))
            {
                try
                {
                    using (var db = new Sts.Lib.Data.Connections.Postgres.DatabaseConnection()
                    {
                        ConnectionString = ConnectionStringNoProvider
                    })
                    {
                        db.Open();
                        cmbDB.Items.AddRange(db.ExecuteReaderAndMap("SELECT datname FROM pg_database;", r => r["datname"] as string).OrderBy(i => i.ToLowerInvariant()).ToArray());
                    }
                }
                catch
                { }
            }
        }
        private void txtPort_Leave(object sender, EventArgs e)
        {
            FillCombo();
        }
    }
}

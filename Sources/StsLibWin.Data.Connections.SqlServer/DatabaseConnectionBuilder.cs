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
            label1 = new Label();
            txtSrv = new TextBox();
            txtPort = new TextBox();
            label2 = new Label();
            txtPwd = new TextBox();
            label3 = new Label();
            txtUid = new TextBox();
            label4 = new Label();
            cmbDB = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 18);
            label1.Name = "label1";
            label1.Size = new Size(38, 13);
            label1.TabIndex = 0;
            label1.Text = "Server";
            // 
            // txtSrv
            // 
            txtSrv.Anchor = (AnchorStyles.Top | AnchorStyles.Left)
                            | AnchorStyles.Right;
            txtSrv.CanSaveControlState = false;
            txtSrv.Location = new Point(78, 15);
            txtSrv.Name = "txtSrv";
            txtSrv.Size = new Size(370, 20);
            txtSrv.TabIndex = 1;
            txtSrv.Leave += field_Leave;
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPort.CanSaveControlState = false;
            txtPort.Location = new Point(364, 99);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(84, 20);
            txtPort.TabIndex = 9;
            txtPort.Text = "1433";
            txtPort.TextAlign = HorizontalAlignment.Right;
            txtPort.KeyPress += txtPort_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 102);
            label2.Name = "label2";
            label2.Size = new Size(53, 13);
            label2.TabIndex = 6;
            label2.Text = "Database";
            // 
            // txtPwd
            // 
            txtPwd.Anchor = (AnchorStyles.Top | AnchorStyles.Left)
                            | AnchorStyles.Right;
            txtPwd.CanSaveControlState = false;
            txtPwd.Location = new Point(78, 71);
            txtPwd.Name = "txtPwd";
            txtPwd.PasswordChar = '*';
            txtPwd.Size = new Size(370, 20);
            txtPwd.TabIndex = 5;
            txtPwd.Leave += field_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 74);
            label3.Name = "label3";
            label3.Size = new Size(53, 13);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // txtUid
            // 
            txtUid.Anchor = (AnchorStyles.Top | AnchorStyles.Left)
                            | AnchorStyles.Right;
            txtUid.CanSaveControlState = false;
            txtUid.Location = new Point(78, 43);
            txtUid.Name = "txtUid";
            txtUid.Size = new Size(370, 20);
            txtUid.TabIndex = 3;
            txtUid.Leave += field_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 46);
            label4.Name = "label4";
            label4.Size = new Size(29, 13);
            label4.TabIndex = 2;
            label4.Text = "User";
            // 
            // cmbDB
            // 
            cmbDB.Anchor = (AnchorStyles.Top | AnchorStyles.Left)
                           | AnchorStyles.Right;
            cmbDB.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDB.FormattingEnabled = true;
            cmbDB.Location = new Point(78, 99);
            cmbDB.Name = "cmbDB";
            cmbDB.Size = new Size(240, 21);
            cmbDB.TabIndex = 7;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(332, 102);
            label5.Name = "label5";
            label5.Size = new Size(26, 13);
            label5.TabIndex = 8;
            label5.Text = "Port";
            // 
            // DatabaseConnectionBuilder
            // 
            Controls.Add(label5);
            Controls.Add(cmbDB);
            Controls.Add(txtUid);
            Controls.Add(label4);
            Controls.Add(txtPwd);
            Controls.Add(label3);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(txtSrv);
            Controls.Add(label1);
            Name = "DatabaseConnectionBuilder";
            Size = new Size(451, 129);
            ResumeLayout(false);
            PerformLayout();

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
                var connectionStringNoProvider = $"User ID={txtUid.Text};Server={txtSrv.Text};";
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
        private void txtPort_Leave(object sender, EventArgs e)
        {
            FillCombo();
        }
    }
}

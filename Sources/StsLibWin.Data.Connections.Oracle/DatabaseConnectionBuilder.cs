using System;
using System.Drawing;
using System.Windows.Forms;
using StsLibWin.Windows.Forms.Data;
using Label = StsLibWin.Windows.Forms.Label;
using TextBox = StsLibWin.Windows.Forms.TextBox;

namespace StsLibWin.Data.Connections.Oracle
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
            label1 = new Label();
            txtSrv = new TextBox();
            txtPort = new TextBox();
            label2 = new Label();
            txtPwd = new TextBox();
            label3 = new Label();
            txtUid = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtSid = new TextBox();
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
            txtSrv.Location = new Point(62, 15);
            txtSrv.Name = "txtSrv";
            txtSrv.Size = new Size(386, 20);
            txtSrv.TabIndex = 0;
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPort.CanSaveControlState = false;
            txtPort.Location = new Point(364, 41);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(84, 20);
            txtPort.TabIndex = 2;
            txtPort.Text = "1521";
            txtPort.TextAlign = HorizontalAlignment.Right;
            txtPort.KeyPress += txtPort_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 44);
            label2.Name = "label2";
            label2.Size = new Size(22, 13);
            label2.TabIndex = 6;
            label2.Text = "Sid";
            // 
            // txtPwd
            // 
            txtPwd.Anchor = (AnchorStyles.Top | AnchorStyles.Left) 
                            | AnchorStyles.Right;
            txtPwd.CanSaveControlState = false;
            txtPwd.Location = new Point(62, 93);
            txtPwd.Name = "txtPwd";
            txtPwd.PasswordChar = '*';
            txtPwd.Size = new Size(386, 20);
            txtPwd.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 96);
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
            txtUid.Location = new Point(62, 67);
            txtUid.Name = "txtUid";
            txtUid.Size = new Size(386, 20);
            txtUid.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 70);
            label4.Name = "label4";
            label4.Size = new Size(29, 13);
            label4.TabIndex = 2;
            label4.Text = "User";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(332, 44);
            label5.Name = "label5";
            label5.Size = new Size(26, 13);
            label5.TabIndex = 8;
            label5.Text = "Port";
            // 
            // txtSid
            // 
            txtSid.Anchor = (AnchorStyles.Top | AnchorStyles.Left) 
                            | AnchorStyles.Right;
            txtSid.CanSaveControlState = false;
            txtSid.Location = new Point(62, 41);
            txtSid.Name = "txtSid";
            txtSid.Size = new Size(264, 20);
            txtSid.TabIndex = 1;
            // 
            // DatabaseConnectionBuilder
            // 
            Controls.Add(txtSid);
            Controls.Add(label5);
            Controls.Add(txtUid);
            Controls.Add(label4);
            Controls.Add(txtPwd);
            Controls.Add(label3);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(txtSrv);
            Controls.Add(label1);
            Name = "DatabaseConnectionBuilder";
            Size = new Size(451, 124);
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
                return $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={txtSrv.Text})(PORT={txtPort.Text}))(CONNECT_DATA=(SERVICE_NAME={txtSid.Text})));User Id={txtUid.Text};Password={txtPwd.Text};";
            }
        }
        public override string DatabaseTypeName
        {
            get
            {
                return "Oracle";
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
    }
}

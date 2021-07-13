using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data.Extensions;
using Sts.Lib.Win.Windows.Forms.Extensions;

namespace Sts.Lib.Win.Windows.Forms.Data
{
    public class CommonDatabaseConnectionBuilderBase : DatabaseConnectionBuilderBase
    {
        protected CommonDatabaseConnectionBuilderBase()
        {
            InitializeComponent();
        }

        private static object Lock { get; } = new object();
        protected ComboBox CmbDB { get; set; }
        protected Label Label1 { get; set; }
        protected Label Label2 { get; set; }
        protected Label Label3 { get; set; }
        protected Label Label4 { get; set; }
        protected Label Label5 { get; set; }
        protected TextBox TxtPort { get; set; }
        protected TextBox TxtPwd { get; set; }
        protected TextBox TxtSrv { get; set; }
        protected TextBox TxtUid { get; set; }

        private void InitializeComponent()
        {
            this.Label1 = new Sts.Lib.Win.Windows.Forms.Label();
            this.TxtSrv = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.TxtPort = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.Label2 = new Sts.Lib.Win.Windows.Forms.Label();
            this.TxtPwd = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.Label3 = new Sts.Lib.Win.Windows.Forms.Label();
            this.TxtUid = new Sts.Lib.Win.Windows.Forms.TextBox();
            this.Label4 = new Sts.Lib.Win.Windows.Forms.Label();
            this.CmbDB = new Sts.Lib.Win.Windows.Forms.ComboBox();
            this.Label5 = new Sts.Lib.Win.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Server";
            // 
            // txtSrv
            // 
            this.TxtSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSrv.Location = new System.Drawing.Point(78, 15);
            this.TxtSrv.Name = "TxtSrv";
            this.TxtSrv.SaveControlState = false;
            this.TxtSrv.Size = new System.Drawing.Size(370, 23);
            this.TxtSrv.TabIndex = 1;
            this.TxtSrv.TextChanged += new System.EventHandler(this.field_Changed);
            this.TxtSrv.Leave+= new System.EventHandler(this.field_Leave);
            // 
            // txtPort
            // 
            this.TxtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPort.Location = new System.Drawing.Point(364, 99);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.SaveControlState = false;
            this.TxtPort.Size = new System.Drawing.Size(84, 23);
            this.TxtPort.TabIndex = 9;
            this.TxtPort.Text = "1433";
            this.TxtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPort.TextChanged += new System.EventHandler(this.field_Changed);
            this.TxtPort.Leave += new System.EventHandler(this.field_Leave);
            this.TxtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(3, 102);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(55, 15);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Database";
            // 
            // txtPwd
            // 
            this.TxtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPwd.Location = new System.Drawing.Point(78, 71);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.PasswordChar = '*';
            this.TxtPwd.SaveControlState = false;
            this.TxtPwd.Size = new System.Drawing.Size(370, 23);
            this.TxtPwd.TabIndex = 5;
            this.TxtPwd.TextChanged += new System.EventHandler(this.field_Changed);
            this.TxtPwd.Leave += new System.EventHandler(this.field_Leave);
            // 
            // label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(3, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 15);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Password";
            // 
            // txtUid
            // 
            this.TxtUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUid.Location = new System.Drawing.Point(78, 43);
            this.TxtUid.Name = "TxtUid";
            this.TxtUid.SaveControlState = false;
            this.TxtUid.Size = new System.Drawing.Size(370, 23);
            this.TxtUid.TabIndex = 3;
            this.TxtUid.TextChanged += new System.EventHandler(this.field_Changed);
            this.TxtUid.Leave += new System.EventHandler(this.field_Leave);
            // 
            // label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(3, 46);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(30, 15);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "User";
            // 
            // cmbDB
            // 
            this.CmbDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                                                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDB.FormattingEnabled = true;
            this.CmbDB.Location = new System.Drawing.Point(78, 99);
            this.CmbDB.Name = "CmbDB";
            this.CmbDB.Size = new System.Drawing.Size(240, 23);
            this.CmbDB.TabIndex = 7;
            // 
            // label5
            // 
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(324, 102);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(29, 15);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Port";
            // 
            // DatabaseConnectionBuilder
            // 
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CmbDB);
            this.Controls.Add(this.TxtUid);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtPort);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtSrv);
            this.Controls.Add(this.Label1);
            this.Name = "DatabaseConnectionBuilder";
            this.Size = new System.Drawing.Size(451, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void FillComboTask()
        {
            if (InvokeRequired)
            {
                this.Invoke(FillComboTask);
                return;
            }

            lock (Lock)
            {
                FillCombo();
            }
        }
        void FillCombo()
        {
            if (CmbDB.Items.Count == 0 && !string.IsNullOrEmpty(TxtSrv.Text) && !string.IsNullOrEmpty(TxtUid.Text))
            {
                try
                {
                    using var db = OpenConnection();
                    CmbDB.Items.AddRange(GetDatabases(db));
                }
                catch
                {
                }
            }
        }

        private async void field_Leave(object sender, EventArgs e)
        {
            await Task.Run((Action) FillComboTask);
        }

        private void field_Changed(object sender, EventArgs e)
        {
            CmbDB.Items.Clear();
        }

        protected virtual string[] GetDatabases(IDbConnection db)
        {
            throw  new NotImplementedException();
        }
    }
}
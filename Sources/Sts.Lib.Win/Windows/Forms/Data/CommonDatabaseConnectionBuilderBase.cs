using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data.Interfaces;

namespace Sts.Lib.Win.Windows.Forms.Data;

public class CommonDatabaseConnectionBuilderBase : DatabaseConnectionBuilderBase
{
    protected CommonDatabaseConnectionBuilderBase()
    {
        InitializeComponent();
    }

    protected ComboBox CmbDB
    {
        get;
        set;
    }

    protected Label Label1
    {
        get;
        set;
    }

    protected Label Label2
    {
        get;
        set;
    }

    protected Label Label3
    {
        get;
        set;
    }

    protected Label Label4
    {
        get;
        set;
    }

    protected Label Label5
    {
        get;
        set;
    }

    protected TextBox TxtPort
    {
        get;
        set;
    }

    protected TextBox TxtPwd
    {
        get;
        set;
    }

    protected TextBox TxtSrv
    {
        get;
        set;
    }

    protected TextBox TxtUid
    {
        get;
        set;
    }

    private void InitializeComponent()
    {
        Label1 = new Label();
        TxtSrv = new TextBox();
        TxtPort = new TextBox();
        Label2 = new Label();
        TxtPwd = new TextBox();
        Label3 = new Label();
        TxtUid = new TextBox();
        Label4 = new Label();
        CmbDB = new ComboBox();
        Label5 = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        Label1.AutoSize = true;
        Label1.Location = new Point(3, 18);
        Label1.Name = "Label1";
        Label1.Size = new Size(39, 15);
        Label1.TabIndex = 0;
        Label1.Text = "Server";
        // 
        // txtSrv
        // 
        TxtSrv.Anchor = AnchorStyles.Top
                        | AnchorStyles.Left
                        | AnchorStyles.Right;
        TxtSrv.Location = new Point(78, 15);
        TxtSrv.Name = "TxtSrv";
        TxtSrv.SaveControlState = false;
        TxtSrv.Size = new Size(370, 23);
        TxtSrv.TabIndex = 1;
        TxtSrv.TextChanged += field_Changed;
        TxtSrv.Leave += field_Leave;
        // 
        // txtPort
        // 
        TxtPort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        TxtPort.Location = new Point(364, 99);
        TxtPort.Name = "TxtPort";
        TxtPort.SaveControlState = false;
        TxtPort.Size = new Size(84, 23);
        TxtPort.TabIndex = 9;
        TxtPort.Text = "1433";
        TxtPort.TextAlign = HorizontalAlignment.Right;
        TxtPort.TextChanged += field_Changed;
        TxtPort.Leave += field_Leave;
        TxtPort.KeyPress += txtPort_KeyPress;
        // 
        // label2
        // 
        Label2.AutoSize = true;
        Label2.Location = new Point(3, 102);
        Label2.Name = "Label2";
        Label2.Size = new Size(55, 15);
        Label2.TabIndex = 6;
        Label2.Text = "Database";
        // 
        // txtPwd
        // 
        TxtPwd.Anchor = AnchorStyles.Top
                        | AnchorStyles.Left
                        | AnchorStyles.Right;
        TxtPwd.Location = new Point(78, 71);
        TxtPwd.Name = "TxtPwd";
        TxtPwd.PasswordChar = '*';
        TxtPwd.SaveControlState = false;
        TxtPwd.Size = new Size(370, 23);
        TxtPwd.TabIndex = 5;
        TxtPwd.TextChanged += field_Changed;
        TxtPwd.Leave += field_Leave;
        // 
        // label3
        // 
        Label3.AutoSize = true;
        Label3.Location = new Point(3, 74);
        Label3.Name = "Label3";
        Label3.Size = new Size(57, 15);
        Label3.TabIndex = 4;
        Label3.Text = "Password";
        // 
        // txtUid
        // 
        TxtUid.Anchor = AnchorStyles.Top
                        | AnchorStyles.Left
                        | AnchorStyles.Right;
        TxtUid.Location = new Point(78, 43);
        TxtUid.Name = "TxtUid";
        TxtUid.SaveControlState = false;
        TxtUid.Size = new Size(370, 23);
        TxtUid.TabIndex = 3;
        TxtUid.TextChanged += field_Changed;
        TxtUid.Leave += field_Leave;
        // 
        // label4
        // 
        Label4.AutoSize = true;
        Label4.Location = new Point(3, 46);
        Label4.Name = "Label4";
        Label4.Size = new Size(30, 15);
        Label4.TabIndex = 2;
        Label4.Text = "User";
        // 
        // cmbDB
        // 
        CmbDB.Anchor = AnchorStyles.Top
                       | AnchorStyles.Left
                       | AnchorStyles.Right;
        CmbDB.DropDownStyle = ComboBoxStyle.DropDownList;
        CmbDB.FormattingEnabled = true;
        CmbDB.Location = new Point(78, 99);
        CmbDB.Name = "CmbDB";
        CmbDB.Size = new Size(240, 23);
        CmbDB.TabIndex = 7;
        // 
        // label5
        // 
        Label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        Label5.AutoSize = true;
        Label5.Location = new Point(324, 102);
        Label5.Name = "Label5";
        Label5.Size = new Size(29, 15);
        Label5.TabIndex = 8;
        Label5.Text = "Port";
        // 
        // DatabaseConnectionBuilder
        // 
        Controls.Add(Label5);
        Controls.Add(CmbDB);
        Controls.Add(TxtUid);
        Controls.Add(Label4);
        Controls.Add(TxtPwd);
        Controls.Add(Label3);
        Controls.Add(TxtPort);
        Controls.Add(Label2);
        Controls.Add(TxtSrv);
        Controls.Add(Label1);
        Name = "DatabaseConnectionBuilder";
        Size = new Size(451, 129);
        ResumeLayout(false);
        PerformLayout();
    }

    private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private async Task FillCombo()
    {
        if (CmbDB.Items.Count == 0 && !string.IsNullOrEmpty(TxtSrv.Text) && !string.IsNullOrEmpty(TxtUid.Text))
        {
            try
            {
                using var db = await ConnectionString.CreateAndOpenConnectionAsync();
                CmbDB.Items.AddRange(GetDatabases(db));
            }
            catch
            { }
        }
    }

    private async void field_Leave(object sender, EventArgs e)
    {
        await FillCombo();
    }

    private void field_Changed(object sender, EventArgs e)
    {
        CmbDB.Items.Clear();
    }

    protected virtual string[] GetDatabases(IEnhancedDbConnection db)
    {
        throw new NotImplementedException();
    }
}

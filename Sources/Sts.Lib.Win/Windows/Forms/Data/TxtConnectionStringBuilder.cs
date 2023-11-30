using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Sts.Lib.Common;
using Sts.Lib.Data;

namespace Sts.Lib.Win.Windows.Forms.Data;

public class TxtConnectionStringBuilder : TxtButtonControl
{
    private bool _setText;

    public GenericConnectionString ConnectionString
    {
        get;
        private set;
    }

    public List<DatabaseConnectionBuilderBase> ConnectionStringBuilders
    {
        get;
    } = new();

    public override bool SaveControlState
    {
        get
        {
            return false;
        }
        set
        { }
    }

    public bool NoProviderInConnectionString
    {
        get;
        set;
    }

    protected override void OnTextChanged()
    {
        base.OnTextChanged();

        if (!_setText)
        {
            ConnectionString = new GenericConnectionString(Text);
        }
    }

    protected override void OnBtnClick()
    {
        var dlg = new DlgConnectionstringBuilder
        {
            StartPosition = FormStartPosition.CenterParent
        };
        dlg.ConnectionStringBuilders.AddRange(ConnectionStringBuilders);

        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            using (DisposableDelegate.Create(() => _setText = true, () => _setText = false))
            {
                Text = NoProviderInConnectionString
                           ? dlg.ConnectionString.ConnectionString
                           : dlg.ConnectionString.FullConnectionString;
                ConnectionString = dlg.ConnectionString;
            }

            RaiseOnConnectionStringAvailable();
        }
    }

    public event EventHandler ConnectionStringAvailable;

    protected virtual void OnConnectionStringAvailable()
    {
        ConnectionStringAvailable?.Invoke(this, EventArgs.Empty);
    }

    private async void RaiseOnConnectionStringAvailable()
    {
        var raise = false;

        try
        {
            using var cn = await ConnectionString.CreateAndOpenConnectionAsync();
            raise = cn != null;
        }
        catch
        {
            raise = false;
        }

        if (raise)
        {
            OnConnectionStringAvailable();
        }
    }

    protected override void OnTextValidated()
    {
        RaiseOnConnectionStringAvailable();
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // _btn
        // 
        btn.Location = new Point(563, 3);
        // 
        // _txt
        // 
        txt.Location = new Point(0, 2);
        // 
        // TxtConnectionStringBuilder
        // 
        Name = "TxtConnectionStringBuilder";
        ResumeLayout(false);
        PerformLayout();
    }
}

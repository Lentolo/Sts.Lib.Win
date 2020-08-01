using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sts.Lib.Data;
using Sts.Lib.Data.Interfaces;

namespace Sts.Lib.Win.Windows.Forms.Data
{
  public partial class TxtConnectionStringBuilder : TxtButtonControl
  {
    public string ConnectionStringNoProvider
    {
      get;
      private set;
    }
    public Type DatabaseConnectionType
    {
      get;
      private set;
    }
    public string Connectionstring
    {
      get;
      private set;
    }
    public bool NoProviderInConnectionString
    {
      get;
      set;
    } = false;

    protected override void OnBtnClick()
    {
      var dlg = new DlgConnectionstringBuilder
      {
        StartPosition = FormStartPosition.CenterParent
      };
      dlg.DatabaseConnectionBuilders.AddRange(DatabaseConnectionBuilders);
      if (dlg.ShowDialog(this) == DialogResult.OK)
      {
        Text = NoProviderInConnectionString ? dlg.ConnectionStringNoProvider : dlg.Connectionstring;
        ConnectionStringNoProvider = dlg.ConnectionStringNoProvider;
        Connectionstring = dlg.Connectionstring;
        DatabaseConnectionType = dlg.DatabaseConnectionType;
        RaiseOnConnectionAvailable();
      }
    }
    public List<DatabaseConnectionBuilderBase> DatabaseConnectionBuilders
    {
      get;
    } = new List<DatabaseConnectionBuilderBase>();
    public IDatabaseConnection CreateConnection()
    {
      try
      {
        return DatabaseConnectionUtils.CreateAndOpen(this.Invoke(c => c.Connectionstring), null);
      }
      catch
      {
      }

      return null;
    }
    public event EventHandler ConnectionAvailable;
    protected virtual void OnConnectionAvailable()
    {
      ConnectionAvailable?.Invoke( this, EventArgs.Empty);
    }
    private async void RaiseOnConnectionAvailable()
    {
      var raise = await Task.Run(() =>
      {
        return Delegates.Utils.TryExecuteExecuteFunc(() =>
        {
          using (var cn = CreateConnection())
          {
            return cn != null;
          }
        }, false);
      });
      if (raise)
      {
        OnConnectionAvailable();
      }
    }
    private void TxtCn_Leave(object sender, EventArgs e)
    {
      RaiseOnConnectionAvailable();
    }
    public override bool SaveControlState { get => false; set { } }
  }
}
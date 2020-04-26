using Sts.Lib.Collections.Generic;
using Sts.Lib.Data;
using Sts.Lib.Data.Interfaces;
using System;
using System.Windows.Forms;
using Sts.Lib.Win.Windows.Forms;

namespace StsLibWin.Windows.Forms.Data
{
  public partial class TxtConnectionStringBuilder : TxtButtonControl
  {

    protected override void OnBtnClick()
    {
      var dlg = new DlgConnectionstringBuilder
      {
        StartPosition = FormStartPosition.CenterParent
      };
      if (dlg.ShowDialog(this) == DialogResult.OK)
      {
        Text = dlg.Connectionstring;
        RaiseOnConnectionAvailable();
      }
    }
    public IDatabaseConnection CreateConnection()
    {
      try
      {
        return DatabaseConnectionUtils.CreateAndOpen(Text, null);
      }
      catch
      {
      }

      return null;
    }
    public event EventHandler ConnectionAvailable;
    protected virtual void OnConnectionAvailable()
    {
      Sts.Lib.Delegates.Utils.RaiseEvent(ConnectionAvailable, (object)this, EventArgs.Empty);
    }
    private void RaiseOnConnectionAvailable()
    {
      var raise = false;
      Sts.Lib.Delegates.Utils.TryExecuteExecuteAction(() =>
      {
        using (var cn = CreateConnection())
        {
          raise = cn != null;
        }
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
    public override bool CanSaveControlState { get => false; set { } }
  }
}
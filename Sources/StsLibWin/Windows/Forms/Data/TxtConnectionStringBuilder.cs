using StsLib.Data;
using StsLib.Data.Interfaces;
using System;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms.Data
{
  public partial class TxtConnectionStringBuilder : TxtButtonControl, ISaveStateControl
  {
    public bool CanSaveState()
    {
      return false;
    }
    public object GetControlState()
    {
      return null;
    }
    public void SetControlState(object value)
    {
    }
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
      StsLib.Delegates.Utils.RaiseEvent(ConnectionAvailable, (object) this, EventArgs.Empty);
    }
    private void RaiseOnConnectionAvailable()
    {
      var raise = false;
      StsLib.Delegates.Utils.TryExecuteExecuteAction(() =>
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
    //void SetSizes()
    //{
    //    BtnDlg.Left = Width - BtnDlg.Width;
    //    BtnDlg.Top = 0;
    //    BtnDlg.Height = TxtCn.Height;
    //    TxtCn.Left = 0;
    //    TxtCn.Top = 0;
    //    TxtCn.Width = Width - BtnDlg.Width - 5;
    //}
    //protected override void OnLoad(EventArgs e)
    //{
    //    base.OnLoad(e);
    //    SetSizes();
    //}

    //protected override void OnResize(EventArgs e)
    //{
    //    base.OnResize(e);
    //    SetSizes();
    //}
    private void TxtCn_Leave(object sender, EventArgs e)
    {
      RaiseOnConnectionAvailable();
    }
  }
}
using StsLib.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class Form : System.Windows.Forms.Form
  {
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      LoadControlsState();
    }
    private List<(string Key, ISaveStateControl Control)> GetControls()
    {
      return StsLib.Linq.Utils.FlattenHierarchy((Control) this, c => c.Controls.OfType<Control>(), (p, c, l) => !(p is ISaveStateControl) && c != null).Select(itm => itm.Item).Where(i => i is ISaveStateControl).Select(itm =>
      {
        var sha256 = StsLib.Security.Cryptography.Utils.Sha256(StsLib.Linq.Utils.GetAncestorsUntil(itm, cc => cc.Parent, cc => cc != this).Aggregate("", (s, c) => s + "/" + c.Name.CleanString()));
        return (sha256, (ISaveStateControl) itm);
      }).ToList();
      //return new List<Tuple<string, Control>>();
    }
    protected virtual void SaveControlData(StsLib.Collections.Generic.Dictionary<string, object> data)
    {
    }
    protected virtual StsLib.Collections.Generic.Dictionary<string, object> LoadControlData()
    {
      return null;
    }
    private string GetDataFilePath()
    {
      return StsLib.IO.Utils.EnsureDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sts Solutions", "StsUtils", "FormData.bin"), true);
    }
    protected void SaveControlsState()
    {
      var data = LoadControlData();
      if (data == null)
      {
        return;
      }

      foreach (var ctl in GetControls().Where(i => i.Control.CanSaveState()))
      {
        data[ctl.Key] = ctl.Control.GetControlState();
      }

      SaveControlData(data);
    }
    protected void LoadControlsState()
    {
      var data = LoadControlData();
      if (data == null)
      {
        return;
      }

      foreach (var ctl in GetControls().Where(i => i.Control.CanSaveState()))
      {
        ctl.Control.SetControlState(data[ctl.Key]);
      }
    }
  }
}
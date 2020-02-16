using StsLib.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StsLibWin.Windows.Forms
{
  public class ControlStatePersister
  {
    private readonly Func<StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>>> _loadDataDelegate;
    private readonly Action<StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>>> _saveDataDelegate;
    public bool SaveState { get; set; }

    public ControlStatePersister()
    { }
    public ControlStatePersister(Func<StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>>> loadDataDelegate, Action<StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>>> saveDataDelegate) : base()
    {
      this._loadDataDelegate = loadDataDelegate;
      this._saveDataDelegate = saveDataDelegate;
    }

    public interface ISaveStateControl
    {
      bool CanSaveControlState
      {
        get; set;
      }
      void LoadControlStateData(StsLib.Collections.Generic.Dictionary<string, object> data);
      void SaveControlStateData(StsLib.Collections.Generic.Dictionary<string, object> data);
    }
    private List<(string Key, ISaveStateControl Control)> GetControls(Control root)
    {
      return StsLib.Linq.Utils.FlattenHierarchy(root, c => c.Controls.OfType<Control>(), (p, c, l) => !(p is ISaveStateControl) && c != null).Select(itm => itm.Item).Where(i => i is ISaveStateControl s && s.CanSaveControlState).Select(itm =>
      {
        var sha256 = StsLib.Security.Cryptography.Utils.Sha256(StsLib.Linq.Utils.GetAncestorsWhile(itm, cc => cc.Parent, cc => cc != root).Aggregate("", (s, c) => s + "/" + c.Name.CleanString()));
        return (sha256, (ISaveStateControl)itm);
      }).ToList();
    }
    protected virtual void SaveControlData(StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>> data)
    {
      (_saveDataDelegate ?? (d => { }))(data);
    }
    protected virtual StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>> LoadControlData()
    {
      return (_loadDataDelegate ?? (Func<StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>>>)(() => (StsLib.Collections.Generic.Dictionary<string, StsLib.Collections.Generic.Dictionary<string, object>>)null))();
    }
    public void SaveControlsState(Control root)
    {
      if (!SaveState)
      {
        return;
      }
      var data = LoadControlData();
      if (data == null)
      {
        return;
      }

      foreach (var ctl in GetControls(root))
      {
        var controlData = data[ctl.Key] ?? new StsLib.Collections.Generic.Dictionary<string, object>(null);
        ctl.Control.SaveControlStateData(controlData);
        data[ctl.Key] = controlData;
      }

      SaveControlData(data);
    }
    public void LoadControlsState(Control root)
    {
      if (!SaveState)
      {
        return;
      }
      var data = LoadControlData();
      if (data == null)
      {
        return;
      }

      foreach (var ctl in GetControls(root))
      {
        var controlData = data[ctl.Key] ?? new StsLib.Collections.Generic.Dictionary<string, object>(null);
        ctl.Control.LoadControlStateData(controlData);
        data[ctl.Key] = controlData;
      }
    }
  }
}
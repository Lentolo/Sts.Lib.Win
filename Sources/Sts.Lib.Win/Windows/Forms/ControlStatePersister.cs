using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sts.Lib.Common.Extensions;

namespace Sts.Lib.Win.Windows.Forms;

public class ControlStatePersister
{
    private readonly Func<Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>>> _loadDataDelegate;
    private readonly Action<Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>>> _saveDataDelegate;
    public bool SaveState { get; set; }

    public ControlStatePersister()
    { }
    public ControlStatePersister(Func<Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>>> loadDataDelegate, Action<Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>>> saveDataDelegate) : base()
    {
        this._loadDataDelegate = loadDataDelegate;
        this._saveDataDelegate = saveDataDelegate;
    }

    public interface ISaveStateControl
    {
        bool SaveControlState
        {
            get; set;
        }
        void SetControlStateData(Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object> data);
        void RetrieveControlStateData(Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object> data);
    }
    private List<(string Key, ISaveStateControl Control)> GetControls(Control root)
    {
        return Sts.Lib.Linq.Utils.FlattenHierarchy(root, c => c.Controls.OfType<Control>(), (p, c, l) => !(p is ISaveStateControl) && c != null).Select(itm => itm.Item).Where(i => i is ISaveStateControl s && s.SaveControlState).Select(itm =>
        {
            var sha256 = Sts.Lib.Security.Cryptography.Utils.Sha256(Sts.Lib.Linq.Utils.GetAncestorsWhile(itm, cc => cc.Parent, cc => cc != root).Aggregate("", (s, c) => s + "/" + c.Name.CleanString()));
            return (sha256, (ISaveStateControl)itm);
        }).ToList();
    }
    protected virtual void SaveControlData(Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>> data)
    {
        (_saveDataDelegate ?? (d => { }))(data);
    }
    protected virtual Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>> LoadControlData()
    {
        return (_loadDataDelegate ?? (Func<Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>>>)(() => (Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>>)null))();
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
            var controlData = data[ctl.Key] ?? new Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>(null);
            ctl.Control.RetrieveControlStateData(controlData);
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
            var controlData = data[ctl.Key] ?? new Sts.Lib.Collections.Generic.Dictionaries.Dictionary<string, object>(null);
            ctl.Control.SetControlStateData(controlData);
            data[ctl.Key] = controlData;
        }
    }
}
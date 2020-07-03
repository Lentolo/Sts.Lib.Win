﻿namespace Sts.Lib.Win.Windows.Forms
{
  public class CheckBox : System.Windows.Forms.CheckBox, ControlStatePersister.ISaveStateControl
  {
    public bool SaveControlState { get; set; }

    public void SetControlStateData(Sts.Lib.Collections.Generic.Dictionary<string, object> data)
    {
      Checked = data["Checked"] as bool? ?? false;
    }

    public void RetrieveControlStateData(Sts.Lib.Collections.Generic.Dictionary<string, object> data)
    {
      data["Checked"] = Checked;
    }
  }
}
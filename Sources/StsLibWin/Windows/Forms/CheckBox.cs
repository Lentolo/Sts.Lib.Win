namespace StsLibWin.Windows.Forms
{
  public class CheckBox : System.Windows.Forms.CheckBox, ControlStatePersister.ISaveStateControl
  {
    public bool CanSaveControlState { get; set; }

    public void LoadControlStateData(StsLib.Collections.Generic.Dictionary<string, object> data)
    {
      Checked = data["Checked"] as bool? ?? false;
    }

    public void SaveControlStateData(StsLib.Collections.Generic.Dictionary<string, object> data)
    {
      data["Checked"] = Checked;
    }
  }
}